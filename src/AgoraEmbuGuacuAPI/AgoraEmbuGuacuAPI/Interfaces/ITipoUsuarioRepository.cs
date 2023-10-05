using AgoraEmbuGuacuAPI.Entities;

namespace AgoraEmbuGuacuAPI.Interfaces
{
    public interface ITipoUsuarioRepository
    {
        TipoUsuario Inserir(TipoUsuario tipoUsuario);
        
        ICollection<TipoUsuario> ListarTodos();
        TipoUsuario BuscarPorId(int id);
       
        void Alterar(TipoUsuario tipoUsuario);
        
        void Excluir(TipoUsuario tipoUsuario);
    }
}
