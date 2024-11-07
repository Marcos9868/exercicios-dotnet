using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalogo.Models
{
    public class Produto
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(80)]
        public string Nome { get; set; } =  string.Empty;        
        [Required]
        [StringLength(300)]
        public string Descricao { get; set; } =  string.Empty;        
        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; } =  0_0;        
        [Required]
        [StringLength(300)]
        public string ImagemUrl { get; set; } =  string.Empty;
        public float Estoque { get; set; }        
        public DateTime DataCadastro { get; set; } =  DateTime.Now; 
        public int CategoriaId { get; set; }
        [JsonIgnore]
        public Categoria? Categoria { get; set; }       
    }
}