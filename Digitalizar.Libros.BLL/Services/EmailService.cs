using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Digitalizar.Libros.BLL.Contrato;
using Digitalizar.Libros.Models.VModels;
using Microsoft.Extensions.Configuration;

namespace Digitalizar.Libros.BLL.Services
{
    public class EmailService: IEmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> EnviarEmailAsync(string emailDestinatario, string asunto, string mensaje)
        {
            try
            {
                var email = new MimeMessage();

                email.From.Add(new MailboxAddress("Digitalizar", _config["Email:UserName"]));


                email.To.Add(MailboxAddress.Parse(emailDestinatario));

                email.Subject = asunto;

                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = mensaje
                };


                using (var smtp = new SmtpClient())
                {

                    await smtp.ConnectAsync(_config["Email:Host"], int.Parse(_config["Email:Port"]!), SecureSocketOptions.StartTls);

                    await smtp.AuthenticateAsync(_config["Email:UserName"], _config["Email:PassWord"]);

                    await smtp.SendAsync(email);

                    await smtp.DisconnectAsync(true);
                };


                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void SendEmail(VMEmail request)
        {
            try
            {
                var email = new MimeMessage();

                email.From.Add(MailboxAddress.Parse(_config.GetSection("Email:UserNme").Value));

                email.From.Add(MailboxAddress.Parse(request.Para));

                email.Subject = request.Asunto;

                email.Body = new TextPart(TextFormat.Html)
                {
                    Text = request.Contenido
                };

                using var smtp = new SmtpClient();

                smtp.Connect(

                    _config.GetSection("Email:Host").Value,
                    Convert.ToInt32(_config.GetSection("Email:Port").Value),
                    SecureSocketOptions.StartTls

                    );

                smtp.Authenticate(_config.GetSection("Email:UserNme").Value, _config.GetSection("Email:PassWord").Value);

                smtp.Send(email);

                smtp.Disconnect(true);

            }
            catch(Exception) 
            { 
                throw;  
            }
           
        }
    }
}
