namespace MODEL
{
    public class Tecnico {

        private int codTec { get; set; }
        private Especialidade especialidade { get; set; }
        private string nome { get; set; }
        public Tecnico() {
        }
        public int GetCodTec() { return this.codTec; }
        public Especialidade GetEspecialidade() { return this.especialidade; }
        public string GetNome() { return this.nome; }

    }
}