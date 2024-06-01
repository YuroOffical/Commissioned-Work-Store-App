using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;

namespace Sales_and_Finance_Application.Aesthetic
{
    public class REPictureBox : PictureBox
    {
        private int bordersize = 0;
        private int borderradius = 40;
        private Color borderColor = Color.Black;

        public REPictureBox()
        {
            this.Size = new Size(150, 40);
            this.BackColor = Color.LightGray;
            this.ForeColor = Color.White;
        }

        private GraphicsPath GetFigurePath(RectangleF rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.Width - radius, rect.Height - radius, radius, radius, 00, 90);
            path.AddArc(rect.X, rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            RectangleF RectSurface = new RectangleF(0, 0, this.Width, this.Height);
            RectangleF RectBorder = new RectangleF(1, 1, this.Width - 0.8F, this.Height - 1);

            if (borderradius > 2)
            {
                using (GraphicsPath pathsurface = GetFigurePath(RectSurface, borderradius))
                using (GraphicsPath pathborder = GetFigurePath(RectBorder, borderradius - 1F))
                using (Pen pensurface = new Pen(this.Parent.BackColor, 2))
                using (Pen pensborder = new Pen(borderColor, bordersize))
                {
                    pensborder.Alignment = PenAlignment.Inset;
                    this.Region = new Region(pathsurface);

                    pevent.Graphics.DrawPath(pensurface, pathsurface);
                    if (bordersize >= 1)
                    {
                        pevent.Graphics.DrawPath(pensborder, pathsurface);
                    }
                }
            }
            else
            {
                this.Region = new Region(RectSurface);
                if (bordersize >= 1)
                {
                    using (Pen pensborder = new Pen(borderColor, bordersize))
                    {
                        pevent.Graphics.DrawRectangle(pensborder, 0, 0, this.Width - 1, this.Height - 1);
                    }
                }
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            this.Parent.BackColorChanged += new EventHandler(Container_BackColorChanged);
        }
        private void Container_BackColorChanged(object sender, EventArgs e)
        {
            if (this.DesignMode)
            {
                this.Invalidate();
            }
        }
    }
}

