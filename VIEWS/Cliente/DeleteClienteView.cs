using CONTROLLER;
using System;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class DeleteClienteView : Form
    {
        public DeleteClienteView(string cnpj, string nome, string telefone, string rua, string numero, string bairro, string cidade, string siglaEs)
        {
            InitializeComponent();

            // Inicializa os campos do formulário com os valores passados como parâmetros.
            txtCnpj.Text = cnpj;
            txtNome.Text = nome;
            txtTelefone.Text = telefone;
            txtRua.Text = rua;
            txtNumero.Text = numero;
            txtBairro.Text = bairro;
            txtCidade.Text = cidade;
            cbEstado.Text = siglaEs;

            btnDeletar.Click += (sender, e) => Delete(decimal.Parse(txtCnpj.Text));
        }
        private void Delete(decimal cnpj)
        {
            // Cria uma instância do controlador de Cliente.
            ControllerCliente controllerCliente = new ControllerCliente();

            // Exibe um diálogo de confirmação para excluir o registro.
            DialogResult resultado = MessageBox.Show("Deseja mesmo excluir o registro ?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                // Chama o método de exclusão do controlador e obtém o resultado.
                var retorno = controllerCliente.Delete(cnpj);

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
