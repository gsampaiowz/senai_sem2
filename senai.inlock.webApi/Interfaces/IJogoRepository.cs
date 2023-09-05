using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
    {
    public interface IJogoRepository
        {
        List<JogoDomain> ListarTodos();
        JogoDomain BuscarPorId(int idJogo);
        void Cadastrar(JogoDomain novoJogo);
        void AtualizarIdCorpo(JogoDomain jogoAtualizado);
        void Deletar(int idJogo);
        void AtualizarIdUrl(int idJogo, JogoDomain jogoAtualizado);
        }
    }
