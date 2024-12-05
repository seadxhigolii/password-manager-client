namespace password_manager_client.UserControls.PasswordManagerForm.Vault.Edit
{
    partial class EditSecureNoteUserControl
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
            notes_label = new Label();
            notes_input = new RichTextBox();
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
            notes_input.BorderStyle = BorderStyle.None;
            notes_input.Location = new Point(3, 44);
            notes_input.Name = "notes_input";
            notes_input.Size = new Size(506, 314);
            notes_input.TabIndex = 2;
            notes_input.Text = "";
            // 
            // EditSecureNoteUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(notes_label);
            Controls.Add(notes_input);
            Name = "EditSecureNoteUserControl";
            Size = new Size(512, 366);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label notes_label;
        private RichTextBox notes_input;
    }
}
