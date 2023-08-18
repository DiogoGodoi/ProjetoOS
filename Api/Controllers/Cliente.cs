using Microsoft.AspNetCore.Mvc;
using API.Service;
using MODEL;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService serviceCliente;

        public ClienteController()
        {
            serviceCliente = new ClienteService();
        }

        [HttpGet]
        public IActionResult GetClientes()
        {
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

            if (clientes.Count > 0)
            {
                return Ok(clientes);
            }
            else
            {
                return NotFound("Status 404: not found");
            }

        }

        [HttpGet("{cnpj}")]
        public IActionResult GetClienteByCnpj(string cnpj)
        {
            var clientes = serviceCliente.ListarPorCnpj(cnpj)
                    .Where(cliente => cliente.GetCnpj() == decimal.Parse(cnpj))
                    .Select(cliente => new {
                       
                        Cnpj = cliente.GetCnpj(),
                        Nome = cliente.GetNome(),
                        Telefone = cliente.GetDadosAPI().telefone,
                        Logradouro = cliente.GetDadosAPI().logradouro,
                        Numero = cliente.GetDadosAPI().numero,
                        Bairro = cliente.GetDadosAPI().bairro,
                        municipio = cliente.GetDadosAPI().municipio,
                        uf = cliente.GetDadosAPI().uf,
                    
                    }).ToList();

            if (clientes.Count > 0)
            {
                return Ok(clientes);
            }
            else
            {
                return NotFound("Status 404: not found");
            }
        }

        [HttpPut("update/{cnpj}")]
        public IActionResult UpdateCliente([FromBody] ClientePJ request, string cnpj)
        {
            
            var retorno = serviceCliente._controlerCliente.Update(request, decimal.Parse(cnpj));

            if(retorno != false)
            {
                return Ok("Registro alterado");
            }
            else
            {
                return BadRequest("Erro");
            }
        }
    }
}
