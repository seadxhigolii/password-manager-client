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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.ForeColor = Color.Blue;
            button1.Location = new Point(3, 109);
            button1.Name = "button1";
            button1.Size = new Size(184, 27);
            button1.TabIndex = 9;
            button1.Text = "Continue";
            button1.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 64);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Repeat Master Password";
            textBox2.Size = new Size(184, 23);
            textBox2.TabIndex = 12;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 6);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Email address";
            textBox1.Size = new Size(184, 23);
            textBox1.TabIndex = 8;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(3, 35);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Master Password";
            textBox3.Size = new Size(184, 23);
            textBox3.TabIndex = 13;
            // 
            // Register
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "Register";
            Size = new Size(191, 141);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox2;
        private TextBox textBox1;
        private TextBox textBox3;
    }
}
