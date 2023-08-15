using CONTROLLER;
using VIEWS.Cliente.Relatorio;
using System.Windows.Forms;

namespace VIEWS
{
    // Classe que representa a interface de usuário relacionada aos clientes
    public partial class ViewCliente : Form
    {
        // Visualizações relacionadas aos clientes
        private ReadClienteView _viewExibirCliente { get; set; }
        private InsertClienteView _viewCadastrarCliente { get; set; }
        private FilterClienteView _viewPesquisarCliente { get; set; }
        private ReportClientView _viewReportClient { get;set; }

        // Construtor da classe ViewCliente
        public ViewCliente()
        {
            InitializeComponent();

            // Configura a janela como um contêiner MDI (Multiple Document Interface)
            this.IsMdiContainer = true;

            _viewReportClient = new ReportClientView();

            // Associações de eventos para diferentes ações do usuário
            Load += (sender, e) => OpenClientReadView(); // Carrega a visualização de leitura de clientes
            btnCadastrar.Click += (sender, e) => OpenClientInserView(); // Abre a visualização de cadastro de clientes
            btnExibir.Click += (sender, e) => OpenClientReadView(); // Abre a visualização de leitura de clientes
            btnPesquisar.Click += (sender, e) => OpenClientFilterView(); // Abre a visualização de filtro de clientes
            btnRelatorios.Click += (sender, e) => OpenClientReport1View(); // Abre a visualização de relatórios de clientes
            tsCadastrar.Click += (sender, e) => OpenClientInserView(); // Abre a visualização de cadastro de clientes
            tsPesquisar.Click += (sender, e) => OpenClientFilterView(); // Abre a visualização de filtro de clientes
            tsReport.Click += (sender, e) => OpenClientReportView(); // Abre a visualização de relatórios de clientes
            btnSair.Click += (sender, e) => this.Close();

            this.WindowState = FormWindowState.Normal;
        }

        // Realiza a transição entre diferentes telas de visualização
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

            // Cria ou exibe uma nova instância da tela
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

        // Abre a visualização de cadastro de clientes
        private void OpenClientInserView()
        {
            transicaoTela(_viewCadastrarCliente);
        }

        // Abre a visualização de leitura de clientes
        private void OpenClientReadView()
        {
            transicaoTela(_viewExibirCliente);
        }

        // Abre a visualização de filtro de clientes
        private void OpenClientFilterView()
        {
            transicaoTela(_viewPesquisarCliente);
        }

        // Abre a visualização de relatórios de clientes
        private void OpenClientReportView()
        {
            // Cria um dataSet de dados
            Dados dados = new Dados();
            // Cria e exibe a visualização do relatório de clientes
            _viewReportClient.SetDados(dados);
            _viewReportClient.ShowDialog();
        }
        private void OpenClientReport1View()
        {
            ReportClientView report = new ReportClientView();
            report.ShowDialog();
        } 
    }
}

