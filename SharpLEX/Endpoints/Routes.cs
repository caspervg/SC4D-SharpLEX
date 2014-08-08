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
        private static readonly string Base = "http://sc4devotion.com/csxlex/api/";
        private static readonly string Version = "v2";

        public static string url(this Route r) 
        {
            RouteAttribute Attribute = GetAttribute(r);
            return Base + Version + Attribute.Endpoint;
        }

        public static string url(this Route r, int id)
        {
            RouteAttribute Attribute = GetAttribute(r);
            return Base + Version + String.Format(Attribute.Endpoint, id);
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
        [RouteAttribute("/user/{0}")] USER,
        [RouteAttribute("/user/all")] ALL_USER,
        [RouteAttribute("/user/download-list")] DOWNLOAD_LIST,
        [RouteAttribute("/user/download-history")] DOWNLOAD_HISTORY,
        [RouteAttribute("/user/register")] REGISTER,
        [RouteAttribute("/user/activate")] ACTIVATE,

        // Lot Routes
        [RouteAttribute("/lot/{0}")] LOT,
        [RouteAttribute("/lot/all")] ALL_LOT,
        [RouteAttribute("/lot/{0}/download")] DOWNLOAD_LOT,
        [RouteAttribute("/lot/{0}/download-list")] DOWNLOAD_LIST_LOT,
        [RouteAttribute("/lot/{0}/comment")] COMMENT,
        [RouteAttribute("/lot/{0}/dependency")] DEPENDENCY,
        [RouteAttribute("/lot/{0}/dependency-string")] DEPENDENCY_STRING,

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
