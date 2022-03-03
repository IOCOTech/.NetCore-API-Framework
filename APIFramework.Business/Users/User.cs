using FluentValidation.Results;
using System.Linq;

namespace APIFramework.Business.Users
{
    public class User : Interfaces.Business.Users.IUser
    {
        private readonly Interfaces.Data.Users.IUser context;

        public User(Interfaces.Data.Users.IUser _context)
        {
            context = _context;
        }
        public Models.Users.User GetUser(string userId)
        {
            var result = context.GetUser(userId);
            return result;
        }

        public string SaveUser(Models.Users.User user)
        {
            user.Validate();
            var result = context.SaveUser(user);
            return result;
        }
    }
}