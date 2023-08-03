namespace MODEL
{
    public class Defeito {

        private int codDefeito { get; set; }
        private string defeito { get; set; }
        public Defeito() {}
        public int GetCodDefeito() { return this.codDefeito; }
        public string GetDefeito() { return this.defeito; }

    }
}