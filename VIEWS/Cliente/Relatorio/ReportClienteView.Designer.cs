namespace VIEWS
{
    partial class ReportClientView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rpv1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rpv1
            // 
            this.rpv1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rpv1.LocalReport.ReportEmbeddedResource = "VIEWS.Cliente.Relatorio.RelClientes.rdlc";
            this.rpv1.Location = new System.Drawing.Point(0, 0);
            this.rpv1.Name = "rpv1";
            this.rpv1.ServerReport.BearerToken = null;
            this.rpv1.Size = new System.Drawing.Size(800, 450);
            this.rpv1.TabIndex = 0;
            // 
            // ReportClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rpv1);
            this.Name = "ReportClientView";
            this.Text = "Lista de clientes";
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rpv1;
    }
}