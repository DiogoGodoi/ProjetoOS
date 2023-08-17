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

            // Projeta a lista de clientes para um novo formato de objeto
            clientes.Select(cliente => new
            {
                Cnpj = cliente.GetCnpj(),
                Nome = cliente.GetNome()
            }).ToList();

            return clientes;
        }

        public List<ClientePJ> ListarPorCnpj(string cnpj)
        {
            // Lê todos os clientes do ControllerCliente
            List<ClientePJ> clientes = _controlerCliente.Read();
            // Filtra os clientes com base no CNPJ fornecido
            clientes.Where(cliente => cliente.GetCnpj() == decimal.Parse(cnpj))
                    .Select(cliente => new { Cnpj = cliente.GetCnpj(),
                                             Nome = cliente.GetNome(),}).ToList();
            return clientes;
        }
    }
}
