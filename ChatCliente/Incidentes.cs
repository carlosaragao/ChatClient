using ChatCliente.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatCliente
{
    public partial class Incidentes : Form
    {
        IncidenteDAO incidenteDAO = new IncidenteDAO();
        Incidente incidente = null;
        public string Usuario;

        public Incidentes(string usuario)
        {
            InitializeComponent();
            this.Usuario = usuario;
        }

        public void exibir()
        {
            try
            {
                dataGridView.DataSource = this.incidenteDAO.ExibirDados();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao exibir os dados {erro}");
            }
        }

        public void limpar()
        {
            txtId.Text = "";
            txtDescricao.Text = "";
            dtDataIncidente.Value = DateTime.Now;
            txtSolucao.Text = "";
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            this.exibir();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.incidente = new Incidente();

            incidente.descricao = txtDescricao.Text;
            incidente.dataIncidente = dtDataIncidente.Value;
            incidente.solucao = txtSolucao.Text;

            try
            {
                this.incidenteDAO.salvar(incidente, this.Usuario);
                MessageBox.Show("Incidente salvo com sucesso");
                this.exibir();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao salvar os dados {erro}");
            }
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtId.Text = dataGridView.CurrentRow.Cells[0].Value.ToString();
            txtDescricao.Text = dataGridView.CurrentRow.Cells[1].Value.ToString();
            DateTime data = DateTime.Parse(dataGridView.CurrentRow.Cells[3].Value.ToString());
            dtDataIncidente.Value = DateTime.Parse(data.ToShortDateString());
            txtSolucao.Text = dataGridView.CurrentRow.Cells[4].Value.ToString();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            this.incidente = new Incidente();

            incidente.id = Convert.ToInt32(txtId.Text);
            incidente.descricao = txtDescricao.Text;
            incidente.dataIncidente = dtDataIncidente.Value;
            incidente.solucao = txtSolucao.Text;

            try
            {
                this.incidenteDAO.editar(incidente, this.Usuario);
                MessageBox.Show("Incidente alterado com sucesso");
                this.exibir();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao alterar os dados {erro}");
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            this.incidente = new Incidente();

            incidente.id = Convert.ToInt32(txtId.Text);

            try
            {
                this.incidenteDAO.excluir(incidente);
                MessageBox.Show("Incidente excluido com sucesso");
                this.exibir();
                this.limpar();
            }
            catch (Exception erro)
            {
                MessageBox.Show($"Erro ao excluir os dados {erro}");
            }
        }
    }
}
