using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpLEX
{
    class RouteAttribute : Attribute
    {
        internal RouteAttribute(string endpoint)
        {
            this.Endpoint = endpoint;
        }

        public string Endpoint { get; private set; }
    }

    public static class Routes
    {
        private static readonly string location = "http://sc4devotion.com/csxlex/api/";
        private static readonly string version = "v2";

        public static string endpoint(this Route r) 
        {
            RouteAttribute attribute = GetAttribute(r);
            return attribute.Endpoint;
        }

        public static string url()
        {
            return location + version;
        }

        private static RouteAttribute GetAttribute(Route r)
        {
            return (RouteAttribute) Attribute.GetCustomAttribute(ForValue(r), typeof(RouteAttribute));
        }

        private static System.Reflection.MemberInfo ForValue(Route r)
        {
            return typeof(Route).GetField(Enum.GetName(typeof(Route), r));
        }
    }

    public enum Route
    {
        // User Routes
        [RouteAttribute("/user")] ME,
        [RouteAttribute("/user/{id}")] USER,
        [RouteAttribute("/user/all")] ALL_USER,
        [RouteAttribute("/user/download-list")] DOWNLOAD_LIST,
        [RouteAttribute("/user/download-history")] DOWNLOAD_HISTORY,
        [RouteAttribute("/user/register")] REGISTER,
        [RouteAttribute("/user/activate")] ACTIVATE,

        // Lot Routes
        [RouteAttribute("/lot/{id}")] LOT,
        [RouteAttribute("/lot/all")] ALL_LOT,
        [RouteAttribute("/lot/{id}/download")] DOWNLOAD_LOT,
        [RouteAttribute("/lot/{id}/download-list")] DOWNLOAD_LIST_LOT,
        [RouteAttribute("/lot/{id}/comment")] COMMENT,
        [RouteAttribute("/lot/{id}/dependency")] DEPENDENCY,
        [RouteAttribute("/lot/{id}/dependency-string")] DEPENDENCY_STRING,

        // Search Routes
        [RouteAttribute("/search")] SEARCH,

        // Category Routes
        [RouteAttribute("/category/broad-category")] BROAD_CATEGORY,
        [RouteAttribute("/category/lex-category")] LEX_CATEGORY,
        [RouteAttribute("/category/lex-type")] LEX_TYPE,
        [RouteAttribute("/category/group")] LOT_GROUP,
        [RouteAttribute("/category/author")] AUTHORS,
        [RouteAttribute("/category/all")] ALL_CATEGORY
    }
}
