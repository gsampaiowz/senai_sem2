using Microsoft.AspNetCore.Mvc;
using webapi.filmes.tarde.Domains;
using webapi.filmes.tarde.Interfaces;
using webapi.filmes.tarde.Repositories;

namespace webapi.filmes.tarde.Controllers
	{
	/// <summary>
	/// Define que a rota de uma requisição será no seguinto formato
	/// dominio/api/nomeController
	/// exemplo: http://lobalhost:5000/api/Genero
	/// </summary>
	[Route("api/[controller]")]
	/// <summary>
	/// Define que é um controlador de API
	/// </summary>
	[ApiController]
	/// <summary>
	/// Define que o tipo de resposta da API é JSON
	/// </summary>
	[Produces("application/json")]
	public class GeneroController : ControllerBase
		{
		/// <summary>
		/// Objeto que receberá os métodos definidos na interface
		/// </summary>
		private IGeneroRepository _generoRepository { get; set; }

		/// <summary>
		/// Instância do objeto generoRepository para que haja referência aos métodos no repositório
		/// </summary>
		public GeneroController()
			{
			_generoRepository = new GeneroRepository();
			}

		/// <summary>
		/// Endpoint que acessa o método de listar os generos
		/// </summary>
		/// <returns>Lista de generos e um status code</returns>
		[HttpGet]
		public IActionResult GetAll()
			{
			try
				{
				//Cria uma lista para receber os generos
				List<GeneroDomain> listaGeneros = _generoRepository.ListarTodos();

				//Retorna o status code 200 ok e a lista de generos no formato JSON
				return Ok(listaGeneros);
				//return new OkObjectResult(listaGeneros);
				//return StatusCode(200, listaGeneros);
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
			{
			try
				{
				//Cria um objeto para recebe os genero
				GeneroDomain generoBuscado = _generoRepository.BuscarPorId(id);

				//Retorna o status code 200 Ok e o genero no formato JSON
				return Ok(generoBuscado);
				//return new OkObjectResult(generoBuscado);
				//return StatusCode(200, generoBuscado);

				//return _generoRepository.ListarTodos().Where(e => e.IdGenero == id);
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		/// <summary>
		/// Endpoint que acessa o método de cadastrar genero
		/// </summary>
		/// <param name="novoGenero">Objeto recebido na requisição</param>
		/// <returns>Status Code</returns>
		[HttpPost]
		public IActionResult Post(GeneroDomain novoGenero)
			{
			try
				{
				//Faz a chamada para o método cadastrar
				_generoRepository.Cadastrar(novoGenero);

				//Retorna o status code 201 e o genero no formato JSON
				//return Created("Teste", novoGenero);
				return StatusCode(201, novoGenero);
				//return StatusCode(201); -> Retorna somente o status code
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		/// <summary>
		/// Endpoint que acessa o método de deletar genero
		/// </summary>
		/// <returns></returns>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
			{
			try
				{
				//Faz a chamada para o método cadastrar
				_generoRepository.Deletar(id);

				//Retorna o status code 204
				return StatusCode(204);
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		}
	}

