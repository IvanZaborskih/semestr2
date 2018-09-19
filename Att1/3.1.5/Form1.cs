using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3._1._5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
                        dataGridView1.Columns.Add("Имя", "Имя");
            dataGridView1.Columns["Имя"].Width = 100;
            dataGridView1.Columns.Add("Возраст", "Возраст");
            dataGridView1.Columns["Возраст"].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {

        }
    }
}
