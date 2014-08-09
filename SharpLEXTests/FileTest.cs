using System;
using System.Net;
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
    public class FileTest
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
        public void TestFile()
        {
            FileRoute route = new FileRoute(username, password);

            File file = route.getFile(2987);

            Assert.AreEqual("BSC Aalesund Hospital Complex", file.Name);
            Assert.AreEqual("caspervg", file.Author);
            Assert.AreEqual(true, file.IsCertified);

            ObjectDumper.Dumper.Dump(file, "File", Console.Out);
        }
    }
}
