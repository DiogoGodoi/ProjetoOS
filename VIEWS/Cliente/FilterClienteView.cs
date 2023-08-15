using CONTROLLER;
using VIEWS.Cliente.Relatorio;
using System.Windows.Forms;

namespace VIEWS
{
    // Classe que representa a interface de usuário para filtrar e exibir clientes
    public partial class FilterClienteView : Form
    {
        // Construtor da classe
        public FilterClienteView()
        {
            InitializeComponent();

            // Configuração do DataGridView para preencher as colunas automaticamente.
            dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Associações de eventos para carregar e filtrar os dados de clientes
            Load += (sender, e) => { Read(); dtGrid.Focus(); }; // Carrega todos os clientes
            btnAtualizar.Click += (sender, e) => { Read(); dtGrid.Focus(); }; // Atualiza a exibição dos clientes
            btnPesquisar.Click += (sender, e) => { Filter(); dtGrid.Focus(); }; // Realiza a filtragem dos clientes
            chkFiltros.SelectedIndexChanged += (sender, e) => { Filtros(); dtGrid.Focus(); };
            chkFiltros.DoubleClick += (sender, e) => { Filtros(); dtGrid.Focus(); };
            chkFiltros.Click += (sender, e) => { Filtros(); dtGrid.Focus(); };
        }

        // Função para realizar a filtragem dos clientes com base nos parâmetros informados
        private void Filter()
        {
            // Cria uma instância do controlador de Cliente.
            ControllerCliente controllerCliente = new ControllerCliente();
            Dados dados = new Dados();

            decimal? cnpj = null;

            // Verifica se um CNPJ foi informado para filtragem
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
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetEndereco().telefone, idx.GetEndereco().logradouro, idx.GetEndereco().numero, idx.GetEndereco().bairro, idx.GetEndereco().municipio, idx.GetEndereco().uf);
                }

                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                // Mensagem exibida quando a pesquisa não encontra clientes registrados com os parâmetros informados
                MessageBox.Show("Não existem clientes registrados com os parâmetros informados", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Função para exibir todos os clientes
        private void Read()
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
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetEndereco().telefone, idx.GetEndereco().logradouro, idx.GetEndereco().numero, idx.GetEndereco().bairro, idx.GetEndereco().municipio, idx.GetEndereco().uf);
                }
                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                // Desabilita o DataGridView se não houver clientes.
                dtGrid.Enabled = false;
            }
        }

        private void Filtros()
        {
            // Percorre os itens do CheckBoxList
            for (int i = 0; i < chkFiltros.Items.Count; i++)
            {
                if (chkFiltros.GetItemChecked(i))
                {
                    string itemValue = chkFiltros.Items[i].ToString();
                    dtGrid.Columns[$"{itemValue}"].Visible = true;
                }
                else if (!chkFiltros.GetItemChecked(i))
                {
                    string itemValue = chkFiltros.Items[i].ToString();
                    dtGrid.Columns[$"{itemValue}"].Visible = false;
                }
            }
        }
    }
}
