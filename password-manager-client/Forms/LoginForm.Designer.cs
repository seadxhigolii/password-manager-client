namespace password_manager_client.Forms
{
    partial class LoginForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            lockwise_label = new Label();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            login_panel = new Panel();
            create_account_button = new Label();
            new_around_here_label = new Label();
            continue_button = new Button();
            back_button = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lockwise_label
            // 
            lockwise_label.AutoSize = true;
            lockwise_label.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lockwise_label.Location = new Point(298, 54);
            lockwise_label.Name = "lockwise_label";
            lockwise_label.Size = new Size(231, 65);
            lockwise_label.TabIndex = 0;
            lockwise_label.Text = "Lockwise";
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Location = new Point(254, 73);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(38, 37);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(254, 125);
            label1.Name = "label1";
            label1.Size = new Size(257, 42);
            label1.TabIndex = 2;
            label1.Text = "Log in or create a new account to \r\naccess your secure vault.";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // login_panel
            // 
            login_panel.Location = new Point(237, 200);
            login_panel.Name = "login_panel";
            login_panel.Size = new Size(312, 101);
            login_panel.TabIndex = 8;
            // 
            // create_account_button
            // 
            create_account_button.AutoSize = true;
            create_account_button.ForeColor = Color.Blue;
            create_account_button.Location = new Point(346, 379);
            create_account_button.Name = "create_account_button";
            create_account_button.Size = new Size(87, 15);
            create_account_button.TabIndex = 22;
            create_account_button.Text = "Create account";
            create_account_button.Click += create_account_button_Click;
            // 
            // new_around_here_label
            // 
            new_around_here_label.AutoSize = true;
            new_around_here_label.Location = new Point(337, 364);
            new_around_here_label.Name = "new_around_here_label";
            new_around_here_label.Size = new Size(103, 15);
            new_around_here_label.TabIndex = 21;
            new_around_here_label.Text = "New around here?";
            // 
            // continue_button
            // 
            continue_button.ForeColor = Color.Blue;
            continue_button.Location = new Point(298, 318);
            continue_button.Name = "continue_button";
            continue_button.Size = new Size(184, 27);
            continue_button.TabIndex = 20;
            continue_button.Text = "Continue";
            continue_button.UseVisualStyleBackColor = true;
            continue_button.Click += continue_button_Click;
            // 
            // back_button
            // 
            back_button.AutoSize = true;
            back_button.ForeColor = Color.Blue;
            back_button.Location = new Point(375, 413);
            back_button.Name = "back_button";
            back_button.Size = new Size(32, 15);
            back_button.TabIndex = 23;
            back_button.Text = "Back";
            back_button.Visible = false;
            back_button.Click += back_button_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(back_button);
            Controls.Add(create_account_button);
            Controls.Add(new_around_here_label);
            Controls.Add(continue_button);
            Controls.Add(login_panel);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Controls.Add(lockwise_label);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "LoginForm";
            Text = "Lockwise Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lockwise_label;
        private PictureBox pictureBox1;
        private Label label1;
        private Panel login_panel;
        private Label create_account_button;
        private Label new_around_here_label;
        private Button continue_button;
        private Label back_button;
    }
}