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

namespace VIEWS.Cliente.Relatorio
{
    public partial class ReportClientView1 : Form
    {
        public ReportClientView1()
        {
            InitializeComponent();

            dtGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Load += (sender, e) => { Read(); dtGrid.Focus(); };
            btnExibir.Click += (sender, e) => { Read(); dtGrid.Focus(); };
        }
        private void Read()
        {
            // Cria uma instância do controlador de Cliente.
            ControllerCliente controllerCliente = new ControllerCliente();

            // Recupera todos os clientes do banco de dados.
            var clientes = controllerCliente.Read();
            Dados dados = new Dados();

            if (clientes.Count > 0)
            {
                // Preenche o DataGridView com os dados dos clientes.
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }
                dtGrid.DataSource = dados.Clientes;
            }
            else
            {
                DataTable tb = new DataTable();
                tb.Columns.Add("Clientes", typeof(string));
                tb.Rows.Add("Sem dados");
                dtGrid.DataSource = tb;
                dtGrid.Enabled = false;
            }
        }
    }
}
