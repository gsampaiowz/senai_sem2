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

				if (usuarioBuscado != null) if (usuarioBuscado.Email == email & usuarioBuscado.Senha != senha) return Conflict("Senha incorreta!");

				return usuarioBuscado == null ? NotFound("Usuário não encontrado") : Ok("Login efetuado com sucesso!");
				}
			catch (Exception erro)
				{
				return BadRequest(erro.Message);
				}
			}
		//[HttpGet]
		//public IActionResult LoginGet(string email, string senha)
		//	{
		//	try
		//		{
		//		UsuarioDomain usuarioBuscado = _usuarioRepository.Login(email, senha);

		//		if (usuarioBuscado != null) if (usuarioBuscado.Email == email & usuarioBuscado.Senha != senha) return Conflict("Senha incorreta!");

		//		return usuarioBuscado == null ? NotFound("Usuário não encontrado") : Ok(usuarioBuscado);
		//		}
		//	catch (Exception erro)
		//		{
		//		return BadRequest(erro.Message);
		//		}
		//	}

		/// <summary>
		/// Endpoint que acessa o metodo de cadastrar
		/// </summary>
		/// <param name="email"></param>
		/// <param name="senha"></param>
		/// <param name="permissao"></param>
		/// <returns></returns>
		[HttpPost("Cadastrar")]
		public IActionResult Post(string email, string senha, bool permissao)
			{
			try
				{
				if (senha.Length < 8) return Conflict("Sua senha precisa de no mínimo 8 caracteres!");

				_usuarioRepository.Cadastrar(email, senha, permissao);

				return StatusCode(201, "Cadastro efetuado com sucesso!");
				}
			catch (Exception erro)
				{
				return BadRequest(erro.Message);
				}
			}

		/// <summary>
		/// Endpoint que acessa o método de listar os usuarios
		/// </summary>
		/// <returns>Lista de usuarios e um status code</returns>
		[HttpGet]
		public IActionResult GetAll()
			{
			try
				{
				//Cria uma lista para receber os usuarios
				List<UsuarioDomain> listaUsuarios = _usuarioRepository.ListarTodos();

				//Retorna o status code 200 ok e a lista de usuarios no formato JSON
				return Ok(listaUsuarios);
				//return new OkObjectResult(listaUsuarios);
				//return StatusCode(200, listaUsuarios);
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		/// <summary>
		/// Endpoint que acessa o metodo Buscar um usuario pelo seu ID
		/// </summary>
		/// <param name="id">ID do usuario a ser buscado</param>
		/// <returns>Status code 200 e o objeto buscado</returns>
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
			{
			try
				{
				//Cria um objeto para recebe o usuario
				UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

				//Retorna o status code 200 Ok e o usuario no formato JSON
				return usuarioBuscado == null ? NotFound("O Gênero buscado não foi encontrado.") : Ok(usuarioBuscado);

				//return new OkObjectResult(usuarioBuscado);
				//return StatusCode(200, usuarioBuscado);

				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		/// <summary>
		/// Endpoint que acessa o método de deletar usuario
		/// </summary>
		/// <returns>Status Code</returns>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
			{
			try
				{

				UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

				if (usuarioBuscado == null) return NotFound("O usuario buscado não foi encontrado.");

				//Faz a chamada para o método deletar
				_usuarioRepository.Deletar(id);

				//Retorna o status code 204
				return StatusCode(204);
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		/// <summary>
		/// Endpoint que acessa o método de atualizar usuario com id na url
		/// </summary>
		/// <returns>Status Code</returns>
		[HttpPut("{id}")]
		public IActionResult PutById(int id, UsuarioDomain usuario)
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

						return NoContent();
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
		public IActionResult Put(UsuarioDomain usuario)
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

						return NoContent();
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
