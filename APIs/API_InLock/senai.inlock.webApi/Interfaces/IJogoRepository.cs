using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
    {
    /// <summary>
    /// Interface responsável pelo repositório JogoRepository
    /// </summary>
    public interface IJogoRepository
        {
        /// <summary>
        /// Método utilizado para listar todos os jogos
        /// </summary>
        /// <returns></returns>
        List<JogoDomain> ListarTodos();
        /// <summary>
        /// Método utilizado para buscar um jogo através do seu id
        /// </summary>
        /// <param name="idJogo"></param>
        /// <returns></returns>
        JogoDomain BuscarPorId(int idJogo);
        /// <summary>
        /// método utilizado para cadastrar um novo jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        void Cadastrar(JogoDomain novoJogo);
        /// <summary>
        /// método utilizado para deletar um jogo existente
        /// </summary>
        /// <param name="idJogo"></param>
        void Deletar(int idJogo);
        }
    }
