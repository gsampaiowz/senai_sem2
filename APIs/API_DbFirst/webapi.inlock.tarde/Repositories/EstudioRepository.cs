using Microsoft.EntityFrameworkCore;
using webapi.inlock.tarde.Contexts;
using webapi.inlock.tarde.Domains;
using webapi.inlock.tarde.Interfaces;

namespace webapi.inlock.tarde.Repositories
    {
    public class EstudioRepository : IEstudioRepository
        {
        readonly InLockContext ctx = new();
        public void Atualizar(Guid id, Estudio estudioAtualizado_)
            {
            Estudio estudioBuscado = BuscarPorId(id);

            if (estudioBuscado != null)
                {
                estudioBuscado.Nome = estudioAtualizado_.Nome;

                ctx.Estudios.Update(estudioBuscado);

                ctx.SaveChanges();
                }
            }

        public Estudio BuscarPorId(Guid id) => ctx.Estudios.ToList().Find(e => e.IdEstudio == id)!;

        public void Cadastrar(Estudio novoEstudio)
            {
            ctx.Estudios.Add(novoEstudio);

            ctx.SaveChanges();
            }
        public void Deletar(Guid id)
            {
            ctx.Estudios.Remove(BuscarPorId(id));
            ctx.SaveChanges();
            }


        public List<Estudio> ListarComJogos() => ctx.Estudios.Include(e => e.Jogos).ToList();

        public List<Estudio> ListarTodos() => ctx.Estudios.ToList();
        }
    }
