using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
    {
    /// <summary>
    /// controller responsável pelos endpoints referentes aos estúdios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
        {

        private IEstudioRepository _estudioRepository { get; set; }
        /// <summary>
        /// construtor que instancia o objeto _estudioRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public EstudioController()
            {
            _estudioRepository = new EstudioRepository();
            }
        /// <summary>
        /// endpoint que lista todos os estúdios
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public IActionResult Get()
            {
            try
                {
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

                return Ok(listaEstudios);
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que busca um estúdio pelo seu id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(int id)
            {
            try
                {
                EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

                return estudioBuscado == null ? NotFound("Estudio não encontrado!") : Ok(estudioBuscado);
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que cadastra um novo estúdio
        /// </summary>
        /// <param name="novoEstudio"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize(Roles = "Administrador")]
        public IActionResult Post(EstudioDomain novoEstudio)
            {
            try
                {
                _estudioRepository.Cadastrar(novoEstudio);

                return StatusCode(201, "Estúdio cadastrado com sucesso!");
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        /// <summary>
        /// endpoint que atualiza um estúdio existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public IActionResult Delete(int id)
            {
            try
                {
                EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

                if (estudioBuscado == null) return NotFound("Nenhum estudio encontrado!");

                _estudioRepository.Deletar(id);

                return StatusCode(204, "Estudio deletado com sucesso.");
                }
            catch (Exception erro)
                {

                return BadRequest(erro);
                }
            }
        }
    }
