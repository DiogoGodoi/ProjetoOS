namespace MODEL
{
    public class Servico {

        private int codServico { get; set; }
        private string descricao { get; set; }
        private double preco { get; set; }
        public Servico(){
        }
        public int GetCodServico() { return this.codServico; }
        public string GetDescicao() { return this.descricao; }
        public double GetPreco() { return this.preco; }

    }
}