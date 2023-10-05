using AgoraEmbuGuacuAPI.Context;
using AgoraEmbuGuacuAPI.Entities;
using AgoraEmbuGuacuAPI.Interfaces;

namespace AgoraEmbuGuacuAPI.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AgoraContext _context;

        private List<Usuario> users = new List<Usuario>();

        public UsuarioRepository(AgoraContext context)
        {
            _context = context;
        }

        public List<Usuario> GetAllUsers()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario GetUserById(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario GetUserByUsername(string nomeUsuario)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Username == nomeUsuario);
        }

        public void CreateUser(Usuario user)
        {
            _context.Usuarios.Add(user);
            _context.SaveChanges();
        }

        public void UpdateUser(Usuario user)
        {
            _context.Usuarios.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user != null)
            {
                _context.Usuarios.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}
