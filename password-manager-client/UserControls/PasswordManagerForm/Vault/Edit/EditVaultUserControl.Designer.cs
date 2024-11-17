namespace password_manager_client.UserControls.PasswordManagerForm.Vault.Edit
{
    partial class EditVaultUserControl
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

        #region Publicly Accessible Elements

        public string NameInput
        {
            get => name_input.Text;
            set => name_input.Text = value;
        }

        public string UsernameInput
        {
            get => username_input.Text;
            set => username_input.Text = value;
        }

        public string PasswordInput
        {
            get => password_input.Text;
            set => password_input.Text = value;
        }

        public bool NameInputEnabled
        {
            get => name_input.Enabled;
            set => name_input.Enabled = value;
        }

        public bool UsernameInputEnabled
        {
            get => username_input.Enabled;
            set => username_input.Enabled = value;
        }

        public bool PasswordInputEnabled
        {
            get => password_input.Enabled;
            set => password_input.Enabled = value;
        }

        #endregion Publicly Accessible Elements

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditVaultUserControl));
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            password_input = new TextBox();
            label3 = new Label();
            username_input = new TextBox();
            label2 = new Label();
            name_input = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(476, 172);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(23, 23);
            pictureBox3.TabIndex = 17;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(447, 172);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(23, 23);
            pictureBox2.TabIndex = 16;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(476, 102);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(23, 23);
            pictureBox1.TabIndex = 15;
            pictureBox1.TabStop = false;
            // 
            // password_input
            // 
            password_input.Location = new Point(14, 172);
            password_input.Name = "password_input";
            password_input.Size = new Size(417, 23);
            password_input.TabIndex = 14;
            password_input.Text = "username@email.com";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(14, 152);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 13;
            label3.Text = "Password";
            // 
            // username_input
            // 
            username_input.Location = new Point(14, 102);
            username_input.Name = "username_input";
            username_input.Size = new Size(456, 23);
            username_input.TabIndex = 12;
            username_input.Text = "username@email.com";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = SystemColors.ControlDarkDark;
            label2.Location = new Point(14, 82);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 11;
            label2.Text = "Username";
            // 
            // name_input
            // 
            name_input.Location = new Point(14, 37);
            name_input.Name = "name_input";
            name_input.Size = new Size(485, 23);
            name_input.TabIndex = 10;
            name_input.Text = "Google Login";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(14, 17);
            label1.Name = "label1";
            label1.Size = new Size(39, 15);
            label1.TabIndex = 9;
            label1.Text = "Name";
            // 
            // EditVaultUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(password_input);
            Controls.Add(label3);
            Controls.Add(username_input);
            Controls.Add(label2);
            Controls.Add(name_input);
            Controls.Add(label1);
            Name = "EditVaultUserControl";
            Size = new Size(512, 212);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private TextBox password_input;
        private Label label3;
        private TextBox username_input;
        private Label label2;
        private TextBox name_input;
        private Label label1;
    }
}
