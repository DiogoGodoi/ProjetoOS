using Microsoft.AspNetCore.Mvc;
using API.Service;
using MODEL;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    // Este � o controlador respons�vel por lidar com as requisi��es relacionadas aos clientes.
    public class ClienteController : ControllerBase
    {
        // O servi�o que ser� utilizado para manipular as opera��es relacionadas aos clientes.
        private readonly ClienteService serviceCliente;

        // Construtor da classe ClienteController.
        public ClienteController()
        {
            // Inicializa o servi�o de Cliente no construtor.
            serviceCliente = new ClienteService();
        }

        // M�todo para recuperar a lista de todos os clientes.
        [HttpGet]
        public IActionResult GetClientes()
        {
            // Utiliza o servi�o para obter a lista de clientes e faz um mapeamento para um objeto an�nimo.
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

            // Verifica se h� clientes na lista e retorna a resposta apropriada.
            if (clientes.Count > 0)
            {
                return Ok(clientes); // 200 OK com a lista de clientes.
            }
            else
            {
                return NotFound("Status 404: not found"); // 404 Not Found se n�o houver clientes.
            }
        }

        // M�todo para recuperar informa��es de um cliente espec�fico com base no CNPJ.
        [HttpGet("{cnpj}")]
        public IActionResult GetClienteByCnpj(string cnpj)
        {
            // Utiliza o servi�o para obter o cliente com o CNPJ especificado e faz um mapeamento para um objeto an�nimo.
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
                return NotFound("Status 404: not found"); // 404 Not Found se o cliente n�o for encontrado.
            }
        }

        // M�todo para atualizar informa��es de um cliente com base no CNPJ.
        [HttpPut("update/{cnpj}")]
        public IActionResult UpdateCliente(string cnpj, string nome, string telefone,
            string logradouro, string numero, string bairro, string municipio, string uf)
        {
            // Cria um objeto ClientePJ com as informa��es fornecidas.
            ClientePJ clientePJ = new ClientePJ(decimal.Parse(cnpj),
                nome, telefone, logradouro, numero, bairro, municipio, uf);

            // Chama o servi�o para atualizar o cliente e obt�m o resultado.
            var retorno = serviceCliente.UpdateCliente(clientePJ, decimal.Parse(cnpj));

            // Verifica o resultado da atualiza��o e retorna a resposta apropriada.
            if (retorno != false)
            {
                return Ok("Registro alterado"); // 200 OK se a atualiza��o for bem-sucedida.
            }
            else
            {
                return BadRequest("Erro"); // 400 Bad Request se a atualiza��o falhar.
            }
        }

        // M�todo para inserir um novo cliente.
        [HttpPost("insert")]
        public IActionResult InsertCliente(string cnpj, string nome, string telefone,
            string logradouro, string numero, string bairro, string municipio, string uf)
        {
            // Cria um objeto ClientePJ com as informa��es fornecidas.
            ClientePJ clientePJ = new ClientePJ(decimal.Parse(cnpj),
                nome, telefone, logradouro, numero, bairro, municipio, uf);

            // Chama o servi�o para inserir o novo cliente e obt�m o resultado.
            var retorno = serviceCliente.InsertCliente(clientePJ);

            // Verifica o resultado da inser��o e retorna a resposta apropriada.
            if (retorno != false)
            {
                return Ok("Registro inserido"); // 200 OK se a inser��o for bem-sucedida.
            }
            else
            {
                return BadRequest("Erro"); // 400 Bad Request se a inser��o falhar.
            }
        }

        // M�todo para deletar um cliente com base no CNPJ.
        [HttpDelete("delete/{cnpj}")]
        public IActionResult DeleteCliente(string cnpj)
        {
            // Chama o servi�o para deletar o cliente e obt�m o resultado.
            var retorno = serviceCliente.DeleteCliente(decimal.Parse(cnpj));

            // Verifica o resultado da dele��o e retorna a resposta apropriada.
            if (retorno != false)
            {
                return Ok("Registro deletado"); // 200 OK se a dele��o for bem-sucedida.
            }
            else
            {
                return BadRequest("Erro"); // 400 Bad Request se a dele��o falhar.
            }
        }
    }

}
