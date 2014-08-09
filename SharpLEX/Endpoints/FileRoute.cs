using System;
using System.Collections.Generic;

using RestSharp;

using SharpLEX.Contracts;
using SharpLEX.Contracts.Future;
using SharpLEX.Contracts.History;

namespace SharpLEX.Endpoints
{
    public class FileRoute
    {
        private HttpBasicAuthenticator auth;

        public FileRoute (string username, string password) {
            this.auth = new HttpBasicAuthenticator(username, password);
        }

        public File getFile(int fileid)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.LOT.endpoint());
            request.AddParameter("id", fileid, ParameterType.UrlSegment);

            return api.Execute<File>(request);
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

        public void doRegistration(string username, string password, string email, string fullname)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.REGISTER.endpoint());
            request.Method = Method.POST;
            request.AddParameter("username", username);
            request.AddParameter("password_1", password);
            request.AddParameter("password_2", password);
            request.AddParameter("email", email);
            if (fullname != null) request.AddParameter("fullname", fullname);

            api.Execute(request);
        }

        public void doActivation(string key)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.ACTIVATE.endpoint());
            request.AddParameter("activation_key", key);

            api.Execute(request);
        }
    }
}
