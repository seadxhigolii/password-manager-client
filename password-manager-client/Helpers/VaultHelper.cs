namespace password_manager_client.Helpers
{
    public static class VaultHelper
    {
        public static Panel CreateVaultEntry(string website, string email, byte[] imageBytes)
        {
            Panel vaultPanel = new Panel
            {
                Size = new Size(267, 30),
                BorderStyle = BorderStyle.None
            };

            Label websiteLabel = new Label
            {
                AutoSize = true,
                Location = new Point(28, 1),
                Text = website,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point),
            };

            Label emailLabel = new Label
            {
                AutoSize = true,
                Location = new Point(28, 15),
                Text = email,
                ForeColor = SystemColors.ControlDark,
                Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point),
            };

            PictureBox iconPictureBox = new PictureBox
            {
                BackgroundImageLayout = ImageLayout.Stretch,
                Location = new Point(3, 7),
                Size = new Size(20, 20),
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
                }
            }

            vaultPanel.Controls.Add(websiteLabel);
            vaultPanel.Controls.Add(emailLabel);
            vaultPanel.Controls.Add(iconPictureBox);

            return vaultPanel;
        }


    }
}