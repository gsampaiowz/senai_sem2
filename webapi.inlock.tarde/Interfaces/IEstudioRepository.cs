using webapi.inlock.tarde.Domains;

namespace webapi.inlock.tarde.Interfaces
    {
    public interface IEstudioRepository
        {
        List<Estudio> ListarTodos();
        Estudio BuscarPorId(Guid id);
        void Cadastrar(Estudio novoEstudio);
        void Atualizar(Guid id, Estudio estudioAtualizado_);
        void Deletar(Guid id);
        List<Estudio> ListarComJogos();
        }
    }
