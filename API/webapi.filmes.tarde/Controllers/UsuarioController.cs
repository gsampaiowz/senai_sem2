using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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
		public IActionResult Login(UsuarioDomain usuario)
			{
			try
				{
				UsuarioDomain usuarioBuscado = _usuarioRepository.Login(usuario.Email, usuario.Senha);

				if (usuarioBuscado == null) return NotFound("Usuário não encontrado");

				//if (usuarioBuscado != null) if (usuarioBuscado.Email == usuario.Email & usuarioBuscado.Senha != usuario.Senha) return Conflict("Senha incorreta!");

				//Caso encontre o usuario buscado, prossegue para a criação do token

				//Define os dados (informações, claims) que serão fornecidos no token - Payload

				var claims = new[]
					{
					//Armazena na claim o id do usuario autenticado
					new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado?.IdUsuario.ToString()),
					//Armazena na claim o email do usuario autenticado
					new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado?.Email),
					//Armazena na claim o tipo de permissão do usuario autenticado
					new Claim(ClaimTypes.Role, usuarioBuscado.Permissao.ToString()),
					//Armazena na claim o tipo de permissão do usuario autenticado
					new Claim("Claim Personalizada", "Valor Personalizada")
					};

				//Definir a chave de acesso ao token
				var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

				//Define as credenciais do token - Header
				var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

				//Define a composição do token
				var token = new JwtSecurityToken
					(
					//emissor do token
					issuer: "webapi.filmes.tarde",

					//destinatario do token
					audience: "webapi.filmes.tarde",

					//dados definidos anteriormente
					claims: claims,

					//tempo de expiração
					expires: DateTime.Now.AddMinutes(30),

					//credenciais do token
					signingCredentials: creds

					);

				//Retorna um status code 200 (Ok) com o token criado
				return Ok(new
					{
					token = new JwtSecurityTokenHandler().WriteToken(token),
					expiration = DateTime.Now.AddMinutes(30),
					}); ;

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
		/// <param name="usuario"></param>
		/// <returns></returns>
		[HttpPost("Cadastrar")]
		public IActionResult Post(UsuarioDomain usuario)
			{
			try
				{
				//if (usuario.Senha?.Length < 8) return Conflict("Sua senha precisa de no mínimo 8 caracteres!");

				_usuarioRepository.Cadastrar(usuario.Email, usuario.Senha, usuario.Permissao);

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
				return StatusCode(204, "Usuario deletado com sucesso.");
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

						return StatusCode(204, "Usuario atualizado com sucesso.");
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

						return StatusCode(204, "Usuario atualizado com sucesso.");
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
