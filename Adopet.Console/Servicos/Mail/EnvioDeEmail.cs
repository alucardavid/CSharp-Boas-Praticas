using Adopet.Console.Servicos.Abstracoes;
using Adopet.Console.Settings;
using System.Net.Mail;
using System.Net;
using FluentResults;
using Adopet.Console.Results;

namespace Adopet.Console.Servicos.Mail
{
    public static class EnvioDeEmail
    {
        private static IMailService CriarMailService()
        {
            MailSettings settings = Configurations.MailSetting;
            SmtpClient smtp = new()
            {
                Host = settings.Servidor,
                Port = settings.Porta,
                Credentials = new NetworkCredential(settings.Usuario, settings.Senha),
                EnableSsl = true,
                UseDefaultCredentials = false
            };
            return new SmtpClientMailService(smtp);
        }

        public static void Disparar(Result resultado)
        {
            ISuccess? success = resultado.Successes.FirstOrDefault();
            if (success is null) return;
            if (success is SuccessWithPets sucesso)
            {
                var emailService = CriarMailService();
                emailService.SendMailAsync(
                    remetente: "alucardavid98@gmail.com",
                    titulo: $"[Adopet] {sucesso.Message}",
                    corpo: $"Foram importados {sucesso.Data.Count()} pets.",
                    destinatario: "d_pereira@outlook.com.br"
                   );
            }
        }

    }
}
