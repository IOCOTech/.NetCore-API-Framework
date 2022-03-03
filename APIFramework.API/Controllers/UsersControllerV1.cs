using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace APIFramework.API.Controllers
{
    [Route("api/user")]
    [ControllerName("User")]
    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    [ApiController]
    public class UsersControllerV1 : ControllerBase
    {
        private readonly Interfaces.Business.Users.IUser context;
        private readonly ILogger<UsersControllerV2> logger;

        public UsersControllerV1(Interfaces.Business.Users.IUser context, ILogger<UsersControllerV2> logger)
        {
            this.context = context;
            this.logger = logger;
        }

        // GET: api/Users/5
        [HttpGet("{userId}", Name = "Get")]
        [ApiVersion("1.0")]
        public ActionResult<Models.Users.User> Get(string userId)
        {
            this.logger.LogInformation("Get user");
            var result = context.GetUser(userId);
            return Ok(result);
        }

        // POST: api/Users
        [HttpPost]
        [ApiVersion("1.0")]
        [ApiVersion("1.1")]
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
