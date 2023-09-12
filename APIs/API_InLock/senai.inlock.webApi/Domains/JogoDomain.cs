using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
    {
    /// <summary>
    /// Classe que representa a entidade (tabela) JOGO
    /// </summary>
    public class JogoDomain
        {
        /// <summary>
        /// Propriedade que representa o id do jogo
        /// </summary>
        public int IdJogo { get; set; }
        /// <summary>
        /// propriedade que representa o id do estúdio
        /// </summary>
        [Required(ErrorMessage = "O estúdio do jogo é obrigatório!")]
        public int IdEstudio { get; set; }
        /// <summary>
        /// propriedade que representa o nome do jogo
        /// </summary>
        [StringLength(100)]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string? Nome { get; set; }
        /// <summary>
        /// propriedade que representa a descrição do jogo
        /// </summary>
        [StringLength(100)]
        [Required(ErrorMessage = "A descrição do jogo é obrigatória")]
        public string? Descricao { get; set; }
        /// <summary>
        /// propriedade que representa a data de lançamento do jogo
        /// </summary>
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime DataLancamento { get; set; }
        /// <summary>
        /// propriedade que representa o valor do jogo
        /// </summary>
        [Required(ErrorMessage = "O valor do jogo é obrigatório!")]
        public decimal Valor { get; set; }
        /// <summary>
        /// propriedade que representa o estúdio do jogo
        /// </summary>
        public EstudioDomain? Estudio { get; set; }
    }
    }
