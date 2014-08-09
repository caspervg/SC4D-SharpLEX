using System;
using System.Collections.Generic;

using RestSharp;

using SharpLEX.Contracts;
using SharpLEX.Contracts.Future;
using SharpLEX.Contracts.History;

namespace SharpLEX.Endpoints
{
    public class UserRoute
    {
        private HttpBasicAuthenticator auth;

        public UserRoute (string username, string password) {
            this.auth = new HttpBasicAuthenticator(username, password);
        }

        public User getMe()
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.ME.endpoint());

            return api.Execute<User>(request);
        }

        public User getUser(int userid)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.USER.endpoint());
            request.AddParameter("id", userid, ParameterType.UrlSegment);

            return api.Execute<User>(request);
        }

        public List<User> getAllUsers(bool concise, int start, int amount)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.ALL_USER.endpoint());
            request.AddParameter("concise", concise);
            request.AddParameter("start", start);
            request.AddParameter("amount", amount);

            return api.Execute<List<User>>(request);
        }

        public List<Contracts.Future.Download> getDownloadList()
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.DOWNLOAD_LIST.endpoint());

            return api.Execute<List<Contracts.Future.Download>>(request);
        }

        public List<Contracts.History.Download> getDownloadHistory()
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.DOWNLOAD_HISTORY.endpoint());

            return api.Execute<List<Contracts.History.Download>>(request);
        }
    }
}
