using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._1._25
{
    public partial class Form1 : Form
    {
        internal BL.Graph Gr;
        private List<BL.Graph> list = new List<BL.Graph>();
        private int currentSubGr = -1;

        public Form1()
        {
            InitializeComponent();
            Gr = new BL.Graph(5);
            Gr.AddEdge(0, 1);
            Gr.AddEdge(1, 2);
            Gr.AddEdge(2, 3);
            Gr.AddEdge(3, 4);
            Gr.AddEdge(0, 4);
            Gr.AddEdge(1, 4);
            
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            int height = pictureBox1.Height;
            int width = pictureBox1.Width;
            int centrH = height / 2;
            int centrW = width / 2;
            int R = Math.Min(centrH, centrW)-20;
            double angle = 0;
            double angleD = 2 * Math.PI / Gr.Size ;
            SolidBrush Br = new SolidBrush(Color.Gray);
            SolidBrush BrRed = new SolidBrush(Color.Red);
            Pen pn = new Pen(Color.Gray, 3);
            Pen pnRed = new Pen(Color.Red, 4);
            Point[] vert = new Point[Gr.Size];
            for (int i = 0; i < Gr.Size; i++)
            {
                int y = centrH + (int)(R*Math.Sin(angle));
                int x = centrW + (int)(R *Math.Cos(angle));
                e.Graphics.FillEllipse(Br, x-5, y-5, 10, 10);
                angle += angleD;
                vert[i].X = x;
                vert[i].Y = y;
            }
            for (int i=0; i < Gr.Size; i++)
            {
                for (int j = i+1; j < Gr.Size; j++)
                {
                    if (Gr.Matrix[i, j] == 1)
                    {
                        e.Graphics.DrawLine(pn,vert[i],vert[j]);
                    }
                }
            }
            if (currentSubGr != -1)
            {
                BL.Graph subGr = list[currentSubGr];
                foreach (var i in subGr.VertInGraph)
                {
                    e.Graphics.FillEllipse(BrRed, vert[i].X - 5, vert[i].Y - 5, 10, 10);
                }
                for (int i = 0; i < subGr.Size; i++)
                {
                    for (int j = i + 1; j < subGr.Size; j++)
                    {
                        if (subGr.Matrix[i, j] == 1)
                        {
                            e.Graphics.DrawLine(pnRed, vert[i], vert[j]);
                        }
                    }
                }
            }


        }

        private void pictureBox1_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            list.Clear();
            list = Gr.GetSubGr(3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            currentSubGr = Math.Min(list.Count - 1, currentSubGr + 1);
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            currentSubGr = Math.Max(-1, currentSubGr - 1);
            pictureBox1.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Program.EditorForm.ShowDialog();
            button1_Click(sender, e);
            pictureBox1.Invalidate();
        }
    }
}
