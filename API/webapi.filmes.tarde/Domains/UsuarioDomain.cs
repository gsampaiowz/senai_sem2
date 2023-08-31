using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
	{
	/// <summary>
	/// 
	/// </summary>
	public class UsuarioDomain
		{
		/// <summary>
		/// 
		/// </summary>
		public int IdUsuario { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
		[StringLength(255, MinimumLength = 6, ErrorMessage = "O seu e-mail deve ter de 6 a 255 caracteres!")]
		[EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
		public string? Email { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Required(ErrorMessage = "A senha do usuário é obrigatória!")]
		[StringLength(128, MinimumLength = 8, ErrorMessage = "A sua senha deve ter de 8 a 128 caracteres!")]
		public string? Senha { get; set; }
		/// <summary>
		/// 
		///</summary>
		[Required(ErrorMessage = "O tipo de permissão do usuário é obrigatório!")]
		public bool Permissao { get; set; }
		}
	}
