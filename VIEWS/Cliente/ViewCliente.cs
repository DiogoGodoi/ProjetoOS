using CONTROLLER;
using VIEWS.Cliente.Relatorio;
using System.Windows.Forms;

namespace VIEWS
{
    // Classe que representa a interface de usuário relacionada aos clientes
    public partial class ViewCliente : Form
    {
        // Visualizações relacionadas aos clientes
        ReadClienteView _viewExibirCliente { get; set; }
        InsertClienteView _viewCadastrarCliente { get; set; }
        FilterClienteView _viewPesquisarCliente { get; set; }

        // Painel de menu deslizante
        public Panel slideMenu = new Panel();

        // Construtor da classe ViewCliente
        public ViewCliente()
        {
            InitializeComponent();

            // Configura a janela como um contêiner MDI (Multiple Document Interface)
            this.IsMdiContainer = true;
            slideMenu = panelMenu;

            // Associações de eventos para diferentes ações do usuário
            Load += (sender, e) => OpenClientReadView(); // Carrega a visualização de leitura de clientes
            btnCadastrar.Click += (sender, e) => OpenClientInserView(); // Abre a visualização de cadastro de clientes
            btnExibir.Click += (sender, e) => OpenClientReadView(); // Abre a visualização de leitura de clientes
            btnPesquisar.Click += (sender, e) => OpenClientFilterView(); // Abre a visualização de filtro de clientes
            btnRelatorios.Click += (sender, e) => OpenClientReportView(); // Abre a visualização de relatórios de clientes
            tsCadastrar.Click += (sender, e) => OpenClientInserView(); // Abre a visualização de cadastro de clientes
            tsPesquisar.Click += (sender, e) => OpenClientFilterView(); // Abre a visualização de filtro de clientes
            tsReport.Click += (sender, e) => OpenClientReportView(); // Abre a visualização de relatórios de clientes

            this.MaximizeBox = false;
            this.WindowState = FormWindowState.Maximized;
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

            //// Redimensiona a tela quando a janela é redimensionada
            //Resize += (sender, e) =>
            //{
            //    tela = new T();
            //    tela.MdiParent = this;
            //    panel4.Controls.Add(tela);
            //    tela.Show();
            //};
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
            // Cria um controlador de cliente e obtém dados para relatório
            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Report();
            Dados dados = new Dados();

            // Verifica se há clientes para gerar o relatório
            if (clientes.Count > 0)
            {
                // Preenche os dados do relatório com informações dos clientes
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }

                // Cria e exibe a visualização do relatório de clientes
                ReportClientView _frmRelatorioCliente = new ReportClientView(dados);
                _frmRelatorioCliente.ShowDialog();
            }
            else
            {
                // Exibe uma mensagem quando não há clientes para relatório
                MessageBox.Show("Sem dados a exibir", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

