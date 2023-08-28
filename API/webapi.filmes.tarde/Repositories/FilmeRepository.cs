using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
	{
	/// <summary>
	/// Classe responsável pelo repositório dos filmes
	/// </summary>
	public class FilmeRepository : IFilmeRepository
		{
		private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=FilmesTarde; User ID=sa; Pwd=Senai@134;";

		/// <summary>
		/// 
		/// </summary>
		/// <param name="filme"></param>
		public void AtualizarIdCorpo(FilmeDomain filme)
			{
			//Instância o Filme a ser atualizado
			filme = new()
				{
				IdFilme = filme.IdFilme,
				IdGenero = filme.IdGenero,
				Titulo = "",
				};

			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryUpdate = $"UPDATE Filme SET Titulo = (@Titulo) WHERE IdFilme LIKE {filme.IdFilme}";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryUpdate, con);

			cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

			//Abre a conexão com o banco de dados
			con.Open();

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// Atualiza um filme atraves do seu id, passando este pela URL
		/// </summary>
		/// <param name="id">Id do Filme a ser atualizado</param>
		/// <param name="filme">Objeto do Filme a ser atualizado</param>
		public void AtualizarIdUrl(int id, FilmeDomain filme)
			{
			//Instância o Filme a ser atualizado
			_ = new FilmeDomain()
				{
				IdGenero = 0,
				Titulo = "ERRO. FILME NAO ENCONTRADO",
				};

			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryUpdateById = $"UPDATE Filme SET Titulo = (@Titulo) WHERE IdFilme LIKE {id}";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryUpdateById, con);

			cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);

			//Abre a conexão com o banco de dados
			con.Open();

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// Busca um Filme pelo seu id
		/// </summary>
		/// <param name="id">Id do Filme a ser buscado</param>
		/// <returns>Filme que possui o id buscado</returns>
		public FilmeDomain BuscarPorId(int id)
			{
			//Instância o Filme a ser buscado
			FilmeDomain FilmeBuscado = new()
				{
				IdFilme = id,
				IdGenero = 0,
				Titulo = "",
				};

			//Declara a SqlConnection passando a String de Conexão como parâmetro
			using (SqlConnection con = new(StringConexao))
				{
				//Declara a instrução a ser executada
				string queryFindById = $"SELECT * FROM Filme WHERE IdFilme LIKE {id}";

				//Abre a conexão com o banco de dados
				con.Open();

				//Declara o SqlDataReader para percorrer (ler) a tabela no banco de dados
				SqlDataReader rdr;

				//Declara o SqlCommand passando a query que será executada e a conexão
				using SqlCommand cmd = new(queryFindById, con);
				//Executa a query e armazena os dados no rdr
				rdr = cmd.ExecuteReader();

				//Enquanto houver registros para serem lidos no rdr, o laço se repetirá.
				if (rdr.Read())
					{
					FilmeBuscado = new()
						{
						//Atribui à propriedade IdFilme os valores das colunas
						IdFilme = Convert.ToInt32(rdr["IdFilme"]),
						IdGenero = Convert.ToInt32(rdr["IdGenero"]),
						Titulo = rdr["Titulo"].ToString(),
						};
					};
				};

			//Retorna a lista de gêneros
			return FilmeBuscado;
			}

		/// <summary>
		/// Cadadtrar um novo Filme
		/// </summary>
		/// <param name="novoFilme">Objeto com as informações que serão cadastradas</param>
		public void Cadastrar(FilmeDomain novoFilme)
			{
			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryInsert = $"INSERT INTO Filme(Titulo) VALUES (@Titulo)";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryInsert, con);

			//Defini o valor do parametro (variavel) incluido na query
			cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

			//Abre a conexão com o banco de dados
			con.Open();

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// Deleta um Filme atraves do seu id
		/// </summary>
		/// <param name="id">Id do Filme a ser deletado</param>
		public void Deletar(int id)
			{
			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryDelete = $"DELETE FROM Filme WHERE IdFilme LIKE {id}";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryDelete, con);

			//Abre a conexão com o banco de dados
			con.Open();

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// Retornar todos os gêneros cadastrados
		/// </summary>
		/// <returns>Uma lista de objetos</returns>
		public List<FilmeDomain> ListarTodos()
			{
			//Cria uma lista de gêneros para armazená-los
			List<FilmeDomain> ListaFilmes = new();

			//Declara a SqlConnection passando a String de Conexão como parâmetro
			using (SqlConnection con = new(StringConexao))
				{
				//Declara a instrução a ser executada
				string querySelectAll = "SELECT * FROM Filme";

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
					FilmeDomain Filme = new()
						{
						//Atribui à propriedade IdFilme os valores das colunas
						IdFilme = Convert.ToInt32(rdr["IdFilme"]),
						IdGenero = Convert.ToInt32(rdr["IdGenero"]),
						Titulo = rdr["Titulo"].ToString(),
						//Genero = rdr[3].ToString(),
						};

					//Adiciona o objeto criado dentro da lista
					ListaFilmes.Add(Filme);
					};
				}

			//Retorna a lista de gêneros
			return ListaFilmes;
			}
		}
	}
