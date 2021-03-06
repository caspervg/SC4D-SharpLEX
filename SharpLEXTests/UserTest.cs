﻿using System;
using System.Net;
using System.IO;
using System.Configuration;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

using SharpLEX.Contracts;
using SharpLEX.Endpoints;

using Fut = SharpLEX.Contracts.Future;
using His = SharpLEX.Contracts.History;

namespace SharpLEXTests
{
    [TestClass]
    public class UserTest
    {
        private string username;
        private string password;

        [TestInitialize]
        public void TestInitialize()
        {
            this.username = ConfigurationManager.AppSettings["username"];
            this.password = ConfigurationManager.AppSettings["password"];
        }

        [TestMethod]
        public void TestMe()
        {
            UserRoute route = new UserRoute(username, password);

            User user = route.getMe();

            Assert.AreEqual("Casper Vg", user.FullName);
            Assert.AreEqual(true, user.IsAdmin);
            Assert.AreEqual(new DateTime(2007, 06, 02), user.Registered);

            ObjectDumper.Dumper.Dump(user, "Me", Console.Out);
        }

        [TestMethod]
        public void TestUser()
        {
            UserRoute route = new UserRoute(username, password);

            User user = route.getUser(1);

            Assert.AreEqual("ADMIN", user.Username);
            Assert.AreEqual(1, user.Id);

            ObjectDumper.Dumper.Dump(user, "User", Console.Out);
        }

        [TestMethod]
        public void TestAllUsers()
        {
            UserRoute route = new UserRoute(username, password);

            List<User> users = route.getAllUsers(true, 0, 10);

            Assert.AreEqual(1, users[0].Id);
            Assert.AreEqual(10, users.Count);

            ObjectDumper.Dumper.Dump(users, "AllUsers", Console.Out);
        }

        [TestMethod]
        public void TestGetDownloadList()
        {
            UserRoute route = new UserRoute(username, password);

            List<Fut.Download> downloadList = route.getDownloadList();

            Assert.IsNotNull(downloadList);
            Assert.IsTrue(downloadList.Count > 0);

            ObjectDumper.Dumper.Dump(downloadList, "GetDownloadList", Console.Out);
        }

        [TestMethod]
        public void TestGetDownloadHistory()
        {
            UserRoute route = new UserRoute(username, password);

            List<His.Download> downloadHistory = route.getDownloadHistory();

            Assert.AreEqual("BSC Mega Props DAE Vol01", downloadHistory[0].Lot.Name);
            Assert.AreEqual(12850364, downloadHistory[0].Record.Id);

            ObjectDumper.Dumper.Dump(downloadHistory, "GetDownloadHistory", Console.Out);
        }
    }
}
