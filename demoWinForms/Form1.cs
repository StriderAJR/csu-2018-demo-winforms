using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoWinForms
{
    public partial class Form1 : Form
    {
        RectangleControl cRectangle;
        int recSide = 30;
        public Form1()
        {
            InitializeComponent();
            cRectangle = new RectangleControl(this, 10, 10, recSide, recSide);
            this.KeyPreview = true;
            this.Controls.Add(cRectangle);
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            cRectangle.Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                case Keys.Up: cRectangle.Move(0, -30); break;
                case Keys.S:
                case Keys.Down: cRectangle.Move(0, 30); break;
                case Keys.A:
                case Keys.Left: cRectangle.Move(-30, 0); break;
                case Keys.D:
                case Keys.Right: cRectangle.Move(30, 0); break;
            }
            this.Invalidate();
        }
    }
}
