using webapi.inlock.codefirst.Contexts;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Util;

namespace webapi.inlock.codefirst.Repositories
    {
    public class UsuarioRepository : IUsuarioRepository
        {
        private readonly InlockContext ctx;
        public UsuarioRepository()
            {
            ctx = new InlockContext();
            }
        
        public Usuario BuscarUsuario(string email, string senha)
            {
            try
                {
                var usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email);

                if (usuarioBuscado != null)
                    {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if(confere)
                        {
                        return usuarioBuscado;
                        };
                    }
                return null!;
                }
            catch (Exception)
                {

                throw new Exception("Erro ao buscar usuário.");
                }
            }

        public void Cadastrar(Usuario novoUsuario)
            {
            try
                {
                novoUsuario.Senha = Criptografia.GerarHash(novoUsuario.Senha!);

                ctx.Usuario.Add(novoUsuario);

                ctx.SaveChanges();
                }
            catch (Exception)
                {

                throw new Exception("Erro ao cadastrar usuário.");
                }
            }
        }
    }
