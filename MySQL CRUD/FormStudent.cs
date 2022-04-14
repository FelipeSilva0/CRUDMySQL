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
    public partial class FormStudent : Form
    {
        private readonly Form1 _parent;
        public string id_usuario, usuario, senha, nome, permissao; 
        public FormStudent(Form1 parent)
        {
            InitializeComponent();
            _parent = parent;
        }

        public void UpdateInfo()
        {
            lbltext.Text = "Update Student";
            btnSave.Text = "Update";
            txtUsuario.Text = usuario;
            txtSenha.Text = senha;
            txtNome.Text = nome;
            txtPermissao.Text = permissao;
        }

        public void SaveInfo()
        {
            lbltext.Text = "Add Student";
            btnSave.Text = "Save";
        }

        public void Clear()
        {
            txtUsuario.Text = txtSenha.Text = txtNome.Text = txtPermissao.Text = string.Empty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(btnSave.Text == "Save")
            {
                Student std = new Student(txtUsuario.Text.Trim(), txtSenha.Text.Trim(), txtNome.Text.Trim(), txtPermissao.Text.Trim(), DateTime.Now);
                DbStudent.AddStudent(std);
                Clear();
            }
            if(btnSave.Text == "Update")
            {
                Student std = new Student(txtUsuario.Text.Trim(), txtSenha.Text.Trim(), txtNome.Text.Trim(), txtPermissao.Text.Trim(), DateTime.Now);
                DbStudent.UpdateStudent(std, id_usuario);
            }
            _parent.Display();
        }
    }
}
