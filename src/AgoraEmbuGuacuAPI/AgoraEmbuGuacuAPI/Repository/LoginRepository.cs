using AgoraEmbuGuacuAPI.Context;
using AgoraEmbuGuacuAPI.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AgoraEmbuGuacuAPI.Entities;
using System.Net.Mail;
using System.Net;
using MimeKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

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
                var tokenRedefinicaoSenha = GerarTokenRedefinicaoSenha();

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


        // Método auxiliar para gerar um token exclusivo para redefinição de senha
        private string GerarTokenRedefinicaoSenha()
        {
            // Use a biblioteca Guid para gerar um token exclusivo
            return Guid.NewGuid().ToString();
        }

        // Método auxiliar para enviar um e-mail com o token de redefinição de senha
        private void EnviarEmailRedefinicaoSenha(string email, string token)
        {
            // Este é um exemplo de implementação genérica de envio de e-mail.
            // Dependendo da sua infraestrutura, você pode optar por integrar um serviço de e-mail, como SendGrid,
            // ou usar uma biblioteca de envio de e-mail, como SmtpClient.

            try
            {
                // Configure a mensagem de e-mail
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Seu Nome", "seu_email@gmail.com")); // Remetente
                message.To.Add(new MailboxAddress("Nome do Destinatário", email)); // Destinatário
                message.Subject = "Redefinição de Senha"; // Assunto

                // Corpo do e-mail
                var bodyBuilder = new BodyBuilder();
                bodyBuilder.TextBody = $"Use o seguinte token para redefinir sua senha: {token}";

                message.Body = bodyBuilder.ToMessageBody();

                // Configure o cliente SMTP (exemplo com Gmail)
                using (var client = new SmtpClient())
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("seu_email@gmail.com", "sua_senha"); // Substitua pelo seu e-mail e senha
                    client.Send(message);
                    client.Disconnect(true);
                }
            }
            catch (Exception ex)
            {
                // Lidar com erros de envio de e-mail, como falhas de autenticação ou problemas de conexão
                // Você pode registrar os erros ou notificar o usuário, dependendo dos requisitos do seu aplicativo.
                Console.WriteLine($"Erro ao enviar e-mail: {ex.Message}");
            }
        }


    }
}
