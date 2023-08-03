namespace MODEL
{
    public class Ordem {

        private int codOrdem { get; set; }

        private Cliente cliente { get; set; }

        private Usuario usuario { get; set; }

        //private List<Tecnico> tecnico { get; set; }

        //private List<Item> item { get; set; }

        //private List<Servico> servico { get; set; }

        //private List<Defeito> defeito { get; set; }

        //private DateTime dataAbertura { get; set; }

        //private DateTime dataFechamento { get; set; }

        public Ordem() {
        }

        public int GetCodOrdem() { return this.codOrdem; }
        public Cliente GetCliente() { return this.cliente;  }
        public Usuario GetUsuario() { return this.usuario; }
        //public List<Tecnico> GetTecnico() { return this.tecnico; }
        //public List<Item> GetItem() { return this.item; }
        //public List<Servico> GetServico() { return this.servico; }
        //public List<Defeito> GetDefeito() { return this.defeito; }
        //public DateTime GetDataAbertura() { return this.dataAbertura; }
        //public DateTime GetDataFechamento() { return this.dataFechamento; }

    }
}