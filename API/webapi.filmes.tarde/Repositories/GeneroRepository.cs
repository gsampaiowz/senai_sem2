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
        //private string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=FilmesTarde; Integrated Security = True;";
        private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=FilmesTarde; User ID=sa; Pwd=Senai@134;";
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int id)
        {
            //Instância o genero a ser buscado
            GeneroDomain generoBuscado = new();

            //Declara a SqlConnection passando a String de Conexão como parâmetro
            using (SqlConnection con = new(StringConexao))
            {
                //Declara a instrução a ser executada
                string queryFindById = "SELECT IdGenero, Nome FROM Genero";

                //Abre a conexão com o banco de dados
                con.Open();

                //Declara o SqlDataReader para percorrer (ler) a tabela no banco de dados
                SqlDataReader rdr;

                //Declara o SqlCommand passando a query que será executada e a conexão
                using SqlCommand cmd = new(queryFindById, con);
                //Executa a query e armazena os dados no rdr
                rdr = cmd.ExecuteReader();

                //Enquanto houver registros para serem lidos no rdr, o laço se repetirá.
                while (rdr.Read())
                {
                    if (Convert.ToInt32(rdr[0]) == id)
                    {
                        generoBuscado = new()
                        {
                            //Atribui à propriedade IdGenero o valor da primeira coluna
                            IdGenero = Convert.ToInt32(rdr[0]),
                            //Atribui à propriedade IdGenero o valor da primeira coluna
                            Nome = rdr[1].ToString(),
                        };

                    };
                };
            };

            //Retorna a lista de gêneros
            return generoBuscado;
        }
        /// <summary>
        /// Cadadtrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Declara a SqlConnection passando a string de conexão como parametro
            using (SqlConnection con = new(StringConexao))
            {

                //Declara a instrução a ser executada
                string queryInsert = $"INSERT INTO Genero(Nome) VALUES (' {novoGenero.Nome} ')";

                //Declara o SqlCommand passando a query que será executada e a conexão
                using SqlCommand cmd = new(queryInsert, con);

                //Abre a conexão com o banco de dados
                con.Open();

                //Apenas executa a instrução (query/consulta)
                cmd.ExecuteNonQuery();
            }
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
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
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";

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
                        //Atribui à propriedade IdGenero o valor da primeira coluna
                        IdGenero = Convert.ToInt32(rdr[0]),
                        //Atribui à propriedade IdGenero o valor da primeira coluna
                        Nome = rdr[1].ToString(),
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
