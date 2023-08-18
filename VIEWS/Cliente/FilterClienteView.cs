using CONTROLLER;
using VIEWS.Cliente.Relatorio;
using System.Windows.Forms;
using System;

namespace VIEWS
{
    // Classe FilterClienteView: Formulário para filtragem de registros de clientes.
    public partial class FilterClienteView : Form
    {
        // Construtor da classe
        public FilterClienteView()
        {
            // Inicializa o formulário e associa eventos aos controles.

            // Inicializa os componentes do formulário.
            InitializeComponent();

            // Configura o DataGridView para preencher as colunas automaticamente.
            dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Associa eventos aos controles.
            Load += (sender, e) => { Read(); dtGrid.Focus(); chkFiltros.SetItemChecked(1, true); chkFiltros.SetItemChecked(0, true); }; // Carrega todos os clientes
            btnAtualizar.Click += (sender, e) => { Read(); dtGrid.Focus(); }; // Atualiza a exibição dos clientes
            btnPesquisar.Click += (sender, e) => { Filter(); dtGrid.Focus(); }; // Realiza a filtragem dos clientes
            chkFiltros.SelectedIndexChanged += (sender, e) => { Filtros(); dtGrid.Focus(); };
            chkFiltros.DoubleClick += (sender, e) => { Filtros(); dtGrid.Focus(); };
            chkFiltros.Click += (sender, e) => { Filtros(); dtGrid.Focus(); };
        }

        // Função para realizar a filtragem dos clientes com base nos parâmetros informados
        private void Filter()
        {
            try
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
                        dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetDadosAPI().telefone, idx.GetDadosAPI().logradouro, idx.GetDadosAPI().numero, idx.GetDadosAPI().bairro, idx.GetDadosAPI().municipio, idx.GetDadosAPI().uf);
                    }

                    dtGrid.DataSource = dados.Clientes;
                }
                else
                {
                    // Exibe mensagem quando a pesquisa não encontra clientes registrados com os parâmetros informados.
                    MessageBox.Show("Não existem clientes registrados com os parâmetros informados", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                // Exibe mensagem em caso de exceção.
                MessageBox.Show("Ocorreu um erro ao filtrar os clientes", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Função para exibir todos os clientes
        private void Read()
        {
            try
            {
                // Cria uma instância do controlador de Cliente.
                ControllerCliente controllerCliente = new ControllerCliente();
                Dados dados = new Dados();

                // Recupera todos os clientes do banco de dados.
                var clientes = controllerCliente.Read();

                if (clientes.Count > 0)
                {
                    // Preenche o DataGridView com os dados dos clientes.
                    foreach (var idx in clientes)
                    {
                        dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetDadosAPI().telefone, idx.GetDadosAPI().logradouro, idx.GetDadosAPI().numero, idx.GetDadosAPI().bairro, idx.GetDadosAPI().municipio, idx.GetDadosAPI().uf);
                    }
                    dtGrid.DataSource = dados.Clientes;
                    dtGrid.Columns["Endereco"].Visible = false;
                    dtGrid.Columns["Numero"].Visible = false;
                    dtGrid.Columns["Cidade"].Visible = false;
                    dtGrid.Columns["Telefone"].Visible = false;
                    dtGrid.Columns["Bairro"].Visible = false;
                    dtGrid.Columns["Estado"].Visible = false;
                }
                else
                {
                    // Desabilita o DataGridView se não houver clientes.
                    dtGrid.Enabled = false;
                }
            }
            catch (Exception)
            {
                // Exibe mensagem em caso de exceção.
                MessageBox.Show("Ocorreu um erro ao carregar os clientes", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Função para exibir/ocultar colunas do DataGridView com base na seleção dos filtros
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
