using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AgoraEmbuGuacuAPI.Entities
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo username é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]        
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo sobrenome é obrigatório")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "O campo idade é obrigatório")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo password é obrigatório")]
        public string Password { get; set; }

        [ForeignKey("TipoUsuario")]

        public int IdTipoUsuario { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public TipoUsuario TipoUsuario { get; set; }

    }
}
