using AgoraEmbuGuacuAPI.Entities;
using AgoraEmbuGuacuAPI.Interfaces;

namespace AgoraEmbuGuacuAPI.Repository
{
    public class DenunciaRepository : IDenunciaRepository
    {
        private List<Denuncia> denuncias = new List<Denuncia>();

        public IEnumerable<Denuncia> ListarDenuncias()
        {
            return denuncias;
        }

        public Denuncia ObterDenunciaPorId(int id)
        {
            return denuncias.FirstOrDefault(d => d.Id == id);
        }

        public void AdicionarDenuncia(Denuncia denuncia)
        {
            denuncias.Add(denuncia);
        }

        public void AtualizarDenuncia(Denuncia denuncia)
        {
            var existingDenuncia = ObterDenunciaPorId(denuncia.Id);
            if (existingDenuncia != null)
            {
                existingDenuncia.Titulo = denuncia.Titulo;
                existingDenuncia.Descricao = denuncia.Descricao;
                // Atualize outros campos, se necessário
            }
        }

        public void AdicionarComentario(int denunciaId, Comentario comentario)
        {
            var denuncia = ObterDenunciaPorId(denunciaId);
            if (denuncia != null)
            {
                denuncia.Comentarios.Add(comentario);
            }
        }
    }
}
