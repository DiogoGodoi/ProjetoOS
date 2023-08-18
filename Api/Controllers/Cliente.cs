using Microsoft.AspNetCore.Mvc;
using API.Service;
using MODEL;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // Este é o controlador responsável por lidar com as requisições relacionadas aos clientes.
    public class ClienteController : ControllerBase
    {
        // O serviço que será utilizado para manipular as operações relacionadas aos clientes.
        private readonly ClienteService serviceCliente;

        // Construtor da classe ClienteController.
        public ClienteController()
        {
            // Inicializa o serviço de Cliente no construtor.
            serviceCliente = new ClienteService();
        }

        // Método para recuperar a lista de todos os clientes.
        [HttpGet]
        public IActionResult GetClientes()
        {
            // Utiliza o serviço para obter a lista de clientes e faz um mapeamento para um objeto anônimo.
            var clientes = serviceCliente.ListarClientes()
                .Select(cliente => new
                {
                    Cnpj = cliente.GetCnpj(),
                    Nome = cliente.GetNome(),
                    Telefone = cliente.GetDadosAPI().telefone,
                    Logradouro = cliente.GetDadosAPI().logradouro,
                    Numero = cliente.GetDadosAPI().numero,
                    Bairro = cliente.GetDadosAPI().bairro,
                    Municipio = cliente.GetDadosAPI().municipio,
                    Uf = cliente.GetDadosAPI().uf,
                }).ToList();

            // Verifica se há clientes na lista e retorna a resposta apropriada.
            if (clientes.Count > 0)
            {
                return Ok(clientes); // 200 OK com a lista de clientes.
            }
            else
            {
                return NotFound("Status 404: not found"); // 404 Not Found se não houver clientes.
            }
        }

        // Método para recuperar informações de um cliente específico com base no CNPJ.
        [HttpGet("{cnpj}")]
        public IActionResult GetClienteByCnpj(string cnpj)
        {
            // Utiliza o serviço para obter o cliente com o CNPJ especificado e faz um mapeamento para um objeto anônimo.
            var clientes = serviceCliente.ListarPorCnpj(cnpj)
                .Where(cliente => cliente.GetCnpj() == decimal.Parse(cnpj))
                .Select(cliente => new {
                    Cnpj = cliente.GetCnpj(),
                    Nome = cliente.GetNome(),
                    Telefone = cliente.GetDadosAPI().telefone,
                    Logradouro = cliente.GetDadosAPI().logradouro,
                    Numero = cliente.GetDadosAPI().numero,
                    Bairro = cliente.GetDadosAPI().bairro,
                    Municipio = cliente.GetDadosAPI().municipio,
                    Uf = cliente.GetDadosAPI().uf,
                }).ToList();

            // Verifica se o cliente foi encontrado e retorna a resposta apropriada.
            if (clientes.Count > 0)
            {
                return Ok(clientes); // 200 OK com o cliente encontrado.
            }
            else
            {
                return NotFound("Status 404: not found"); // 404 Not Found se o cliente não for encontrado.
            }
        }

        // Método para atualizar informações de um cliente com base no CNPJ.
        [HttpPut("update/{cnpj}")]
        public IActionResult UpdateCliente(string cnpj, string nome, string telefone,
            string logradouro, string numero, string bairro, string municipio, string uf)
        {
            // Cria um objeto ClientePJ com as informações fornecidas.
            ClientePJ clientePJ = new ClientePJ(decimal.Parse(cnpj),
                nome, telefone, logradouro, numero, bairro, municipio, uf);

            // Chama o serviço para atualizar o cliente e obtém o resultado.
            var retorno = serviceCliente.UpdateCliente(clientePJ, decimal.Parse(cnpj));

            // Verifica o resultado da atualização e retorna a resposta apropriada.
            if (retorno != false)
            {
                return Ok("Registro alterado"); // 200 OK se a atualização for bem-sucedida.
            }
            else
            {
                return BadRequest("Erro"); // 400 Bad Request se a atualização falhar.
            }
        }

        // Método para inserir um novo cliente.
        [HttpPost("insert")]
        public IActionResult InsertCliente(string cnpj, string nome, string telefone,
            string logradouro, string numero, string bairro, string municipio, string uf)
        {
            // Cria um objeto ClientePJ com as informações fornecidas.
            ClientePJ clientePJ = new ClientePJ(decimal.Parse(cnpj),
                nome, telefone, logradouro, numero, bairro, municipio, uf);

            // Chama o serviço para inserir o novo cliente e obtém o resultado.
            var retorno = serviceCliente.InsertCliente(clientePJ);

            // Verifica o resultado da inserção e retorna a resposta apropriada.
            if (retorno != false)
            {
                return Ok("Registro inserido"); // 200 OK se a inserção for bem-sucedida.
            }
            else
            {
                return BadRequest("Erro"); // 400 Bad Request se a inserção falhar.
            }
        }

        // Método para deletar um cliente com base no CNPJ.
        [HttpDelete("delete/{cnpj}")]
        public IActionResult DeleteCliente(string cnpj)
        {
            // Chama o serviço para deletar o cliente e obtém o resultado.
            var retorno = serviceCliente.DeleteCliente(decimal.Parse(cnpj));

            // Verifica o resultado da deleção e retorna a resposta apropriada.
            if (retorno != false)
            {
                return Ok("Registro deletado"); // 200 OK se a deleção for bem-sucedida.
            }
            else
            {
                return BadRequest("Erro"); // 400 Bad Request se a deleção falhar.
            }
        }
    }

}
