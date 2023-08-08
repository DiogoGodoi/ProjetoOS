using CONTROLLER;
using System;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class UpdateClienteView : Form
    {
        public UpdateClienteView(string cnpj, string nome, string telefone, string rua, string numero, string bairro, string cidade, string siglaEs)
        {
            InitializeComponent();

            txtCnpj.Text = cnpj;
            txtNome.Text = nome;
            txtTelefone.Text = telefone;
            txtRua.Text = rua;
            txtNumero.Text = numero;
            txtBairro.Text = bairro;
            txtCidade.Text = cidade;
            cbEstado.Text = siglaEs;
        }
        private void Update(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            if (txtCnpj.Text.Length > 15)
            {
                MessageBox.Show("Cnpj do cliente excede 15 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNome.Text.Length > 45)
            {
                MessageBox.Show("Nome do cliente excede 45 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtTelefone.Text.Length > 18)
            {
                MessageBox.Show("Telefone do cliente excede 18 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtRua.Text.Length > 45)
            {
                MessageBox.Show("Rua do cliente excede 45 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtNumero.Text.Length > 7)
            {
                MessageBox.Show("Nímero da residencia do cliente excede 7 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (txtCidade.Text.Length > 35)
            {
                MessageBox.Show("Cidade do cliente excede 35 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (cbEstado.Text.Length > 2)
            {
                MessageBox.Show("A sigla do estado só pode ter 2 caracteres do cliente excede 35 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MODEL.Cliente cliente = new MODEL.Cliente(decimal.Parse(txtCnpj.Text), txtNome.Text, txtTelefone.Text, txtRua.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, cbEstado.Text);
                var retorno = controllerCliente.Update(cliente, decimal.Parse(txtCnpj.Text));
                if (retorno == true)
                {
                    MessageBox.Show("Alterado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCnpj.Text = string.Empty;
                    txtNome.Text = string.Empty;
                    txtTelefone.Text = string.Empty;
                    txtRua.Text = string.Empty;
                    txtNumero.Text = string.Empty;
                    txtBairro.Text = string.Empty;
                    txtCidade.Text = string.Empty;
                    cbEstado.Text = string.Empty;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro na alteracao", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
