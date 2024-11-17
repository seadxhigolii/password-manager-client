namespace password_manager_client.UserControls.LoginForm.Login
{
    partial class LoginUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Publicly Accessible Values
        public string EmailInput
        {
            get { return login_email_input.Text; }
        }
        public string PasswordInput
        {
            get { return login_password_input.Text; }
        }
        #endregion Publicly Accessible Values

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            login_password_input = new TextBox();
            login_email_input = new TextBox();
            SuspendLayout();
            // 
            // login_password_input
            // 
            login_password_input.Location = new Point(3, 32);
            login_password_input.Name = "login_password_input";
            login_password_input.PlaceholderText = "Master Password";
            login_password_input.PasswordChar = '•';
            login_password_input.Size = new Size(184, 23);
            login_password_input.TabIndex = 17;
            // 
            // login_email_input
            // 
            login_email_input.Location = new Point(3, 3);
            login_email_input.Name = "login_email_input";
            login_email_input.PlaceholderText = "Email address";
            login_email_input.Size = new Size(184, 23);
            login_email_input.TabIndex = 14;
            // 
            // LoginUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(login_password_input);
            Controls.Add(login_email_input);
            Name = "LoginUserControl";
            Size = new Size(192, 59);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox login_password_input;
        private TextBox login_email_input;
    }
}
