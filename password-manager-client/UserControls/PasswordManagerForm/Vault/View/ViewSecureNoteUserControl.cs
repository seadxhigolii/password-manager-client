using password_manager_client.Forms.Shared;
namespace password_manager_client.UserControls.PasswordManagerForm.Vault.View
{
    public partial class ViewSecureNoteUserControl : UserControl
    {
        public ViewSecureNoteUserControl()
        {
            InitializeComponent();
        }

        private void secure_note_copy_button_Click(object sender, EventArgs e)
        {

            Form parentForm = this.FindForm();

            if (parentForm != null && !string.IsNullOrEmpty(notes_input.Text))
            {
                Clipboard.SetText(notes_input.Text);
                ToastForm.ShowToast(parentForm, "Copied to clipboard!");
            }
        }
    }
}
