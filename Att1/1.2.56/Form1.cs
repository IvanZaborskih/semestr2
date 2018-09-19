using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1._2._56
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void buttonSize_Click(object sender, EventArgs e)
        {
            string name1 = textBox2.Text;
            string name2 = textBox3.Text;
            string name3 = textBox3.Text;
            try
            {
                int k1 = BL.txtFile.TextSize(name1);
                int k2 = BL.txtFile.TextSize(name2);
                int k3 = BL.txtFile.TextSize(name3);
                labelSize.Text = "Количество строк=" + Convert.ToString(k1 + k2 + k3);
            }
            catch
            {
                labelSize.Text = "Количество строк=-1";
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox1.Text = dialog.SafeFileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox2.Text = dialog.SafeFileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "txt files (*.txt)|*.txt";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                textBox3.Text = dialog.SafeFileName;
            }
        }
    }
}
