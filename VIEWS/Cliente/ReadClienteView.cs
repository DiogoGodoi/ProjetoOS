using System.Data;
using System.Windows.Forms;
using CONTROLLER;
using VIEWS.Cliente.Relatorio;

namespace VIEWS
{
    // Classe que representa a interface de usuário para visualização e manipulação de dados de clientes
    public partial class ReadClienteView : Form
    {
        // Construtor da classe
        public ReadClienteView()
        {
            InitializeComponent();

            // Configuração do DataGridView para preencher as colunas automaticamente.
            dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Associação de eventos para carregar, atualizar, alterar e deletar registros de clientes
            Load += (sender, e) => { Read(); dtGrid.Focus(); chkFiltros.SetItemChecked(1, true); chkFiltros.SetItemChecked(0, true); }; // Carrega todos os clientes
            btnAlterar.Click += (sender, e) => OpenUpdateClientView(); // Abre a tela de alteração do cliente
            btnDeletar.Click += (sender, e) => OpenDeleteClientView(); // Abre a tela de exclusão do cliente
            chkFiltros.DoubleClick += (sender, e) => { Filtros(); dtGrid.Focus(); };
            chkFiltros.Click += (sender, e) => { Filtros(); dtGrid.Focus(); };
        }

        // Função para abrir a tela de alteração do cliente
        private void OpenUpdateClientView()
        {
            if (dtGrid.Rows.Count > 1)
            {
                // Obtém os valores da linha selecionada no DataGridView.
                DataGridViewRow linhaSelecionada = dtGrid.Rows[dtGrid.SelectedCells[0].RowIndex];
                var cnpj = linhaSelecionada.Cells[0].Value.ToString();
                var nome = linhaSelecionada.Cells[1].Value.ToString();
                var telefone = linhaSelecionada.Cells[2].Value.ToString();
                var rua = linhaSelecionada.Cells[3].Value.ToString();
                var numero = linhaSelecionada.Cells[4].Value.ToString();
                var bairro = linhaSelecionada.Cells[5].Value.ToString();
                var cidade = linhaSelecionada.Cells[6].Value.ToString();
                var siglaEs = linhaSelecionada.Cells[7].Value.ToString();

                // Cria e exibe o formulário de atualização com os dados do cliente.
                MODEL.ClientePJ cliente = new MODEL.ClientePJ(decimal.Parse(cnpj), nome, telefone, rua, numero, bairro, cidade, siglaEs);
                UpdateClienteView _frmAlterarCliente = new UpdateClienteView(cliente);
                _frmAlterarCliente.Show();
                _frmAlterarCliente.txtNome.Focus();
                _frmAlterarCliente.FormClosed += (sender, e) => { Read(); dtGrid.Focus(); };
                
            }
            else
            {
                MessageBox.Show("Sem registros para alterar", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Função para abrir a tela de exclusão do cliente
        private void OpenDeleteClientView()
        {
            if (dtGrid.Rows.Count > 1)
            {
                // Obtém os valores da linha selecionada no DataGridView.
                DataGridViewRow linhaSelecionada = dtGrid.Rows[dtGrid.SelectedCells[0].RowIndex];
                var cnpj = linhaSelecionada.Cells[0].Value.ToString();
                var nome = linhaSelecionada.Cells[1].Value.ToString();
                var telefone = linhaSelecionada.Cells[2].Value.ToString();
                var rua = linhaSelecionada.Cells[3].Value.ToString();
                var numero = linhaSelecionada.Cells[4].Value.ToString();
                var bairro = linhaSelecionada.Cells[5].Value.ToString();
                var cidade = linhaSelecionada.Cells[6].Value.ToString();
                var siglaEs = linhaSelecionada.Cells[7].Value.ToString();

                // Cria e exibe o formulário de exclusão com os dados do cliente.
                MODEL.ClientePJ cliente = new MODEL.ClientePJ(decimal.Parse(cnpj), nome, telefone, rua, numero, bairro, cidade, siglaEs);
                DeleteClienteView _frmAlterarCliente = new DeleteClienteView(cliente);
                _frmAlterarCliente.Show();
                _frmAlterarCliente.FormClosed += (sender, e) => { Read(); dtGrid.Focus(); };
            }
            else
            {
                MessageBox.Show("Sem registros para excluir", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dtGrid.Columns["Endereco"].Visible = false;
                dtGrid.Columns["Numero"].Visible = false;
                dtGrid.Columns["Cidade"].Visible = false;
                dtGrid.Columns["Telefone"].Visible = false;
                dtGrid.Columns["Bairro"].Visible = false;
                dtGrid.Columns["Estado"].Visible = false;
            }
            else
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("Clientes", typeof(string));
                tb.Rows.Add("Sem dados");
                dtGrid.DataSource = tb;
                dtGrid.Enabled = false;
            }
        }

        // Função para aplicar filtros de exibição nos dados do DataGridView
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
