using System;
using System.Net;
using System.Configuration;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using SharpLEX.Contracts;
using SharpLEX.Endpoints;

using Fut = SharpLEX.Contracts.Future;
using His = SharpLEX.Contracts.History;

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

            Assert.AreEqual(1, users[0].Id);
            Assert.AreEqual(10, users.Length);
        }

        [TestMethod]
        public void TestGetDownloadList()
        {
            UserRoute route = new UserRoute(cred);

            Fut.Download[] downloadList = route.getDownloadList();

            Assert.AreEqual(1, downloadList.Length);
            Assert.AreEqual("CP Map - St Elwood", downloadList[0].Lot.Name);
            Assert.AreEqual(13893494, downloadList[0].Record.Id);
        }

        [TestMethod]
        public void TestGetDownloadHistory()
        {
            UserRoute route = new UserRoute(cred);

            His.Download[] downloadHistory = route.getDownloadHistory();

            Assert.AreEqual("BSC Mega Props DAE Vol01", downloadHistory[0].Lot.Name);
            Assert.AreEqual(12850364, downloadHistory[0].Record.Id);
        }
    }
}
