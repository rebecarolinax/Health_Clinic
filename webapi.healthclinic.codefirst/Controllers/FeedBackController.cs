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
    public class FeedBackController : ControllerBase
    {
        private readonly IFeedBackRepository _FeedBackRepository;

        public FeedBackController()
        {
            _FeedBackRepository = new FeedBackRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<FeedBack> listaFeedBack = _FeedBackRepository.ListarTodos();
                return Ok(listaFeedBack);
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
                FeedBack FeedBackBuscado = _FeedBackRepository.BuscarPorId(id);
                return Ok(FeedBackBuscado);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(FeedBack FeedBackCadastrado)
        {
            try
            {
                _FeedBackRepository.Cadastrar(FeedBackCadastrado);
                return StatusCode(201, FeedBackCadastrado);
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
                _FeedBackRepository.Deletar(id);
                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(FeedBack FeedBackCadastrado, Guid id)
        {
            try
            {
                _FeedBackRepository.Atualizar(id, FeedBackCadastrado);

                return StatusCode(201);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
