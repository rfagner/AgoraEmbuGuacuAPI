using System.ComponentModel.DataAnnotations;

namespace AgoraEmbuGuacuAPI.Entities
{
    public class Denuncia
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage ="O campo título é obrigatório")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "O campo descrição é obrigatório")]
        public string Descricao { get; set; }
        public string Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Localizacao { get; set; }
        public List<Comentario> Comentarios { get; set; }
        // Outros campos relevantes
    }
}
