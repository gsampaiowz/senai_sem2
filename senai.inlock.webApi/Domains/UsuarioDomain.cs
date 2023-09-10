using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
    {
    public class UsuarioDomain
        {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "O tipo do usuário é obrigatório!")]
        public int IdTipoUsuario { get; set; }
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]

        public string? Email { get; set; }
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(128, MinimumLength = 8, ErrorMessage = "A sua senha deve ter de 8 a 128 caracteres!")]
        public string? Senha { get; set; }
        public TiposUsuarioDomain? TipoUsuario { get; set; }
        }
    }
