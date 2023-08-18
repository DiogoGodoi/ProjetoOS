using CONTROLLER;
using MODEL;

namespace API.Service
{
    // Este é o serviço responsável por fornecer operações relacionadas aos clientes.
    public class ClienteService
    {
        // Referência ao controlador de cliente para acessar os métodos CRUD.
        public ControllerCliente _controlerCliente { get; set; }

        // Construtor da classe ClienteService.
        public ClienteService()
        {
            // Inicializa a referência ao controlador de cliente no construtor.
            this._controlerCliente = new ControllerCliente();
        }

        // Obtém a lista de todos os clientes.
        public List<ClientePJ> ListarClientes()
        {
            // Chama o método Read do controlador de cliente para obter a lista de clientes.
            List<ClientePJ> clientes = _controlerCliente.Read();

            return clientes;
        }

        // Obtém a lista de clientes por CNPJ.
        public List<ClientePJ> ListarPorCnpj(string cnpj)
        {
            // Chama o método Read do controlador de cliente para obter a lista de clientes.
            List<ClientePJ> clientes = _controlerCliente.Read();

            return clientes;
        }

        // Atualiza informações de um cliente específico.
        public bool UpdateCliente(ClientePJ cliente, decimal cnpj)
        {
            // Chama o método Update do controlador de cliente para atualizar o cliente.
            var retorno = _controlerCliente.Update(cliente, cnpj);

            // Verifica o resultado da atualização e retorna um valor booleano.
            return retorno != false;
        }

        // Insere um novo cliente.
        public bool InsertCliente(ClientePJ cliente)
        {
            // Chama o método Insert do controlador de cliente para inserir o novo cliente.
            var retorno = _controlerCliente.Insert(cliente);

            // Verifica o resultado da inserção e retorna um valor booleano.
            return retorno != false;
        }

        // Deleta um cliente por CNPJ.
        public bool DeleteCliente(decimal cnpj)
        {
            // Chama o método Delete do controlador de cliente para deletar o cliente.
            var retorno = _controlerCliente.Delete(cnpj);

            // Verifica o resultado da deleção e retorna um valor booleano.
            return retorno != false;
        }
    }

}
