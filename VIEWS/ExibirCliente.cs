using System;
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

            foreach (var idx in clientes)
            {
                dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
            }

            dtGrid.DataSource = dados.Clientes;
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if (dtGrid.Rows.Count > 1)
            {
                foreach (DataGridViewRow item in dtGrid.Rows)
                {
                    if (!item.IsNewRow) // Verifica se não é uma nova linha vazia
                    {
                        cnpj = item.Cells[0].Value.ToString();
                        nome = item.Cells[1].Value.ToString();
                        telefone = item.Cells[2].Value.ToString();
                        rua = item.Cells[3].Value.ToString();
                        numero = item.Cells[4].Value.ToString();
                        bairro = item.Cells[5].Value.ToString();
                        cidade = item.Cells[6].Value.ToString();
                        siglaEs = item.Cells[7].Value.ToString();
                    }
                }
                frmAlterarCliente _frmAlterarCliente = new frmAlterarCliente(cnpj, nome, telefone, rua, numero, bairro, cidade, siglaEs);
                _frmAlterarCliente.Show();
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

            foreach (var idx in clientes)
            {
                dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
            }

            dtGrid.DataSource = dados.Clientes;
        }
        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if(dtGrid.Rows.Count > 1) { 
                foreach (DataGridViewRow item in dtGrid.Rows)
                {
                    if (!item.IsNewRow) // Verifica se não é uma nova linha vazia
                    {
                        cnpj = item.Cells[0].Value.ToString();
                        nome = item.Cells[1].Value.ToString();
                        telefone = item.Cells[2].Value.ToString();
                        rua = item.Cells[3].Value.ToString();
                        numero = item.Cells[4].Value.ToString();
                        bairro = item.Cells[5].Value.ToString();
                        cidade = item.Cells[6].Value.ToString();
                        siglaEs = item.Cells[7].Value.ToString();
                    }
                }
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
