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
    public partial class MainForm : Form
    {
        RectangleControl cRectangle1, cRectangle2;
        int recSide = 30;
        public MainForm()
        {
            InitializeComponent();
            cRectangle1 = new RectangleControl(this, 0, 0, recSide, recSide, new[] { Color.Red, Color.Yellow, Color.Green });
            cRectangle2 = new RectangleControl(this, 50, 50, recSide, recSide, new[] { Color.Black, Color.White, Color.Blue });
            this.KeyPreview = true;
        }

        private void Form1_Paint(object sender, PaintEventArgs e) {
            cRectangle1.Draw(e.Graphics);
            cRectangle2.Draw(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {   
                case Keys.W: cRectangle1.Move(0, -recSide); break;
                case Keys.I: cRectangle2.Move(0, -recSide); break;
                case Keys.S: cRectangle1.Move(0, recSide); break;
                case Keys.K: cRectangle2.Move(0, recSide);  break;
                case Keys.A: cRectangle1.Move(-recSide, 0); break;
                case Keys.J: cRectangle2.Move(-recSide, 0); break;
                case Keys.D: cRectangle1.Move(recSide, 0); break;
                case Keys.L: cRectangle2.Move(recSide, 0);  break;
            }
            this.Invalidate();
        }
    }
}