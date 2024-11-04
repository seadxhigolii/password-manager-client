using password_manager_client.UserControls;
using System.Windows.Forms;

namespace password_manager_client
{
    public partial class Lockwise : Form
    {
        public Lockwise()
        {
            PasswordDetails passwordDetails = new PasswordDetails();
            InitializeComponent();
            LoadUserControl(passwordDetails);
        }

        private void LoadUserControl(UserControl userControl)
        {
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(userControl);

            userControl.Dock = DockStyle.None;
            userControl.Anchor = AnchorStyles.None;

            userControl.Left = (mainPanel.ClientSize.Width - userControl.Width) / 2;
            userControl.Top = (mainPanel.ClientSize.Height - userControl.Height) / 2;
        }


    }
}
