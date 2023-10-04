namespace AgoraEmbuGuacuAPI.Entities
{
    public class Comentario
    {
        public int Id { get; set; }
        public string Texto { get; set; }
        public string Autor { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
