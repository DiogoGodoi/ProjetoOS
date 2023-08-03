using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class frmViewCliente : Form
    {
        frmExibirCliente _viewExibirCliente { get; set; }
        frmCadastrarCliente _viewCadastrarCliente { get; set; }
        frmAlterarCliente _viewAlterarCliente { get; set; }
        public Panel panelTransition = new Panel();
        public frmViewCliente()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            panelTransition = panel3;

        }
        public void transicaoTela<T>(T tela) where T : Form, new()
        {
            if (ActiveMdiChild != null)
            {
                foreach (T item in panel3.Controls)
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
        private void ReadView(object sender, EventArgs e)
        {
            transicaoTela(_viewExibirCliente);
        }

        private void InsertView(object sender, EventArgs e)
        {
            transicaoTela(_viewCadastrarCliente);
        }

        private void ViewCliente_Load(object sender, EventArgs e)
        {
            transicaoTela(_viewExibirCliente);
        }
    }
}

