using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using VIEWS.Cliente.Relatorio;

namespace VIEWS
{
    public partial class frmRelatorioCliente : Form
    {
        Dados dados = new Dados();

        // Construtor da classe que recebe os dados para gerar o relatório
        public frmRelatorioCliente(Dados dados)
        {
            InitializeComponent();
            this.dados = dados;

            // Evento de carregamento do formulário para gerar o relatório
            Load += (sender, e) => GerarRelatorio();
        }

        // Método assíncrono para gerar o relatório
        private async void GerarRelatorio()
        {
            // Simula um atraso de 3 segundos (opcional)
            await Task.Delay(TimeSpan.FromSeconds(3));

            // Limpa os dados anteriores do relatório
            this.rpv1.LocalReport.DataSources.Clear();

            // Adiciona os dados ao relatório
            this.rpv1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Ds", dados.Tables[0]));

            // Atualiza o relatório
            this.rpv1.RefreshReport();
        }
    }

}
