using password_manager_client.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                ToastForm.ShowToast(parentForm, "Copied to clipboard!", "success");
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
