namespace password_manager_client.UserControls.PasswordManagerForm.Vault.Create
{
    public partial class CreateVaultUserControl : UserControl
    {
        private CreateSecureNoteUserControl _createSecureNoteUserControl;
        private CreateVaultWebsiteUserControl _createVaultWebsiteUserControl;
        private readonly int _defaultSecureNotePositionY = 323;

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

                ResetInputsAndLabels();

                int newY = 323;
                _createSecureNoteUserControl.Location = new Point(
                    _createSecureNoteUserControl.Location.X,
                    _defaultSecureNotePositionY);
            }
            else if (selectedValue == "Login")
            {
                _createVaultWebsiteUserControl.Visible = true;
                _createSecureNoteUserControl.Visible = true;

                ResetInputsAndLabels();

                _createSecureNoteUserControl.Location = new Point(
                    _createVaultWebsiteUserControl.Location.X,
                    _createVaultWebsiteUserControl.Location.Y + _createVaultWebsiteUserControl.Height + 20);
            }
        }

        private void ResetInputsAndLabels()
        {
            _createVaultWebsiteUserControl.WebsiteInput = null;
            _createSecureNoteUserControl.NotesInputText = null;
            _createSecureNoteUserControl.NotesLabelVisible = true;
        }

        //private int GetBottomMostControlY()
        //{
        //    int maxY = 0;

        //    foreach (Control control in Controls)
        //    {
        //        if (control.Visible)
        //        {
        //            int bottomY = control.Location.Y + control.Height;
        //            if (bottomY > maxY)
        //            {
        //                maxY = bottomY;
        //            }
        //        }
        //    }

        //    return maxY;
        //}
    }
}
