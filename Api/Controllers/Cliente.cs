using CONTROLLER;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Cliente : ControllerBase {

    [HttpGet]
    [Route("/Cliente")]
    public IActionResult GetCliente()
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            List<MODEL.Cliente> cliente = new List<MODEL.Cliente>();
            cliente = controllerCliente.Read();
            var dados = cliente.Select(i => new
            {
                Cnpj = i.GetCnpj(),
                Nome = i.GetNome()
            }).ToList();

            return Ok(dados);
        }

        [HttpGet]
        [Route("/Cliente/{cnpj}")]
        public IActionResult SelectCliente(string cnpj)
        {
            ControllerCliente controllerCliente = new ControllerCliente();
            var cliente = controllerCliente.Read();
            var dados = cliente.Where(i => i.GetCnpj() == decimal.Parse(cnpj));
            var result = dados.Select(i => new
            {
             Cnpj = i.GetCnpj(),
             Nome = i.GetNome(),
            }).ToList();

            return Ok(result);
        }
    }
}
