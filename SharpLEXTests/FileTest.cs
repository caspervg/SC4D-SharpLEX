using System;
using System.Net;
using System.Configuration;
using System.Linq;
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

            File file = route.GetFile(2987);

            Assert.AreEqual("BSC Aalesund Hospital Complex", file.Name);
            Assert.AreEqual("caspervg", file.Author);
            Assert.AreEqual(true, file.IsCertified);

            ObjectDumper.Dumper.Dump(file, "File", Console.Out);
        }

        [Ignore]
        [TestMethod]
        public void TestDownloadFile()
        {
            FileRoute route = new FileRoute(username, password);

            route.DownloadFile(2, "E:\\Binary\\");
        }

        [TestMethod]
        public void TestAllFiles()
        {
            FileRoute route = new FileRoute(username, password);

            List<File> files = route.GetAllFiles();

            Assert.AreEqual(2, files[0].Id);
            Assert.AreEqual(true, files.Any(f => f.Name == "BSC Aalesund Hospital Complex"));
        }

        [TestMethod]
        public void TestAddRemoveDownloadList()
        {
            FileRoute fileRoute = new FileRoute(username, password);
            UserRoute userRoute = new UserRoute(username, password);

            fileRoute.AddToDownloadList(2561);
            Assert.AreEqual(true, userRoute.getDownloadList().Any(f => f.Lot.Id == 2561));
            fileRoute.DeleteFromDownloadList(2561);
            Assert.AreEqual(false, userRoute.getDownloadList().Any(f => f.Lot.Id == 2561));
        }
    }
}
