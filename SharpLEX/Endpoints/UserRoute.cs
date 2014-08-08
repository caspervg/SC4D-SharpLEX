using System;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

using SharpLEX.Contracts;
using SharpLEX.Support;

namespace SharpLEX.Endpoints
{
    public class UserRoute
    {
        private NetworkCredential Credentials;

        public UserRoute (NetworkCredential cred) {
            this.Credentials = cred;
        }

        public User getMe()
        {
            HttpWebRequest request = WebRequest.Create(Route.ME.url()) as HttpWebRequest;
            request.Credentials = Credentials;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }                    
                DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                settings.DateTimeFormat = new DateTimeFormat("yyyyMMdd");

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(User), settings);
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                return objResponse as User;
            }
        }

        public User getUser(int userid)
        {
            HttpWebRequest request = WebRequest.Create(Route.USER.url(userid)) as HttpWebRequest;
            request.Credentials = Credentials;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }
                DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                settings.DateTimeFormat = new DateTimeFormat("yyyyMMdd");

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(User), settings);
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                return objResponse as User;
            }
        }

        public User[] getAllUsers(bool concise, int start, int amount)
        {
            NameValueCollection parameters = new NameValueCollection();
            parameters.Add("concise", concise.ToString());
            parameters.Add("start", start.ToString());
            parameters.Add("amount", amount.ToString());
            var url = Util.CreateUrl(Route.ALL_USER.url(), parameters);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            request.Credentials = Credentials;

            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).", response.StatusCode, response.StatusDescription));
                }
                DataContractJsonSerializerSettings settings = new DataContractJsonSerializerSettings();
                settings.DateTimeFormat = new DateTimeFormat("yyyyMMdd");

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(User[]), settings);
                object objResponse = jsonSerializer.ReadObject(response.GetResponseStream());
                return objResponse as User[];
            }
        }
    }
}
