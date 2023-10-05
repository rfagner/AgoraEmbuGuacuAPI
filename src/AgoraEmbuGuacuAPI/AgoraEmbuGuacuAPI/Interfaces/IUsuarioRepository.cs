using AgoraEmbuGuacuAPI.Entities;

namespace AgoraEmbuGuacuAPI.Interfaces
{
    public interface IUsuarioRepository
    {
        List<Usuario> GetAllUsers();
        Usuario GetUserById(int id);
        Usuario GetUserByUsername(string nomeUsuario);
        void CreateUser(Usuario usuario);
        void UpdateUser(Usuario usuario);
        void DeleteUser(int id);
    }
}
