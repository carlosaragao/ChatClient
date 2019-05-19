using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ChatCliente.Model
{
    public class Conexao
    {

        string strConexao = "server=192.168.0.109;userid=ip;password=aps5semestre2019;database=aps";
        protected MySqlConnection conexao = null;

        // Método para abrir a conexão com o banco

        public void AbrirConexao()
        {
            try
            {
                conexao = new MySqlConnection(strConexao);
                conexao.Open();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }

        // Método para fechar a conexão com o banco

        public void fecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(strConexao);
                conexao.Close();
            }
            catch (Exception erro)
            {
                throw erro;
            }
        }
    }
}
