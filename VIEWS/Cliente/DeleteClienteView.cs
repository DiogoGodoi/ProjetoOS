using CONTROLLER;
using System.Windows.Forms;

namespace VIEWS
{
    // Classe que representa a interface de usuário para exclusão de um cliente
    public partial class DeleteClienteView : Form
    {
        // Construtor da classe, recebe um objeto 'cliente' para preencher os campos do formulário
        public DeleteClienteView(MODEL.Cliente cliente)
        {
            InitializeComponent();

            // Inicializa os campos do formulário com os valores passados como parâmetros.
            txtCnpj.Text = cliente.GetCnpj().ToString(); // Define o CNPJ
            txtNome.Text = cliente.GetNome(); // Define o nome
            txtTelefone.Text = cliente.GetEndereco().telefone; // Define o telefone
            txtRua.Text = cliente.GetEndereco().logradouro; // Define a rua
            txtNumero.Text = cliente.GetEndereco().numero; // Define o número
            txtBairro.Text = cliente.GetEndereco().bairro; // Define o bairro
            txtCidade.Text = cliente.GetEndereco().municipio; // Define a cidade
            cbEstado.Text = cliente.GetEndereco().uf; // Define a sigla do estado

            // Associa o evento de clique do botão 'Deletar' à função Delete
            btnDeletar.Click += (sender, e) => Delete();

            this.MaximizeBox = false;
        }

        // Função para realizar a exclusão do cliente
        private void Delete()
        {
            // Cria uma instância do controlador de Cliente.
            ControllerCliente controllerCliente = new ControllerCliente();

            // Exibe um diálogo de confirmação para excluir o registro.
            DialogResult resultado = MessageBox.Show("Deseja mesmo excluir o registro ?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Chama o método de exclusão do controlador e obtém o resultado.
                var retorno = controllerCliente.Delete(decimal.Parse(txtCnpj.Text));

                if (retorno == true)
                {
                    // Exibe uma mensagem de sucesso e fecha o formulário.
                    MessageBox.Show("Deletado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    // Exibe uma mensagem de erro e fecha o formulário.
                    MessageBox.Show("Erro na exclusão", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                // Exibe uma mensagem de cancelamento e fecha o formulário.
                MessageBox.Show("Operação cancelada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
