using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
    {
    /// <summary>
    /// Interface responsável pelo repositório UsuarioRepository
    /// </summary>
    public interface IUsuarioRepository
        {
        /// <summary>
        /// método utilizado para buscar um usuário através do seu email e senha
        /// </summary>
        /// <param name="email"></param>
        /// <param name="senha"></param>
        /// <returns>Token JWT e expiration</returns>
        UsuarioDomain Login (string? email, string? senha);
        /// <summary>
        /// método utilizado para listar todos os usuários
        /// </summary>
        /// <returns></returns>
        List<UsuarioDomain> ListarTodos();
        /// <summary>
        /// método utilizado para buscar um usuário através do seu id
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        UsuarioDomain BuscarPorId(int idUsuario);
        /// <summary>
        /// método utilizado para cadastrar um novo usuário
        /// </summary>
        /// <param name="novoUsuario"></param>
        void Cadastrar(UsuarioDomain novoUsuario);
        /// <summary>
        /// método utilizado para atualizar um usuário existente passando o id pelo corpo da requisição
        /// </summary>
        /// <param name="usuarioAtualizado"></param>
        void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado);
        /// <summary>
        /// método utilizado para deletar um usuário existente
        /// </summary>
        /// <param name="idUsuario"></param>
        void Deletar(int idUsuario);
        /// <summary>
        /// método utilizado para atualizar um usuário existente passando o id pela url da requisição
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="usuarioAtualizado"></param>
        void AtualizarIdUrl(int idUsuario, UsuarioDomain usuarioAtualizado);
        }
    }
