namespace AgoraEmbuGuacuAPI.Entities
{
    public class Denuncia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Localizacao { get; set; }
        public List<Comentario> Comentarios { get; set; }
        // Outros campos relevantes
    }
}
