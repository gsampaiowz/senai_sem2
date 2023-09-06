using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
    {
    public class JogoRepository : IJogoRepository
        {

        private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=FilmesTarde; User ID=sa; Pwd=Senai@134;";

        public void AtualizarIdCorpo(JogoDomain jogoAtualizado)
            {
            throw new NotImplementedException();
            }

        public void AtualizarIdUrl(int idJogo, JogoDomain jogoAtualizado)
            {
            throw new NotImplementedException();
            }

        public JogoDomain BuscarPorId(int idJogo) => ListarTodos().FirstOrDefault(e => e.IdJogo == idJogo)!;
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

        public void Deletar(int idJogo)
            {
            using SqlConnection con = new(StringConexao);

            string queryDelete = "DELETE FROM Jogo WHERE IdJogo = @IdJogo";

            using SqlCommand cmd = new(queryDelete, con);

            cmd.Parameters.AddWithValue("@IdJogo", idJogo);

            con.Open();

            cmd.ExecuteNonQuery();
            }

        public List<JogoDomain> ListarTodos()
            {
            using SqlConnection con = new(StringConexao);

            string querySelectAll = "SELECT IdJogo, Nome, Descricao, DataLancamento, Valor, IdEstudio FROM Jogo";

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
                    IdEstudio = Convert.ToInt32(rdr[5])
                    };

                listaJogos.Add(jogo);
                }

            return listaJogos;
            }
        }
    }
