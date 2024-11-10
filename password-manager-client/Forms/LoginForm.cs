﻿using password_manager_client.UserControls.LoginForm.Register;
using password_manager_client.UserControls.LoginForm.Login;
using System.Windows.Forms;
using password_manager_client.Services.Auth;
using password_manager_client.Services.Auth.Dto;

namespace password_manager_client.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;
        private LoginUserControl _loginUserControl;
        private RegisterUserControl _registerUserControl;
        private UserControl activeUserControl;
        public LoginForm()
        {
            _authService = new AuthService("https://localhost:7260");

            _authService.IsAuthenticatedObservable
                .Subscribe(isAuthenticated =>
                {
                    // Update UI based on authentication state
                    MessageBox.Show(isAuthenticated ? "Logged in!" : "Logged out");
                });
            _loginUserControl = new LoginUserControl();
            _registerUserControl = new RegisterUserControl();
            InitializeComponent();
            LoadUserControl(_loginUserControl, 0);
        }

        private void create_account_button_Click(object sender, EventArgs e)
        {
            login_panel.Controls.Clear();
            LoadUserControl(_registerUserControl, 0);
            back_button.Visible = true;
            back_button.Location = new Point(new_around_here_label.Location.X + 38, new_around_here_label.Location.Y); ;
            create_account_button.Visible = false;
            new_around_here_label.Visible = false;
            activeUserControl = _registerUserControl;
        }

        private void LoadUserControl(UserControl userControl, int topPosition)
        {
            login_panel.Controls.Add(userControl);

            userControl.Dock = DockStyle.None;
            userControl.Anchor = AnchorStyles.None;

            userControl.Left = (login_panel.ClientSize.Width - userControl.Width) / 2;
            userControl.Top = topPosition;
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            login_panel.Controls.Clear();
            LoadUserControl(_loginUserControl, 0);
            back_button.Visible = false;
            create_account_button.Visible = true;
            new_around_here_label.Visible = true;
            activeUserControl = _loginUserControl;
        }

        private void continue_button_Click(object sender, EventArgs e)
        {
            if (IsUserControlActive(_loginUserControl))
            {

            }
            else if (IsUserControlActive(_registerUserControl))
            {
                var registerData = new RegisterDto
                {
                    Username = _registerUserControl.EmailInput,
                    MasterPassword = _registerUserControl.PasswordInput,
                    MasterPasswordRepeated = _registerUserControl.RepeatPasswordInput
                };

                _authService.Register(registerData);
            }
        }
        private bool IsUserControlActive(UserControl userControl)
        {
            return activeUserControl == userControl;
        }
    }
}
