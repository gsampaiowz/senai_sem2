using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
    {
    /// <summary>
    /// controller responsável pelos endpoints referentes aos jogos
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class JogoController : ControllerBase
        {

        private IJogoRepository _jogoRepository { get; set; }
        /// <summary>
        /// construtor que instancia o objeto _jogoRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public JogoController()
            {
            _jogoRepository = new JogoRepository();
            }

        /// <summary>
        /// endpoint que lista todos os jogos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
            {
            try
                {
                return Ok(_jogoRepository.ListarTodos());
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que busca um jogo pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
            {
            try
                {
                JogoDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

                return jogoBuscado == null ? NotFound("Jogo não encontrado!") : Ok(jogoBuscado);
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que cadastra um novo jogo
        /// </summary>
        /// <param name="novoJogo"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(JogoDomain novoJogo)
            {
            try
                {
                _jogoRepository.Cadastrar(novoJogo);

                return StatusCode(201, "Jogo cadastrado com sucesso!");
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que atualiza um jogo existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
            {
            try
                {
                _jogoRepository.Deletar(id);

                return StatusCode(204, "Jogo deletado com sucesso.");
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        }
    }
