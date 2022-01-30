using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace grafika1
{
    public partial class Form1 : Form
    {
        Bitmap obraz, kopia;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int szerokosc = obraz.Width;
            int wysokosc = obraz.Height;

            for (int y = 0; y < wysokosc; y++)
            {
                for (int x = 0; x < szerokosc; x++)
                {
                    Color p = obraz.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    kopia.SetPixel(x, y, Color.FromArgb(a, r, g, b));
                }
            }
            pictureBox2.Image = kopia;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int width = obraz.Width;
            int height = obraz.Height;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color p = obraz.GetPixel(x, y);

                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;

                    int srednia = (r + g + b) / 3;

                    kopia.SetPixel(x, y, Color.FromArgb(a, srednia, srednia, srednia));
                }
            }
            pictureBox2.Image = kopia;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            obraz = new Bitmap(openFileDialog1.FileName);
            kopia = new Bitmap(obraz.Width, obraz.Height);
            pictureBox1.Image = obraz;
        }
    }
}
