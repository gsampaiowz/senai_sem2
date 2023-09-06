using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EstudioController : ControllerBase
        {

        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
            {
            _estudioRepository = new EstudioRepository();
            }

        [HttpGet]
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

        [HttpGet("{id}")]
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

        [HttpPost]
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

        [HttpDelete("{id}")]
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
