using password_manager_client.Utils;

namespace password_manager_client.Forms.Shared
{
    public class ToastForm : Form
    {
        private static readonly List<ToastForm> ActiveToasts = new List<ToastForm>();
        private Label messageLabel;
        private Form parentForm;

        public ToastForm(Form parentForm, string message, string? messageType, int duration = 3000)
        {
            this.parentForm = parentForm ?? throw new ArgumentNullException(nameof(parentForm));

            FormBorderStyle = FormBorderStyle.None;
            StartPosition = FormStartPosition.Manual;
            BackColor = ToastColors.GetBackgroundColor(messageType);
            Opacity = 1;
            ShowInTaskbar = false;
            TopMost = true;

            int maxWidth = 320;
            int textWidth = TextRenderer.MeasureText(message, new Font("Segoe UI", 10, FontStyle.Regular)).Width;
            int toastWidth = Math.Max(textWidth + 15, maxWidth);
            int toastHeight = 50;
            Size = new Size(toastWidth, toastHeight);

            string displayMessage = message;
            if (textWidth > maxWidth - 15)
            {
                displayMessage = CropTextWithEllipsis(message, maxWidth - 15, new Font("Segoe UI", 10, FontStyle.Regular));
            }

            messageLabel = new Label
            {
                Text = displayMessage,
                ForeColor = ToastColors.GetTextColor(messageType),
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                Font = new Font("Segoe UI", 10, FontStyle.Regular)
            };
            Controls.Add(messageLabel);

            UpdateToastPosition();

            parentForm.Move += ParentForm_PositionChanged;
            parentForm.Resize += ParentForm_PositionChanged;

            var timer = new System.Windows.Forms.Timer
            {
                Interval = duration
            };
            timer.Tick += (s, e) =>
            {
                timer.Stop();
                FadeOutAndClose();
            };
            timer.Start();

            ActiveToasts.Insert(0, this);
            RepositionActiveToasts();
        }

        private void FadeOutAndClose()
        {
            var fadeTimer = new System.Windows.Forms.Timer
            {
                Interval = 50
            };
            fadeTimer.Tick += (fs, fe) =>
            {
                if (Opacity > 0)
                {
                    Opacity -= 0.05;
                }
                else
                {
                    fadeTimer.Stop();
                    parentForm.Move -= ParentForm_PositionChanged;
                    parentForm.Resize -= ParentForm_PositionChanged;

                    ActiveToasts.Remove(this);
                    RepositionActiveToasts();
                    Close();
                }
            };
            fadeTimer.Start();
        }

        private void ParentForm_PositionChanged(object sender, EventArgs e)
        {
            UpdateToastPosition();
        }

        private void UpdateToastPosition()
        {
            int x = parentForm.Location.X + parentForm.Width - Width - 15;
            int y = parentForm.Location.Y + 50 + ActiveToasts.IndexOf(this) * (Height + 5);
            Location = new Point(x, y);
        }

        private string CropTextWithEllipsis(string text, int maxWidth, Font font)
        {
            string ellipsis = "...";
            int ellipsisWidth = TextRenderer.MeasureText(ellipsis, font).Width;

            for (int i = text.Length - 1; i > 0; i--)
            {
                string croppedText = text.Substring(0, i) + ellipsis;
                int croppedWidth = TextRenderer.MeasureText(croppedText, font).Width;

                if (croppedWidth <= maxWidth - ellipsisWidth)
                {
                    return croppedText;
                }
            }

            return ellipsis;
        }

        private static void RepositionActiveToasts()
        {
            int offset = 50;
            foreach (var toast in ActiveToasts)
            {
                toast.Location = new Point(
                    toast.parentForm.Location.X + toast.parentForm.Width - toast.Width - 15,
                    toast.parentForm.Location.Y + offset
                );
                offset += toast.Height + 5;
            }
        }

        public static void ShowToast(Form parentForm, string message, string? messageType = null, int duration = 3000)
        {
            var toast = new ToastForm(parentForm, message, messageType, duration);
            toast.Show();
        }
    }
}
