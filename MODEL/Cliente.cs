using API_EXTERNAS;

namespace MODEL {
    public class Cliente
    {
        //Atributos
        protected string nome { get; set; }
        protected ModelApiReceita dadosAPI { get; set; } 


        // Construtor para a classe Cliente que inicializa as propriedades.
        public Cliente()
        {
            dadosAPI = new ModelApiReceita();
        }


        //Setters
        public bool SetNome(string nome)
        {
            if(nome.Length <= 45 && nome.Length > 6)
            {
                this.nome = nome;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetLogradouro(string logradouro)
        {
            if (logradouro.Length > 5&& logradouro.Length <= 45)
            {
                this.dadosAPI.logradouro = logradouro;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetTelefone(string telefone)
        {
            if (telefone.Length <= 18 && telefone.Length > 10)
            {
                this.dadosAPI.telefone = telefone;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetNumero(string numero)
        {
            if (numero.Length <= 7 && numero.Length != 0)
            {
                this.dadosAPI.numero = numero;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetBairro(string bairro)
        {
            if (bairro.Length > 5 && bairro.Length <= 45)
            {
                this.dadosAPI.bairro = bairro;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetMunicipio(string municipio)
        {
            if (municipio.Length <= 35 && municipio.Length > 5)
            {
                this.dadosAPI.municipio = municipio;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool SetUf(string uf)
        {
            if(uf.Length == 2)
            {
                dadosAPI.uf = uf;
                return true;
            }
            else
            {
                return false;
            }
        }


        // Métodos para acessar as propriedades privadas.
        public string GetNome() { return this.nome; }
        public void SetDadosAPI(ModelApiReceita dadosApi) { this.dadosAPI = dadosApi; }
        public ModelApiReceita GetDadosAPI() { return this.dadosAPI; }
    }
}