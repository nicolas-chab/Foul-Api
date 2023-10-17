//using Azure.Core;
//using Foul_Api.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Org.BouncyCastle.Asn1;
//using Org.BouncyCastle.Asn1.Ocsp;
//using Org.BouncyCastle.Ocsp;
//using System.Security.Cryptography;

//namespace Foul_Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TeamsController : ControllerBase
//    {
//        private readonly Datacontext db;
//        private readonly Dictionary<int, List<string>> _userSubscriptions; // In-memory user subscriptions (for simplicity)




//        public TeamsController(Datacontext context)
//        {
//            db = context;
//            _userSubscriptions = new Dictionary<int, List<string>>();
//        }

//        [HttpGet]
//        public ActionResult GetAll()
//        {
//            var list = (
//                from Team in db.Team

//                select new
//                {
//                    Team.id,
//                    Team.zona,
//                    Team.player,
//                    Team.trainer,
//                    Team.partidos

//                });
//            return Ok(list);


//            // return await db.Team.Include(t => t.Player).ToListAsync();
//        }
//        [HttpPost("subscribe")]
//        public ActionResult SubscribeToTeam(int userId, int teamId)
//        {
//            var user = db.users.FirstOrDefault(u => u.id == userId);
//            var team = db.Team.FirstOrDefault(t => t.id == teamId);

//            if (user != null && team != null)
//            {
//                // Parse the existing comma-separated team IDs
//                var subscribedTeamIds = user.SubscribedTeams?.Split(',').Select(int.Parse).ToList() ?? new List<int>();

//                // Check if the teamId is not already in the user's subscribed teams
//                if (!subscribedTeamIds.Contains(teamId))
//                {
//                    // Add the teamId to the list of subscribed teams
//                    subscribedTeamIds.Add(teamId);

//                    // Join the list of team IDs back into a comma-separated string
//                    user.SubscribedTeams = string.Join(",", subscribedTeamIds);

//                    db.SaveChanges();

//                    // You can also update the team's SubscribedUsers similarly

//                    return Ok("Subscription successful.");
//                }
//                else
//                {
//                    return BadRequest("User is already subscribed to this team.");
//                }
//            }

//            return NotFound("User or team not found.");
//        }


//        [HttpGet("teams/{userId}")]
//        public ActionResult GetTeamsForUser(int userId)
//        {
//            var user = db.users.FirstOrDefault(u => u.id == userId);

//            if (user != null)
//            {
//                if (user.SubscribedTeams != null)
//                {
//                    var teamIds = user.SubscribedTeams.Split(',').Select(int.Parse).ToList();

//                    var teams = db.Team.Where(t => teamIds.Contains(t.id)).ToList();

//                    return Ok(teams);
//                }
//                return NotFound("you have to subscribe to a team for this to show something");
//            }

//            return NotFound("User not found.");
//        }



//    }
//}
//using Azure.Core;
//using Foul_Api.Models;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Org.BouncyCastle.Asn1;
//using Org.BouncyCastle.Asn1.Ocsp;
//using Org.BouncyCastle.Ocsp;
//using System.Security.Cryptography;

//namespace Foul_Api.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class TeamsController : ControllerBase
//    {
//        private readonly Datacontext db;
//        private readonly Dictionary<int, List<string>> _userSubscriptions; // In-memory user subscriptions (for simplicity)




//        public TeamsController(Datacontext context)
//        {
//            db = context;
//            _userSubscriptions = new Dictionary<int, List<string>>();
//        }

//        [HttpGet]
//        public ActionResult GetAll()
//        {
//            var list = (
//                from Team in db.Team

//                select new
//                {
//                    Team.id,
//                    Team.zona,
//                    Team.player,
//                    Team.trainer,
//                    Team.partidos

//                });
//            return Ok(list);


//            // return await db.Team.Include(t => t.Player).ToListAsync();
//        }
//        [HttpPost("subscribe")]
//        public ActionResult SubscribeToTeam(int userId, int teamId)
//        {
//            var user = db.users.FirstOrDefault(u => u.id == userId);
//            var team = db.Team.FirstOrDefault(t => t.id == teamId);

//            if (user != null && team != null)
//            {
//                // Parse the existing comma-separated team IDs
//                var subscribedTeamIds = user.SubscribedTeams?.Split(',').Select(int.Parse).ToList() ?? new List<int>();

//                // Check if the teamId is not already in the user's subscribed teams
//                if (!subscribedTeamIds.Contains(teamId))
//                {
//                    // Add the teamId to the list of subscribed teams
//                    subscribedTeamIds.Add(teamId);

//                    // Join the list of team IDs back into a comma-separated string
//                    user.SubscribedTeams = string.Join(",", subscribedTeamIds);

//                    db.SaveChanges();

//                    // You can also update the team's SubscribedUsers similarly

//                    return Ok("Subscription successful.");
//                }
//                else
//                {
//                    return BadRequest("User is already subscribed to this team.");
//                }
//            }

//            return NotFound("User or team not found.");
//        }


//        [HttpGet("teams/{userId}")]
//        public ActionResult GetTeamsForUser(int userId)
//        {
//            var user = db.users.FirstOrDefault(u => u.id == userId);

//            if (user != null)
//            {
//                if (user.SubscribedTeams != null)
//                {
//                    var teamIds = user.SubscribedTeams.Split(',').Select(int.Parse).ToList();

//                    var teams = db.Team.Where(t => teamIds.Contains(t.id)).ToList();

//                    return Ok(teams);
//                }
//                return NotFound("you have to subscribe to a team for this to show something");
//            }

//            return NotFound("User not found.");
//        }



//    }
//}

