using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
    {
    [Table("Estudio")]
    public class Estudio
        {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "Nome obrigatório!")]
        [Column(TypeName = "VARCHAR(150)")]
        [StringLength(100)]
        public string? Nome { get; set; }
        
        //ref da lista de jogo
        public List<Jogo>? Jogos { get; set; }
        }
    }
