using APIFramework.Interfaces.Business.Users;
using APIFramework.Interfaces.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var result = context.SaveUser(user);
            return result;
        }
    }
}