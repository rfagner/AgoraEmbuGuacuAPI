using AgoraEmbuGuacuAPI.Interfaces;
using AgoraEmbuGuacuAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AgoraEmbuGuacuAPI.Repository;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Desenvolvedor, Administrador")]
        public IActionResult GetAllUsers()
        {
            var users = _userRepository.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Desenvolvedor, Administrador")]
        public IActionResult GetUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound(); 
            }
            return Ok(user);
        }

        [HttpPost]
        
        public IActionResult CreateUser(Usuario user)
        {
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            
            _userRepository.CreateUser(user);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Desenvolvedor, Administrador, Usuario")]
        public IActionResult UpdateUser(int id, Usuario user)
        {
            if (id != user.Id)
            {
                return BadRequest(); 
            }

            

            _userRepository.UpdateUser(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Desenvolvedor, Administrador")]
        public IActionResult DeleteUser(int id)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return NotFound(); 
            }            

            _userRepository.DeleteUser(id); 
            return NoContent(); 
        }
    }
}
