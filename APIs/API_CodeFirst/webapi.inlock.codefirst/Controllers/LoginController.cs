using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Repositories;
using webapi.inlock.codefirst.ViewModels;

namespace webapi.inlock.codefirst.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
        {
        private readonly IUsuarioRepository _usuarioRepository;
        public LoginController()
            {
            _usuarioRepository = new UsuarioRepository();
            }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
            {
            try
                {
                Usuario usuarioBuscado = _usuarioRepository.BuscarUsuario(usuario.Email!, usuario.Senha!);

                if(usuarioBuscado == null) return StatusCode(401, "Email ou senha inválidos!");

                var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Jti!, usuarioBuscado!.IdUsuario!.ToString()!),
                    new Claim(JwtRegisteredClaimNames.Email!, usuarioBuscado!.Email!.ToString()!),
                    new Claim(ClaimTypes.Role!, usuarioBuscado!.TipoUsuario!.Titulo!.ToString()!),
                    };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jogo-chave-autenticacao-webapi-dev"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken
                    (
                    issuer: "webapi.inlock.codefirst",
                    audience: "webapi.inlock.codefirst",
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
        }
    }
