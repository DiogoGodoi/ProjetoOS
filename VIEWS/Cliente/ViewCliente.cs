using CONTROLLER;
using System;
using VIEWS.Cliente.Relatorio;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class frmViewCliente : Form
    {
        frmExibirCliente _viewExibirCliente { get; set; }
        frmCadastrarCliente _viewCadastrarCliente { get; set; }
        frmPesquisarClienteView _viewPesquisarCliente { get; set; } 

        public Panel slideMenu = new Panel();
        public frmViewCliente()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            slideMenu = panelMenu;
        }
        public void transicaoTela<T>(T tela) where T : Form, new()
        {

            if (ActiveMdiChild != null)
            {
                foreach (T item in panelMenu.Controls)
                {
                    item.Close();
                }
            }
            if (tela == null || tela.IsDisposed)
            {
                tela = new T();
                tela.MdiParent = this;
                panel4.Controls.Add(tela);
                tela.Show();
            }
            else
            {
                tela.Close();
            }

            Resize += (sender, e) =>
            {
                tela = new T();
                tela.MdiParent = this;
                panel4.Controls.Add(tela);
                tela.Show();
            };
        }
        private void Insert(object sender, EventArgs e)
        {
            transicaoTela(_viewCadastrarCliente);
        }
        private void Read(object sender, EventArgs e)
        {
            transicaoTela(_viewExibirCliente);
        }
        private void Filter(object sender, EventArgs e)
        {
            transicaoTela(_viewPesquisarCliente);
        }
        private void Report(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Report();
            Dados dados = new Dados();

            if (clientes.Count > 0)
            {
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }

                frmRelatorioCliente _frmRelatorioCliente = new frmRelatorioCliente(dados);
                _frmRelatorioCliente.ShowDialog();
            }
            else
            {
                dados.Clientes.Rows.Add("Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados");
                frmRelatorioCliente _frmRelatorioCliente = new frmRelatorioCliente(dados);
                _frmRelatorioCliente.ShowDialog();
            }
        }
        private void ReportStrip(object sender, EventArgs e)
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

                frmRelatorioCliente _frmRelatorioCliente = new frmRelatorioCliente(dados);
                _frmRelatorioCliente.ShowDialog();
            }
            else
            {
                dados.Clientes.Rows.Add("Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados");
                frmRelatorioCliente _frmRelatorioCliente = new frmRelatorioCliente(dados);
                _frmRelatorioCliente.ShowDialog();
            }
        }
        private void CarregamentoTela(object sender, EventArgs e)
        {
            transicaoTela(_viewExibirCliente);
        }
        private void InsertStrip(object sender, EventArgs e)
        {
            transicaoTela(_viewCadastrarCliente);
        }
        private void FilterStrip(object sender, EventArgs e)
        {
            transicaoTela(_viewPesquisarCliente);
        }
    }
}

