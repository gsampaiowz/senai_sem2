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
		[StringLength(255)]
		public string? Email { get; set; }
		/// <summary>
		/// 
		/// </summary>
		[Required(ErrorMessage = "A senha do usuário é obrigatória!")]
		[StringLength(128)]
		public string? Senha { get; set; }
		/// <summary>
		/// 
		///</summary>
		[Required(ErrorMessage = "O tipo de permissão do usuário é obrigatório!")]
		public bool Permissao { get; set; }
		}
	}
