using CONTROLLER;
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
    public partial class frmPesquisarClienteView : Form
    {
        public frmPesquisarClienteView()
        {
            InitializeComponent();
            dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmPesquisarClienteView_Load(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Read();
            Dados dados = new Dados();

            if (clientes.Count > 0)
            {
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                dtGrid.Enabled = false;
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            Dados dados = new Dados();
            var retorno = controllerCliente.Filter(decimal.Parse(txtCnpj.Text), txtNome.Text);
            if(retorno.Count > 0)
            {
                foreach (var idx in retorno)
                {
                dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
            }

            dtGrid.DataSource = dados.Clientes;

        }
    }
}
