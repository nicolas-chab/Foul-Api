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
                if (db.referees.Any(r => r.email == request.emailr))
                {
                    return BadRequest("referee already exists");

                }
                createpasswordhash(request.passwordr, out byte[] passwordhash, out byte[] passwordsalt);
                var referee = new Referee
                {
                    FirstAndLastName = request.Fullnamer,
                    email = request.emailr,
                    legajo= request.numerodelegajor,
                    password = request.passwordr,
                    passwordhash = passwordhash,
                    passwordsalt = passwordsalt,
                    verificationtoken = createrandomtoken()
                };
                db.referees.Add(referee);
                await db.SaveChangesAsync();

                return Ok("user successfully created");
            }

            [HttpPost("login")]
            public async Task<IActionResult> Login(refereeregisterrequest request)
            {
                var referee = await db.users.FirstOrDefaultAsync(r => r.email == request.email);
                if (referee == null)
                {
                    return BadRequest("user not found");
                }
                if (!verifypasswordhash(request.password, user.passwordhash, user.passwordsalt))
                {
                    return BadRequest("Password is incorrect");
                }
                if (referee.verifiedat == null)
                {
                    return BadRequest("not verified");
                }

                return Ok($"welcome back, {user.email}!");
            }
            [HttpPost("Verify")]
            public async Task<IActionResult> Verify(string token)
            {
                var user = await db.users.FirstOrDefaultAsync(u => u.verificationtoken == token);
                if (user == null)
                {
                    return BadRequest("invalid token");
                }
                user.verifiedat = DateTime.Now;
                await db.SaveChangesAsync();
                return Ok("user verified");
            }
            [HttpPost("forgot-password")]
            public async Task<IActionResult> forgotpassword(string email)
            {
                var user = await db.users.FirstOrDefaultAsync(u => u.email == email);
                if (user == null)
                {
                    return BadRequest("user not found");
                }
                user.passwordresettoken = createrandomtoken();
                user.resettokenexpires = DateTime.Now.AddDays(10);
                await db.SaveChangesAsync();

                return Ok("you may now reset your password");
            }
            [HttpPost("reset-password")]
            public async Task<IActionResult> resetpassword(resetpasswordrequest request)
            {
                var user = await db.users.FirstOrDefaultAsync(u => u.passwordresettoken == request.token);
                if (user == null || user.resettokenexpires < DateTime.Now)
                {
                    return BadRequest("Invalid token.");
                }
                createpasswordhash(request.password, out byte[] passwordhash, out byte[] passwordsalt);

                user.passwordhash = passwordhash;
                user.passwordsalt = passwordsalt;
                user.password = request.password;
                user.passwordresettoken = null;
                user.resettokenexpires = null;
                db.referees.Update(Referee);
                await db.SaveChangesAsync();
                return Ok("password succesfully reset.");
            }

        }
    }

