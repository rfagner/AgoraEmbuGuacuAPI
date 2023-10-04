using AgoraEmbuGuacuAPI.Interfaces;
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
        public IActionResult Logar(string email, string senha)
        {
            var logar = _repo.Logar(email, senha);
            if (logar == null)
                return Unauthorized();

            return Ok(new { token = logar });
        }


    }
}
