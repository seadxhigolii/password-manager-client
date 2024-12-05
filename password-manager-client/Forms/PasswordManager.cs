using password_manager_client.Forms.Shared;
using password_manager_client.Helpers;
using password_manager_client.Helpers.Decryption;
using password_manager_client.Helpers.Encryption;
using password_manager_client.Models;
using password_manager_client.Services.Vault;
using password_manager_client.Services.Vault.Dto;
using password_manager_client.UserControls;
using password_manager_client.UserControls.PasswordManagerForm.PasswordWebsite;
using password_manager_client.UserControls.PasswordManagerForm.Vault.Create;
using password_manager_client.UserControls.PasswordManagerForm.Vault.Edit;
using password_manager_client.UserControls.PasswordManagerForm.Vault.View;

namespace password_manager_client
{
    public partial class Lockwise : Form
    {
        private readonly UIManager _uiManager;
        private readonly VaultService _vaultService;
        private readonly ViewVaultUserControl _viewVaultUserControl;
        private readonly CreateVaultUserControl _createVaultUserControl;
        private readonly EditVaultUserControl _editVaultUserControl;
        private readonly ViewVaultWebsiteUserControl _viewVaultWebsiteUserControl;
        private readonly EditVaultWebsiteUserControl _editVaultWebsiteUserControl;
        private readonly CreateVaultWebsiteUserControl _createVaultWebsiteUserControl;
        private readonly CreateSecureNoteUserControl _createSecureNoteUserControl;
        private readonly EditSecureNoteUserControl _editSecureNoteUserControl;
        private readonly ViewSecureNoteUserControl _viewSecureNoteUserControl;
        private UserControl _activeUserControl;
        private Vault _currentVault;
        private Guid _previousVaultId = Guid.Empty;

        public Lockwise()
        {
            InitializeComponent();

            _vaultService = new VaultService(new HttpClient());
            _viewVaultUserControl = new ViewVaultUserControl();
            _editVaultUserControl = new EditVaultUserControl();
            _viewVaultWebsiteUserControl = new ViewVaultWebsiteUserControl();
            _editVaultWebsiteUserControl = new EditVaultWebsiteUserControl();
            _createVaultWebsiteUserControl = new CreateVaultWebsiteUserControl();
            _createSecureNoteUserControl = new CreateSecureNoteUserControl();
            _viewSecureNoteUserControl = new ViewSecureNoteUserControl();
            _editSecureNoteUserControl = new EditSecureNoteUserControl();

            _uiManager = new UIManager(
                mainPanel,
                item_information_label,
                last_updated_groupbox,
                password_history_label,
                password_history_value,
                save_button,
                edit_button,
                cancel_button,
                save_icon,
                edit_icon,
                duplicate_button,
                duplicate_icon,
                main_group
            );

            _createVaultUserControl = new CreateVaultUserControl(
                _createVaultWebsiteUserControl,
                _createSecureNoteUserControl
            );

            LoadAllVaults();
        }

        private async void LoadAllVaults()
        {
            var vaultListResponse = await _vaultService.GetAllByUserIdAsync(Session.UserId);

            if (vaultListResponse != null && vaultListResponse.Succeeded && vaultListResponse.Data != null)
            {
                vaultsFlowLayoutPanel.Controls.Clear();

                foreach (var vault in vaultListResponse.Data)
                {
                    var vaultPanel = VaultHelper.CreateVaultEntry(
                        vault.Id,
                        vault.Title,
                        vault.Username,
                        vault.FavIcon,
                        DisplayVaultDetailsAsync
                    );

                    vaultsFlowLayoutPanel.Controls.Add(vaultPanel);
                }
            }
            else
            {
                MessageBox.Show("Failed to load vaults: " + vaultListResponse?.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task DisplayVaultDetailsAsync(Guid vaultId)
        {
            if (_previousVaultId == vaultId)
                return;

            _previousVaultId = vaultId;
            var vaultData = await _vaultService.GetVaultByIdAsync(vaultId);

            if (vaultData.Data != null)
            {
                _currentVault = vaultData.Data;
                switch (vaultData.Data.ItemType)
                {
                    case Enum.VaultItemTypeEnum.Password:
                        DisplayPasswordTypeVaultDetails(vaultData.Data);
                        break;
                    case Enum.VaultItemTypeEnum.SecureNote:
                        DisplaySecureNoteTypeVaultDetails(vaultData.Data);
                        break;
                    case Enum.VaultItemTypeEnum.BankCard:
                        break;
                    default:
                        break;
                }
                    
              
            }
            else
            {
                Form parentForm = this.FindForm();
                ToastForm.ShowToast(parentForm, "An error occurred", "error");
            }
        }

        private void create_vault_button_Click(object sender, EventArgs e)
        {
            _uiManager.SetActiveUserControl(ref _activeUserControl, _createVaultUserControl);
            _uiManager.ResetToMainView();

            // Add and position UserControls
            _uiManager.LoadUserControl(_createVaultUserControl, 50);
            _uiManager.LoadUserControl(_createVaultWebsiteUserControl, 80 + _createVaultUserControl.Height);
            _uiManager.LoadUserControl(_createSecureNoteUserControl, 70 + _createVaultUserControl.Height);

            _createSecureNoteUserControl.Visible = false;
            _createVaultWebsiteUserControl.Visible = false;

            _uiManager.ConfigureForCreateVault();

            // Force layout update
            mainPanel.PerformLayout();
        }

        private void edit_button_Click(object sender, EventArgs e)
        {
            switch (_currentVault.ItemType)
            {
                case Enum.VaultItemTypeEnum.Password:
                    _editVaultUserControl.NameInput = _viewVaultUserControl.NameInput;
                    _editVaultUserControl.UsernameInput = _viewVaultUserControl.UsernameInput;
                    _editVaultUserControl.PasswordInput = _viewVaultUserControl.PasswordInput;
                    _editVaultWebsiteUserControl.WebsiteInput = _viewVaultWebsiteUserControl.WebsiteInput;

                    _uiManager.ResetToMainView();
                    _uiManager.SetActiveUserControl(ref _activeUserControl, _editVaultUserControl);
                    _uiManager.ConfigureForEditVault();
                    _uiManager.LoadUserControl(_editVaultUserControl, 50);
                    _uiManager.LoadUserControl(_editVaultWebsiteUserControl, 60 + _editVaultUserControl.Height + 20);
                    item_information_label.Visible = true;
                    item_information_label.Text = "EDIT ITEM";
                    last_updated_groupbox.Visible = true;
                    break;
                case Enum.VaultItemTypeEnum.SecureNote:
                    _editVaultUserControl.NameInput = _currentVault.Title;

                    _viewVaultUserControl.UsernameInput = !string.IsNullOrEmpty(_currentVault.Username) ? _currentVault.Username : null;
                    _viewVaultUserControl.PasswordInput = !string.IsNullOrEmpty(_currentVault.EncryptedPassword) ? DecryptionHelper.Decrypt(_currentVault.EncryptedPassword) : null;

                    _uiManager.ResetToMainView();
                    _uiManager.SetActiveUserControl(ref _activeUserControl, _editVaultUserControl);
                    _uiManager.ConfigureForEditVault();
                    _uiManager.LoadUserControl(_editVaultUserControl, 50);
                    _uiManager.LoadUserControl(_editSecureNoteUserControl, 60 + _editVaultUserControl.Height + 20);
                    _editSecureNoteUserControl.NotesInputText = !string.IsNullOrEmpty(_currentVault.EncryptedNotes) ? DecryptionHelper.Decrypt(_currentVault.EncryptedNotes) : null;

                    item_information_label.Visible = true;
                    item_information_label.Text = "EDIT ITEM";
                    last_updated_groupbox.Visible = true;

                    break;
                case Enum.VaultItemTypeEnum.BankCard:
                    break;
                default:
                    break;
            }         
        }

        private async void save_button_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            if (_activeUserControl == _createVaultUserControl)
            {
                var vault = new CreateVaultDto
                {
                    UserId = Session.UserId,
                    ItemType = 1,
                    Title = _createVaultUserControl.NameInput,
                    EncryptedPassword = string.IsNullOrWhiteSpace(_createVaultUserControl.PasswordInput)
                        ? null
                        : EncryptionHelper.EncryptWithRSA(_createVaultUserControl.PasswordInput, Session.PublicKey),
                                    Username = string.IsNullOrWhiteSpace(_createVaultUserControl.UsernameInput)
                        ? null
                        : _createVaultUserControl.UsernameInput,
                                    Url = string.IsNullOrWhiteSpace(_createVaultWebsiteUserControl.WebsiteInput)
                        ? null
                        : _createVaultWebsiteUserControl.WebsiteInput,
                                    EncryptedNotes = string.IsNullOrWhiteSpace(_createSecureNoteUserControl.NotesInputText)
                        ? null
                        : EncryptionHelper.EncryptWithRSA(_createSecureNoteUserControl.NotesInputText, Session.PublicKey)
                };

                if (string.IsNullOrWhiteSpace(vault.Title))
                {
                    ToastForm.ShowToast(parentForm, "Error: Name can't be empty.", "error");
                    return;
                }

                var result = await _vaultService.CreateAsync(vault);

                if (result)
                {
                    ToastForm.ShowToast(parentForm, "Vault created successfully!", "success");
                    LoadAllVaults();
                    _uiManager.ResetToMainView();
                }
                else
                {
                    ToastForm.ShowToast(parentForm, "An error occurred.", "error");
                }
            }
            else if (_activeUserControl == _editVaultUserControl)
            {
                string decryptedPassword = null;

                if (!string.IsNullOrEmpty(_currentVault.EncryptedPassword))
                {
                    decryptedPassword = DecryptionHelper.Decrypt(_currentVault.EncryptedPassword);
                }

                var vault = new UpdateVaultDto
                {
                    Id = _currentVault.Id,
                    ItemType = 1,
                    Title = _editVaultUserControl.NameInput,
                    EncryptedPassword = decryptedPassword != _editVaultUserControl.PasswordInput ? _editVaultUserControl.PasswordInput : null,
                    Username = _editVaultUserControl.UsernameInput,
                    Url = _editVaultWebsiteUserControl.WebsiteInput
                };

                if (string.IsNullOrWhiteSpace(vault.Title))
                {
                    ToastForm.ShowToast(parentForm, "Error: Name can't be empty.", "error");
                    return;
                }

                var result = await _vaultService.UpdateVaultAsync(vault);

                if (result.Data != null)
                {
                    ToastForm.ShowToast(parentForm, "Vault updated successfully!", "success");
                    _previousVaultId = Guid.Empty;
                    DisplayVaultDetails(result.Data);
                    LoadAllVaults();
                    _uiManager.ResetToMainView(); 
                }
                else
                {
                    ToastForm.ShowToast(parentForm, "An error occurred.", "error");
                }
            }
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            _uiManager.ResetToMainView();
        }

        private void DisplayVaultDetails(Vault vault)
        {
            if (_activeUserControl != null)
            {
                _uiManager.ResetToMainView();
            }

            _currentVault = vault;
            _activeUserControl = _viewVaultUserControl;

            _uiManager.LoadUserControl(_viewVaultUserControl, 50);
            _uiManager.LoadUserControl(_viewVaultWebsiteUserControl, 60 + _viewVaultUserControl.Height + 20);

            string decryptedPassword = DecryptionHelper.Decrypt(vault.EncryptedPassword);
            _viewVaultUserControl.NameInput = vault.Title;
            _viewVaultUserControl.UsernameInput = vault.Username;
            _viewVaultUserControl.PasswordInput = decryptedPassword;
            _viewVaultUserControl.VaultId = vault.Id;
            _viewVaultWebsiteUserControl.WebsiteInput = vault.Url;

            _uiManager.ConfigureForViewLoginTypeVault(
                hasPasswordHistory: vault.PasswordHistory != null,
                passwordHistoryValueText: vault.PasswordHistory?.ToString()
            );
        }

        private void DisplayPasswordTypeVaultDetails(Vault vaultData)
        {
            _currentVault = vaultData;

            _uiManager.ResetToMainView();
            _uiManager.SetActiveUserControl(ref _activeUserControl, _viewVaultUserControl);

            _viewVaultUserControl.NameInput = vaultData.Title;
            _viewVaultUserControl.UsernameInput = vaultData.Username;
            _viewVaultUserControl.PasswordInput = DecryptionHelper.Decrypt(vaultData.EncryptedPassword);
            _viewVaultWebsiteUserControl.WebsiteInput = vaultData.Url;

            _uiManager.LoadUserControl(_viewVaultUserControl, 50);

            if (!string.IsNullOrEmpty(vaultData.Url) && !string.IsNullOrEmpty(vaultData.EncryptedNotes))
            {
                _uiManager.LoadUserControl(_viewVaultWebsiteUserControl, 60 + _viewVaultUserControl.Height + 20);
                _uiManager.LoadUserControl(_viewSecureNoteUserControl, _viewVaultUserControl.Height + _viewVaultWebsiteUserControl.Height + 80);
            }
            else if (!string.IsNullOrEmpty(vaultData.Url))
            {
                _uiManager.LoadUserControl(_viewVaultWebsiteUserControl, 60 + _viewVaultUserControl.Height + 20);
            }
            else
            {
                _uiManager.LoadUserControl(_viewSecureNoteUserControl, 60 + _viewVaultUserControl.Height + 20);
            }

            _uiManager.ConfigureForViewLoginTypeVault(
                hasPasswordHistory: _currentVault.PasswordHistory != null,
                passwordHistoryValueText: _currentVault.PasswordHistory?.ToString()
            );
        }

        private void DisplaySecureNoteTypeVaultDetails(Vault vaultData)
        {
            _currentVault = vaultData;
            _viewSecureNoteUserControl.Location = new Point((mainPanel.ClientSize.Width - _viewSecureNoteUserControl.Width) / 2, 0);

            _uiManager.ResetToMainView();
            _uiManager.SetActiveUserControl(ref _activeUserControl, _viewVaultUserControl);

            _viewVaultUserControl.NameInput = vaultData.Title;
            _viewVaultUserControl.UsernameInput = !string.IsNullOrEmpty(vaultData.Username) ? _currentVault.Username : null;
            _viewVaultUserControl.PasswordInput = !string.IsNullOrEmpty(vaultData.EncryptedPassword) ? DecryptionHelper.Decrypt(vaultData.EncryptedPassword) : null;
            _viewVaultWebsiteUserControl.WebsiteInput = !string.IsNullOrEmpty(vaultData.Url) ? _currentVault.Url : null;

            _uiManager.LoadUserControl(_viewVaultUserControl, 50);
            _uiManager.LoadUserControl(_viewSecureNoteUserControl, _viewVaultUserControl.Height + 50);
            
            _viewSecureNoteUserControl.NotesLabelVisible = true;
            _viewSecureNoteUserControl.NotesInputVisible = true;
            _viewSecureNoteUserControl.NotesInputText = DecryptionHelper.Decrypt(vaultData.EncryptedNotes);

            _uiManager.ConfigureForViewLoginTypeVault(
                hasPasswordHistory: _currentVault.PasswordHistory != null,
                passwordHistoryValueText: _currentVault.PasswordHistory?.ToString()
            ); 
        }
    }
}