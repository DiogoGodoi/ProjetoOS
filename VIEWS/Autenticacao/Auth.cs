using System.Windows.Forms;

namespace VIEWS.Autenticacao
{
    public partial class frmAuth : Form
    {
        public frmAuth()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            btnSair.Click += (sender, e) => { this.Close(); };
        }
    }
}
