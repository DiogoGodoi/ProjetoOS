using API_EXTERNAS;

namespace MODEL {
    public class Cliente
    {
        //Atributos
        private decimal cnpj { get; set; }
        private string nome { get; set; }
        private ModelReceitaFederal endereco { get; set; } 

        // Construtor para a classe Cliente que inicializa as propriedades.
        public Cliente(decimal cnpj, string nome, string telefone, string rua, string numero, string bairro, string cidade, string siglaEs)
        {
            this.cnpj = cnpj;
            this.nome = nome;
            endereco = new ModelReceitaFederal();
            endereco.telefone = telefone;
            endereco.logradouro = rua;
            endereco.numero = numero;
            endereco.bairro = bairro;
            endereco.municipio = cidade;
            endereco.uf = siglaEs;
        }

        // Métodos para acessar as propriedades privadas.
        public decimal GetCnpj() { return this.cnpj; }
        public string GetNome() { return this.nome; }
        public ModelReceitaFederal GetEndereco() { return this.endereco; }
    }

}