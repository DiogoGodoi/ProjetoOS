using VIEWS.Cliente.Relatorio;
using System.Windows.Forms;
using VIEWS.Cliente;

namespace VIEWS
{
    // Classe que representa a interface de usuário relacionada aos clientes
    public partial class ViewCliente : Form
    {
        // Visualizações relacionadas aos clientes
        private ReadClienteView _viewExibirCliente { get; set; }
        private InsertClienteView _viewCadastrarCliente { get; set; }
        private FilterClienteView _viewPesquisarCliente { get; set; }
        private ReportClientView _viewReportClient { get; set; }
        private ProtectClientView _viewProtTela { get; set; }

        // Construtor da classe ViewCliente
        public ViewCliente()
        {
            InitializeComponent();

            // Configura a janela como um contêiner MDI (Multiple Document Interface)
            this.IsMdiContainer = true;

            // Inicializa a visualização de relatórios
            _viewReportClient = new ReportClientView();

            // Associações de eventos para diferentes ações do usuário
            pctLogo.Click += (sender, e) => TransicaoTela(_viewProtTela);
            Load += (sender, e) => TransicaoTela(_viewProtTela); ; // Carrega a visualização de proteção da tela
            btnCadastrar.Click += (sender, e) => TransicaoTela(_viewCadastrarCliente); // Abre a visualização de cadastro de clientes
            btnExibir.Click += (sender, e) => TransicaoTela(_viewExibirCliente); // Abre a visualização de leitura de clientes
            btnPesquisar.Click += (sender, e) => TransicaoTela(_viewPesquisarCliente); // Abre a visualização de filtro de clientes
            btnRelatorios.Click += (sender, e) => {
                Dados dados = new Dados();
                _viewReportClient.SetDados(dados);
                _viewReportClient.ShowDialog();
            };
            tsPesquisar.Click += (sender, e) => TransicaoTela(_viewPesquisarCliente); // Abre a visualização de filtro de clientes
            tsReport.Click += (sender, e) => {
                Dados dados = new Dados();
                _viewReportClient.SetDados(dados);
                _viewReportClient.ShowDialog();
            };
            btnSair.Click += (sender, e) => this.Close();

            // Configura as dicas de ferramentas para os botões
            tolTipExibir.SetToolTip(btnExibir, "Exiba a lista de clientes");
            tolTipCadastrar.SetToolTip(btnCadastrar, "Cadastre um novo cliente");
            tolTipPesquisar.SetToolTip(btnPesquisar, "Procure um cliente");
            tolTipRelatorios.SetToolTip(btnRelatorios, "Imprima a lista de clientes");

            // Define o estado inicial da janela
            this.WindowState = FormWindowState.Normal;
        }

        // Realiza a transição entre diferentes telas de visualização
        public void TransicaoTela<T>(T tela) where T : Form, new()
        {
            // Fecha outras instâncias abertas da mesma tela
            if (ActiveMdiChild != null)
            {
                foreach (T item in panelConteudo.Controls)
                {
                    item.Close();
                }
            }

            // Cria ou exibe uma nova instância da tela
            if (tela == null || tela.IsDisposed)
            {
                tela = new T();
                tela.MdiParent = this;
                panelConteudo.Controls.Add(tela);
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
                panelConteudo.Controls.Add(tela);
                tela.Show();
            };
        }
    }
}

