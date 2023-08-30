using CONTROLLER;
using MODEL;
using System;
using System.Windows.Forms;

namespace VIEWS
{
    // Classe que representa a interface de usuário para atualização de dados de clientes
    public partial class UpdateClienteView : Form
    {
        // Construtor da classe que recebe um objeto Cliente para preencher os campos
        public UpdateClienteView(MODEL.ClientePJ cliente)
        {
            InitializeComponent();

            // Preenche os campos do formulário com os valores recebidos.
            txtCnpj.Text = cliente.GetCnpj().ToString();
            txtNome.Text = cliente.GetNome();
            txtTelefone.Text = cliente.GetDadosAPI().telefone;
            txtRua.Text = cliente.GetDadosAPI().logradouro;
            txtNumero.Text = cliente.GetDadosAPI().numero;
            txtBairro.Text = cliente.GetDadosAPI().bairro;
            txtCidade.Text = cliente.GetDadosAPI().municipio;
            cbEstado.Text = cliente.GetDadosAPI().uf;

            txtNome.Focus();

            // Associação de evento para realizar a atualização dos dados
            btnAlterar.Click += (sender, e) => Update();
            this.MaximizeBox = false;
        }

        // Função para realizar a atualização dos dados do cliente
        private void Update()
        {
            try
            {
                // Cria uma instância do controlador de Cliente.
                ControllerCliente controllerCliente = new ControllerCliente();
                // Cria um objeto Cliente com os dados inseridos no formulário.
                ClientePJ cliente = new ClientePJ();

                bool validarNome = cliente.SetNome(txtNome.Text);
                bool validarLogradouro = cliente.SetLogradouro(txtRua.Text);
                bool validarTelefone = cliente.SetTelefone(txtTelefone.Text);
                bool validarNumero = cliente.SetNumero(txtNumero.Text);
                bool validarBairro = cliente.SetBairro(txtBairro.Text);
                bool validarMunicipio = cliente.SetMunicipio(txtCidade.Text);
                bool validarUF = cliente.SetUf(cbEstado.Text);

                // Realiza validações nos campos de entrada antes da inserção.
                if (validarNome == false)
                {
                    MessageBox.Show("Nome do cliente excede 45 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarTelefone == false)
                {
                    MessageBox.Show("Telefone do cliente excede 18 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarLogradouro == false)
                {
                    MessageBox.Show("Rua do cliente excede 45 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarNumero == false)
                {
                    MessageBox.Show("Número da residência do cliente excede 7 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarBairro == false)
                {
                    MessageBox.Show("Bairro do cliente excede 45 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarMunicipio == false)
                {
                    MessageBox.Show("Cidade do cliente excede 35 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarUF == false)
                {
                    MessageBox.Show("A sigla do estado só pode ter 2 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
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
