using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
    {
    [Table("Jogo")]
    public class Jogo
        {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Nome obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Descrição obrigatória!")]
        [Column(TypeName = "TEXT")]
        [StringLength(100)]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Data de lançamento obrigatória!")]
        [Column(TypeName = "DATE")]
        public DateTime DataLancamento { get; set; }

        [Required(ErrorMessage = "Valor obrigatório!")]
        [Column(TypeName = "SMALLMONEY")]
        public decimal Valor { get; set; }

        public Guid IdEstudio { get; set; }

        //ref. da tabela Estúdio - FK
        [ForeignKey("IdEstudio")]
        public Estudio? Estudio { get; set; }
        }
    }
