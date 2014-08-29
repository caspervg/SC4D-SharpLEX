using System;
using System.Net;

using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

using SharpLEX.Contracts;
using SharpLEX.Endpoints;


namespace SharpLEXTests
{
    [TestClass]
    public class SearchTest
    {

        [TestMethod]
        public void TestCategoryOverview()
        {
            SearchRoute route = new SearchRoute();

            CategoryOverview overview = route.GetCategories();

            Assert.AreEqual("Agriculture", overview.BroadCategories[0].Name);
            Assert.AreEqual("ADMIN", overview.LexAuthors[0].Name);
            Assert.AreEqual("00 Locked", overview.LexCategories[0].Name);
            Assert.AreEqual("BSC - VIP girafe flora", overview.LexGroups[0].Name);
            Assert.AreEqual("BTE", overview.LexTypes[0].Name);
        }

        [TestMethod]
        public void TestSearch()
        {
            SearchRoute route = new SearchRoute();

            route.AddFilter(SharpLEX.Filter.AMOUNT, 100);
            route.AddFilter(SharpLEX.Filter.CONCISE, false);
            route.AddFilter(SharpLEX.Filter.START, 0);
            route.AddFilter(SharpLEX.Filter.CREATOR, 1);
            route.AddFilter(SharpLEX.Filter.TITLE, "concorde");
            List<File> files = route.DoSearch();

            Assert.AreEqual(1007, files[0].Id);
        }
    }
}
