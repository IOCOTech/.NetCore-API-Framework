using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.Interfaces.Business.Users
{
    public interface IUser
    {
        public string SaveUser(Models.Users.User user);
        public Models.Users.User GetUser(string userId);
    }
}
