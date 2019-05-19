using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ChatCliente
{
    public partial class Login : Form
    {

        MySqlConnection Con = null;
        private string strCon = "server=192.168.0.109;userid=ip;password=aps5semestre2019;database=aps";
        private string strSql = string.Empty;
        public bool logado = false;
        public string nome = "";

        public Login()
        {
            InitializeComponent();
        }

        public void Logar()
        {
            Con = new MySqlConnection(strCon);

            string usuario, senha;

            int count;

            try
            {
                usuario = txtUsuario.Text;
                senha = txtSenha.Text;

                strSql = "SELECT COUNT(ID) FROM usuario WHERE usuario = @Usuario AND senha = @Senha";

                MySqlCommand cmd = new MySqlCommand(strSql, Con);

                cmd.Parameters.Add("@Usuario", MySqlDbType.VarChar).Value = usuario;
                cmd.Parameters.Add("@Senha", MySqlDbType.VarChar).Value = senha;

                Con.Open();

                count = Convert.ToInt32(cmd.ExecuteScalar());

                if (count > 0)
                {
                    logado = true;
                    nome = usuario;
                    MessageBox.Show("Logado com Sucesso!");
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Login ou senha incorretos!");
                    logado = false;
                }
            }
            catch (MySqlException e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            //frmCliente frm = new frmCliente("carlos");
            //frm.ShowDialog();
            Logar();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                Logar();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
