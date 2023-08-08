namespace MODEL {
    public class Cliente {
    private decimal cnpj { get; set; }
    private string nome { get; set; }
    private string telefone { get; set; }
    private string rua { get; set; }
    private string numero { get; set; }
    private string bairro { get; set; }
    private string cidade { get; set; }
    private string siglaEs { get; set; }
    public Cliente(decimal cnpj, string nome, string telefone, string rua, string numero, string bairro, string cidade, string siglaEs)
    {        
    this.cnpj = cnpj;
    this.nome = nome;
    this.telefone = telefone;
    this.rua = rua;
    this.numero = numero;
    this.bairro = bairro;
    this.cidade = cidade;
    this.siglaEs = siglaEs;
    }
    public decimal GetCnpj() { return this.cnpj; }
    public string GetNome() { return this.nome; }
    public string GetTelefone() { return this.telefone; }
    public string GetRua() { return this.rua; }
    public string GetNumero() { return this.numero; }
    public string GetBairro() { return this.bairro; }
    public string GetCidade() { return this.cidade; }
    public string GetSiglaEs() { return this.siglaEs; }
    }
}