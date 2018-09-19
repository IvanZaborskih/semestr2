using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2._2._12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] arrStr1 = textBox1.Text.Split(' ');
            string[] arrStr2 = textBox2.Text.Split(' ');
            textBox3.Clear();
            int counter = BL.StringArr.TwoQue(arrStr1, arrStr2,out string[] arrOut);
            textBox3.Lines=arrOut;
            textBox3.AppendText(string.Format("Было сделано шагов:{0}", counter));
        }
    }
}
