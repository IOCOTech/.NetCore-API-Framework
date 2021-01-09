using APIFramework.MockData.Helpers;
using APIFramework.Models.Users;
using System.Collections.Generic;
using System.Text.Json;

namespace APIFramework.MockData.Users
{
    public static class UserData
    {
        private const string USERLIST_FILENAME = "users.mockdata.json";
        private const string USERNEW_FILENAME = "user-new.mockdata.json";
        public static Models.Users.User FirstUser => ListUsers[0];

        private static List<Models.Users.User> _listUsers;
        public static List<Models.Users.User> ListUsers
        {
            get
            {
                if (_listUsers == null)
                {
                    var strJson = ResourceHelper.GetResourceAsString(USERLIST_FILENAME);
                    var result = JsonSerializer.Deserialize<List<User>>(strJson);
                    _listUsers = result;
                }
                return _listUsers;
            }
        }
    };
}
