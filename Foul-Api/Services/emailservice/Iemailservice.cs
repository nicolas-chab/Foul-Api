using Foul_Api.Models;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace Foul_Api.Services.emailservice
{
    public interface Iemailservice
    {
        void sendemail(Emaildto request);
    }
}
