using System.ComponentModel.DataAnnotations;

namespace webapi.filmes.tarde.Domains
{
    /// <summary>
    /// Classe que representa a entidade(tabela) Filme
    /// </summary>
    public class FilmeDomain
    {
		/// <summary>
		/// Chave primaria
		/// </summary>
        public int IdFilme { get; set; }
		/// <summary>
		/// Titulo Filme
		/// </summary>
        [Required(ErrorMessage = "O título do filme é obrigatório!")]
        [StringLength(50)]
        public string? Titulo { get; set;}
		/// <summary>
		/// Genero Filme
		/// </summary>
		[Required(ErrorMessage = "O gênero do filme é obrigatório")]
        public int IdGenero { get; set; }
        /// <summary>
		/// Referência para a classe GeneroDomain
		/// </summary>
        public GeneroDomain? Genero { get; set; }
    }
}
