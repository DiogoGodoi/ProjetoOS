namespace MODEL
{
    public class ClientePF: Cliente
    {
        private decimal cpf { get; set; }

        public ClientePF(decimal cpf, string nome, string telefone,
            string rua, string numero,
            string bairro, string cidade,
            string siglaEs) : base(nome, telefone, rua, numero, bairro, cidade, siglaEs)
        {
            this.cpf = cpf;
        }

        public decimal GetCpf() { return cpf; }
    }
}
