using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace ChatCliente.Model
{
    class IncidenteDAO : Conexao
    {

        MySqlCommand comando = null;
        string strSQL;

        // Método para exibir os dados no Grid

        public DataTable ExibirDados()
        {
            try
            {
                AbrirConexao();
                this.strSQL = "Select I.id, I.descricao, U.usuario, I.data_incidente, I.solucao from incidente as I inner join usuario as U on U.id = I.usuario_id";

                comando = new MySqlCommand(this.strSQL, conexao);

                MySqlDataAdapter Da = new MySqlDataAdapter();
                Da.SelectCommand = comando;

                DataTable Dt = new DataTable();

                Da.Fill(Dt);

                return Dt;
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                fecharConexao();
            }
        }

        // Método para salvar os dados do form

        public void salvar(Incidente incidente, string usuario)
        {
            try
            {
                AbrirConexao();

                int idUsuario = this.retornaUsuario(usuario);

                this.strSQL = "INSERT INTO incidente (descricao, usuario_id, data_incidente, solucao) values (@descricao, @IdUser, @data, @solucao)";

                comando = new MySqlCommand(this.strSQL, conexao);

                comando.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = incidente.descricao;
                comando.Parameters.AddWithValue("@IdUser", idUsuario);
                comando.Parameters.Add("@data", MySqlDbType.Date).Value = incidente.dataIncidente;
                comando.Parameters.Add("@solucao", MySqlDbType.VarChar).Value = incidente.solucao;

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro; ;
            }
            finally
            {
                fecharConexao();
            }
        }

        // Método para editar os dados

        public void editar(Incidente incidente, string usuario)
        {
            try
            {
                AbrirConexao();

                int idUsuario = this.retornaUsuario(usuario);

                this.strSQL = "UPDATE incidente SET descricao = @descricao, usuario_id = @IdUser, data_incidente = @data, solucao = @solucao WHERE id = @id";

                comando = new MySqlCommand(this.strSQL, conexao);

                comando.Parameters.Add("@id", MySqlDbType.Int32).Value = incidente.id;
                comando.Parameters.AddWithValue("@IdUser", idUsuario);
                comando.Parameters.Add("@descricao", MySqlDbType.VarChar).Value = incidente.descricao;
                comando.Parameters.Add("@data", MySqlDbType.Date).Value = incidente.dataIncidente;
                comando.Parameters.Add("@solucao", MySqlDbType.VarChar).Value = incidente.solucao;

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                fecharConexao();
            }
        }

        // Método para excluir os dados

        public void excluir(Incidente incidente)
        {
            try
            {
                AbrirConexao();

                this.strSQL = "DELETE FROM incidente WHERE id = @id";

                comando = new MySqlCommand(this.strSQL, conexao);

                comando.Parameters.Add("@id", MySqlDbType.Int32).Value = incidente.id;

                comando.ExecuteNonQuery();
            }
            catch (Exception erro)
            {
                throw erro;
            }
            finally
            {
                fecharConexao();
            }
        }

        public int retornaUsuario(string usuario)
        {
            string strUser = $"SELECT id FROM usuario WHERE usuario = '{usuario}'";

            MySqlCommand cmdUser = new MySqlCommand(strUser, conexao);
            MySqlDataAdapter Da = new MySqlDataAdapter();
            Da.SelectCommand = cmdUser;
            DataTable Dt = new DataTable();
            Da.Fill(Dt);

            return (int)Dt.Rows[0]["id"];
        }
    }
}
