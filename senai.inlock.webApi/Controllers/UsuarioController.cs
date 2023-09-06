using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace senai.inlock.webApi.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
        {

        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
            {
            _usuarioRepository = new UsuarioRepository();
            }

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

        [HttpPost]
        public IActionResult Login(UsuarioDomain novoUsuario)
            {
            try
                {
                _usuarioRepository.Login(novoUsuario.Email, novoUsuario.Senha);

                if (novoUsuario == null) return NotFound("Email ou senha inválidos!");  

                var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Email, novoUsuario.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, novoUsuario.IdUsuario.ToString()),
                    new Claim(ClaimTypes.Role, novoUsuario.IdTipoUsuario.ToString())
                    };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-autenticacao"));

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

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
            {
            try
                {
                _usuarioRepository.Deletar(id);

                return StatusCode(204, "Usuário deletado com sucesso.");
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        }
    }
