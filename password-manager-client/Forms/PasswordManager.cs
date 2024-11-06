using password_manager_client.UserControls;
using password_manager_client.UserControls.PasswordManagerForm.PasswordWebsite;
using System.Windows.Forms;

namespace password_manager_client
{
    public partial class Lockwise : Form
    {
        private PasswordDetails _passwordDetails;
        private PasswordWebsite _passwordWebsite;

        public Lockwise()
        {
            _passwordDetails = new PasswordDetails();
            _passwordWebsite = new PasswordWebsite();
            InitializeComponent();

            LoadUserControl(_passwordDetails, 30);
            LoadUserControl(_passwordWebsite, 30 + _passwordDetails.Height + 20);
        }

        private void LoadUserControl(UserControl userControl, int topPosition)
        {
            mainPanel.Controls.Add(userControl);

            userControl.Dock = DockStyle.None;
            userControl.Anchor = AnchorStyles.None;

            userControl.Left = (mainPanel.ClientSize.Width - userControl.Width) / 2;
            userControl.Top = topPosition;
        }

    }
}
