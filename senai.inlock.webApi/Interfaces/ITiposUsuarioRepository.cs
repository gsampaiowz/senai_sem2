using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
    {
    public interface ITiposUsuarioRepository
        {
        List<TiposUsuario> ListarTodos();
        TiposUsuario BuscarPorId(int idTipoUsuario);
        void Cadastrar(TiposUsuario novoTipoUsuario);
        void AtualizarIdCorpo(TiposUsuario tipoUsuarioAtualizado);
        void Deletar(int idTipoUsuario);
        void AtualizarIdUrl(int idTipoUsuario, TiposUsuario tipoUsuarioAtualizado);

        }
    }
