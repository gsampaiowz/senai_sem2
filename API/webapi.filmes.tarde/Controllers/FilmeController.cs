using Microsoft.AspNetCore.Authorization;
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
	[ApiController]
	[Produces("application/json")]
	[Authorize(Roles = "ADM")]
	public class FilmeController : ControllerBase
		{
		/// <summary>
		/// Objeto que receberá os métodos definidos na interface
		/// </summary>
		private IFilmeRepository _filmeRepository { get; set; }

		/// <summary>
		/// Instância do objeto FilmeRepository para que haja referência aos métodos no repositório
		/// </summary>
		public FilmeController()
			{
			_filmeRepository = new FilmeRepository();
			}

		/// <summary>
		/// Endpoint que acessa o método de listar os Filmes
		/// </summary>
		/// <returns>Lista de Filmes e um status code</returns>
		[HttpGet]
		public IActionResult GetAll()
			{
			try
				{
				//Cria uma lista para receber os Filmes
				List<FilmeDomain> listaFilmes = _filmeRepository.ListarTodos();

				//Retorna o status code 200 ok e a lista de Filmes no formato JSON
				return Ok(listaFilmes);
				//return new OkObjectResult(listaFilmes);
				//return StatusCode(200, listaFilmes);
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}
		/// <summary>
		/// Endpoint que acessa o metodo Buscar um filme pelo seu ID
		/// </summary>
		/// <param name="id">ID do filme a ser buscado</param>
		/// <returns>Status code 200 e o objeto buscado</returns>
		[HttpGet("{id}")]
		public IActionResult GetById(int id)
			{
			try
				{
				//Cria um objeto para recebe o filme
				FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

				//Retorna o status code 200 Ok e o filme no formato JSON
				return filmeBuscado == null ? NotFound("O Filme buscado não foi encontrado.") : Ok(filmeBuscado);

				//return new OkObjectResult(filmeBuscado);
				//return StatusCode(200, filmeBuscado);

				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		/// <summary>
		/// Endpoint que acessa o método de cadastrar Filme
		/// </summary>
		/// <param name="novoFilme">Objeto recebido na requisição</param>
		/// <returns>Status Code</returns>
		[HttpPost]
		public IActionResult Post(FilmeDomain novoFilme)
			{
			try
				{
				//Faz a chamada para o método cadastrar
				_filmeRepository.Cadastrar(novoFilme);

				//Retorna o status code 201 e o Filme no formato JSON
				//return Created("Teste", novoFilme);
				return StatusCode(201, novoFilme);
				//return StatusCode(201); -> Retorna somente o status code
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		/// <summary>
		/// Endpoint que acessa o método de deletar Filme
		/// </summary>
		/// <returns>Status Code</returns>
		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
			{
			try
				{

				FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

				if (filmeBuscado == null)
					{
					return NotFound("O Filme buscado não foi encontrado.");
					}

				//Faz a chamada para o método deletar
				_filmeRepository.Deletar(id);

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
		/// Endpoint que acessa o método de atualizar Filme com id na url
		/// </summary>
		/// <returns>Status Code</returns>
		[HttpPut("{id}")]
		public IActionResult PutByUrl(int id, FilmeDomain filme)
			{
			try
				{
				//Faz a chamada para achar o objeto a ser atualizado
				FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(id);

				if (filmeBuscado != null)
					{

					try
						{
						_filmeRepository.AtualizarIdUrl(id, filme);

						return NoContent();
						}
					catch (Exception erro)
						{

						return BadRequest(erro.Message);
						}
					}
				return NotFound("O Filme buscado não foi encontrado.");
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}

		/// <summary>
		/// Endpoint que acessa o método de atualizar Filme com id no corpo JSON
		/// </summary>
		/// <returns>Status Code</returns>
		[HttpPut]
		public IActionResult PutByBody(FilmeDomain filme)
			{
			try
				{
				//Faz a chamada para achar o objeto a ser atualizado
				FilmeDomain filmeBuscado = _filmeRepository.BuscarPorId(filme.IdFilme);

				if (filmeBuscado != null)
					{

					try
						{
						_filmeRepository.AtualizarIdCorpo(filme);

						return NoContent();
						}
					catch (Exception erro)
						{

						return BadRequest(erro.Message);
						}
					}
				return NotFound("O Filme buscado não foi encontrado.");
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}
		}
	}

