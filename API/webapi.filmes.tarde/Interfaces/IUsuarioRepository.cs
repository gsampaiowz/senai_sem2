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
		}
	}
