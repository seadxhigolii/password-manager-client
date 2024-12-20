﻿using ruc = password_manager_client.UserControls.LoginForm.Register;

namespace password_manager_client.UserControls.LoginForm.Login
{
    public partial class LoginUserControl : UserControl
    {
        private ruc.RegisterUserControl _registerUserControl;
        public LoginUserControl()
        {
            _registerUserControl = new ruc.RegisterUserControl();
            InitializeComponent();

            var savedUsername = Properties.Settings.Default.SavedEmail;

            if (!string.IsNullOrEmpty(savedUsername))
            {
                login_email_input.Text = savedUsername;
            }
        }
    }
}
