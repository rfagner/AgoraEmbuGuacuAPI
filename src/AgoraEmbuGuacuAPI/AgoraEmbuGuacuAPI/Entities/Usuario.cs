using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AgoraEmbuGuacuAPI.Entities
{
    public class Usuario
    {
        [Key]
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo username é obrigatório")]
        [MinLength(3, ErrorMessage ="Minino 3 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]        
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo sobrenome é obrigatório")]
        public string SobreNome { get; set; }

        [Required(ErrorMessage = "O campo idade é obrigatório")]
        public int Idade { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "O formato do telefone é inválido. Use 11 dígitos.")]
        [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O campo email é obrigatório")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo password é obrigatório")]
        [MinLength(8, ErrorMessage = "A senha deve conter no mínimo 8 caracteres")]
        public string Password { get; set; }

        [ForeignKey("TipoUsuario")]

        public int IdTipoUsuario { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public TipoUsuario TipoUsuario { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
        public string TokenRedefinicaoSenha { get; set; }
        public DateTime? DataExpiracaoTokenRedefinicaoSenha { get; set; }

    }
}
