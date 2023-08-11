using CONTROLLER;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEWS.Cliente.Relatorio;

namespace VIEWS
{
    public partial class ReportClientView : Form
    {
        private Dados dados = new Dados();

        // Construtor da classe que recebe os dados para gerar o relatório
        public ReportClientView()
        {
            InitializeComponent();

            // Evento de carregamento do formulário para gerar o relatório
            Load += (sender, e) => GenerateReport();
            rpv1.Print += (sender, e) => { this.Close(); };
            this.FormClosed += (sender, e) => { MessageBox.Show("Arquivo salvo", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information); };
        }

        // Método assíncrono para gerar o relatório
        private async void GenerateReport()
        {
            // Cria um controlador de cliente e obtém dados para relatório
            ControllerCliente controllerCliente = new ControllerCliente();
            var clientes = controllerCliente.Report();

            // Verifica se há clientes para gerar o relatório
            if (clientes.Count > 0)
            {
                // Preenche os dados do relatório com informações dos clientes
                foreach (var idx in clientes)
                {
                    dados.Clientes.Rows.Add(idx.GetCnpj(), idx.GetNome(), idx.GetTelefone(), idx.GetRua(), idx.GetNumero(), idx.GetBairro(), idx.GetCidade(), idx.GetSiglaEs());
                }


                // Simula um atraso de 3 segundos (opcional)
                await Task.Delay(TimeSpan.FromSeconds(3));

                // Limpa os dados anteriores do relatório
                this.rpv1.LocalReport.DataSources.Clear();

                // Adiciona os dados ao relatório
                this.rpv1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Ds", dados.Tables[0]));

                // Atualiza o relatório
                this.rpv1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Sem dados a exibir", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void SetDados(Dados dados)
        {
            this.dados = dados;
        }
    }
}
