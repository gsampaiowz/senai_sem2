using Microsoft.EntityFrameworkCore;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
    {
    public class EstudioRepository : IEstudioRepository
        {
        InLockContext ctx = new();
        public void Atualizar(Guid id, Estudio estudioAtualizado_)
            {
            throw new NotImplementedException();
            }

        public Estudio BuscarPorId(Guid id)
            {
            throw new NotImplementedException();
            }

        public void Cadastrar(Estudio novoEstudio)
            {
            throw new NotImplementedException();
            }

        public void Deletar(Guid id)
            {
            throw new NotImplementedException();
            }

        public List<Estudio> ListarComJogos() => ctx.Estudios.Include(e => e.Jogos).ToList();

        public List<Estudio> ListarTodos() => ctx.Estudios.ToList();
        }
    }
