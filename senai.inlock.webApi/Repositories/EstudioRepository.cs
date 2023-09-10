using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
    {
    public class EstudioRepository : IEstudioRepository
        {

        private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog = inlock_games; User ID=sa; Pwd=Senai@134;";
        //private readonly string StringConexao = "Data Source = SAMPAIO; Initial Catalog = inlock_games; Integrated Security = True;";
        public void AtualizarIdCorpo(EstudioDomain estudioAtualizado)
            {
            using SqlConnection con = new(StringConexao);
            }

        public void AtualizarIdUrl(int idEstudio, EstudioDomain estudioAtualizado)
            {
            using SqlConnection con = new(StringConexao);

            }

        public EstudioDomain BuscarPorId(int idEstudio) => ListarTodos().FirstOrDefault(e => e.IdEstudio == idEstudio)!;

        public void Cadastrar(EstudioDomain novoEstudio)
            {
            using SqlConnection con = new(StringConexao);

            string queryInsert = "INSERT INTO Estudio(Nome) VALUES (@Nome)";

            con.Open();

            using SqlCommand cmd = new(queryInsert, con);

            cmd.Parameters.AddWithValue("@Nome", novoEstudio.Nome);

            con.Open();

            cmd.ExecuteNonQuery();
            }

        public void Deletar(int idEstudio)
            {
            using SqlConnection con = new(StringConexao);

            string queryDelete = "DELETE FROM Estudio WHERE IdEstudio = @IdEstudio";

            using SqlCommand cmd = new(queryDelete, con);

            cmd.Parameters.AddWithValue("@IdEstudio", idEstudio);

            con.Open();

            cmd.ExecuteNonQuery();
            }

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
                    Nome = rdr[1].ToString()
                    };

                listaEstudios.Add(estudio);
                }

            return listaEstudios;
            }
        }
    }
