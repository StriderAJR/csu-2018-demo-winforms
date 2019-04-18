using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoWinForms
{
    public partial class RectangleControl : UserControl
    {
        Form parent;

        Rectangle rectangle;
        Color[] colors = new[] { Color.Red, Color.Yellow, Color.Green };
        int iColor = 0;
        Timer timer = new Timer();
        Pen blackPen = new Pen(Color.Black, 2);
        Brush brush = new SolidBrush(Color.Black);
        bool forward = true;

        public RectangleControl(Form parent, int startX, int startY, int width, int height)
        {
            InitializeComponent();
            this.parent = parent;
            this.Width = parent.Width;
            this.Height = parent.Height;

            this.rectangle = new Rectangle(startX, startY, width, height);

            timer.Interval = 500;
            timer.Tick += (s, e) =>
            {
                if (forward) iColor++;
                else iColor--;

                if (iColor == colors.Length-1) forward = false;
                if (iColor == 0) forward = true;
                this.parent.Invalidate();
            };
            timer.Start();
        }

        public void Move(int deltaX, int deltaY) {
            if (rectangle.X + deltaX > this.Width) rectangle.X = 0;
            else if (rectangle.X + deltaX < 0) rectangle.X = this.Width - rectangle.Width;
            else rectangle.X += deltaX;

            if (rectangle.Y + deltaY > this.Height) rectangle.Y = 0;
            else if (rectangle.Y + deltaY < 0) rectangle.Y = this.Height - rectangle.Height;
            else rectangle.Y += deltaY;

            this.parent.Invalidate();
        }

        private void RectangleControl_Paint(object sender, PaintEventArgs e)
        {
            brush = new SolidBrush(colors[iColor]);
            e.Graphics.FillRectangle(brush, rectangle);
            e.Graphics.DrawRectangle(blackPen, rectangle);
        }
    }
}
