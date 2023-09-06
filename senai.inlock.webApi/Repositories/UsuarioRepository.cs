using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using System.Data.SqlClient;

namespace senai.inlock.webApi.Repositories
    {
    public class UsuarioRepository : IUsuarioRepository
        {

        private readonly string StringConexao = "Data Source = NOTE10-S14\\SQLEXPRESS; Initial Catalog=FilmesTarde; User ID=sa; Pwd=Senai@134;";

        public void AtualizarIdCorpo(UsuarioDomain usuarioAtualizado)
            {
            throw new NotImplementedException();
            }

        public void AtualizarIdUrl(int idUsuario, UsuarioDomain usuarioAtualizado)
            {
            throw new NotImplementedException();
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
            using SqlConnection con = new(StringConexao);

            string querySelectAll = "SELECT IdUsuario, Email, Senha, IdTipoUsuario FROM Usuario";

            using SqlCommand cmd = new(querySelectAll, con);

            con.Open();

            SqlDataReader rdr = cmd.ExecuteReader();

            List<UsuarioDomain> listaUsuarios = new();

            while (rdr.Read())
                {
                UsuarioDomain usuario = new()
                    {
                    IdUsuario = Convert.ToInt32(rdr[0]),
                    Email = rdr[1].ToString(),
                    Senha = rdr[2].ToString(),
                    IdTipoUsuario = Convert.ToInt32(rdr[3])
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
