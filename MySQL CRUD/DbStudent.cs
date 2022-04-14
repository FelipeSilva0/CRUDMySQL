using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MySQL_CRUD
{
    class DbStudent
    {
        public static MySqlConnection GetConnection()
        {
            // Criar banco de dados e fazer a alteração aqui
            string sql = "datasource=186.202.152.30;username=database;password=senha;database=gpespecialista";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("MySQL Connection! \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return con;
        }

        public static void AddStudent(Student std)
        {
            string sql = "INSERT INTO tb_user VALUES (NULL, @Usuario, @Senha, @Nome, @Permissao, NULL)";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = std.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = std.senha;
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = std.nome;
            cmd.Parameters.Add("@Permissao", MySqlDbType.VarChar).Value = std.permissao;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Added Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not insert. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void UpdateStudent(Student std, string id_usuario)
        {
            string sql = "UPDATE tb_user SET usuario = @Usuario, senha = @Senha, nome = @Nome, permissao = @Permissao, WHERE id_usuario = @id_usuario";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id_usuario", MySqlDbType.VarChar).Value = id_usuario;
            cmd.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = std.usuario;
            cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = std.senha;
            cmd.Parameters.Add("@Nome", MySqlDbType.VarChar).Value = std.nome;
            cmd.Parameters.Add("@Permissao", MySqlDbType.VarChar).Value = std.permissao;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Update Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not update. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DeleteStudent(string id_usuario)
        {
            string sql = "DELETE FROM tb_user WHERE id_usuario = @id_usuario";
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@id_usuario", MySqlDbType.VarChar).Value = id_usuario;
            try
            {
                cmd.ExecuteNonQuery();
                MessageBox.Show("Deleted Sucessfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Student not delete. \n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            con.Close();
        }

        public static void DisplayAndSearch(string query, DataGridView dgv)
        {
            string sql = query;
            MySqlConnection con = GetConnection();
            MySqlCommand cmd = new MySqlCommand(sql, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tbl = new DataTable();
            adp.Fill(tbl);
            dgv.DataSource = tbl;
            con.Close();
        }
    }
}
