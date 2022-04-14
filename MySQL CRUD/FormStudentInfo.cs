using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_CRUD
{
    public partial class Form1 : Form
    {
        FormStudent form;
        public Form1()
        {
            InitializeComponent();
            form = new FormStudent(this);
        }
        
        public void Display()
        {
            //if(checkTeste.Checked)
            //{
                DbStudent.DisplayAndSearch("SELECT id_usuario, usuario, senha, nome, permissao FROM tb_user", dataGridView);
            //}
           
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            form.Clear();
            form.SaveInfo();
            form.ShowDialog();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            Display();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            DbStudent.DisplayAndSearch("SELECT id_usuario, usuario, senha, nome, permissao FROM tb_user WHERE Usuario LIKE'%"+ txtSearch.Text +"%'", dataGridView);
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex == 0)
            {
                if (MessageBox.Show("Are you want to update student record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    //Edit
                    form.Clear();
                    form.id_usuario = dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
                    form.usuario = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    form.senha = dataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
                    form.nome = dataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
                    form.permissao = dataGridView.Rows[e.RowIndex].Cells["Column5"].Value.ToString();
                    form.UpdateInfo();
                    form.ShowDialog();
                }
                return;
            }
            if(e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Are you want to delete student record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    DbStudent.DeleteStudent(dataGridView.Rows[e.RowIndex].Cells[2].Value.ToString());
                    Display();
                }
                return;
            }
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            Display();
        }
    }
}
