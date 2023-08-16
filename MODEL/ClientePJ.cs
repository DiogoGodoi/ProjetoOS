namespace MODEL
{
    public class ClientePJ: Cliente
    {
        private decimal cnpj { get; set; }

        public ClientePJ(decimal cnpj, string nome, string telefone, 
            string rua, string numero, 
            string bairro, string cidade, 
            string siglaEs) : base(nome, telefone, rua, numero, bairro, cidade, siglaEs)
        {
            this.cnpj = cnpj;
        }

        public decimal GetCnpj() { return cnpj; }
    }
}
