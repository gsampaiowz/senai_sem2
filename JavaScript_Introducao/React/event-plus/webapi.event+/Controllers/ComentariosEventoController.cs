using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.event_.Domains;
using webapi.event_.Interfaces;
using webapi.event_.Repositories;

namespace webapi.event_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ComentariosEventoController : ControllerBase
    {
        private ComentariosEventoRepository _comentariosEventoRepository { get; set; }

        public ComentariosEventoController() => _comentariosEventoRepository = new ComentariosEventoRepository();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_comentariosEventoRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_comentariosEventoRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpGet("BuscarPorIdUsuario")]
        public IActionResult GetByIdUser(Guid idUsuario, Guid idEvento)
        {
            try
            {
                return Ok(_comentariosEventoRepository.BuscarPorIdUsuario(idUsuario, idEvento));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }



        [HttpPost]
        public IActionResult Post(ComentariosEvento comentario)
        {
            try
            {
                _comentariosEventoRepository.Cadastrar(comentario);
                return StatusCode(201, comentario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentariosEventoRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
                throw;
            }
        }
    }
}
