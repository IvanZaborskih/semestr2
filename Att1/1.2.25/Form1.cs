using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using BL;

namespace _1._2._25
{
    public partial class Form1 : Form
    {
        string name="";
        BinFile bf = null;


        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Lines = bf.SetSize50();
                
            }
            catch
            {
                MessageBox.Show("Выберите файл");
            }
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                name = openFileDialog1.FileName;
                label1.Text = System.IO.Path.GetFileName(name);
                bf = new BinFile(name);
                textBox1.Lines = bf.ReadFile();
                
            }
        }
    }
}
