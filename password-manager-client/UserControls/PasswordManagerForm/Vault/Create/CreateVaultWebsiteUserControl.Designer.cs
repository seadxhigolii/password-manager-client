namespace password_manager_client.UserControls.PasswordManagerForm.Vault.Create
{
    partial class CreateVaultWebsiteUserControl
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
            textBox3 = new TextBox();
            label3 = new Label();
            SuspendLayout();
            // 
            // textBox3
            // 
            textBox3.Enabled = false;
            textBox3.Location = new Point(18, 34);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(481, 23);
            textBox3.TabIndex = 14;
            textBox3.Text = "www.url.com";
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
            // CreateVaultWebsiteUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(textBox3);
            Controls.Add(label3);
            Name = "CreateVaultWebsiteUserControl";
            Size = new Size(521, 70);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox3;
        private Label label3;
    }
}
