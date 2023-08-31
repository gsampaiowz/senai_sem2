using webapi.filmes.tarde.Domains;

namespace webapi.filmes.tarde.Interfaces
	{
	/// <summary>
	/// 
	/// </summary>
	public interface IUsuarioRepository
		{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="email"></param>
		/// <param name="senha"></param>
		/// <returns></returns>
		UsuarioDomain Login(string email, string senha);
		/// <summary>
		/// 
		/// </summary>
		/// <param name="email"></param>
		/// <param name="senha"></param>
		/// <param name="permissao"></param>
		/// <returns></returns>
		void Cadastrar(string email, string senha, bool permissao);

		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		List<UsuarioDomain> ListarTodos();

		/// <summary>
		/// Buscar um objeto através do seu id
		/// </summary>
		/// <param name="id">Id do objeto a ser buscado</param>
		/// <returns>Objeto buscado</returns>
		UsuarioDomain BuscarPorId(int id);

		/// <summary>
		/// Atualizar um Usuario existente passando o id pelo corpo da requisição (JSON)
		/// </summary>
		/// <param name="Usuario">Objeto com as novas informações</param>
		void AtualizarIdCorpo(UsuarioDomain Usuario);

		/// <summary>
		/// Atualizar um Usuario existente passando o id na URL da requisição
		/// </summary>
		/// <param name="id">Id do objeto a ser atualizado</param>
		/// <param name="Usuario">Objeto com as novas informações</param>
		void AtualizarIdUrl(int id, UsuarioDomain Usuario);

		/// <summary>
		/// Deletar um Usuario existente
		/// </summary>
		/// <param name="id">Id do objeto a ser deletado</param>
		void Deletar(int id);
		}
	}
