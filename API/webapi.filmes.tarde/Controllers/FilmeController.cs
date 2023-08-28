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

		[HttpGet("{id}")]
		public IActionResult GetById(int id)
			{
			try
				{
				//Cria um objeto para recebe os Filme
				FilmeDomain FilmeBuscado = _filmeRepository.BuscarPorId(id);

				//Retorna o status code 200 Ok e o Filme no formato JSON
				return Ok(FilmeBuscado);
				//return new OkObjectResult(FilmeBuscado);
				//return StatusCode(200, FilmeBuscado);

				//return _FilmeRepository.ListarTodos().Where(e => e.IdFilme == id);
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
				//Faz a chamada para o método cadastrar
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
		public IActionResult PutById(int id, FilmeDomain FilmeAtualizado)
			{
			try
				{
				//Faz a chamada para o método cadastrar
				_filmeRepository.AtualizarIdUrl(id, FilmeAtualizado);

				//Retorna o status code 200
				return StatusCode(200);
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
		public IActionResult Put(FilmeDomain FilmeAtualizado)
			{
			try
				{
				//Faz a chamada para o método cadastrar
				_filmeRepository.AtualizarIdCorpo(FilmeAtualizado);

				//Retorna o status code 200
				return StatusCode(200);
				}
			catch (Exception erro)
				{
				//Retorna um status code 400 e a mensagem de erro 
				return BadRequest(erro.Message);
				}
			}
		}
	}

