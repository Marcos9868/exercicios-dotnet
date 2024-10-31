namespace ApiCatalogo.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } =  string.Empty;        
        public string Descricao { get; set; } =  string.Empty;        
        public decimal Preco { get; set; } =  0_0;        
        public string ImagemUrl { get; set; } =  string.Empty;
        public float Estoque { get; set; }        
        public DateTime DataCadastro { get; set; } =  DateTime.Now;        
    }
}