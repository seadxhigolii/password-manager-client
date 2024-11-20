namespace password_manager_client.UserControls.PasswordManagerForm.PasswordWebsite
{
    partial class ViewVaultWebsiteUserControl
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

        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewVaultWebsiteUserControl));
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            website_input = new TextBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = (Image)resources.GetObject("pictureBox3.BackgroundImage");
            pictureBox3.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox3.Location = new Point(480, 34);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(23, 23);
            pictureBox3.TabIndex = 12;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = (Image)resources.GetObject("pictureBox2.BackgroundImage");
            pictureBox2.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox2.Location = new Point(451, 34);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(23, 23);
            pictureBox2.TabIndex = 11;
            pictureBox2.TabStop = false;
            // 
            // website_input
            // 
            website_input.Enabled = false;
            website_input.Location = new Point(18, 34);
            website_input.Name = "website_input";
            website_input.Size = new Size(417, 23);
            website_input.TabIndex = 10;
            website_input.Text = "www.url.com";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = SystemColors.ControlDarkDark;
            label3.Location = new Point(18, 14);
            label3.Name = "label3";
            label3.Size = new Size(49, 15);
            label3.TabIndex = 9;
            label3.Text = "Website";
            // 
            // ViewVaultWebsiteUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pictureBox3);
            Controls.Add(pictureBox2);
            Controls.Add(website_input);
            Controls.Add(label3);
            Name = "ViewVaultWebsiteUserControl";
            Size = new Size(521, 70);
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private TextBox website_input;
        private Label label3;
    }
}
