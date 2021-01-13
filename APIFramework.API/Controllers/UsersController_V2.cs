﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APIFramework.API.Controllers
{
    [Route("api/user")]
    [ApiVersion("2.0")]
    [ApiController]
    public class UsersController_V2 : ControllerBase
    {
        private readonly Interfaces.Business.Users.IUser context;
        private readonly ILogger<UsersController_V2> logger;

        public UsersController_V2(Interfaces.Business.Users.IUser _context, ILogger<UsersController_V2> logger)
        {
            context = _context;
            this.logger = logger;
        }

        // GET: api/Users/5
        [HttpGet("{userId}", Name = "Get")]
        public ActionResult<Models.Users.User> Get(string userId)
        {
            throw new NotImplementedException();
        }

        // POST: api/Users
        [HttpPost]
        public ActionResult<string> Post([FromBody] Models.Users.User user)
        {
            var result = context.SaveUser(user);
            return Ok(result);
        }

        //// PUT api/<UserController_V2>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController_V2>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
