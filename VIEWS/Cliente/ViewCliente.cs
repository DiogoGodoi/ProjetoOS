using CONTROLLER;
using System;
using VIEWS.Cliente.Relatorio;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class ViewCliente : Form
    {
        // Variáveis para as diferentes views
        ReadClienteView _viewExibirCliente { get; set; }
        InsertClienteView _viewCadastrarCliente { get; set; }
        FilterClienteView _viewPesquisarCliente { get; set; }

        // Painel para o menu deslizante
        public Panel slideMenu = new Panel();

        public ViewCliente()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            slideMenu = panelMenu;
            Load += (sender, e) => transicaoTela(_viewExibirCliente);
        }

        // Método para realizar a transição entre telas
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

        // Manipula o evento de inserção quando o botão é clicado
        private void Insert(object sender, EventArgs e)
        {
            transicaoTela(_viewCadastrarCliente);
        }

        // Manipula o evento de leitura quando o botão é clicado
        private void Read(object sender, EventArgs e)
        {
            transicaoTela(_viewExibirCliente);
        }

        // Manipula o evento de filtro quando o botão é clicado
        private void Filter(object sender, EventArgs e)
        {
            transicaoTela(_viewPesquisarCliente);
        }

        // Manipula o evento de geração de relatório quando o botão é clicado
        private void Report(object sender, EventArgs e)
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

        // Manipula o evento de geração de relatório na barra de menu quando o item é selecionado
        private void ReportStrip(object sender, EventArgs e)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Read();
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
                dados.Clientes.Rows.Add("Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados", "Sem dados");
                frmRelatorioCliente _frmRelatorioCliente = new frmRelatorioCliente(dados);
                _frmRelatorioCliente.ShowDialog();
            }
        }

        // Manipula o evento de inserção na barra de menu quando o item é selecionado
        private void InsertStrip(object sender, EventArgs e)
        {
            transicaoTela(_viewCadastrarCliente);
        }

        // Manipula o evento de filtro na barra de menu quando o item é selecionado
        private void FilterStrip(object sender, EventArgs e)
        {
            transicaoTela(_viewPesquisarCliente);
        }
    }

}

