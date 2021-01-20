using APIFramework.UnitTests.Data.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.UnitTests.Data.Users
{
    [TestClass]
    public class UserTests
    {

        //APIFrameworkContext dbContext;
        //APIFramework.Data.Users.User dataLayer;

        [ClassInitialize]
        public static void TestFixtureSetup(TestContext context)
        {
            AppSettings.InitializeConfig();
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //dbContext = DBHelper.GetDBContext();
            //dbContext.Database.EnsureDeleted();
            //DBHelper.SeedDB(dbContext);

            var mock = new Mock<ILogger<APIFramework.Data.Users.User>>();
            mock.Verify(
               x => x.Log(
                   LogLevel.Information,
                   It.IsAny<EventId>(),
                   It.Is<It.IsAnyType>((o, t) => string.Equals("Index page say hello", o.ToString(), StringComparison.InvariantCultureIgnoreCase)),
                   It.IsAny<Exception>(),
                   (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
               Times.Once);

            // dataLayer = new APIFramework.Data.Users.User(mock.Object);
        }

        [TestMethod]
        public void GetUserClaims()
        {
            //Models.Users.User user = Mock.MockData.Users.UserData.ListUsers.First();
            //var result = dataLayer.GetUserClaims(user.id);
            //Assert.IsNotNull(result, "Value returned is null");
        }
    }
}