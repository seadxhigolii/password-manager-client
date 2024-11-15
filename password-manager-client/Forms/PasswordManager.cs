using password_manager_client.Helpers;
using password_manager_client.Services.Vault;
using password_manager_client.Services.Vault.Dto;
using password_manager_client.UserControls;
using password_manager_client.UserControls.PasswordManagerForm.PasswordWebsite;
using password_manager_client.UserControls.PasswordManagerForm.Vault.Create;
using password_manager_client.UserControls.PasswordManagerForm.Vault.Edit;
using System.Windows.Forms;

namespace password_manager_client
{
    public partial class Lockwise : Form
    {
        private ViewVaultUserControl _viewVaultUserControl;
        private CreateVaultUserControl _createVaultUserControl;
        private EditVaultUserControl _editVaultUserControl;
        private ViewVaultWebsiteUserControl _viewVaultWebsiteUserControl;
        private EditVaultWebsiteUserControl _editVaultWebsiteUserControl;
        private CreateVaultWebsiteUserControl _createVaultWebsiteUserControl;
        private UserControl _activeUserControl;
        private VaultService _vaultService;
        private int _initialGroupBoxTop;
        public Lockwise()
        {
            var httpClient = new HttpClient();
            _viewVaultUserControl = new ViewVaultUserControl();
            _createVaultUserControl = new CreateVaultUserControl();
            _editVaultUserControl = new EditVaultUserControl();
            _viewVaultWebsiteUserControl = new ViewVaultWebsiteUserControl();
            _editVaultWebsiteUserControl = new EditVaultWebsiteUserControl();
            _createVaultWebsiteUserControl = new CreateVaultWebsiteUserControl();
            _activeUserControl = new UserControl();
            _vaultService = new VaultService(httpClient);

            InitializeComponent();

            LoadUserControl(_viewVaultUserControl, 50);
            LoadUserControl(_viewVaultWebsiteUserControl, 50 + _viewVaultUserControl.Height + 20);

            _initialGroupBoxTop = last_updated_groupbox.Top;
            _activeUserControl = _viewVaultUserControl;
        }

        private void create_vault_button_Click(object sender, EventArgs e)
        {
            if (_activeUserControl != null)
            {
                mainPanel.Controls.Remove(_activeUserControl);
            }
            _activeUserControl = _createVaultUserControl;

            LoadUserControl(_createVaultWebsiteUserControl, 100 + _viewVaultUserControl.Height + 20);
            mainPanel.Controls.Remove(_viewVaultWebsiteUserControl);

            if (_activeUserControl == _createVaultUserControl)
            {
                #region Main Panel label changes

                item_information_label.Text = "ADD ITEM";
                last_updated_groupbox.Visible = false;

                #endregion Main Panel label changes

                #region Button changes

                save_button.Location = edit_button.Location;
                save_icon.Location = edit_icon.Location;
                cancel_button.Location = duplicate_button.Location;
                edit_button.Visible = false;
                edit_icon.Visible = false;
                duplicate_button.Visible = false;
                duplicate_icon.Visible = false;

                #endregion Button changes
            }

            LoadUserControl(_createVaultUserControl, 50);
        }
        private void LoadUserControl(UserControl userControl, int topPosition)
        {
            mainPanel.Controls.Add(userControl);

            userControl.Dock = DockStyle.None;
            userControl.Anchor = AnchorStyles.None;

            userControl.Left = (mainPanel.ClientSize.Width - userControl.Width) / 2;
            userControl.Top = topPosition;
            userControl.BringToFront();
        }

        private async void save_button_Click(object sender, EventArgs e)
        {
            if (_activeUserControl == _createVaultUserControl)
            {
                var vault = new CreateVaultDto
                {
                    UserId = Session.UserId,    
                    ItemType = 1,
                    Title = _createVaultUserControl.NameInput,
                    EncryptedPassword = _createVaultUserControl.PasswordInput,
                    Username = _createVaultUserControl.UsernameInput
                };

                await _vaultService.CreateAsync(vault);
            }
        }
    }
}
