using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace VIEWS
{
    public partial class ViewHome : Form
    {
        public ViewHome()
        {
            InitializeComponent();
            btnClientes.Click += (sender, e) => OpenViewCliente();
            TsMenuClientes.Click += (sender, e) => OpenViewCliente();
        }

        public void OpenViewCliente()
        {
            Thread _thread = new Thread(ViewCliente);
            _thread.SetApartmentState(ApartmentState.STA);
            _thread.Start();
            this.Close();
        }

        public void ViewCliente()
        {
            Application.Run(new ViewCliente());
        }
    }
}
