using CONTROLLER;
using System;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class UpdateClienteView : Form
    {
        private MODEL.Cliente cliente;
        public UpdateClienteView(string cnpj, string nome, 
            string telefone, string rua, 
            string numero, string bairro, 
            string cidade, string siglaEs)
        {
            InitializeComponent();

            // Preenche os campos do formulário com os valores recebidos.
            txtCnpj.Text = cnpj;
            txtNome.Text = nome;
            txtTelefone.Text = telefone;
            txtRua.Text = rua;
            txtNumero.Text = numero;
            txtBairro.Text = bairro;
            txtCidade.Text = cidade;
            cbEstado.Text = siglaEs;

            btnAlterar.Click += (sender, e) => Update(cliente);
        }

        private void Update(MODEL.Cliente cliente)
        {
            try
            {
                // Cria uma instância do controlador de Cliente.
                ControllerCliente controllerCliente = new ControllerCliente();

                // Validação do tamanho máximo dos campos antes da atualização.
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
                    MessageBox.Show("Número da residência do cliente excede 7 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtCidade.Text.Length > 35)
                {
                    MessageBox.Show("Cidade do cliente excede 35 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (cbEstado.Text.Length > 2)
                {
                    MessageBox.Show("A sigla do estado só pode ter 2 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // Cria um objeto Cliente com os dados atualizados.
                    cliente = new MODEL.Cliente(decimal.Parse(txtCnpj.Text), txtNome.Text, txtTelefone.Text, txtRua.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, cbEstado.Text);

                    // Chama o método de atualização do controlador e obtém o resultado.
                    var retorno = controllerCliente.Update(cliente, decimal.Parse(txtCnpj.Text));
                    if (retorno == true)
                    {
                        // Exibe uma mensagem de sucesso, limpa os campos do formulário e fecha o formulário.
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
                        // Exibe uma mensagem de erro.
                        MessageBox.Show("Erro na alteração", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem de erro caso ocorra uma exceção.
                MessageBox.Show("Por favor insira os dados", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
