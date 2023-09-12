using System.Data.SqlClient;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;

namespace webapi.filmes.tarde.Repositories
	{
	/// <summary>
	/// Classe responsável pelo repositório dos gêneros
	/// </summary>
	public class GeneroRepository : IGeneroRepository
		{
		/// <summary>
		/// String de conexão com o banco de dados que recebe os seguintes parâmetros:
		/// Data Source : Nome do servidor do banco
		/// Initial Catalog: Nome do banco de dados
		/// Autenticação
		///     - windows : Integrated Security = True
		///     - SqlServer : User Id = sa; Pwd = Senha
		/// </summary>
		//private readonly string StringConexao = "Data Source = SAMPAIO; Initial Catalog=FilmesTarde; Integrated Security = True;";
		private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=FilmesTarde; User ID=sa; Pwd=Senai@134;";

		/// <summary>
		/// Atualiza um genero atraves do seu id, passando este pelo corpo JSON
		/// </summary>
		/// <param name="genero">Objeto do genero a ser atualizado</param>
		public void AtualizarIdCorpo(GeneroDomain genero)
			{
			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryUpdateIdBody = $"UPDATE Genero SET Nome = (@Nome) WHERE IdGenero LIKE (@IdGenero)";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryUpdateIdBody, con);

			cmd.Parameters.AddWithValue("@Nome", genero.Nome);
			cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

			//Abre a conexão com o banco de dados
			con.Open();

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// Atualiza um genero atraves do seu id, passando este pela URL
		/// </summary>
		/// <param name="id">Id do genero a ser atualizado</param>
		/// <param name="genero">Objeto do genero a ser atualizado</param>
		public void AtualizarIdUrl(int id, GeneroDomain genero)
			{
			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryUpdateIdUrl = $"UPDATE Genero SET Nome = (@Nome) WHERE IdGenero LIKE (@IdGenero)";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryUpdateIdUrl, con);

			cmd.Parameters.AddWithValue("@Nome", genero.Nome);
			cmd.Parameters.AddWithValue("@IdGenero", id);

			//Abre a conexão com o banco de dados
			con.Open();

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// Busca um genero pelo seu id
		/// </summary>
		/// <param name="id">Id do genero a ser buscado</param>
		/// <returns>Genero que possui o id buscado</returns>
		public GeneroDomain BuscarPorId(int id) => ListarTodos().FirstOrDefault(genero => genero.IdGenero == id)!;

		/// <summary>
		/// Cadadtrar um novo genero
		/// </summary>
		/// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
		public void Cadastrar(GeneroDomain novoGenero)
			{
			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryInsert = $"INSERT INTO Genero(Nome) VALUES (@Nome)";

			//Declara o SqlCommand passando a query que será executada e a conexão
			using SqlCommand cmd = new(queryInsert, con);

			//Defini o valor do parametro (variavel) incluido na query
			cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);

			//Abre a conexão com o banco de dados
			con.Open();

			//Apenas executa a instrução (query/consulta)
			cmd.ExecuteNonQuery();
			}

		/// <summary>
		/// Deleta um genero atraves do seu id
		/// </summary>
		/// <param name="id">Id do genero a ser deletado</param>
		public void Deletar(int id)
			{
			//Declara a SqlConnection passando a string de conexão como parametro
			using SqlConnection con = new(StringConexao);

			//Declara a instrução a ser executada
			string queryDelete = $"DELETE FROM Genero WHERE IdGenero LIKE {id}";

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
		public List<GeneroDomain> ListarTodos()
			{
			//Cria uma lista de gêneros para armazená-los
			List<GeneroDomain> ListaGeneros = new();

			//Declara a SqlConnection passando a String de Conexão como parâmetro
			using (SqlConnection con = new(StringConexao))
				{
				//Declara a instrução a ser executada
				string querySelectAll = "SELECT * FROM Genero";

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
					GeneroDomain genero = new()
						{
						//Atribui à propriedade IdGenero os valores das colunas
						IdGenero = Convert.ToInt32(rdr["IdGenero"]),
						Nome = rdr["Nome"].ToString(),
						};

					//Adiciona o objeto criado dentro da lista
					ListaGeneros.Add(genero);
					};
				}

			//Retorna a lista de gêneros
			return ListaGeneros;
			}
		}
	}
