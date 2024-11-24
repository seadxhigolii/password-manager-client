using password_manager_client.Forms.Shared;

namespace password_manager_client.UserControls
{
    public partial class ViewVaultUserControl : UserControl
    {
        public ViewVaultUserControl()
        {
            InitializeComponent();
        }

        private void username_copy_button_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();

            if (parentForm != null && !string.IsNullOrEmpty(username_input.Text))
            {
                Clipboard.SetText(username_input.Text);
                ToastForm.ShowToast(parentForm, "Copied to clipboard!");
            }
        }

        private void password_copy_button_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm();
            if (!string.IsNullOrEmpty(password_input.Text))
            {
                Clipboard.SetText(password_input.Text);
                ToastForm.ShowToast(parentForm, "Copied to clipboard!");
            }
        }
    }
}
