using Microsoft.AspNetCore.Mvc;
using API.Service;

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
            var clientes = serviceCliente.GetClientes()
                .Select(cliente => new { Cnpj = cliente.GetCnpj(),
                                         Nome = cliente.GetNome()}).ToList();

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
            var clientes = serviceCliente.GetClientesByCnpj(cnpj)
                    .Where(cliente => cliente.GetCnpj() == decimal.Parse(cnpj))
                    .Select(cliente => new {
                        Cnpj = cliente.GetCnpj(),
                        Nome = cliente.GetNome(),
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
    }
}
