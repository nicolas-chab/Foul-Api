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
    public class Refereecontroller : ControllerBase
    {
        private readonly Datacontext _context;

        public Refereecontroller(Datacontext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] Referee referee)
        {
            // Add the referee to the database
            _context.referees.Add(referee);
            _context.SaveChanges();
            return Ok("Registration successful.");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] Referee loginRequest)
        {
            Referee referee = _context.referees.FirstOrDefault(r => r.email == loginRequest.email && r.password == loginRequest.password);
            if (referee != null)
            {
                return Ok($"Welcome, {referee.FirstAndLastName}.");
            }
            else
            {
                return BadRequest("Login failed.");
            }
        }

    }
}
