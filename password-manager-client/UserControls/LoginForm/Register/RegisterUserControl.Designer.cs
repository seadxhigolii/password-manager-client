namespace password_manager_client.UserControls.LoginForm.Register
{
    partial class RegisterUserControl
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
            get { return email_input.Text; }
        }
        public string PasswordInput
        {
            get { return password_input.Text; }
        }
        public string RepeatPasswordInput
        {
            get { return repeat_password_input.Text; }
        }
        #endregion Publicly Accessible Values

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            repeat_password_input = new TextBox();
            email_input = new TextBox();
            password_input = new TextBox();
            SuspendLayout();
            // 
            // repeat_password_input
            // 
            repeat_password_input.Location = new Point(3, 64);
            repeat_password_input.Name = "repeat_password_input";
            repeat_password_input.PlaceholderText = "Repeat Master Password";
            repeat_password_input.Size = new Size(184, 23);
            repeat_password_input.TabIndex = 12;
            // 
            // email_input
            // 
            email_input.Location = new Point(3, 6);
            email_input.Name = "email_input";
            email_input.PlaceholderText = "Email address";
            email_input.Size = new Size(184, 23);
            email_input.TabIndex = 8;
            // 
            // password_input
            // 
            password_input.Location = new Point(3, 35);
            password_input.Name = "password_input";
            password_input.PlaceholderText = "Master Password";
            password_input.Size = new Size(184, 23);
            password_input.TabIndex = 13;
            // 
            // RegisterUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(password_input);
            Controls.Add(repeat_password_input);
            Controls.Add(email_input);
            Name = "RegisterUserControl";
            Size = new Size(191, 92);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox repeat_password_input;
        private TextBox email_input;
        private TextBox password_input;
    }
}
