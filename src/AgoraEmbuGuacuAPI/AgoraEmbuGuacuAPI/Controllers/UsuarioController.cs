using AgoraEmbuGuacuAPI.Interfaces;
using AgoraEmbuGuacuAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgoraEmbuGuacuAPI.Repository;

namespace AgoraEmbuGuacuAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _userRepository;

        public UsuarioController(IUsuarioRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound(); // Retorne 404 se o usuário não existir
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser(Usuario user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            // Adicione validações de usuário aqui, como verificação de duplicatas de nome de usuário ou e-mail
            _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, Usuario user)
        {
            if (id != user.Id)
            {
                return BadRequest(); // Retorne 400 se o ID do usuário não corresponder ao ID na solicitação
            }

            // Adicione validações de usuário aqui, se necessário

            _userRepository.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound(); // Retorne 404 se o usuário não existir
            }

            // Adicione validações ou restrições de exclusão, se necessário

            _userRepository.DeleteUser(id); // Chama o método de exclusão no repositório
            return NoContent(); // Retorne 204 para indicar que o usuário foi excluído com sucesso
        }
    }
}
