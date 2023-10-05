using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

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
        [Required(ErrorMessage = "O campo autor é obrigatório")]
        public string Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        [Required(ErrorMessage = "O campo Localização é obrigatório")]
        public string Localizacao { get; set; }       
        public List<Comentario> Comentarios { get; set; }
        
    }
}
