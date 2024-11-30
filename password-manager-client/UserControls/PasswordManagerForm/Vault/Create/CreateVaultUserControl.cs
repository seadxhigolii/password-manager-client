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


            Controls.Add(_createVaultWebsiteUserControl);
            Controls.Add(_createSecureNoteUserControl);

            _createSecureNoteUserControl.Visible = false;
            _createVaultWebsiteUserControl.Visible = false;

            vault_type_dropdown.SelectedIndexChanged += VaultTypeDropdown_SelectedIndexChanged;
            vault_type_dropdown.SelectedItem = "Login";
            InitializeDropdown();
        }

        private void InitializeDropdown()
        {
            _createVaultWebsiteUserControl.Visible = true;
            _createSecureNoteUserControl.Visible = true;

            _createSecureNoteUserControl.Location = new Point(
                _createVaultWebsiteUserControl.Location.X,
                _createVaultWebsiteUserControl.Location.Y + _createVaultWebsiteUserControl.Height + 20);

        }

        private void VaultTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = vault_type_dropdown.SelectedItem.ToString();

            if (selectedValue == "Secure Note")
            {
                _createVaultWebsiteUserControl.Visible = false;
                _createSecureNoteUserControl.Visible = true;

                int newY = GetBottomMostControlY() + 80;
                _createSecureNoteUserControl.Location = new Point(_createSecureNoteUserControl.Location.X, newY);
            }
            else if (selectedValue == "Login")
            {
                _createVaultWebsiteUserControl.Visible = true;
                _createSecureNoteUserControl.Visible = true;

                _createSecureNoteUserControl.Location = new Point(
                    _createVaultWebsiteUserControl.Location.X,
                    _createVaultWebsiteUserControl.Location.Y + _createVaultWebsiteUserControl.Height + 20);
            }
        }

        private int GetBottomMostControlY()
        {
            int maxY = 0;

            foreach (Control control in Controls)
            {
                if (control.Visible)
                {
                    int bottomY = control.Location.Y + control.Height;
                    if (bottomY > maxY)
                    {
                        maxY = bottomY;
                    }
                }
            }

            return maxY;
        }
    }
}
