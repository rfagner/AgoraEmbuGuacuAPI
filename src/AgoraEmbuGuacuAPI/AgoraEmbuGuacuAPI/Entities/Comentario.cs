using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AgoraEmbuGuacuAPI.Entities
{
    public class Comentario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo texto é obrigatório")]
        public string Texto { get; set; }
        [Required(ErrorMessage = "O campo autor é obrigatório")]
        public string Autor { get; set; }
        public DateTime DataCriacao { get; set; }
        public int DenunciaId { get; set; }
        
        [JsonIgnore]
        public Denuncia Denuncia { get; set; }
    }
}
