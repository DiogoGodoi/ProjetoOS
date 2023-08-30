namespace MODEL
{
    public class ClientePJ: Cliente
    {
        private decimal cnpj { get; set; }
        private string logradouro { get; set; }

        public bool SetEndereco(string logradouro)
        {

            if (logradouro.Length <= 15)
            {
                this.logradouro = logradouro;
                return true;
            }
            else
            {
                return false; ;
            }

        }
        public string GetEndereco() { return logradouro; }
        public bool SetCnpj (string cnpj) { 
        
            if(cnpj.Length == 14)
            {
                this.cnpj = decimal.Parse(cnpj);
                return true;
            }
            else
            {
                return false; ;
            }

        }
        public decimal GetCnpj() { return cnpj; }
    }
}
