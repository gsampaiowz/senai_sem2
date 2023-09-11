using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
    {
    /// <summary>
    /// Classe que representa a entidade (tabela) ESTUDIO
    /// </summary>
    public class EstudioDomain
        {
        /// <summary>
        /// Propriedade que representa o id do estúdio
        /// </summary>
        public int IdEstudio { get; set; }
        /// <summary>
        /// Propriedade que representa o nome do estúdio
        /// </summary>
        [StringLength(100)]
        [Required(ErrorMessage = "O nome do estúdio é obrigatório!")]
        public string? Nome { get; set; }
    }
    }
