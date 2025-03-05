using Core_APISendMail.Modal;
using System.Net.Mail;
using System.Net;
namespace Core_APISendMail.Services
{
    public class MailServices : IMailServices
    {
        private readonly IConfiguration _configuration;
        public MailServices(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(Email model)
        {
            try
            {
                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(_configuration["Email:Username"], _configuration["Email:Password"]),
                    EnableSsl = true,
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(model.ToEmail),
                    Subject = $"Portfolio Contact: {model.Subject}",
                    Body = $"Name: {model.Name}\nEmail: {model.ToEmail}\nMessage: {model.Message}",
                    IsBodyHtml = false,
                };
                mailMessage.To.Add(_configuration["Email:RecipientEmail"]);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
