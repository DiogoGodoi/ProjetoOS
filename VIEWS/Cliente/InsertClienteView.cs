using CONTROLLER;
using System;
using System.Windows.Forms;
using MODEL;

namespace VIEWS
{
    // Classe InsertClienteView: Formulário para inserção de novos registros de clientes.
    public partial class InsertClienteView : Form
    {
        // Construtor da classe
        public InsertClienteView()
        {
            // Inicializa o formulário e associa eventos aos controles.

            // Inicializa os componentes do formulário.
            InitializeComponent();

            // Associa o evento de carregamento do formulário à função que define o foco no campo CNPJ.
            Load += (sender, e) => { txtCnpj.Focus(); };
            // Associa o evento de clique do botão 'Inserir' à função Insert.
            btnInserir.Click += (sender, e) => Insert();
            // Associa o evento de clique do botão 'Cnpj' à função BuscaCnpjApi.
            btnCnpj.Click += (sender, e) => BuscaCnpjApi(txtCnpj.Text);
        }

        // Função para realizar a inserção de um novo cliente
        private void Insert()
        {
            try
            {
                // Cria uma instância do controlador de Cliente.
                ControllerCliente controllerCliente = new ControllerCliente();

                // Realiza validações nos campos de entrada antes da inserção.
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
                    // Cria um objeto Cliente com os dados inseridos no formulário.
                    ClientePJ cliente = new ClientePJ(decimal.Parse(txtCnpj.Text), txtNome.Text, txtTelefone.Text, txtRua.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, cbEstado.Text);
         
                    // Chama o método de inserção do controlador e obtém o resultado.
                    var retorno = controllerCliente.Insert(cliente);

                    if (retorno == true)
                    {
                        // Exibe uma mensagem de sucesso, limpa os campos do formulário e define o foco no campo CNPJ.
                        MessageBox.Show("Cadastrado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCnpj.Text = string.Empty;
                        txtNome.Text = string.Empty;
                        txtTelefone.Text = string.Empty;
                        txtRua.Text = string.Empty;
                        txtNumero.Text = string.Empty;
                        txtBairro.Text = string.Empty;
                        txtCidade.Text = string.Empty;
                        cbEstado.Text = string.Empty;
                        txtCnpj.Focus();
                    }
                    else
                    {
                        // Exibe uma mensagem de erro em caso de falha na inserção.
                        MessageBox.Show("Erro no cadastro", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception)
            {
                // Exibe uma mensagem em caso de exceção.
                MessageBox.Show("Por favor insira os dados", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Função para buscar dados de cliente via API a partir do CNPJ
        private async void BuscaCnpjApi(string cnpj)
        {
            // Cria uma instância do controlador de Cliente.
            ControllerApiReceita controllerApiReceita = new ControllerApiReceita();
            // Realiza a chamada assíncrona à API para buscar dados de cliente.
            var retorno = await controllerApiReceita.ApiReceita(cnpj);

            if (retorno != null)
            {
                // Preenche os campos do formulário com os dados retornados da API.
                txtNome.Text = retorno.nome;
                txtTelefone.Text = retorno.telefone;
                txtRua.Text = retorno.logradouro;
                txtNumero.Text = retorno.numero;
                txtBairro.Text = retorno.bairro;
                txtCidade.Text = retorno.municipio;
                cbEstado.Text = retorno.uf;
            }
            else
            {
                // Exibe mensagem caso a empresa não seja localizada.
                MessageBox.Show("Empresa não localizada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

}
