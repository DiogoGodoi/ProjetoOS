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
        public frmRelatorioCliente(Dados dados)
        {
            InitializeComponent();
            this.dados = dados;
        }

        private async void RelatorioCliente_Load(object sender, EventArgs e)
        {
            await Task.Delay(TimeSpan.FromSeconds(3));
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("Ds", dados.Tables[0]));
            this.reportViewer1.RefreshReport();
        }
    }
}
