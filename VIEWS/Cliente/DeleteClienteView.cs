using CONTROLLER;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class DeleteClienteView : Form
    {
        public DeleteClienteView(MODEL.Cliente cliente)
        {
            InitializeComponent();

            // Inicializa os campos do formulário com os valores passados como parâmetros.
            txtCnpj.Text = cliente.GetCnpj().ToString();
            txtNome.Text = cliente.GetNome();
            txtTelefone.Text = cliente.GetTelefone();
            txtRua.Text = cliente.GetRua();
            txtNumero.Text = cliente.GetNumero();
            txtBairro.Text = cliente.GetBairro();
            txtCidade.Text = cliente.GetCidade();
            cbEstado.Text = cliente.GetSiglaEs();


            btnDeletar.Click += (sender, e) => Delete();
        }
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
