using AgoraEmbuGuacuAPI.Context;
using AgoraEmbuGuacuAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AgoraEmbuGuacuAPI.Entities;

namespace AgoraEmbuGuacuAPI.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly AgoraContext _context;

        public LoginRepository(AgoraContext context)
        {
            _context = context;
        }

        public string Logar(string email, string senha)
        {
            //return contextoBanco.Usuarios.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();

            // Irá realizar uma pesquisa pelo email do usuário
            var usuario = _context.Usuarios
                .Include(t => t.TipoUsuario)
                .FirstOrDefault(x => x.Email == email);


            if (usuario != null)
            {
                // Verifica se a senha que recebe por parâmetro é a mesma senha que está no banco
                bool validPassword = BCrypt.Net.BCrypt.Verify(senha, usuario.Password);



                if (validPassword)
                {
                    // Criar as credênciais do JWT

                    // Definimos as Claims
                    var minhasClaims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuario.Id.ToString()),
                        new Claim(ClaimTypes.Role, usuario.TipoUsuario.Tipo.ToString())

                    };

                    // Criamos as chaves
                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("clinica-vet-2022-@#$-chave-de-authenticacao"));

                    // Criamos as credênciais
                    var credenciais = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    // Geramos o token
                    var meuToken = new JwtSecurityToken(
                        issuer: "clinica.webAPI",
                        audience: "clinica.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: credenciais
                    );

                    // Retornamos o token em formato de string
                    return new JwtSecurityTokenHandler().WriteToken(meuToken);
                }

            }

            return null;
        }

        public bool RecuperarSenha(string email)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == email);

            if (usuario != null)
            {
                // Gere um token exclusivo para redefinição de senha
                var tokenRedefinicaoSenha = GerarTokenRedefinicaoSenha(usuario);

                // Armazene o token no banco de dados junto com a data de expiração (opcional)
                usuario.TokenRedefinicaoSenha = tokenRedefinicaoSenha;
                usuario.DataExpiracaoTokenRedefinicaoSenha = DateTime.UtcNow.AddHours(2); // Define um prazo de validade de 2 horas

                _context.SaveChanges();

                // Envie um e-mail com o token de redefinição de senha para o usuário (implementação real requer integração com serviço de e-mail)
                EnviarEmailRedefinicaoSenha(usuario.Email, tokenRedefinicaoSenha);

                return true;
            }

            return false;
        }

        public bool RedefinirSenha(string email, string token, string novaSenha)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == email);

            if (usuario != null && usuario.TokenRedefinicaoSenha == token && usuario.DataExpiracaoTokenRedefinicaoSenha >= DateTime.UtcNow)
            {
                // A validação do token é bem-sucedida e dentro do prazo de validade

                // Redefina a senha do usuário
                usuario.Password = BCrypt.Net.BCrypt.HashPassword(novaSenha);

                // Limpe o token de redefinição de senha e a data de expiração
                usuario.TokenRedefinicaoSenha = null;
                usuario.DataExpiracaoTokenRedefinicaoSenha = null;

                _context.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
