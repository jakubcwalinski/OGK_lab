using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafika2
{
    public partial class Form1 : Form
    {
        private void okrag(int srodX, int srodY, int promien, Color color)
        {
            Bitmap p = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            int d = (5 - promien * 4) / 4;
            int x = 0;
            int y = promien;

            do
            {
                if (srodX + x >= 0 && srodX + x <= p.Width - 1 && srodY + y >= 0 && srodY + y <= p.Height - 1) p.SetPixel(srodX + x, srodY + y, color);
                if (srodX + x >= 0 && srodX + x <= p.Width - 1 && srodY - y >= 0 && srodY - y <= p.Height - 1) p.SetPixel(srodX + x, srodY - y, color);
                if (srodX - x >= 0 && srodX - x <= p.Width - 1 && srodY + y >= 0 && srodY + y <= p.Height - 1) p.SetPixel(srodX - x, srodY + y, color);
                if (srodX - x >= 0 && srodX - x <= p.Width - 1 && srodY - y >= 0 && srodY - y <= p.Height - 1) p.SetPixel(srodX - x, srodY - y, color);
                if (srodX + y >= 0 && srodX + y <= p.Width - 1 && srodY + x >= 0 && srodY + x <= p.Height - 1) p.SetPixel(srodX + y, srodY + x, color);
                if (srodX + y >= 0 && srodX + y <= p.Width - 1 && srodY - x >= 0 && srodY - x <= p.Height - 1) p.SetPixel(srodX + y, srodY - x, color);
                if (srodX - y >= 0 && srodX - y <= p.Width - 1 && srodY + x >= 0 && srodY + x <= p.Height - 1) p.SetPixel(srodX - y, srodY + x, color);
                if (srodX - y >= 0 && srodX - y <= p.Width - 1 && srodY - x >= 0 && srodY - x <= p.Height - 1) p.SetPixel(srodX - y, srodY - x, color);
                if (d < 0)
                {
                    d += 2 * x + 1;
                }
                else
                {
                    d += 2 * (x - y) + 1;
                    y--;
                }
                x++;
            } while (x <= y);
            pictureBox1.Image = p;
        }
        private void linia(Point from, Point to)
        {
            Bitmap p = new Bitmap(pictureBox1.Width, pictureBox1.Height);

            double deltaX = to.X - from.X;
            double deltaY = to.Y - from.Y;
            double deltaErr = Math.Abs(deltaY / deltaX);
            double error = deltaErr - 0.5;
            int y = from.Y;

            for (int x = from.X; x <= to.X; x++)
            {
                p.SetPixel(x, y, Color.White);
                error += deltaErr;
                if (error >= 0.5)
                {
                    y += 1;
                    error -= 1.0;
                }
            }
            pictureBox1.Image = p;
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point poczatek = new Point(Decimal.ToInt32(numericUpDown1.Value), Decimal.ToInt32(numericUpDown2.Value));
            Point koniec = new Point(Decimal.ToInt32(numericUpDown3.Value), Decimal.ToInt32(numericUpDown4.Value));
            linia(poczatek, koniec);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            okrag(100, 100, 50, Color.White);
        }
    }
}