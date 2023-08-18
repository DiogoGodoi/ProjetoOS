using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace API_EXTERNAS
{
    // Classe ControllerApiReceita: Controlador para acessar a API da Receita Federal.
    public class ControllerApiReceita
    {
        // Método para consultar os dados de uma empresa na Receita Federal.
        public async Task<ApiReceita> ApiReceita(string cnpj)
        {
            // URL da API da Receita Federal para consulta de CNPJ.
            string url = $"https://www.receitaws.com.br/v1/cnpj/{cnpj}";

            // Criação de um objeto HttpClient para fazer a requisição à API.
            HttpClient cliente = new HttpClient();

            try
            {
                // Faz a requisição GET à API.
                HttpResponseMessage response = await cliente.GetAsync(url);

                // Verifica se a requisição foi bem-sucedida.
                if (response.IsSuccessStatusCode)
                {
                    // Lê o conteúdo da resposta.
                    string content = await response.Content.ReadAsStringAsync();

                    // Converte o conteúdo JSON em um objeto ModelReceitaFederal.
                    ApiReceita dados = JsonConvert.DeserializeObject<ApiReceita>(content);

                    // Retorna os dados da Receita Federal.
                    return dados;
                }
                else
                {
                    // Retorna nulo caso a requisição não seja bem-sucedida.
                    return null;
                }
            }
            catch (HttpRequestException ex)
            {
                // Lança uma exceção em caso de erro na requisição.
                throw new Exception($"Erro ao consultar a Receita Federal: {ex.Message}");
            }
        }
    }

}
