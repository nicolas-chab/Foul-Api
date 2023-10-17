using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System.Security.Cryptography;

namespace Foul_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Refereecontroller : ControllerBase
    {
      

            private readonly Datacontext db;

            private void createpasswordhash(string password, out byte[] passwordhash, out byte[] passwordsalt)
            {
                using (var hmac = new HMACSHA512())
                {
                    passwordsalt = hmac.Key;
                    passwordhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                }

            }
            private bool verifypasswordhash(string password, byte[] passwordhash, byte[] passwordsalt)
            {
                using (var hmac = new HMACSHA512(passwordsalt))
                {

                    var computedhash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                    return computedhash.SequenceEqual(passwordhash);
                }

            }
            private string createrandomtoken()
            {
                return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
            }
            public Refereecontroller(Datacontext context)
            {
                db = context;
            }

            [HttpPost("registerreferee")]
            public async Task<IActionResult> CreateReferee(refereeregisterrequest1 request)
            {
                if (db.referees.Any(r => r.email == request.email))
                {
                    return BadRequest("referee already exists");

                }
                createpasswordhash(request.password, out byte[] passwordhash, out byte[] passwordsalt);
                var referee = new Referee
                {
                    FirstAndLastName = request.Fullname,
                    email = request.email,
                    legajo= request.numerodelegajo,
                    password = request.password,
                    passwordhash = passwordhash,
                    passwordsalt = passwordsalt,
                    verificationtoken = createrandomtoken()
                };
                db.referees.Add(referee);
                await db.SaveChangesAsync();

                return Ok("referee successfully created");
            }

            [HttpPost("login-referee")]
            public async Task<IActionResult> Login(refereelogin request)
            {
                var referee = await db.referees.FirstOrDefaultAsync(r => r.email == request.email);
                if (referee == null)
                {
                    return BadRequest("referee not found");
                }
                if (!verifypasswordhash(request.password, referee.passwordhash, referee.passwordsalt))
                {
                    return BadRequest("Password is incorrect");
                }
                if (referee.verifiedat == null)
                {
                    return BadRequest("not verified");
                }

                return Ok($"welcome back, {referee.FirstAndLastName}!");
            }
            [HttpPost("Verify-referee")]
            public async Task<IActionResult> Verify(string token)
            {
                var referee = await db.referees.FirstOrDefaultAsync(r => r.verificationtoken == token);
                if (referee == null)
                {
                    return BadRequest("invalid token");
                }
                referee.verifiedat = DateTime.Now;
                await db.SaveChangesAsync();
                return Ok("referee verified");
            }
            [HttpPost("forgot-password-refere")]
            public async Task<IActionResult> forgotpasswordreferee(string email)
            {
                var referee = await db.referees.FirstOrDefaultAsync(r => r.email == email);
                if (referee == null)
                {
                    return BadRequest("referee not found");
                }
                referee.passwordresettoken = createrandomtoken();
                referee.resettokenexpires = DateTime.Now.AddDays(10);
                await db.SaveChangesAsync();

                return Ok("you may now reset your password");
            }
            [HttpPost("reset-password-referee")]
            public async Task<IActionResult> resetpasswordreferee(resetpasswordrequest request)
            {
                var referee = await db.referees.FirstOrDefaultAsync(r => r.passwordresettoken == request.token);
                if (referee == null || referee.resettokenexpires < DateTime.Now)
                {
                    return BadRequest("Invalid token.");
                }
                createpasswordhash(request.password, out byte[] passwordhash, out byte[] passwordsalt);

                referee.passwordhash = passwordhash;
                referee.passwordsalt = passwordsalt;
                referee.password = request.password;
                referee.passwordresettoken = null;
                referee.resettokenexpires = null;
                db.referees.Update(referee);
                await db.SaveChangesAsync();
                return Ok("password succesfully reset.");
            }

        }
    }

