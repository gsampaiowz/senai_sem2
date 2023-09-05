using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
    {
    public interface IEstudioRepository
        {
        List<EstudioDomain> ListarTodos();
        EstudioDomain BuscarPorId(int idEstudio);
        void Cadastrar(EstudioDomain novoEstudio);
        void AtualizarIdCorpo(EstudioDomain estudioAtualizado);
        void Deletar(int idEstudio);
        void AtualizarIdUrl(int idEstudio, EstudioDomain estudioAtualizado);
        }
    }
