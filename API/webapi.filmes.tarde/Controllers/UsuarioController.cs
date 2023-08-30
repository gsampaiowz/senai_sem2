using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
	{
	/// <summary>
	/// 
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	[Produces("application/json")]
	public class UsuarioController : ControllerBase
		{
		private IUsuarioRepository _usuarioRepository { get; set; }
		/// <summary>
		/// 
		/// </summary>
		public UsuarioController()
			{
			_usuarioRepository = new UsuarioRepository();
			}
		/// <summary>
		/// Endpoint que acessa o método de Login
		/// </summary>
		/// <returns></returns>
		[HttpPost]
		public IActionResult Login(string email, string senha)
			{
			try
				{
				UsuarioDomain usuarioBuscado = _usuarioRepository.Login(email, senha);
				return usuarioBuscado == null ? NotFound("Usuário não encontrado") : Ok(usuarioBuscado);
				}
			catch (Exception erro)
				{
				return BadRequest(erro.Message);
				}
			}
		}
	}
