using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AgoraEmbuGuacuAPI.Entities
{
    public class TipoUsuario
    {
        [Key]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public ICollection<Usuario> Usuarios { get; set; }
    }
}
