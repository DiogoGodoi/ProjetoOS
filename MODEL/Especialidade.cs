namespace MODEL
{
    public class Especialidade {

       
        private int codEspecialidade { get; set; }
        private string nome { get; set; }
        public Especialidade(){
        }
        public int GetCodEspecialidade() { return this.codEspecialidade; }
        public string GetNome() { return this.nome; }

    }
}