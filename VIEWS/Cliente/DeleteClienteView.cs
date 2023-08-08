using CONTROLLER;
using System;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class frmViewDeletarCliente : Form
    {
        public frmViewDeletarCliente(string cnpj, string nome, string telefone, string rua, string numero, string bairro, string cidade, string siglaEs)
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
        private void Delete(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();

            DialogResult resultado = MessageBox.Show("Deseja mesmo excluir o registro ?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
           
            if(resultado == DialogResult.Yes)
            {
                var retorno = controllerCliente.Delete(decimal.Parse(txtCnpj.Text));

                if(retorno == true)
                {
                    MessageBox.Show("Deletado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro na exclusão", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("Operação cancelada", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
