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

namespace _1._1._25
{
    public partial class Form1 : Form
    {
        string name = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                name = dialog.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BL.FileWork file = new BL.FileWork(name);
            file.SumInt(out int sum,out int kol);
            label1.Text = "Количество чисел="+Convert.ToString(kol);
            label2.Text = "Сумма чисел="+Convert.ToString(sum);
        }
    }
}
