namespace password_manager_client.Helpers
{
    public static class VaultHelper
    {
        public static Panel CreateVaultEntry(Guid vaultId, string title, string email, byte[] imageBytes, Func<Guid, Task> onClick)
        {
            Panel vaultPanel = new Panel
            {
                Size = new Size(260, 30),
                BorderStyle = BorderStyle.None,
                Cursor = Cursors.Hand
            };

            Label nameLabel = new Label
            {
                AutoSize = true,
                Location = new Point(28, 1),
                Text = title,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
                Cursor = Cursors.Hand
            };

            Label emailLabel = new Label
            {
                AutoSize = true,
                Location = new Point(28, 15),
                Text = email,
                ForeColor = SystemColors.ControlDark,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point),
                Cursor = Cursors.Hand
            };

            PictureBox iconPictureBox = new PictureBox
            {
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(3, 7),
                Size = new Size(20, 20),
                Cursor = Cursors.Hand
            };

            if (imageBytes != null && imageBytes.Length > 0)
            {
                try
                {
                    using (var ms = new MemoryStream(imageBytes))
                    {
                        iconPictureBox.Image = Image.FromStream(ms);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading image: {ex.Message}");
                }
            }

            async void PanelClickHandler(object sender, EventArgs e)
            {
                try
                {
                    await onClick(vaultId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error handling vault click: {ex.Message}");
                }
            }

            vaultPanel.Click += PanelClickHandler;
            nameLabel.Click += PanelClickHandler;
            emailLabel.Click += PanelClickHandler;
            iconPictureBox.Click += PanelClickHandler;

            vaultPanel.Controls.Add(nameLabel);
            vaultPanel.Controls.Add(emailLabel);
            vaultPanel.Controls.Add(iconPictureBox);

            return vaultPanel;
        }
    }
}
