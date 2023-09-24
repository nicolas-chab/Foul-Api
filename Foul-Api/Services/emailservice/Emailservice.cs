using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace Foul_Api.Services.emailservice
{
    public class Emailservice : Iemailservice
    {
        private readonly IConfiguration _config;

        public Emailservice(IConfiguration config)
        {
            _config = config;
        }
        public void sendemail(Emaildto request)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
            email.To.Add(MailboxAddress.Parse(request.To));
            email.Subject = request.subject;
            email.Body = new TextPart(TextFormat.Html) { Text = request.body };
            using var smtp = new SmtpClient();
            smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);//if i need to send it to gmail instead of ethereal i put gmail
            smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
            smtp.Send(email);
            smtp.Disconnect(true);

        }
    }
}
