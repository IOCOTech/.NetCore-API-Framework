using System;

namespace APIFramework.Mock.Business.Users
{
    public class User : Interfaces.Business.Users.IUser
    {
        public Models.Users.User GetUser(string userId)
        {
            return MockData.Users.UserData.FirstUser;
        }

        public string SaveUser(Models.Users.User user)
        {
            return MockData.Users.UserData.FirstUser.Id;
        }
    }
}