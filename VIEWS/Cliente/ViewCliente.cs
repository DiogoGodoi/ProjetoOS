using CONTROLLER;
using System;
using VIEWS.Cliente.Relatorio;
using System.Windows.Forms;
using System.Threading;

namespace VIEWS
{
    public partial class ViewCliente : Form
    {
        ReadClienteView _viewExibirCliente { get; set; }
        InsertClienteView _viewCadastrarCliente { get; set; }
        FilterClienteView _viewPesquisarCliente { get; set; }

        public Panel slideMenu = new Panel();

        public ViewCliente()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            slideMenu = panelMenu;

            Load += (sender, e) => OpenClientReadView();
            btnCadastrar.Click += (sender, e) => OpenClientInserView();
            btnExibir.Click += (sender, e) => OpenClientReadView();
            btnPesquisar.Click += (sender, e) => OpenClientFilterView();
            btnRelatorios.Click += (sender, e) => OpenClientReportView();
            tsCadastrar.Click += (sender, e) => OpenClientInserView();
            tsPesquisar.Click += (sender, e) => OpenClientFilterView();
            tsReport.Click += (sender, e) => OpenClientReportView();
            btnSair.Click += (sender, e) => OpenViewHome();
        }
        public void transicaoTela<T>(T tela) where T : Form, new()
        {
            // Fecha outras instâncias abertas da mesma tela
            if (ActiveMdiChild != null)
            {
                foreach (T item in panelMenu.Controls)
                {
                    item.Close();
                }
            }

            // Cria uma nova instância da tela se ainda não existe ou se foi fechada
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

            // Redimensiona a tela quando a janela é redimensionada
            Resize += (sender, e) =>
            {
                tela = new T();
                tela.MdiParent = this;
                panel4.Controls.Add(tela);
                tela.Show();
            };
        }
        private void OpenClientInserView()
        {
            transicaoTela(_viewCadastrarCliente);
        }
        private void OpenClientReadView()
        {
            transicaoTela(_viewExibirCliente);
        }
        private void OpenClientFilterView()
        {
            transicaoTela(_viewPesquisarCliente);
        }
        private void OpenClientReportView()
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Report();
            Dados dados = new Dados();

            // Verifica se há clientes para gerar o relatório
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
                // Mensagem exibida quando não se tem clientes cadastrados
                MessageBox.Show("Sem dados a exibir", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void OpenViewHome()
        {
            Thread thread = new Thread(ViewHome);
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            this.Close();
        }
        private void ViewHome()
        {
            Application.Run(new ViewHome());
        }
    }
}

