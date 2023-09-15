using webapi.inlock.codefirst.Domains;

namespace webapi.inlock.codefirst.Interfaces
    {
    public interface IUsuarioRepository
        {
        Usuario BuscarUsuario(String email, String senha);
        void Cadastrar(Usuario novoUsuario);
        }
    }
