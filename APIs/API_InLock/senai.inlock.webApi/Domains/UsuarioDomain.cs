using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
    {
    /// <summary>
    /// Classe que representa a entidade (tabela) USUARIO
    /// </summary>
    public class UsuarioDomain
        {
        /// <summary>
        /// Propriedade que representa o id do usuário
        /// </summary>
        public int IdUsuario { get; set; }
        /// <summary>
        /// Propriedade que representa o id do tipo de usuário
        /// </summary>
        [Required(ErrorMessage = "O tipo do usuário é obrigatório!")]
        public int IdTipoUsuario { get; set; }
        /// <summary>
        /// Propriedade que representa o email do usuário
        /// </summary>
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        [StringLength(100, ErrorMessage = "O e-mail do usuário deve conter no máximo 256 caracteres!")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string? Email { get; set; }
        /// <summary>
        /// Propriedade que representa a senha do usuário
        /// </summary>
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "A sua senha deve ter de 8 a 128 caracteres!")]
        public string? Senha { get; set; }
        /// <summary>
        /// Propriedade que representa o tipo de usuário
        /// </summary>
        public TiposUsuarioDomain? TipoUsuario { get; set; }
        }
    }
