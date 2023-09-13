using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
    {
    [Table("TipoUsuario")]
    public class TipoUsuario
        {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Título obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        public string? Titulo { get; set; }
        }
    }
