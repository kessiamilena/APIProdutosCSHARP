using APIProdutos.Domains;
using APIProdutos.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace APIProdutos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly ProdutoService _service;

        public ProdutoController(ProdutoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult Listar()
        {
            return Ok(_service.Listar());
        }

        [HttpGet("{id}")]
        public ActionResult BuscarPorId(int id)
        {
            Produto? produto = _service.BuscarPorId(id);

            if(produto == null)
            {
                return NotFound("Produto não encontrado.");
            }

            return Ok(produto);
        }

        [HttpPost]
        public ActionResult Cadastrar(Produto produto)
        {
            try
            {
                _service.Cadastrar(produto);
                return StatusCode(201, "Produto cadastrado com sucesso");
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpPut("{id}")]
        public ActionResult Atualizar(int id, Produto produto)
        {
            try
            {
                if(_service.BuscarPorId(id) == null)
                {
                    return NotFound("Produto não encontrado");
                }

                _service.Atualizar(id, produto);
                return Ok("Produto atualizado com sucesso.");
            }

            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Deletar(int id)
        {
            try
            {
                _service.Deletar(id);
                return Ok("Produto removido com sucesso.");
            }
            catch (Exception erro)
            {
                return NotFound(erro.Message);
            }
        }
    }
}
