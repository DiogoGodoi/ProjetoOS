namespace MODEL
{
    public class ClientePF: Cliente
    {
        private decimal cpf { get; set; }

        public ClientePF(decimal cpf, string nome, string telefone,
            string logradouro, string numero,
            string bairro, string municipio,
            string uf) : base(nome, telefone, logradouro, numero, bairro, municipio, uf)
        {
            this.cpf = cpf;
        }
        public decimal GetCpf() { return cpf; }
    }
}
