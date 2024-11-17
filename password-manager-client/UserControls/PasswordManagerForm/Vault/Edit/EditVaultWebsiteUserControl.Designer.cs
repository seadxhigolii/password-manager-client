namespace password_manager_client.UserControls.PasswordManagerForm.Vault.Edit
{
    partial class EditVaultWebsiteUserControl
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

        public string WebsiteInput
        {
            get => website_input.Text;
            set => website_input.Text = value;
        }

        #endregion Publicly Accessible Elements

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            website_input = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // website_input
            // 
            website_input.Enabled = false;
            website_input.Location = new Point(18, 34);
            website_input.Name = "website_input";
            website_input.Size = new Size(487, 23);
            website_input.TabIndex = 14;
            website_input.Text = "www.url.com";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(18, 14);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 13;
            label3.Text = "Website";
            // 
            // EditVaultWebsiteUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(website_input);
            Controls.Add(label3);
            Name = "EditVaultWebsiteUserControl";
            Size = new Size(521, 70);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox website_input;
        private Label label3;
    }
}
