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
        Color[] colors;
        int iColor = 0;
        Timer timer = new Timer();
        Pen blackPen = new Pen(Color.Black, 2);
        Brush brush = new SolidBrush(Color.Black);
        bool forward = true;

        public RectangleControl(Form parent, int startX, int startY, int width, int height, Color[] colors)
        {
            InitializeComponent();
            this.parent = parent;
            this.colors = colors;
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
                parent.Invalidate();
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

            parent.Invalidate();
        }

        public void Draw(Graphics graphics)
        {
            brush = new SolidBrush(colors[iColor]);
            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(blackPen, rectangle);
        }
    }
}
