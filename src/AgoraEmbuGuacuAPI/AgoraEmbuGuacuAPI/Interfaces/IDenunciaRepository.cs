using AgoraEmbuGuacuAPI.Entities;

namespace AgoraEmbuGuacuAPI.Interfaces
{
    public interface IDenunciaRepository
    {        
        // Método para listar todas as denúncias
        IEnumerable<Denuncia> ListarDenuncias();

        // Método para obter uma denúncia específica por ID
        Denuncia ObterDenunciaPorId(int id);

        // Método para adicionar uma nova denúncia
        void AdicionarDenuncia(Denuncia denuncia);

        // Método para atualizar uma denúncia existente
        void AtualizarDenuncia(Denuncia denuncia);

        // Método para adicionar um comentário a uma denúncia
        void AdicionarComentario(int denunciaId, Comentario comentario);
        void ExcluirDenuncia(int id);
    }
}
