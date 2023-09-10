using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
    {
    public class JogoDomain
        {
        public int IdJogo { get; set; }
        [Required(ErrorMessage = "O estúdio do jogo é obrigatório!")]
        public int IdEstudio { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "O nome do jogo é obrigatório!")]
        public string? Nome { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "A descrição do jogo é obrigatória")]
        public string? Descricao { get; set; }
        [Required(ErrorMessage = "A data de lançamento do jogo é obrigatória!")]
        public DateTime DataLancamento { get; set; }
        [Required(ErrorMessage = "O valor do jogo é obrigatório!")]
        public decimal Valor { get; set; }
        public EstudioDomain? Estudio { get; set; }
    }
    }
