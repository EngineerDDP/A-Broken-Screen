using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 电视坏了
{
    public partial class Form1 : Form
    {
        private const Int32 WIDTH = 1920;
        private const Int32 SIZE = 7;
        private const Int32 HEIGHT = 1080;
        Bitmap map;

        private int i = 0;

        public Form1()
        {
            InitializeComponent();
            map = new Bitmap(WIDTH, HEIGHT);
        }

        private void flash()
        {
            Graphics g = Graphics.FromImage(map);
            //获取填充色画刷
            SolidBrush b = new SolidBrush(System.Drawing.Color.Black);
            //创建可用矩阵
            Rectangle rect = new Rectangle(0, 0, SIZE, SIZE);
            int[,] ab = new int[HEIGHT / SIZE, WIDTH / SIZE];
            Random r = new Random();
            int i, j;
            for (i = 0; i < HEIGHT / SIZE; ++i)
            {
                for (j = 0; j < WIDTH / SIZE; ++j)
                {
                    ab[i, j] = r.Next() % 2 == 0 ? 0 : 1;
                }
            }
            for (i = 0; i < HEIGHT / SIZE; ++i)
            {
                for (j = 0; j < WIDTH / SIZE; ++j)
                {
                    if (ab[i, j] == 1)
                    {
                        rect.Location = new Point(j * SIZE, i * SIZE);
                        g.FillRectangle(b, rect);
                    }
                }
            }
            if (PicBox.Image != null)
                PicBox.Image.Dispose();
            PicBox.Image = map;
            map = new Bitmap(WIDTH, HEIGHT);
            g.Dispose();
            b.Dispose();
        }

        private void changebgc()
        {
            switch(i)
            {
                case 0:
                    PicBox.BackColor = Color.Blue;
                    break;
                case 1:
                    PicBox.BackColor = Color.Red;
                    break;
                case 2:
                    PicBox.BackColor = Color.Green;
                    break;
                case 3:
                    PicBox.BackColor = Color.Purple;
                    break;
                case 4:
                    PicBox.BackColor = Color.Yellow;
                    i = -1;
                    break;
                default:
                    i = -1;
                    break;
            }
            ++i;
        }

        private void lch_Tick(object sender, EventArgs e)
        {
            flash();
        }
    }
}
