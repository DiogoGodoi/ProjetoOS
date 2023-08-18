namespace MODEL
{
    public class ClientePJ: Cliente
    {
        private decimal cnpj { get; set; }

        public ClientePJ(decimal cnpj, string nome, string telefone, 
            string logradouro, string numero, 
            string bairro, string municipio, 
            string uf) : base(nome, telefone, logradouro, numero, bairro, municipio, uf)
        {
            this.cnpj = cnpj;
        }

        public decimal GetCnpj() { return cnpj; }
    }
}
