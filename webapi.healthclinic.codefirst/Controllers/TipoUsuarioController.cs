using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapi.healthclinic.codefirst.Domains;
using webapi.healthclinic.codefirst.Interfaces;
using webapi.healthclinic.codefirst.Repositories;

namespace webapi.healthclinic.codefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<TipoUsuario> listaTipoUsuario = _tipoUsuarioRepository.ListarTodos();
                return Ok(listaTipoUsuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoUsuario tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorId(id);
                return Ok(tipoUsuarioBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(TipoUsuario usuarioCadastrado)
        {
            try
            {
                _tipoUsuarioRepository.Cadastrar(usuarioCadastrado);
                return StatusCode(201, usuarioCadastrado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(TipoUsuario usuarioCadastrado, Guid id)
        {
            try
            {
                _tipoUsuarioRepository.Atualizar(id, usuarioCadastrado);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
