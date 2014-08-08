using System;
using System.Net;
using System.Configuration;
using SharpLEX.Contracts;
using SharpLEX.Endpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SharpLEXTests
{
    [TestClass]
    public class UserTest
    {
        private NetworkCredential cred;

        [TestInitialize]
        public void TestInitialize()
        {
            var username = ConfigurationManager.AppSettings["username"];
            var password = ConfigurationManager.AppSettings["password"];
            cred = new NetworkCredential(username, password);
        }

        [TestMethod]
        public void TestMe()
        {
            UserRoute route = new UserRoute(cred);

            User user = route.getMe();

            Assert.AreEqual("Casper Vg", user.FullName);
            Assert.AreEqual(true, user.Admin);
        }

        [TestMethod]
        public void TestUser()
        {
            UserRoute route = new UserRoute(cred);

            User user = route.getUser(1);

            Assert.AreEqual("ADMIN", user.UserName);
            Assert.AreEqual(1, user.Id);
        }

        [TestMethod]
        public void TestAllUsers()
        {
            UserRoute route = new UserRoute(cred);

            User[] users = route.getAllUsers(true, 0, 10);

            Console.WriteLine(users[0].Id);
        }
    }
}
