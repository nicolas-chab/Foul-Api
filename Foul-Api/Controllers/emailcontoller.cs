using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace Foul_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class emailcontoller : ControllerBase
    {
        private readonly Iemailservice _emailservice;
        public emailcontoller(Iemailservice emailserrvice)
        {
            _emailservice = emailserrvice;
        }
        [HttpPost]
        public IActionResult sendemail(Emaildto request)
        {
            _emailservice.sendemail(request);
            return Ok();
        }
    }

}
