namespace password_manager_client.UserControls.PasswordManagerForm.Vault.View
{
    partial class ViewSecureNoteUserControl
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
        public string NotesLabelText
        {
            get => notes_label.Text;
            set => notes_label.Text = value;
        }

        public bool NotesLabelVisible
        {
            get => notes_label.Visible;
            set => notes_label.Visible = value;
        }

        public string NotesInputText
        {
            get => notes_input.Text;
            set => notes_input.Text = value;
        }
        public bool NotesInputVisible
        {
            get => notes_input.Visible;
            set => notes_input.Visible = value;
        }

        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewSecureNoteUserControl));
            notes_label = new Label();
            notes_input = new RichTextBox();
            secure_note_copy_button = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)secure_note_copy_button).BeginInit();
            SuspendLayout();
            // 
            // notes_label
            // 
            notes_label.AutoSize = true;
            notes_label.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            notes_label.ForeColor = SystemColors.ControlDarkDark;
            notes_label.Location = new Point(7, 9);
            notes_label.Name = "notes_label";
            notes_label.Size = new Size(59, 21);
            notes_label.TabIndex = 3;
            notes_label.Text = "NOTES";
            // 
            // notes_input
            // 
            notes_input.BackColor = Color.White;
            notes_input.BorderStyle = BorderStyle.None;
            notes_input.Location = new Point(3, 44);
            notes_input.Name = "notes_input";
            notes_input.ReadOnly = true;
            notes_input.Size = new Size(506, 314);
            notes_input.TabIndex = 2;
            notes_input.Text = "";
            // 
            // secure_note_copy_button
            // 
            secure_note_copy_button.BackColor = Color.White;
            secure_note_copy_button.BackgroundImage = (Image)resources.GetObject("secure_note_copy_button.BackgroundImage");
            secure_note_copy_button.BackgroundImageLayout = ImageLayout.Stretch;
            secure_note_copy_button.Location = new Point(481, 53);
            secure_note_copy_button.Name = "secure_note_copy_button";
            secure_note_copy_button.Size = new Size(23, 23);
            secure_note_copy_button.TabIndex = 7;
            secure_note_copy_button.TabStop = false;
            secure_note_copy_button.Click += secure_note_copy_button_Click;
            // 
            // ViewSecureNoteUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(secure_note_copy_button);
            Controls.Add(notes_label);
            Controls.Add(notes_input);
            Name = "ViewSecureNoteUserControl";
            Size = new Size(512, 366);
            ((System.ComponentModel.ISupportInitialize)secure_note_copy_button).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label notes_label;
        private RichTextBox notes_input;
        private PictureBox secure_note_copy_button;
    }
}
