using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
    {
    /// <summary>
    /// Classe que representa a entidade (tabela) TIPOUSUARIO
    /// </summary>
    public class TiposUsuarioDomain
        {
        /// <summary>
        /// propriedade que representa o id do tipo de usuário
        /// </summary>
        public int IdTipoUsuario { get; set; }
        /// <summary>
        /// propriedade que representa o título do tipo de usuário
        /// </summary>
        public string? Titulo { get; set; }
    }
    }
