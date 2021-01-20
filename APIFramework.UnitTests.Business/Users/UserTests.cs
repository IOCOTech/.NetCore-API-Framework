using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIFramework.UnitTests.Business.Users
{
    [TestClass]
    public class UserTest
    {
        readonly Moq.Mock<Interfaces.Data.Users.IUser> mockRepo = new Mock<Interfaces.Data.Users.IUser>();
        private Interfaces.Business.Users.IUser context;

        [TestInitialize]
        public void TestInitialize()
        {
            context = new APIFramework.Business.Users.User(mockRepo.Object);
        }

        [TestMethod]
        public void GetUser()
        {
            string UserID = "3e7fd640-2b65-4395-becf-3bc948ea045a";
            mockRepo.Setup(repo => repo.GetUser(UserID))
                .Returns(MockData.Users.UserData.ListUsers.First());
            var resultUser = this.context.GetUser(UserID);
            Assert.IsNotNull(resultUser.Id, "UserId returned is null");
        }
    }
}
