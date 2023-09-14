using Microsoft.AspNetCore.Mvc;
using webapi.inlock.codefirst.Domains;
using webapi.inlock.codefirst.Interfaces;
using webapi.inlock.codefirst.Repositories;

namespace webapi.inlock.codefirst.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
        {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController()
            {
            _usuarioRepository = new UsuarioRepository();
            }

        [HttpPost]
        public IActionResult Post(Usuario novoUsuario)
            {
            try
                {
                _usuarioRepository.Cadastrar(novoUsuario);

                return Created("Cadastro efetuado com sucesso!",novoUsuario);
                }
            catch (Exception)
                {

                throw new Exception("Erro ao cadastrar usuário.");
                }
            }
        }
    }
