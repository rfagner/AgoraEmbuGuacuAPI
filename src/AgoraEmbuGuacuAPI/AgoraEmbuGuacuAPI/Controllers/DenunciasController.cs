using AgoraEmbuGuacuAPI.Entities;
using AgoraEmbuGuacuAPI.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost("{id}/comentario")]
        public IActionResult PostComentario(int id, [FromBody] Comentario comentario)
        {
            var denuncia = _denunciaRepository.ObterDenunciaPorId(id);

            if (denuncia == null)
            {
                return NotFound(); // Retorne um status HTTP 404 se a denúncia não existir
            }

            if (denuncia.Comentarios == null)
            {
                denuncia.Comentarios = new List<Comentario>();
            }

            denuncia.Comentarios.Add(comentario);

            // Atualize a denúncia no banco de dados (ou na fonte de dados)
            _denunciaRepository.AtualizarDenuncia(denuncia);

            return Ok(comentario); // Retorne um status HTTP 200 com o comentário criado
        }



    }
}
