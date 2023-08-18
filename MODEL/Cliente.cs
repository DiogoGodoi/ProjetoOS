using API_EXTERNAS;

namespace MODEL {
    public class Cliente
    {
        //Atributos
        protected string nome { get; set; }
        protected ApiReceita dadosAPI { get; set; } 

        // Construtor para a classe Cliente que inicializa as propriedades.
        public Cliente(string nome, string telefone, string logradouro, string numero, string bairro, string municipio, string uf)
        {
            this.nome = nome;
            dadosAPI = new ApiReceita();
            dadosAPI.telefone = telefone;
            dadosAPI.logradouro = logradouro;
            dadosAPI.numero = numero;
            dadosAPI.bairro = bairro;
            dadosAPI.municipio = municipio;
            dadosAPI.uf = uf;
        }

        // M�todos para acessar as propriedades privadas.
        public string GetNome() { return this.nome; }
        public ApiReceita GetDadosAPI() { return this.dadosAPI; }
    }

}