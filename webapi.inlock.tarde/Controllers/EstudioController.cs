using Microsoft.AspNetCore.Mvc;
using webapi.inlock.tarde.Interfaces;
using webapi.inlock.tarde.Repositories;

namespace webapi.inlock.tarde.Controllers
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
        public IActionResult GetAll()
            {
            try
                {
                return Ok(_estudioRepository.ListarTodos());
                }
            catch (Exception erro)
                {

                throw new Exception("Erro ao listar os estúdios" + erro.Message);
                }
            }

        [HttpGet("ListarComJogos")]
        public IActionResult GetWithGames()
            {
            try
                {
                return Ok(_estudioRepository.ListarComJogos());
                }
            catch (Exception erro)
                {

                throw new Exception("Erro ao listar os estúdios com os jogos" + erro.Message);
                }
            }
        }
    }

