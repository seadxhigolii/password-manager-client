using password_manager_client.UserControls;
using password_manager_client.UserControls.PasswordManagerForm.PasswordWebsite;
using System.Windows.Forms;

namespace password_manager_client
{
    public partial class Lockwise : Form
    {
        private ViewVaultUserControl _passwordDetails;
        private PasswordWebsiteUserControl _passwordWebsite;

        public Lockwise()
        {
            _passwordDetails = new ViewVaultUserControl();
            _passwordWebsite = new PasswordWebsiteUserControl();
            InitializeComponent();

            LoadUserControl(_passwordDetails, 50);
            LoadUserControl(_passwordWebsite, 50 + _passwordDetails.Height + 20);
        }

        private void LoadUserControl(UserControl userControl, int topPosition)
        {
            mainPanel.Controls.Add(userControl);

            userControl.Dock = DockStyle.None;
            userControl.Anchor = AnchorStyles.None;

            userControl.Left = (mainPanel.ClientSize.Width - userControl.Width) / 2;
            userControl.Top = topPosition;
        }

        private void create_vault_button_Click(object sender, EventArgs e)
        {

        }
    }
}
