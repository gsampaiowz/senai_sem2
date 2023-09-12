using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
    {
    /// <summary>
    /// classe responsável pelo repositório dos estúdios
    /// </summary>
    public class EstudioRepository : IEstudioRepository
        {

        //private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog = inlock_games; User ID=sa; Pwd=Senai@134;";
        private readonly string StringConexao = "Data Source = SAMPAIO; Initial Catalog = inlock_games; Integrated Security = True;";

        /// <summary>
        /// método responsável por buscar um estúdio pelo seu id
        /// </summary>
        /// <param name="idEstudio"></param>
        /// <returns></returns>
        public EstudioDomain BuscarPorId(int idEstudio) => ListarTodos().FirstOrDefault(e => e.IdEstudio == idEstudio)!;
        /// <summary>
        /// método responsável por cadastrar um novo estúdio
        /// </summary>
        /// <param name="novoEstudio"></param>
        public void Cadastrar(EstudioDomain novoEstudio)
            {
            using SqlConnection con = new(StringConexao);

            string queryInsert = "INSERT INTO Estudio(Nome) VALUES (@Nome)";

            con.Open();

            using SqlCommand cmd = new(queryInsert, con);

            cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

            cmd.ExecuteNonQuery();
            }
        /// <summary>
        /// método responsável por deletar um estúdio
        /// </summary>
        /// <param name="idEstudio"></param>
        public void Deletar(int idEstudio)
            {
            using SqlConnection con = new(StringConexao);

            string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";

            using SqlCommand cmd = new(queryDelete, con);

            cmd.Parameters.AddWithValue("@IdEstudio", idEstudio);

            con.Open();

            cmd.ExecuteNonQuery();
            }
        /// <summary>
        /// método responsável por listar todos os estúdios
        /// </summary>
        /// <returns></returns>
        public List<EstudioDomain> ListarTodos()
            {

            List<EstudioDomain> listaEstudios = new();

            using SqlConnection con = new(StringConexao);

            string querySelectAll = "SELECT * FROM Estudio";

            using SqlCommand cmd = new(querySelectAll, con);

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
                {
                EstudioDomain estudio = new()
                    {
                    IdEstudio = Convert.ToInt32(rdr[0]),
                    Nome = rdr[1].ToString(),
                    ListaJogos = new List<JogoDomain>()
                    };

                using SqlConnection conJogos = new(StringConexao);

                string querySelectAllJogos = "SELECT * FROM Jogo WHERE IdEstudio = @IdEstudio";

                using SqlCommand cmdJogos = new(querySelectAllJogos, conJogos);

                cmdJogos.Parameters.AddWithValue("@IdEstudio", estudio.IdEstudio);

                conJogos.Open();

                SqlDataReader rdrJogos = cmdJogos.ExecuteReader();

                while (rdrJogos.Read())
                {
                    JogoDomain jogo = new()
                    {
                        IdJogo = Convert.ToInt32(rdrJogos[0]),
                        IdEstudio = Convert.ToInt32(rdrJogos[1]),
                        Nome = rdrJogos[2].ToString(),
                        Descricao = rdrJogos[3].ToString(),
                        DataLancamento = Convert.ToDateTime(rdrJogos[4]),
                        Valor = Convert.ToDecimal(rdrJogos[5]),
                    };
                    estudio.ListaJogos.Add(jogo);
                    }

                listaEstudios.Add(estudio);
                }

            return listaEstudios;
            }
        }
    }
