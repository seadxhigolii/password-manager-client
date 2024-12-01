namespace password_manager_client.UserControls.PasswordManagerForm.Vault.Create
{
    partial class CreateVaultUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateVaultUserControl));
            copy_password_icon = new PictureBox();
            view_password_icon = new PictureBox();
            copy_username_icon = new PictureBox();
            password_input = new TextBox();
            password_label = new Label();
            username_input = new TextBox();
            username_label = new Label();
            name_input = new TextBox();
            name_label = new Label();
            generate_password_icon = new PictureBox();
            vault_type_dropdown = new ComboBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)copy_password_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)view_password_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)copy_username_icon).BeginInit();
            ((System.ComponentModel.ISupportInitialize)generate_password_icon).BeginInit();
            SuspendLayout();
            // 
            // copy_password_icon
            // 
            copy_password_icon.BackgroundImage = (Image)resources.GetObject("copy_password_icon.BackgroundImage");
            copy_password_icon.BackgroundImageLayout = ImageLayout.Stretch;
            copy_password_icon.Location = new Point(480, 220);
            copy_password_icon.Name = "copy_password_icon";
            copy_password_icon.Size = new Size(23, 23);
            copy_password_icon.TabIndex = 17;
            copy_password_icon.TabStop = false;
            // 
            // view_password_icon
            // 
            view_password_icon.BackgroundImage = (Image)resources.GetObject("view_password_icon.BackgroundImage");
            view_password_icon.BackgroundImageLayout = ImageLayout.Stretch;
            view_password_icon.Location = new Point(451, 220);
            view_password_icon.Name = "view_password_icon";
            view_password_icon.Size = new Size(23, 23);
            view_password_icon.TabIndex = 16;
            view_password_icon.TabStop = false;
            // 
            // copy_username_icon
            // 
            copy_username_icon.BackgroundImage = (Image)resources.GetObject("copy_username_icon.BackgroundImage");
            copy_username_icon.BackgroundImageLayout = ImageLayout.Stretch;
            copy_username_icon.Location = new Point(480, 150);
            copy_username_icon.Name = "copy_username_icon";
            copy_username_icon.Size = new Size(23, 23);
            copy_username_icon.TabIndex = 15;
            copy_username_icon.TabStop = false;
            // 
            // password_input
            // 
            password_input.Location = new Point(18, 220);
            password_input.Name = "password_input";
            password_input.Size = new Size(399, 23);
            password_input.TabIndex = 14;
            // 
            // password_label
            // 
            password_label.AutoSize = true;
            password_label.ForeColor = SystemColors.ControlDarkDark;
            password_label.Location = new Point(18, 200);
            password_label.Name = "password_label";
            password_label.Size = new Size(57, 15);
            password_label.TabIndex = 13;
            password_label.Text = "Password";
            // 
            // username_input
            // 
            username_input.Location = new Point(18, 150);
            username_input.Name = "username_input";
            username_input.Size = new Size(456, 23);
            username_input.TabIndex = 12;
            // 
            // username_label
            // 
            username_label.AutoSize = true;
            username_label.ForeColor = SystemColors.ControlDarkDark;
            username_label.Location = new Point(18, 130);
            username_label.Name = "username_label";
            username_label.Size = new Size(60, 15);
            username_label.TabIndex = 11;
            username_label.Text = "Username";
            // 
            // name_input
            // 
            name_input.Location = new Point(18, 85);
            name_input.Name = "name_input";
            name_input.Size = new Size(485, 23);
            name_input.TabIndex = 10;
            // 
            // name_label
            // 
            name_label.AutoSize = true;
            name_label.ForeColor = SystemColors.ControlDarkDark;
            name_label.Location = new Point(18, 65);
            name_label.Name = "name_label";
            name_label.Size = new Size(39, 15);
            name_label.TabIndex = 9;
            name_label.Text = "Name";
            // 
            // generate_password_icon
            // 
            generate_password_icon.BackgroundImage = (Image)resources.GetObject("generate_password_icon.BackgroundImage");
            generate_password_icon.BackgroundImageLayout = ImageLayout.Stretch;
            generate_password_icon.Location = new Point(423, 220);
            generate_password_icon.Name = "generate_password_icon";
            generate_password_icon.Size = new Size(23, 23);
            generate_password_icon.TabIndex = 18;
            generate_password_icon.TabStop = false;
            // 
            // vault_type_dropdown
            // 
            vault_type_dropdown.DropDownStyle = ComboBoxStyle.DropDownList;
            vault_type_dropdown.FormattingEnabled = true;
            vault_type_dropdown.Items.AddRange(new object[] { "Login", "Secure Note" });
            vault_type_dropdown.Location = new Point(18, 30);
            vault_type_dropdown.Name = "vault_type_dropdown";
            vault_type_dropdown.Size = new Size(485, 23);
            vault_type_dropdown.TabIndex = 19;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = SystemColors.ControlDarkDark;
            label4.Location = new Point(18, 8);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 20;
            label4.Text = "Type";
            // 
            // CreateVaultUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label4);
            Controls.Add(vault_type_dropdown);
            Controls.Add(generate_password_icon);
            Controls.Add(copy_password_icon);
            Controls.Add(view_password_icon);
            Controls.Add(copy_username_icon);
            Controls.Add(password_input);
            Controls.Add(password_label);
            Controls.Add(username_input);
            Controls.Add(username_label);
            Controls.Add(name_input);
            Controls.Add(name_label);
            Name = "CreateVaultUserControl";
            Size = new Size(521, 270);
            ((System.ComponentModel.ISupportInitialize)copy_password_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)view_password_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)copy_username_icon).EndInit();
            ((System.ComponentModel.ISupportInitialize)generate_password_icon).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        #region Publicly Accessible Values
        public string NameInput
        {
            get { return name_input.Text; }
        }
        public string UsernameInput
        {
            get { return username_input.Text; }
        }
        public string PasswordInput
        {
            get { return password_input.Text; }
        }

        #endregion Publicly Accessible Elements

        private PictureBox copy_password_icon;
        private PictureBox view_password_icon;
        private PictureBox copy_username_icon;
        private TextBox password_input;
        private Label password_label;
        private TextBox username_input;
        private Label username_label;
        private TextBox name_input;
        private Label name_label;
        private PictureBox generate_password_icon;
        private ComboBox vault_type_dropdown;
        private Label label4;
    }
}
