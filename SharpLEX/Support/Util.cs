using System;
using System.Web;
using System.Linq;
using System.Collections.Specialized;

namespace SharpLEX.Support
{
    public class Util
    {
        public static string CreateUrl(string url, NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                         from value in nvc.GetValues(key)
                         select string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(value)))
                .ToArray();
            return url + "?" + string.Join("&", array);
        }
    }
}
