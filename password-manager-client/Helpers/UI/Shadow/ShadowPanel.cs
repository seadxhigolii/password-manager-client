using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace password_manager_client.Helpers.UI.Shadow
{
    public class ShadowPanel : Panel
    {
        public int ShadowOffset { get; set; } = 5;
        public int ShadowBlur { get; set; } = 10;
        public Color ShadowColor { get; set; } = Color.FromArgb(50, 0, 0, 0); // Semi-transparent black

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (GraphicsPath path = new GraphicsPath())
            {
                // Draw the shadow with rounded corners and blur
                int radius = 15;
                path.AddArc(ShadowOffset, ShadowOffset, radius, radius, 180, 90);
                path.AddArc(this.Width - ShadowBlur - radius, ShadowOffset, radius, radius, 270, 90);
                path.AddArc(this.Width - ShadowBlur - radius, this.Height - ShadowBlur - radius, radius, radius, 0, 90);
                path.AddArc(ShadowOffset, this.Height - ShadowBlur - radius, radius, radius, 90, 90);
                path.CloseFigure();

                // Apply shadow effect
                using (PathGradientBrush brush = new PathGradientBrush(path))
                {
                    brush.CenterColor = ShadowColor;
                    brush.SurroundColors = new[] { Color.Transparent };
                    e.Graphics.FillPath(brush, path);
                }
            }
        }
    }

}
