using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIFramework.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly Interfaces.Business.Users.IUser context;
        private readonly ILogger<UsersController> logger;

        public UsersController(Interfaces.Business.Users.IUser _context, ILogger<UsersController> logger)
        {
            context = _context;
            this.logger = logger;
        }

        // GET: api/Users/5
        [HttpGet("{userId}", Name = "Get")]
        public ActionResult<Models.Users.User> Get(string userId)
        {
            var result = context.GetUser(userId);
            return Ok(result);
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<string> Post([FromBody] Models.Users.User user)
        {
            var result = context.SaveUser(user);
            return Ok(result);
        }

        //// PUT: api/Users/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
