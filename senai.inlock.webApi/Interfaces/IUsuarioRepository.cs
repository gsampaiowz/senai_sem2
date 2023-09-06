using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
    {
    public interface IUsuarioRepository
        {
        UsuarioDomain Login (string? email, string? senha);
        List<UsuarioDomain> ListarTodos();
        UsuarioDomain BuscarPorId(int idUsuario);
        void Cadastrar(UsuarioDomain novoUsuario);
        void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado);
        void Deletar(int idUsuario);
        void AtualizarIdUrl(int idUsuario, UsuarioDomain usuarioAtualizado);
        }
    }
