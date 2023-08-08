using System;
using System.Data;
using System.Windows.Forms;
using CONTROLLER;

namespace VIEWS
{
    public partial class frmExibirCliente : Form
    {
        private string cnpj { get; set; }
        private string nome { get; set; }
        private string telefone { get; set; }
        private string rua { get; set; }
        private string numero { get; set; }
        private string bairro { get; set; }
        private string cidade { get; set; }
        private string siglaEs { get; set; }
        public frmExibirCliente()
        {
            InitializeComponent();
            dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ExibirCliente_Load(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Read();
            Dados dados = new Dados();

            if(clientes.Count > 0)
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
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dtGrid.Rows.Count > 1)
            {   
                DataGridViewRow linhaSelecionada = dtGrid.Rows[dtGrid.SelectedCells[0].RowIndex];
                cnpj = linhaSelecionada.Cells[0].Value.ToString();
                nome = linhaSelecionada.Cells[1].Value.ToString();
                telefone = linhaSelecionada.Cells[2].Value.ToString();
                rua = linhaSelecionada.Cells[3].Value.ToString();
                numero = linhaSelecionada.Cells[4].Value.ToString();
                bairro = linhaSelecionada.Cells[5].Value.ToString();
                cidade = linhaSelecionada.Cells[6].Value.ToString();
                siglaEs = linhaSelecionada.Cells[7].Value.ToString();
                        
                frmAlterarCliente _frmAlterarCliente = new frmAlterarCliente(cnpj, nome, telefone, rua, numero, bairro, cidade, siglaEs);
                _frmAlterarCliente.ShowDialog();
                }
            else
            {
                MessageBox.Show("Sem registros para alterar", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnAtualizar_Click(object sender, EventArgs e)
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
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if(dtGrid.Rows.Count > 1) {

                DataGridViewRow linhaSelecionada = dtGrid.Rows[dtGrid.SelectedCells[0].RowIndex];
                cnpj = linhaSelecionada.Cells[0].Value.ToString();
                nome = linhaSelecionada.Cells[1].Value.ToString();
                telefone = linhaSelecionada.Cells[2].Value.ToString();
                rua = linhaSelecionada.Cells[3].Value.ToString();
                numero = linhaSelecionada.Cells[4].Value.ToString();
                bairro = linhaSelecionada.Cells[5].Value.ToString();
                cidade = linhaSelecionada.Cells[6].Value.ToString();
                siglaEs = linhaSelecionada.Cells[7].Value.ToString();
      
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
