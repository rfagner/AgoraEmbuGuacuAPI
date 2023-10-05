namespace AgoraEmbuGuacuAPI.Interfaces
{
    public interface ILoginRepository
    {
        string Logar(string email, string senha);

        bool RecuperarSenha(string email);

        bool RedefinirSenha(string email, string token, string novaSenha);
    }
}
