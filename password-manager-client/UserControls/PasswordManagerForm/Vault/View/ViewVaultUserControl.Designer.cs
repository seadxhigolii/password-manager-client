namespace password_manager_client.UserControls
{
    partial class ViewVaultUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewVaultUserControl));
            label1 = new Label();
            name_input = new TextBox();
            username_input = new TextBox();
            label2 = new Label();
            password_input = new TextBox();
            label3 = new Label();
            username_copy_button = new PictureBox();
            password_show_button = new PictureBox();
            password_copy_button = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)username_copy_button).BeginInit();
            ((System.ComponentModel.ISupportInitialize)password_show_button).BeginInit();
            ((System.ComponentModel.ISupportInitialize)password_copy_button).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(14, 12);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // name_input
            // 
            name_input.Enabled = false;
            name_input.Location = new Point(14, 32);
            name_input.Name = "name_input";
            name_input.Size = new Size(485, 23);
            name_input.TabIndex = 1;
            name_input.Text = "Google Login";
            // 
            // username_input
            // 
            username_input.Enabled = false;
            username_input.Location = new Point(14, 97);
            username_input.Name = "username_input";
            username_input.Size = new Size(456, 23);
            username_input.TabIndex = 3;
            username_input.Text = "username@email.com";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(14, 77);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 2;
            label2.Text = "Username";
            // 
            // password_input
            // 
            password_input.Enabled = false;
            password_input.Location = new Point(14, 167);
            password_input.Name = "password_input";
            password_input.Size = new Size(417, 23);
            password_input.TabIndex = 5;
            password_input.Text = "username@email.com";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(14, 147);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 4;
            label3.Text = "Password";
            // 
            // username_copy_button
            // 
            username_copy_button.BackgroundImage = (Image)resources.GetObject("username_copy_button.BackgroundImage");
            username_copy_button.BackgroundImageLayout = ImageLayout.Stretch;
            username_copy_button.Location = new Point(476, 97);
            username_copy_button.Name = "username_copy_button";
            username_copy_button.Size = new Size(23, 23);
            username_copy_button.TabIndex = 6;
            username_copy_button.TabStop = false;
            username_copy_button.Click += username_copy_button_Click;
            // 
            // password_show_button
            // 
            password_show_button.BackgroundImage = (Image)resources.GetObject("password_show_button.BackgroundImage");
            password_show_button.BackgroundImageLayout = ImageLayout.Stretch;
            password_show_button.Location = new Point(447, 167);
            password_show_button.Name = "password_show_button";
            password_show_button.Size = new Size(23, 23);
            password_show_button.TabIndex = 7;
            password_show_button.TabStop = false;
            // 
            // password_copy_button
            // 
            password_copy_button.BackgroundImage = (Image)resources.GetObject("password_copy_button.BackgroundImage");
            password_copy_button.BackgroundImageLayout = ImageLayout.Stretch;
            password_copy_button.Location = new Point(476, 167);
            password_copy_button.Name = "password_copy_button";
            password_copy_button.Size = new Size(23, 23);
            password_copy_button.TabIndex = 8;
            password_copy_button.TabStop = false;
            password_copy_button.Click += password_copy_button_Click;
            // 
            // ViewVaultUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            Controls.Add(password_copy_button);
            Controls.Add(password_show_button);
            Controls.Add(username_copy_button);
            Controls.Add(password_input);
            Controls.Add(label3);
            Controls.Add(username_input);
            Controls.Add(label2);
            Controls.Add(name_input);
            Controls.Add(label1);
            Name = "ViewVaultUserControl";
            Size = new Size(521, 212);
            ((System.ComponentModel.ISupportInitialize)username_copy_button).EndInit();
            ((System.ComponentModel.ISupportInitialize)password_show_button).EndInit();
            ((System.ComponentModel.ISupportInitialize)password_copy_button).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region Publicly Accessible Elements
        public string NameInput
        {
            get => name_input.Text;
            set => name_input.Text = value;
        }

        public string UsernameInput
        {
            get => username_input.Text;
            set
            {
                username_input.Text = value;
                UsernameVisible = !string.IsNullOrEmpty(value);
            }
        }

        public bool UsernameVisible
        {
            get => username_input.Visible;
            set
            {
                username_input.Visible = value;
                username_input.Visible = value;
            }
        }

        public string PasswordInput
        {
            get => password_input.Text;
            set
            {
                password_input.Text = value;
                PasswordVisible = !string.IsNullOrEmpty(value);
            }
        }

        public bool PasswordVisible
        {
            get => password_input.Visible;
            set
            {
                password_input.Visible = value;
                password_input.Visible = value;
            }
        }
        public Guid VaultId { get; set; }


        #endregion Publicly Accessible Elements

        private Label label1;
        private TextBox name_input;
        private TextBox username_input;
        private Label label2;
        private TextBox password_input;
        private Label label3;
        private PictureBox username_copy_button;
        private PictureBox password_show_button;
        private PictureBox password_copy_button;
    }
}
