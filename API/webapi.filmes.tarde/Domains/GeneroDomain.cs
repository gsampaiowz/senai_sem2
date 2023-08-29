using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
	/// <summary>
	/// Classe que representa a entidade(tabela) Genero
	/// </summary>
	public class GeneroDomain
	{
		/// <summary>
		/// Atributo IdGenero
		/// </summary>
		public int IdGenero { get; set; }
		/// <summary>
		/// Atributo Nome
		/// </summary>
		[Required(ErrorMessage = "O nome do gênero é obrigatório!")]
		[StringLength(50)]
		public string? Nome { get; set; }
	}   
}
