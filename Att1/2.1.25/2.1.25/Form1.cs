using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._1._25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int n = 0, k = 0;
            try
            {
                n = Int32.Parse(textBoxN.Text);
                k = Int32.Parse(textBoxK.Text);
                var count = new BL.Counted(n, k);
                count.SolCount(out int win, out int[] los);
                textBox3.Clear();
                foreach (var i in los)
                {
                    textBox3.AppendText("был удален " + i + " игрок\n");
                }
                textBox3.AppendText("Выиграл игрок под номером " + win);
            }
            catch (FormatException)
            {
                MessageBox.Show("Введите целые значения");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Введите k<=N");
            }
        }
    }
}
