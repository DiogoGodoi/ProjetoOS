using API_EXTERNAS;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace CONTROLLER
{
    public class ControllerApiReceita
    {
        //Método api receita federal
        public async Task<ModelReceitaFederal> ApiReceita(string cnpj)
        {
            string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";
            HttpClient cliente = new HttpClient();

            try
            {
                HttpResponseMessage response = await cliente.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    ModelReceitaFederal dados = JsonConvert.DeserializeObject<ModelReceitaFederal>(content);
                    return dados;
                }
                else
                {
                    return null;
                }

            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Erro ao consultar o CEP: {ex.Message}");
            }
        }
    }
}
