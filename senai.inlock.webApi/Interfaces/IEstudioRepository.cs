using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
    {
    /// <summary>
    /// Interface responsável pelo repositório EstudioRepository
    /// </summary>
    public interface IEstudioRepository
        {
        /// <summary>
        /// Método utilizado para listar todos os estúdios
        /// </summary>
        /// <returns>Lista de estudios</returns>
        List<EstudioDomain> ListarTodos();
        /// <summary>
        /// Método utilizado para buscar um estúdio através do seu id
        /// </summary>
        /// <param name="idEstudio"></param>
        /// <returns>Estudio buscado</returns>
        EstudioDomain BuscarPorId(int idEstudio);
        /// <summary>
        /// Método utilizado para cadastrar um novo estúdio
        /// </summary>
        /// <param name="novoEstudio"></param>
        void Cadastrar(EstudioDomain novoEstudio);
        /// <summary>
        /// Método utilizado para deletar um estúdio existente
        /// </summary>
        /// <param name="idEstudio"></param>
        void Deletar(int idEstudio);
        }
    }
