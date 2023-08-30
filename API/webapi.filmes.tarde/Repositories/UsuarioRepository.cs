using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
	{
	/// <summary>
	/// 
	/// </summary>
	public class UsuarioRepository : IUsuarioRepository
		{
		private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=FilmesTarde; User ID=sa; Pwd=Senai@134;";
		/// <summary>
		/// 
		/// </summary>
		/// <param name="email"></param>
		/// <param name="senha"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public UsuarioDomain Login(string email, string senha)
			{
			using SqlConnection con = new(StringConexao);

			string queryLogin = $"SELECT IdUsuario, Email, Senha, Permissao FROM Usuario WHERE Email = (@email) AND Senha = (@senha)";

			using SqlCommand cmd = new(queryLogin, con);

			cmd.Parameters.AddWithValue("@email", email);
			cmd.Parameters.AddWithValue("@senha", senha);

			con.Open();

			cmd.ExecuteNonQuery();

			SqlDataReader rdr = cmd.ExecuteReader();

			UsuarioDomain usuario = null!;

			if (rdr.Read())
				{

				usuario = new()
					{
					IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
					Email = rdr["Email"].ToString(),
					Senha = rdr["Senha"].ToString(),
					Permissao = Convert.ToBoolean(rdr["Permissao"]),
					};
				}

			return usuario;
			}
		}
	}
