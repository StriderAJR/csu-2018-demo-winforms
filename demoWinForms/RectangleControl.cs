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

        public void Move(int deltaX, int deltaY)
        {
            this.rectangle.X += deltaX;
            this.rectangle.Y += deltaY;
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
