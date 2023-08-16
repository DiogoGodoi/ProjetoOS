using API_EXTERNAS;

namespace MODEL {
    public class Cliente
    {
        //Atributos
        protected string nome { get; set; }
        protected EnderecoApi endereco { get; set; } 

        // Construtor para a classe Cliente que inicializa as propriedades.
        public Cliente(string nome, string telefone, string rua, string numero, string bairro, string cidade, string siglaEs)
        {
            this.nome = nome;
            endereco = new EnderecoApi();
            endereco.telefone = telefone;
            endereco.logradouro = rua;
            endereco.numero = numero;
            endereco.bairro = bairro;
            endereco.municipio = cidade;
            endereco.uf = siglaEs;
        }

        // Métodos para acessar as propriedades privadas.
        public string GetNome() { return this.nome; }
        public EnderecoApi GetEndereco() { return this.endereco; }
    }

}