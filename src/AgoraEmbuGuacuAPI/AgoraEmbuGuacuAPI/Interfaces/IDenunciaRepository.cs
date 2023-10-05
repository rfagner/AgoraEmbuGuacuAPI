using AgoraEmbuGuacuAPI.Entities;

namespace AgoraEmbuGuacuAPI.Interfaces
{
    public interface IDenunciaRepository
    {        
        
        IEnumerable<Denuncia> ListarDenuncias();
        
        Denuncia ObterDenunciaPorId(int id);
        
        void AdicionarDenuncia(Denuncia denuncia);
        
        void AtualizarDenuncia(Denuncia denuncia);
        
        void AdicionarComentario(int denunciaId, Comentario comentario);
        void ExcluirDenuncia(int id);
    }
}
