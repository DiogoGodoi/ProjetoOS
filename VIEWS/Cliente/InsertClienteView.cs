using CONTROLLER;
using MODEL;
using System;
using System.Windows.Forms;

namespace VIEWS
{
    // Classe que representa a interface de usuário para inserção de um novo cliente
    public partial class InsertClienteView : Form
    {
        // Construtor da classe
        public InsertClienteView()
        {
            InitializeComponent();

            // Associação do evento de clique do botão 'Inserir' à função Insert
            Load += (sender, e) => { txtCnpj.Focus(); };
            btnInserir.Click += (sender, e) => Insert();
        }

        // Função para realizar a inserção de um novo cliente
        private void Insert()
        {
            try
            {
                // Cria uma instância do controlador de Cliente.
                ControllerCliente controllerCliente = new ControllerCliente();

                // Validação do tamanho máximo dos campos antes da inserção.
                if (txtCnpj.Text.Length > 15)
                {
                    MessageBox.Show("Cnpj do cliente excede 15 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (txtNome.Text.Length > 45)
                {
                    MessageBox.Show("Nome do cliente excede 45 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (maskedTextBox1.Text.Length > 18)
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
                    // Cria um objeto Cliente com os dados inseridos no formulário.
                    MODEL.Cliente cliente = new MODEL.Cliente(decimal.Parse(txtCnpj.Text), txtNome.Text, maskedTextBox1.Text, txtRua.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, cbEstado.Text);

                    // Chama o método de inserção do controlador e obtém o resultado.
                    var retorno = controllerCliente.Insert(cliente);

                    if (retorno == true)
                    {
                        // Exibe uma mensagem de sucesso, limpa os campos do formulário e define o foco no campo CNPJ.
                        MessageBox.Show("Cadastrado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCnpj.Text = string.Empty;
                        txtNome.Text = string.Empty;
                        maskedTextBox1.Text = string.Empty;
                        txtRua.Text = string.Empty;
                        txtNumero.Text = string.Empty;
                        txtBairro.Text = string.Empty;
                        txtCidade.Text = string.Empty;
                        cbEstado.Text = string.Empty;
                        txtCnpj.Focus();
                    }
                    else
                    {
                        // Exibe uma mensagem de erro.
                        MessageBox.Show("Erro no cadastro", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
