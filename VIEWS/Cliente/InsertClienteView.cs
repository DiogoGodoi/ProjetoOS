using CONTROLLER;
using System;
using System.Windows.Forms;
using MODEL;
using API_EXTERNAS;
using System.Drawing;

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
            Load += (sender, e) => { cbTipo.Focus(); };
            // Associa o evento de clique do botão 'Inserir' à função Insert.
            btnInserir.Click += (sender, e) => Insert();
            // Associa o evento de clique do botão 'Cnpj' à função BuscaCnpjApi.
            btnCnpj.Click += (sender, e) => BuscaCnpjApi(mskIdentificador.Text);
            cbTipo.SelectedIndexChanged += (sender, e) => SelectTipo();
            toolTipCnpj.ToolTipTitle = "Busca por CNPJ";
            toolTipCnpj.ToolTipIcon = ToolTipIcon.Info;
            toolTipCnpj.SetToolTip(btnCnpj, "Pesquise a empresa pelo cnpj");
        }

        // Função para realizar a inserção de um novo cliente
        public void Insert()
        {
            try
            {
                // Cria uma instância do controlador de Cliente.
                ControllerCliente controllerCliente = new ControllerCliente();
                // Cria um objeto Cliente com os dados inseridos no formulário.
                ClientePJ cliente = new ClientePJ();

                bool validarCnpj = cliente.SetCnpj(mskIdentificador.Text);
                bool validarNome = cliente.SetNome(txtNome.Text);
                bool validarLogradouro = cliente.SetLogradouro(txtRua.Text);
                bool validarTelefone = cliente.SetTelefone(txtTelefone.Text);
                bool validarNumero = cliente.SetNumero(txtNumero.Text);
                bool validarBairro = cliente.SetBairro(txtBairro.Text);
                bool validarMunicipio = cliente.SetMunicipio(txtCidade.Text);
                bool validarUF = cliente.SetUf(cbEstado.Text);

                // Realiza validações nos campos de entrada antes da inserção.
                if (validarCnpj == false)
                {
                    MessageBox.Show("Cnpj do cliente excede 14 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarNome == false)
                {
                    MessageBox.Show("Nome do cliente deve ter no minimo 6 e no maximo 45 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarTelefone == false)
                {
                    MessageBox.Show("Nome do cliente deve ter no minimo 10 e no maximo 18 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarLogradouro == false)
                {
                    MessageBox.Show("Nome do cliente deve ter no minimo 5 e no maximo 45 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (validarNumero == false)
                {
                    MessageBox.Show("Número da residência do cliente excede 7 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }else if(validarBairro == false)
                {
                    MessageBox.Show("Nome do cliente deve ter no minimo 5 e no maximo 45 caracteres", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    // Chama o método de inserção do controlador e obtém o resultado.
                    var retorno = controllerCliente.Insert(cliente);

                    if (retorno == true)
                    {
                        // Exibe uma mensagem de sucesso, limpa os campos do formulário e define o foco no campo CNPJ.
                        MessageBox.Show("Cadastrado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        mskIdentificador.Text = string.Empty;
                        txtNome.Text = string.Empty;
                        txtTelefone.Text = string.Empty;
                        txtRua.Text = string.Empty;
                        txtNumero.Text = string.Empty;
                        txtBairro.Text = string.Empty;
                        txtCidade.Text = string.Empty;
                        cbEstado.Text = string.Empty;
                        mskIdentificador.Focus();
                    }
                    else
                    {
                        // Exibe uma mensagem de erro em caso de falha na inserção.
                        MessageBox.Show("Erro no cadastro", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                // Exibe uma mensagem em caso de exceção.
                MessageBox.Show("Por favor insira os dados= " + ex.Message, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void SelectTipo()
        {
            if (cbTipo.SelectedIndex == 1)
            {
                btnCnpj.Text = "Cpf";
                btnCnpj.Enabled = false;
                btnCnpj.BackColor = Color.White;
                mskIdentificador.Mask = "999.999.999-99";
            }
            else if(cbTipo.SelectedIndex == 0)
            {
                btnCnpj.Text = "Cnpj";
                btnCnpj.Enabled = true;
                btnCnpj.BackColor = Color.FromArgb(0, 0, 64);
                mskIdentificador.Mask = "999.999.999/9999-99";
            }
        }
    }

}
