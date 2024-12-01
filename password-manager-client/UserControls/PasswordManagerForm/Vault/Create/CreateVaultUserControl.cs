using password_manager_client.Utils;

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
        }

        private void VaultTypeDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = vault_type_dropdown.SelectedItem.ToString();

            if (selectedValue == "Secure Note")
            {
                SetViewForSecureNoteVault();
                ResetInputsAndLabels();

                _createSecureNoteUserControl.Location = new Point(
                    _createSecureNoteUserControl.Location.X,
                    CreateVaultLayoutConstants.DefaultSecureNotePositionY);
            }
            else if (selectedValue == "Login")
            {
                SetViewForLoginVault();
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
            name_input.Text = null;
        }

        private void SetViewForSecureNoteVault()
        {
            _createVaultWebsiteUserControl.Visible = false;
            _createSecureNoteUserControl.Visible = true;

            username_label.Visible = false;
            username_input.Visible = false;

            password_label.Visible = false;
            password_input.Visible = false;

            copy_username_icon.Visible = false;
            copy_password_icon.Visible = false;
            generate_password_icon.Visible = false;
            view_password_icon.Visible = false;

            this.Height = CreateVaultLayoutConstants.CreateVaultSecureNotePanelHeight;
        }

        private void SetViewForLoginVault()
        {
            _createVaultWebsiteUserControl.Visible = true;
            _createSecureNoteUserControl.Visible = true;

            username_label.Visible = true;
            username_input.Visible = true;

            password_label.Visible = true;
            password_input.Visible = true;

            copy_username_icon.Visible = true;
            copy_password_icon.Visible = true;
            generate_password_icon.Visible = true;
            view_password_icon.Visible = true;

            this.Height = CreateVaultLayoutConstants.CreateVaultLoginPanelHeight;

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
