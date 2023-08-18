using CONTROLLER;
using System;
using System.Windows.Forms;

namespace VIEWS
{
    // Classe DeleteClienteView: Formulário para exclusão de um registro de cliente.
    public partial class DeleteClienteView : Form
    {
        // Construtor da classe, recebe um objeto 'cliente' para preencher os campos do formulário
        public DeleteClienteView(MODEL.ClientePJ cliente)
        {
            // Inicializa o formulário e associa eventos aos controles.

            // Inicializa os componentes do formulário.
            InitializeComponent();

            // Preenche os campos do formulário com os valores do objeto cliente.
            txtCnpj.Text = cliente.GetCnpj().ToString(); // Define o CNPJ
            txtNome.Text = cliente.GetNome(); // Define o nome
            txtTelefone.Text = cliente.GetDadosAPI().telefone; // Define o telefone
            txtRua.Text = cliente.GetDadosAPI().logradouro; // Define a rua
            txtNumero.Text = cliente.GetDadosAPI().numero; // Define o número
            txtBairro.Text = cliente.GetDadosAPI().bairro; // Define o bairro
            txtCidade.Text = cliente.GetDadosAPI().municipio; // Define a cidade
            cbEstado.Text = cliente.GetDadosAPI().uf; // Define a sigla do estado

            // Associa o evento de clique do botão 'Deletar' à função Delete
            btnDeletar.Click += (sender, e) => Delete();

            // Desabilita o botão de maximizar no canto superior direito do formulário.
            this.MaximizeBox = false;
        }

        // Função para realizar a exclusão do cliente
        private void Delete()
        {
            try
            {
                // Cria uma instância do controlador de Cliente.
                ControllerCliente controllerCliente = new ControllerCliente();

                // Exibe um diálogo de confirmação para excluir o registro.
                DialogResult resultado = MessageBox.Show("Deseja mesmo excluir o registro?", "Confirmação de Exclusão", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.Yes)
                {
                    // Chama o método de exclusão do controlador e obtém o resultado.
                    var retorno = controllerCliente.Delete(decimal.Parse(txtCnpj.Text));

                    if (retorno == true)
                    {
                        // Exibe uma mensagem de sucesso e fecha o formulário.
                        MessageBox.Show("Registro deletado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        // Exibe uma mensagem de erro e fecha o formulário.
                        MessageBox.Show("Erro na exclusão do registro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                }
                else
                {
                    // Exibe uma mensagem de cancelamento e fecha o formulário.
                    MessageBox.Show("Operação de exclusão cancelada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception)
            {
                // Exibe mensagem em caso de exceção.
                MessageBox.Show("Ocorreu um erro ao tentar excluir o registro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
