using System;
using System.Windows.Forms;
using CONTROLLER;
using VIEWS.Cliente.Relatorio;

namespace VIEWS
{
    public partial class ReadClienteView : Form
    {
        public ReadClienteView()
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

        // Manipula o evento de atualização quando o botão é clicado.
        private void Update(object sender, EventArgs e)
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
                UpdateClienteView _frmAlterarCliente = new UpdateClienteView(cnpj, nome, telefone, rua, numero, bairro, cidade, siglaEs);
                _frmAlterarCliente.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sem registros para alterar", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        // Manipula o evento de exclusão quando o botão é clicado.
        private void Delete(object sender, EventArgs e)
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
                DeleteClienteView _frmAlterarCliente = new DeleteClienteView(cnpj, nome, telefone, rua, numero, bairro, cidade, siglaEs);
                _frmAlterarCliente.Show();
            }
            else
            {
                MessageBox.Show("Sem registros para excluir", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
