using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi.inlock.codefirst.Domains
    {
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
        {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Email obrigatório!")]
        [Column(TypeName = "VARCHAR(100)")]
        [StringLength(100)]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatória!")]
        [Column(TypeName = "VARCHAR(200)")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve conter de 6 a 60 caracteres!")]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "Tipo de usuário obrigatório!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuario? TipoUsuario { get; set; }
        }
    }
