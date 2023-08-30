namespace MODEL
{
    public class ClientePF: Cliente
    {
        private decimal cpf { get; set; }
        public ClientePF() { }
        public bool SetCnpjf(string cpf)
        {

            if (cpf.Length <= 11)
            {
                this.cpf = decimal.Parse(cpf);
                return true;
            }
            else
            {
                return false; ;
            }

        }
        public decimal GetCpf() { return cpf; }
    }
}
