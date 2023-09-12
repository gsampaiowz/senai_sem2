using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
    {
    /// <summary>
    /// controller responsável pelos endpoints referentes aos usuários
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
        {

        private IUsuarioRepository _usuarioRepository { get; set; }
        /// <summary>
        /// construtor que instancia o objeto _usuarioRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public UsuarioController() => _usuarioRepository = new UsuarioRepository();
        /// <summary>
        /// endpoint que lista todos os usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
            {
            try
                {
                return Ok(_usuarioRepository.ListarTodos());
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que busca um usuário pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
            {
            try
                {
                UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                return usuarioBuscado == null ? NotFound("Usuario não encontrado!") : Ok(usuarioBuscado);
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que faz o login de um usuário pelo seu email e senha
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(UsuarioDomain novoUsuario)
            {
            try
                {
                UsuarioDomain usuarioBuscado = _usuarioRepository.Login(novoUsuario.Email, novoUsuario.Senha);

                if (usuarioBuscado == null)
                    return NotFound("Usuário não encontrado");

                var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.Titulo.ToString()),
                    };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogo-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                    issuer: "senai.inlock.webApi",
                    audience: "senai.inlock.webApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                    );

                return Ok(new
                    {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = DateTime.Now.AddMinutes(30),
                    });
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que cadastra um novo usuário
        /// </summary>
        /// <param name="novoUsuario"></param>
        /// <returns></returns>
        [HttpPost("Cadastrar")]
        public IActionResult Post(UsuarioDomain novoUsuario)
            {
            try
                {
                _usuarioRepository.Cadastrar(novoUsuario);

                return StatusCode(201, "Usuario cadastrado com sucesso!");
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que deleta um usuário pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            {
            try
                {
                _usuarioRepository.Deletar(id);

                return StatusCode(200, "Usuário deletado com sucesso.");
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }

        /// <summary>
		/// Endpoint que acessa o método de atualizar usuario com id na url
		/// </summary>
		/// <returns>Status Code</returns>
		[HttpPut("{id}")]
        public IActionResult PutByUrl(int id, UsuarioDomain usuario)
            {
            try
                {
                //Faz a chamada para achar o objeto a ser atualizado
                UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

                if (usuarioBuscado != null)
                    {

                    try
                        {
                        _usuarioRepository.AtualizarIdUrl(id, usuario);

                        return StatusCode(201, "Usuario atualizado com sucesso.");
                        }
                    catch (Exception erro)
                        {

                        return BadRequest(erro.Message);
                        }
                    }
                return NotFound("O Gênero buscado não foi encontrado.");
                }
            catch (Exception erro)
                {
                //Retorna um status code 400 e a mensagem de erro 
                return BadRequest(erro.Message);
                }
            }

        /// <summary>
        /// Endpoint que acessa o método de atualizar usuario com id no corpo JSON
        /// </summary>
        /// <returns>Status Code</returns>
        [HttpPut]
        public IActionResult PutByBody(UsuarioDomain usuario)
            {
            try
                {
                //Faz a chamada para achar o objeto a ser atualizado
                UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(usuario.IdUsuario);

                if (usuarioBuscado != null)
                    {

                    try
                        {
                        _usuarioRepository.AtualizarIdCorpo(usuario);

                        return StatusCode(201, "Usuario atualizado com sucesso.");
                        }
                    catch (Exception erro)
                        {

                        return BadRequest(erro.Message);
                        }
                    }
                return NotFound("O Gênero buscado não foi encontrado.");
                }
            catch (Exception erro)
                {
                //Retorna um status code 400 e a mensagem de erro 
                return BadRequest(erro.Message);
                }
            }
        }
    }
