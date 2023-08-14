using System.Collections.Generic;
using MODEL;
using DAO;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;

namespace CONTROLLER
{
    public class ControllerCliente
    {
        // Construtor para a classe ControllerCliente.
        public ControllerCliente() { }

        // Insere um novo registro de Cliente usando a classe DAO correspondente.
        public bool Insert(Cliente Cliente)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Insert(Cliente);
        }

        // Atualiza um registro existente de Cliente usando a classe DAO correspondente.
        public bool Update(Cliente Cliente, decimal cnpj)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Update(Cliente, cnpj);
        }

        // Exclui um registro de Cliente usando a classe DAO correspondente.
        public bool Delete(decimal cnpj)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Delete(cnpj);
        }

        // Recupera uma lista de todos os registros de Cliente usando a classe DAO correspondente.
        public List<Cliente> Read()
        {
            DaoCliente dao = new DaoCliente();
            return dao.Read();
        }

        // Recupera uma lista de registros de Cliente com base em critérios de filtro usando a classe DAO correspondente.
        public List<Cliente> Filter(decimal? cnpj, string nome)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Filter(cnpj, nome);
        }

        // Recupera uma lista de todos os registros de Cliente para fins de relatório usando a classe DAO correspondente.
        public List<Cliente> Report()
        {
            DaoCliente dao = new DaoCliente();
            return dao.report();
        }

        //Método api receita federal
        public async Task<ApiReceitaFederal> ApiReceita(string cnpj)
        {
            string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";
            HttpClient cliente = new HttpClient();

            try
            {
                HttpResponseMessage response = await cliente.GetAsync(url);
                response.EnsureSuccessStatusCode();  // Lança uma exceção se a resposta não for bem-sucedida

                string content = await response.Content.ReadAsStringAsync();
                ApiReceitaFederal dados = JsonConvert.DeserializeObject<ApiReceitaFederal>(content);
                return dados;
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Erro ao consultar o CEP: {ex.Message}");
            }
        }
    }
}
