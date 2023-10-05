namespace AgoraEmbuGuacuAPI.Entities
{
    public class RedefinirSenhaRequest
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NovaSenha { get; set; }
    }
}
