using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
{
	/// <summary>
	/// Interface responsável pelo repositório GeneroRepository
	/// Define os métodos que serão implementados pelo repositório
	/// </summary>
	public interface IGeneroRepository
	{
		//CRUD

		//TipoDeRetorno NomeMetodo(TipoParametro NomeParametro)

		/// <summary>
		/// Cadastrar um novo Gênero
		/// </summary>
		/// <param name="novoGenero">Objeto que será cadastrado</param>
		void Cadastrar(GeneroDomain novoGenero);

		/// <summary>
		/// Retornar todos os gêneros cadastrados
		/// </summary>
		/// <returns>Uma lista de objetos</returns>
		List<GeneroDomain> ListarTodos();

		/// <summary>
		/// Buscar um objeto através do seu id
		/// </summary>
		/// <param name="id">Id do objeto a ser buscado</param>
		/// <returns>Objeto buscado</returns>
		GeneroDomain BuscarPorId(int id);

		/// <summary>
		/// Atualizar um gênero existente passando o id pelo corpo da requisição (JSON)
		/// </summary>
		/// <param name="genero">Objeto com as novas informações</param>
		void AtualizarIdCorpo(GeneroDomain genero);

		/// <summary>
		/// Atualizar um gênero existente passando o id na URL da requisição
		/// </summary>
		/// <param name="id">Id do objeto a ser atualizado</param>
		/// <param name="genero">Objeto com as novas informações</param>
		void AtualizarIdUrl(int id, GeneroDomain genero);

		/// <summary>
		/// Deletar um gênero existente
		/// </summary>
		/// <param name="id">Id do objeto a ser deletado</param>
		void Deletar(int id);
	}
}
