using CONTROLLER;
using MODEL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class frmCadastrarCliente : Form
    {
        public frmCadastrarCliente()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            Cliente cliente = new Cliente(decimal.Parse(txtCnpj.Text), txtNome.Text, txtTelefone.Text, txtRua.Text, txtNumero.Text, txtBairro.Text, txtCidade.Text, cbEstado.Text);
            var retorno = controllerCliente.Insert(cliente);
            if(retorno == true)
            {
                MessageBox.Show("Cadastrado com sucesso", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Erro no cadastro", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
