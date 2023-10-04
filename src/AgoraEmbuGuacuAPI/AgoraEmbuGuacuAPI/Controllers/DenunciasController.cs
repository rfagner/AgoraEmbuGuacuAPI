using AgoraEmbuGuacuAPI.Entities;
using AgoraEmbuGuacuAPI.Interfaces;
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
        public IActionResult GetDenuncias()
        {
            // Suponha que você tenha uma lista de denúncias em memória (substitua pela lógica do seu banco de dados)
            var denuncias = _denunciaRepository.ListarDenuncias();

            return Ok(denuncias);
        }

        [HttpPost]
        public IActionResult PostDenuncia(Denuncia denuncia)
        {
            // Valide os dados da denúncia, por exemplo, garantindo que os campos obrigatórios sejam preenchidos

            // Salve a denúncia no banco de dados ou em outra fonte de dados
            _denunciaRepository.AdicionarDenuncia(denuncia);

            // Retorne um status HTTP 201 (Created) e a denúncia criada
            return CreatedAtAction(nameof(GetDenuncia), new { id = denuncia.Id }, denuncia);
        }

        [HttpGet("{id}")]
        public IActionResult GetDenuncia(int id)
        {
            // Encontre a denúncia pelo ID (substitua pela lógica do seu banco de dados)
            var denuncia = _denunciaRepository.ObterDenunciaPorId(id);

            if (denuncia == null)
            {
                return NotFound(); // Retorne um status HTTP 404 (Not Found) se a denúncia não existir
            }

            return Ok(denuncia);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarDenuncia(int id, Denuncia denuncia)
        {
            if (id != denuncia.Id)
            {
                return BadRequest("O ID da denúncia na URL não corresponde ao ID da denúncia no corpo da solicitação.");
            }

            try
            {
                // Verifique se a denúncia com o ID especificado existe
                var existingDenuncia = _denunciaRepository.ObterDenunciaPorId(id);

                if (existingDenuncia == null)
                {
                    return NotFound($"Denúncia com o ID {id} não encontrada.");
                }

                // Atualize os campos da denúncia existente com os valores do corpo da solicitação
                existingDenuncia.Titulo = denuncia.Titulo;
                existingDenuncia.Descricao = denuncia.Descricao;
                // Atualize outros campos, se necessário

                _denunciaRepository.AtualizarDenuncia(existingDenuncia);

                return NoContent(); // Retorna uma resposta HTTP 204 (No Content) após a atualização bem-sucedida
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

            // Chame o método no repositório para adicionar o comentário e definir o autor
            _denunciaRepository.AdicionarComentario(denunciaId, comentario); // Substitua "NomeDoAutor" pelo nome real do autor

            return Ok(denuncia); // Retorna a denúncia atualizada
        }




        [HttpDelete("{id}")]
        public IActionResult ExcluirDenuncia(int id)
        {
            _denunciaRepository.ExcluirDenuncia(id);
            return NoContent(); // Retorna uma resposta HTTP 204 (No Content) após a exclusão
        }



    }
}
