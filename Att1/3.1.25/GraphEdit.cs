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
    public partial class GraphEdit : Form
    {
        BL.Graph graph=null;
        int matrixSize = 0;
        bool isAdditing = true;
        public GraphEdit()
        {
            InitializeComponent();
        }

        private void GraphEdit_Load(object sender, EventArgs e)
        {
            isAdditing = false;
            graph=Program.MainForm.Gr;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < graph.Size; i++)
            {
                string name = "";
                name += (char)('A' + i);
                var cl = new DataGridViewCheckBoxColumn(false);
                cl.Width = 25;
                cl.HeaderText = name;
                dataGridView1.Columns.Add(cl);
                dataGridView1.Rows.Add();
                dataGridView1[i, i].Style.BackColor = Color.Gray;
                
            }
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    if (graph.Matrix[i, j] == 1)
                    {
                        dataGridView1[i, j].Value = true;
                    }
                    else
                        dataGridView1[i, j].Value = null;
                    dataGridView1[i, j].ReadOnly = true;
                }
                string name = "";
                name += (char)('A' + i);
                dataGridView1.Rows[i].HeaderCell.Value = name;
            }
            matrixSize = graph.Size;
            isAdditing = true;
        }

        private void GraphEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (CheckGraph() == false)
            {
                MessageBox.Show("Граф не связный");
                e.Cancel = true;
            }
            else
            {
                GraphEditSave();
            }
        }

        private bool CheckGraph()
        {
            for (int i = 0; i < matrixSize; i++)
            {
                bool zn = false;
                for (int j = 0; j < matrixSize; j++)
                {
                    if (i != j&&dataGridView1[i,j].Value!=null)
                    {
                        zn = true;
                        break;
                    }
                }
                if (zn == false)
                    return false;
            }
            return true;
        }

        private void добавитьВершинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (matrixSize >= 26)
                return;
            isAdditing = false;
            int i = matrixSize;
            string name = "";
            name += (char)('A' + i);
            var cl = new DataGridViewCheckBoxColumn(false);
            cl.Width = 25;
            cl.HeaderText = name;
            cl.ReadOnly = true;
            dataGridView1.Columns.Add(cl);
            var row = new DataGridViewRow();
            row.ReadOnly = true;
            dataGridView1.Rows.Add(row);
            int sizeRow = dataGridView1.ColumnCount-1;
            dataGridView1[sizeRow, sizeRow].Style.BackColor= Color.Gray;
            matrixSize++;
            isAdditing = true;
        }

        private void удалитьВершинуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (matrixSize <= 1)
                return;
            isAdditing = false;
            matrixSize--;
            dataGridView1.Columns.RemoveAt(matrixSize);
            dataGridView1.Rows.RemoveAt(matrixSize);
            isAdditing = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!isAdditing)
                return;
            if (e.RowIndex < 0)
                return;
            if (e.RowIndex == e.ColumnIndex)
                return;
            var zn = dataGridView1[e.ColumnIndex, e.RowIndex].Value;
            if (zn == null)
            {
                dataGridView1[e.RowIndex, e.ColumnIndex].Value = true;
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = true;
            }
            else
            {
                (dataGridView1[e.RowIndex, e.ColumnIndex].Value) = null;
                dataGridView1[e.ColumnIndex, e.RowIndex].Value = null;
            }
        }

        private void GraphEditSave()
        {
            Program.MainForm.Gr = new BL.Graph(matrixSize);
            for (int i = 0; i < matrixSize; i++)
            {
                for (int j = i+1; j < matrixSize; j++)
                {
                    if (dataGridView1[i, j].Value != null)
                    {
                        Program.MainForm.Gr.AddEdge(i, j);
                    }
                }
            }
        }
    }
}
