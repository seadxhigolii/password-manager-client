using ruc = password_manager_client.UserControls.LoginForm.Register;

namespace password_manager_client.UserControls.LoginForm.Login
{
    public partial class LoginUserControl : UserControl
    {
        private ruc.RegisterUserControl _registerUserControl;
        public LoginUserControl()
        {
            _registerUserControl = new ruc.RegisterUserControl();
            InitializeComponent();
        }

        private void create_account_button_Click(object sender, EventArgs e)
        {

        }
    }
}
