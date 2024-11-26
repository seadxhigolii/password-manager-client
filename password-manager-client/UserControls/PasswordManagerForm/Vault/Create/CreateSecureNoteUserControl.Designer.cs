namespace password_manager_client.UserControls.PasswordManagerForm.Vault.Create
{
    partial class CreateSecureNoteUserControl
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

        #endregion

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            notes_input = new RichTextBox();
            notes_label = new Label();
            SuspendLayout();
            // 
            // notes_input
            // 
            notes_input.BorderStyle = BorderStyle.None;
            notes_input.Location = new Point(3, 49);
            notes_input.Name = "notes_input";
            notes_input.Size = new Size(506, 314);
            notes_input.TabIndex = 0;
            notes_input.Text = "";
            // 
            // notes_label
            // 
            notes_label.AutoSize = true;
            notes_label.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            notes_label.ForeColor = SystemColors.ControlDarkDark;
            notes_label.Location = new Point(14, 14);
            notes_label.Name = "notes_label";
            notes_label.Size = new Size(59, 21);
            notes_label.TabIndex = 1;
            notes_label.Text = "NOTES";
            // 
            // CreateSecureNoteUserControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(notes_label);
            Controls.Add(notes_input);
            Name = "CreateSecureNoteUserControl";
            Size = new Size(512, 366);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RichTextBox notes_input;
        private Label notes_label;
    }
}
