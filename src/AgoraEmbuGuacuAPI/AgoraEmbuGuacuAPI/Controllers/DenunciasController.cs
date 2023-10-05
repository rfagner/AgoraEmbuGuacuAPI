using AgoraEmbuGuacuAPI.Entities;
using AgoraEmbuGuacuAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AgoraEmbuGuacuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DenunciasController : ControllerBase
    {
        private readonly IDenunciaRepository _denunciaRepository;

        public DenunciasController(IDenunciaRepository denunciaRepository)
        {
            _denunciaRepository = denunciaRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Desenvolvedor, Administrador, Usuario")]
        public IActionResult GetDenuncias()
        {
            
            var denuncias = _denunciaRepository.ListarDenuncias();

            return Ok(denuncias);
        }

        [HttpPost]
        [Authorize(Roles = "Desenvolvedor, Administrador, Usuario")]
        public IActionResult PostDenuncia(Denuncia denuncia)
        {
            

            
            _denunciaRepository.AdicionarDenuncia(denuncia);

            
            return CreatedAtAction(nameof(GetDenuncia), new { id = denuncia.Id }, denuncia);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Desenvolvedor, Administrador, Usuario")]
        public IActionResult GetDenuncia(int id)
        {
            
            var denuncia = _denunciaRepository.ObterDenunciaPorId(id);

            if (denuncia == null)
            {
                return NotFound(); 
            }

            return Ok(denuncia);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Desenvolvedor, Administrador, Usuario")]
        public IActionResult AtualizarDenuncia(int id, Denuncia denuncia)
        {
            if (id != denuncia.Id)
            {
                return BadRequest("O ID da denúncia na URL não corresponde ao ID da denúncia no corpo da solicitação.");
            }

            try
            {
                
                var existingDenuncia = _denunciaRepository.ObterDenunciaPorId(id);

                if (existingDenuncia == null)
                {
                    return NotFound($"Denúncia com o ID {id} não encontrada.");
                }

                
                existingDenuncia.Titulo = denuncia.Titulo;
                existingDenuncia.Descricao = denuncia.Descricao;
                

                _denunciaRepository.AtualizarDenuncia(existingDenuncia);

                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao atualizar a denúncia: {ex.Message}");
            }
        }
        

        [HttpPost("{denunciaId}/comentarios")]
        public IActionResult AdicionarComentario(int denunciaId, [FromBody] Comentario comentario)
        {
            if (comentario == null)
            {
                return BadRequest("O objeto de comentário é nulo.");
            }

            var denuncia = _denunciaRepository.ObterDenunciaPorId(denunciaId);
            if (denuncia == null)
            {
                return NotFound("A denúncia não foi encontrada.");
            }

            if (denuncia.Comentarios == null)
            {
                denuncia.Comentarios = new List<Comentario>();
            }

            
            _denunciaRepository.AdicionarComentario(denunciaId, comentario); 

            return Ok(denuncia); 
        }




        [HttpDelete("{id}")]
        [Authorize(Roles = "Desenvolvedor, Administrador")]
        public IActionResult ExcluirDenuncia(int id)
        {
            _denunciaRepository.ExcluirDenuncia(id);
            return NoContent(); 
        }



    }
}
