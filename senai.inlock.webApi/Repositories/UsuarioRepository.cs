using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=inlock_games; User ID=sa; Pwd=Senai@134;";
        //private readonly string StringConexao = "Data Source = SAMPAIO; Initial Catalog=inlock_games; Integrated Security = True;";

        public void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado)
        {
            using SqlConnection con = new(StringConexao);

            //Declara a instrução a ser executada
            string queryUpdateIdBody = "UPDATE Usuario SET Email = (@Email), Senha = (@Senha), IdTipoUsuario = (@IdTipoUsuario) WHERE IdUsuario LIKE (@IdUsuario)";

            //Declara o SqlCommand passando a query que será executada e a conexão
            using SqlCommand cmd = new(queryUpdateIdBody, con);

            //Abre a conexão com o banco de dados
            con.Open();

            cmd.Parameters.AddWithValue("@Email", usuarioAtualizado.Email);
            cmd.Parameters.AddWithValue("@Senha", usuarioAtualizado.Senha);
            cmd.Parameters.AddWithValue("@IdTipoUsuario", usuarioAtualizado.IdTipoUsuario);
            cmd.Parameters.AddWithValue("@IdUsuario", usuarioAtualizado.IdUsuario);

            //Apenas executa a instrução (query/consulta)
            cmd.ExecuteNonQuery();
        }

        public void AtualizarIdUrl(int idUsuario, UsuarioDomain usuarioAtualizado)
        {
            //Declara a SqlConnection passando a string de conexão como parametro
            using SqlConnection con = new(StringConexao);

            //Declara a instrução a ser executada
            string queryUpdateIdUrl = $"UPDATE Usuario SET Email = (@Email), Senha = (@Senha), IdTipoUsuario = (@IdTipoUsuario) WHERE IdUsuario LIKE (@IdUsuario)";

            //Declara o SqlCommand passando a query que será executada e a conexão
            using SqlCommand cmd = new(queryUpdateIdUrl, con);

            cmd.Parameters.AddWithValue("@Email", usuarioAtualizado.Email);
            cmd.Parameters.AddWithValue("@Senha", usuarioAtualizado.Senha);
            cmd.Parameters.AddWithValue("@IdTipoUsuario", usuarioAtualizado.IdTipoUsuario);
            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

            //Abre a conexão com o banco de dados
            con.Open();

            //Apenas executa a instrução (query/consulta)
            cmd.ExecuteNonQuery();
        }

        public UsuarioDomain BuscarPorId(int idUsuario) => ListarTodos().FirstOrDefault(e => e.IdUsuario == idUsuario)!;

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using SqlConnection con = new(StringConexao);

            string queryInsert = "INSERT INTO Usuario(Email, Senha, IdTipoUsuario) VALUES (@Email, @Senha, @IdTipoUsuario)";

            using SqlCommand cmd = new(queryInsert, con);

            cmd.Parameters.AddWithValue("@Email", novoUsuario.Email);
            cmd.Parameters.AddWithValue("@Senha", novoUsuario.Senha);
            cmd.Parameters.AddWithValue("@IdTipoUsuario", novoUsuario.IdTipoUsuario);

            con.Open();

            cmd.ExecuteNonQuery();
        }

        public void Deletar(int idUsuario)
        {
            using SqlConnection con = new(StringConexao);

            string queryDelete = "DELETE FROM Usuario WHERE IdUsuario = @IdUsuario";

            using SqlCommand cmd = new(queryDelete, con);

            cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

            con.Open();

            cmd.ExecuteNonQuery();
        }

        public List<UsuarioDomain> ListarTodos()
        {
            List<UsuarioDomain> listaUsuarios = new();

            using SqlConnection con = new(StringConexao);

            string querySelectAll = "SELECT U.IdUsuario, U.IdTipoUsuario, U.Email, U.Senha, TU.Titulo FROM Usuario AS U INNER JOIN TiposUsuario AS TU ON U.IdTipoUsuario = TU.IdTipoUsuario";

            using SqlCommand cmd = new(querySelectAll, con);

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                UsuarioDomain usuario = new()
                {
                    IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                    IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                    Email = rdr["Email"].ToString(),
                    Senha = rdr["Senha"].ToString(),
                    TipoUsuario = new TiposUsuarioDomain()
                    {
                        IdTipoUsuario = Convert.ToInt32(rdr["IdTipoUsuario"]),
                        Titulo = rdr[4].ToString()
                    }
                };

                listaUsuarios.Add(usuario);
            }

            return listaUsuarios;
        }

        public UsuarioDomain Login(string? email, string? senha)
        {
            using SqlConnection con = new(StringConexao);

            string queryLogin = "SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuario WHERE Email = @Email AND Senha = @Senha";

            using SqlCommand cmd = new(queryLogin, con);

            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Senha", senha);

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            UsuarioDomain usuarioBuscado = null!;

            if (rdr.Read())
            {
                usuarioBuscado.IdUsuario = Convert.ToInt32(rdr[0]);
                usuarioBuscado.Email = rdr[1].ToString();
                usuarioBuscado.IdTipoUsuario = Convert.ToInt32(rdr[3]);
            }
            return usuarioBuscado;
        }
    }
}
