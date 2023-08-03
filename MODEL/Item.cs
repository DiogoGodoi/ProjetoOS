namespace MODEL
{
    public class Item {

        private int codItem;

        private string descicao;

        private string tipoUn;

        private double preco;

        public Item() {
        }
        public int GetCodItem() { return this.codItem; }
        public string GetDescirao() { return this.descicao; }
        public string GetTipoUn() { return this.tipoUn; }
        public double GetPreco() { return this.preco; }

    }
}