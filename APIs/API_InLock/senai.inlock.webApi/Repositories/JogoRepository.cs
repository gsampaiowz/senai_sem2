using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    /// <summary>
    /// classe responsável pelo repositório dos jogos
    /// </summary>
    public class JogoRepository : IJogoRepository
    {

        private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=inlock_games; User ID=sa; Pwd=Senai@134;";
        //private readonly string StringConexao = "Data Source = SAMPAIO; Initial Catalog=inlock_games; Integrated Security = True;";

        /// <summary>
        /// metodo responsável por buscar um jogo pelo seu id
        /// </summary>
        /// <param name="idJogo"></param>
        /// <returns></returns>
        public JogoDomain BuscarPorId(int idJogo) => ListarTodos().FirstOrDefault(e => e.IdJogo == idJogo)!;
        /// <summary>
        /// método responsável por cadastrar um novo jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        public void Cadastrar(JogoDomain novoJogo)
        {
            using SqlConnection con = new(StringConexao);

            string queryInsert = "INSERT INTO Jogo(Nome, Descricao, DataLancamento, Valor, IdEstudio) VALUES (@Nome, @Descricao, @DataLancamento, @Valor, @IdEstudio)";

            using SqlCommand cmd = new(queryInsert, con);

            cmd.Parameters.AddWithValue("@Nome", novoJogo.Nome);
            cmd.Parameters.AddWithValue("@Descricao", novoJogo.Descricao);
            cmd.Parameters.AddWithValue("@DataLancamento", novoJogo.DataLancamento);
            cmd.Parameters.AddWithValue("@Valor", novoJogo.Valor);
            cmd.Parameters.AddWithValue("@IdEstudio", novoJogo.IdEstudio);

            con.Open();

            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// método responsável por deletar um jogo
        /// </summary>
        /// <param name="idJogo"></param>
        public void Deletar(int idJogo)
        {
            using SqlConnection con = new(StringConexao);

            string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdJogo";

            using SqlCommand cmd = new(queryDelete, con);

            cmd.Parameters.AddWithValue("@IdJogo", idJogo);

            con.Open();

            cmd.ExecuteNonQuery();
        }
        /// <summary>
        /// método responsável por listar todos os jogos
        /// </summary>
        /// <returns></returns>
        public List<JogoDomain> ListarTodos()
        {
            using SqlConnection con = new(StringConexao);

            string querySelectAll = "SELECT J.IdJogo, J.Nome, J.Descricao, J.DataLancamento, J.Valor, J.IdEstudio, E.Nome From Jogo AS J INNER JOIN Estudio AS E ON J.IdEstudio = E.IdEstudio;";

            using SqlCommand cmd = new(querySelectAll, con);

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            List<JogoDomain> listaJogos = new();

            while (rdr.Read())
            {
                JogoDomain jogo = new()
                {
                    IdJogo = Convert.ToInt32(rdr[0]),
                    Nome = rdr[1].ToString(),
                    Descricao = rdr[2].ToString(),
                    DataLancamento = Convert.ToDateTime(rdr[3]),
                    Valor = Convert.ToDecimal(rdr[4]),
                    IdEstudio = Convert.ToInt32(rdr[5]),
                    Estudio = new EstudioDomain()
                    {
                        IdEstudio = Convert.ToInt32(rdr[5]),
                        Nome = rdr[6].ToString()
                    }
                };

                listaJogos.Add(jogo);
            }

            return listaJogos;
        }
    }
}
