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
		//private readonly string StringConexao = "Data Source = SAMPAIO; Initial Catalog=FilmesTarde; Integrated Security = True;";
		private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=FilmesTarde; User ID=sa; Pwd=Senai@134;";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="usuario"></param>
		public void AtualizarIdCorpo(UsuarioDomain usuario)
			{
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryUpdateIdBody = "UPDATE Usuario SET Email = (@Email), Senha = (@Senha), Permissao = (@Permissao) WHERE IdUsuario LIKE (@IdUsuario)";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryUpdateIdBody, con);

			//Abre a conexão com o banco de dados
			con.Open();

			cmd.Parameters.AddWithValue("@Email", usuario.Email);
			cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
			cmd.Parameters.AddWithValue("@Permissao", usuario.Permissao);
			cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="usuario"></param>
		public void AtualizarIdUrl(int id, UsuarioDomain usuario)
			{
			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryUpdateIdUrl = $"UPDATE Usuario SET Email = (@Email), Senha = (@Senha), Permissao = (@Permissao) WHERE IdUsuario LIKE (@IdUsuario)";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryUpdateIdUrl, con);

			cmd.Parameters.AddWithValue("@Email", usuario.Email);
			cmd.Parameters.AddWithValue("@Senha", usuario.Senha);
			cmd.Parameters.AddWithValue("@Permissao", usuario.Permissao);
			cmd.Parameters.AddWithValue("@IdUsuario", id);

			//Abre a conexão com o banco de dados
			con.Open();

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public UsuarioDomain BuscarPorId(int id) => ListarTodos().FirstOrDefault(usuario => usuario.IdUsuario == id)!;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="email"></param>
		/// <param name="senha"></param>
		/// <param name="permissao"></param>
		/// <returns></returns>
		public void Cadastrar(string? email, string? senha, bool? permissao)
			{
			using SqlConnection con = new(StringConexao);

			string queryRegister = $"INSERT INTO Usuario (Email, Senha, Permissao) VALUES (@Email, @Senha, @Permissao)";

			using SqlCommand cmd = new(queryRegister, con);

			cmd.Parameters.AddWithValue("@Email", email);
			cmd.Parameters.AddWithValue("@Senha", senha);
			cmd.Parameters.AddWithValue("@Permissao", permissao);

			con.Open();

			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public void Deletar(int id)
			{
			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryDelete = $"DELETE FROM Usuario WHERE IdUsuario LIKE {id}";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryDelete, con);

			//Abre a conexão com o banco de dados
			con.Open();

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}
		/// <summary>
		/// 
		/// </summary>
		/// <returns></returns>
		public List<UsuarioDomain> ListarTodos()
			{
			//Cria uma lista de gêneros para armazená-los
			List<UsuarioDomain> ListaUsuarios = new();

			//Declara a SqlConnection passando a String de Conexão como parâmetro
			using (SqlConnection con = new(StringConexao))
				{
				//Declara a instrução a ser executada
				string querySelectAll = "SELECT * FROM Usuario";

				//Abre a conexão com o banco de dados
				con.Open();

				//Declara o SqlDataReader para percorrer (ler) a tabela no banco de dados
				SqlDataReader rdr;

				//Declara o SqlCommand passando a query que será executada e a conexão
				using SqlCommand cmd = new(querySelectAll, con);
				//Executa a query e armazena os dados no rdr
				rdr = cmd.ExecuteReader();

				//Enquanto houver registros para serem lidos no rdr, o laço se repetirá.
				while (rdr.Read())
					{
					UsuarioDomain usuario = new()
						{
						//Atribui à propriedade IdUsuario os valores das colunas
						IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
						Email = rdr["Email"].ToString(),
						Senha = rdr["Senha"].ToString(),
						Permissao = Convert.ToBoolean(rdr["Permissao"])
						};

					//Adiciona o objeto criado dentro da lista
					ListaUsuarios.Add(usuario);
					};
				}
			//Retorna a lista de gêneros
			return ListaUsuarios;
			}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="email"></param>
		/// <param name="senha"></param>
		/// <returns></returns>
		/// <exception cref="NotImplementedException"></exception>
		public UsuarioDomain Login(string? email, string? senha)
			{
			using SqlConnection con = new(StringConexao);

			string queryLogin = $"SELECT IdUsuario, Email, Senha, Permissao FROM Usuario WHERE Email = (@email) AND Senha = (@senha)";

			using SqlCommand cmd = new(queryLogin, con);

			cmd.Parameters.AddWithValue("@email", email);
			cmd.Parameters.AddWithValue("@senha", senha);

			con.Open();

			SqlDataReader rdr = cmd.ExecuteReader();

			UsuarioDomain usuario = null!;

			if (rdr.Read())
				{

				usuario = new()
					{
					IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
					Email = rdr["Email"].ToString(),
					Permissao = Convert.ToBoolean(rdr["Permissao"]),
					};
				}

			return usuario;
			}
		}
	}



