using CONTROLLER;
using VIEWS.Cliente.Relatorio;
using System;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class FilterClienteView : Form
    {
        public FilterClienteView()
        {
            InitializeComponent();

            // Configuração do DataGridView para preencher as colunas automaticamente.
            dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Cria uma instância do controlador de Cliente.
            ControllerCliente controllerCliente = new ControllerCliente();

            // Recupera todos os clientes do banco de dados.
            var clientes = controllerCliente.Read();
            Dados dados = new Dados();

            if (clientes.Count > 0)
            {
                // Preenche o DataGridView com os dados dos clientes.
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                // Desabilita o DataGridView se não houver clientes.
                dtGrid.Enabled = false;
            }
        }

        // Manipula o evento de filtro quando o botão é clicado.
        private void Filter(object sender, EventArgs e)
        {
            // Cria uma instância do controlador de Cliente.
            ControllerCliente controllerCliente = new ControllerCliente();
            Dados dados = new Dados();
            decimal? cnpj = null;

            if (txtCnpj.Text != string.Empty)
            {
                // Converte o CNPJ informado para decimal.
                cnpj = decimal.Parse(txtCnpj.Text);
            }

            // Chama o método de filtro do controlador e obtém o resultado.
            var retorno = controllerCliente.Filter(cnpj, txtNome.Text);

            if (retorno.Count > 0)
            {
                // Preenche o DataGridView com os dados filtrados dos clientes.
                foreach (var idx in retorno)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }

                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                //Mensagem exibiba quando a pesquisa não encontra clientes registrados com os parâmetros informados
                MessageBox.Show("Não existem clientes registrados com os parâmetros informados", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }   
        }

        // Manipula o evento de leitura quando o botão é clicado.
        private void Read(object sender, EventArgs e)
        {
            // Cria uma instância do controlador de Cliente.
            ControllerCliente controllerCliente = new ControllerCliente();

            // Recupera todos os clientes do banco de dados.
            var clientes = controllerCliente.Read();
            Dados dados = new Dados();

            if (clientes.Count > 0)
            {
                // Preenche o DataGridView com os dados dos clientes.
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                // Desabilita o DataGridView se não houver clientes.
                dtGrid.Enabled = false;
            }
        }
    }

}
