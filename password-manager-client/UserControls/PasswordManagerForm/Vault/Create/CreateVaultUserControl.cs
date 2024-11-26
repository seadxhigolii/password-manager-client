namespace password_manager_client.UserControls.PasswordManagerForm.Vault.Create
{
    public partial class CreateVaultUserControl : UserControl
    {
        private CreateSecureNoteUserControl _createSecureNoteUserControl;
        private CreateVaultWebsiteUserControl _createVaultWebsiteUserControl;

        public CreateVaultUserControl(
            CreateVaultWebsiteUserControl createVaultWebsiteUserControl,
            CreateSecureNoteUserControl createSecureNoteUserControl)
        {
            InitializeComponent();

            _createVaultWebsiteUserControl = createVaultWebsiteUserControl;
            _createSecureNoteUserControl = createSecureNoteUserControl;


            Controls.Add(_createSecureNoteUserControl);
            Controls.Add(_createVaultWebsiteUserControl);

            _createSecureNoteUserControl.Visible = false;
            _createVaultWebsiteUserControl.Visible = false;

            vault_type_dropdown.SelectedIndexChanged += VaultTypeDropdown_SelectedIndexChanged;
        }

        private void VaultTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = vault_type_dropdown.SelectedItem.ToString();

            if (selectedValue == "Secure Note")
            {
                _createVaultWebsiteUserControl.Visible = false;
                _createSecureNoteUserControl.Visible = true;
            }
            else if (selectedValue == "Login")
            {
                _createSecureNoteUserControl.Visible = false;
                _createVaultWebsiteUserControl.Visible = true;
            }
        }

    }
}
