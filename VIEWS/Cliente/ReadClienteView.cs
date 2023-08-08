using System;
using System.Windows.Forms;
using CONTROLLER;
using VIEWS.Cliente.Relatorio;

namespace VIEWS
{
    public partial class frmExibirCliente : Form
    {
        public frmExibirCliente()
        {
            InitializeComponent();

            dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Read();
            Dados dados = new Dados();

            if (clientes.Count > 0)
            {
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                dtGrid.Enabled = false;
            }
        }
        private void Update(object sender, EventArgs e)
        {
            if (dtGrid.Rows.Count > 1)
            {   
                DataGridViewRow linhaSelecionada = dtGrid.Rows[dtGrid.SelectedCells[0].RowIndex];
                var cnpj = linhaSelecionada.Cells[0].Value.ToString();
                var nome = linhaSelecionada.Cells[1].Value.ToString();
                var telefone = linhaSelecionada.Cells[2].Value.ToString();
                var rua = linhaSelecionada.Cells[3].Value.ToString();
                var numero = linhaSelecionada.Cells[4].Value.ToString();
                var bairro = linhaSelecionada.Cells[5].Value.ToString();
                var cidade = linhaSelecionada.Cells[6].Value.ToString();
                var siglaEs = linhaSelecionada.Cells[7].Value.ToString();
                        
                frmAlterarCliente _frmAlterarCliente = new frmAlterarCliente(cnpj, nome, telefone, rua, numero, bairro, cidade, siglaEs);
                _frmAlterarCliente.ShowDialog();
                }
            else
            {
                MessageBox.Show("Sem registros para alterar", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Read(object sender, EventArgs e)
        {

            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Read();
            Dados dados = new Dados();

            if (clientes.Count > 0)
            {
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                dtGrid.Enabled = false;
            }
        }
        private void Delete(object sender, EventArgs e)
        {
            if(dtGrid.Rows.Count > 1) {

                DataGridViewRow linhaSelecionada = dtGrid.Rows[dtGrid.SelectedCells[0].RowIndex];
                var cnpj = linhaSelecionada.Cells[0].Value.ToString();
                var nome = linhaSelecionada.Cells[1].Value.ToString();
                var telefone = linhaSelecionada.Cells[2].Value.ToString();
                var rua = linhaSelecionada.Cells[3].Value.ToString();
                var numero = linhaSelecionada.Cells[4].Value.ToString();
                var bairro = linhaSelecionada.Cells[5].Value.ToString();
                var cidade = linhaSelecionada.Cells[6].Value.ToString();
                var siglaEs = linhaSelecionada.Cells[7].Value.ToString();
      
                frmViewDeletarCliente _frmAlterarCliente = new frmViewDeletarCliente(cnpj, nome, telefone, rua, numero, bairro, cidade, siglaEs);
                _frmAlterarCliente.Show();
            }
            else
            {
                MessageBox.Show("Sem registros para excluir", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
