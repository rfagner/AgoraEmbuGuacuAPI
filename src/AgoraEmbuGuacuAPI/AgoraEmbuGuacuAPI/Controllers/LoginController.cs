using AgoraEmbuGuacuAPI.Entities;
using AgoraEmbuGuacuAPI.Interfaces;
using AgoraEmbuGuacuAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgoraEmbuGuacuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginRepository _repo;

        public LoginController(ILoginRepository repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public IActionResult Logar(Login login)
        {
            var logar = _repo.Logar(login.email, login.senha);
            if (logar == null)
                return Unauthorized();

            return Ok(new { token = logar });
        }

        // Endpoint para solicitar a recuperação de senha
        [HttpPost("recuperarsenha")]
        public IActionResult RecuperarSenha([FromBody] RecuperarSenhaRequest recuperarSenhaRequest)
        {
            var sucesso = _repo.RecuperarSenha(recuperarSenhaRequest.Email);

            if (sucesso)
            {
                return Ok("E-mail de recuperação de senha enviado com sucesso.");
            }

            return BadRequest("E-mail não encontrado.");
        }

        // Endpoint para redefinir a senha com base no token de recuperação
        [HttpPost("redefinirsenha")]
        public IActionResult RedefinirSenha([FromBody] RedefinirSenhaRequest redefinirSenhaRequest)
        {
            var sucesso = _repo.RedefinirSenha(redefinirSenhaRequest.Email, redefinirSenhaRequest.Token, redefinirSenhaRequest.NovaSenha);

            if (sucesso)
            {
                return Ok("Senha redefinida com sucesso.");
            }

            return BadRequest("Token inválido ou expirado.");
        }


    }
}
