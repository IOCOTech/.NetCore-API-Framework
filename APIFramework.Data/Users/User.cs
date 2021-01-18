using Microsoft.Extensions.Logging;
using System;

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
            logger.LogInformation($"User - userId - {user.Id}");
            logger.LogTrace($"User - userId - {user.Id}", user.Id);
            
            if (string.IsNullOrEmpty(user.Id))
            {
                user.Id = Guid.NewGuid().ToString();
                //context.Users.Add(user);
            }
            else
            {
                //context.Users.Update(user);
            }
            //context.SaveChanges();
            return user.Id;
        }
        public Models.Users.User GetUser(string userId)
        {
            //var user = context.Users.FirstOrDefault(u => u.id == userId);
            return new Models.Users.User();// return user
        }
    }
}
