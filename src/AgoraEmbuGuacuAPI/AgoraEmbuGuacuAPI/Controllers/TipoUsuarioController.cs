using AgoraEmbuGuacuAPI.Entities;
using AgoraEmbuGuacuAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgoraEmbuGuacuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUsuarioController : ControllerBase
    {
        private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

        public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
        {
            _tipoUsuarioRepository = tipoUsuarioRepository;
        }

        [HttpPost]
        [Authorize(Roles = "Desenvolvedor, Administrador")]
        public IActionResult Cadastrar(TipoUsuario tipoUsuario)
        {
            try
            {
                var retorno = _tipoUsuarioRepository.Inserir(tipoUsuario);
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        [HttpGet]
        [Authorize(Roles = "Desenvolvedor, Administrador")]
        public IActionResult Listar()
        {
            try
            {
                var retorno = _tipoUsuarioRepository.ListarTodos();
                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Desenvolvedor, Administrador")]
        public IActionResult BuscarTipoUsuarioPorId(int id)
        {
            try
            {
                var retorno = _tipoUsuarioRepository.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Tipo usuário não encontrado" });
                }

                return Ok(retorno);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Desenvolvedor, Administrador")]
        public IActionResult Alterar(int id, TipoUsuario tipoUsuario)
        {
            try
            {
                
                if (id != tipoUsuario.Id)
                {
                    return BadRequest(new { Message = "Dados não conferem" });
                }

                
                var retorno = _tipoUsuarioRepository.BuscarPorId(id);
                if (retorno == null)
                {
                    return NotFound(new { Message = "Tipo Usuário não encontrado" });
                }

                
                _tipoUsuarioRepository.Alterar(tipoUsuario);

                return NoContent();
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Desenvolvedor, Administrador")]
        public IActionResult Excluir(int id)
        {
            try
            {
                
                var tipoUsuario = _tipoUsuarioRepository.BuscarPorId(id);
                if (tipoUsuario == null)
                {
                    return NotFound(new { Message = "Tipo Usuário não encontrado" });
                }

                _tipoUsuarioRepository.Excluir(tipoUsuario);

                return Ok(new
                {
                    msg = "TipoUsuario excluído com sucesso"
                });
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Falha na transação",
                    Message = ex.Message,
                });
            }
        }
    }
}
