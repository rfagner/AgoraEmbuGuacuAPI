using AgoraEmbuGuacuAPI.Context;
using AgoraEmbuGuacuAPI.Entities;
using AgoraEmbuGuacuAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AgoraEmbuGuacuAPI.Repository
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        
        private readonly AgoraContext _context;

        public TipoUsuarioRepository(AgoraContext context)
        {
            _context = context;
        }

        public void Alterar(TipoUsuario tipoUsuario)
        {
            // Compara a base de dados atual do Tipo Usuário e vê se tem modificações
            _context.Entry(tipoUsuario).State = EntityState.Modified;
            _context.SaveChanges();
        }        

        public TipoUsuario BuscarPorId(int id)
        {
            var listarTipoUsuarioPorId = _context.TipoUsuario
                .Include(u => u.Usuarios)
                .FirstOrDefault(p => p.Id == id);
            return listarTipoUsuarioPorId;
        }

        public void Excluir(TipoUsuario tipoUsuario)
        {
            _context.TipoUsuario.Remove(tipoUsuario);
            _context.SaveChanges();
        }

        public TipoUsuario Inserir(TipoUsuario tipoUsuario)
        {
            _context.TipoUsuario.Add(tipoUsuario);
            _context.SaveChanges();
            return tipoUsuario;
        }

        public ICollection<TipoUsuario> ListarTodos()
        {
            var listarTipoUsuario = _context.TipoUsuario
                .Include(u => u.Usuarios)
                .ToList();
            return listarTipoUsuario.ToList();
        }
    }
}
