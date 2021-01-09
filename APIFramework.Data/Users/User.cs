using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace APIFramework.Data.Users
{
    public class User : Interfaces.Data.Users.IUser
    {
        //private readonly DBCONTEXT context;
        private readonly ILogger<User> logger;

        public User(ILogger<User> logger) //pass "DBCONTEXT _context" as parameter in constructor
        {
            // context = _context;
            this.logger = logger;
        }


        public string SaveUser(Models.Users.User user)
        {

            logger.LogInformation($"User - userId - {user.id}");
            logger.LogTrace($"ClaimsInput - ObjectId - {user.id}", user.id);
            
            if (string.IsNullOrEmpty(user.id))
            {
                user.id = Guid.NewGuid().ToString();
                //context.Users.Add(user);
            }
            else
            {
                //context.Users.Update(user);
            }
            //context.SaveChanges();
            return user.id;
        }
        public Models.Users.User GetUser(string userId)
        {
            //var user = context.Users.FirstOrDefault(u => u.id == userId);
            return new Models.Users.User();// return user
        }
    }
}
