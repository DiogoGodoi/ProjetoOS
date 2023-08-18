using CONTROLLER;
using MODEL;

namespace API.Service
{
    public class ClienteService
    {
        public ControllerCliente _controlerCliente { get; set; }

        public ClienteService()
        {
            this._controlerCliente = new ControllerCliente();
        }

        public List<ClientePJ> ListarClientes()
        {
            List<ClientePJ> clientes = _controlerCliente.Read();

            return clientes;
        }

        public List<ClientePJ> ListarPorCnpj(string cnpj)
        {
            List<ClientePJ> clientes = _controlerCliente.Read();

            return clientes;
        }

        public bool UpdateCliente(ClientePJ cliente, decimal cnpj)
        {
            var retorno = _controlerCliente.Update(cliente, cnpj);
            if(retorno != false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
