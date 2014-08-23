using System;
using RestSharp;

namespace SharpLEX.Endpoints
{
    public class LexApi
    {
        private static readonly string location = "http://sc4devotion.com/csxlex/api/";
        private static readonly string version = "v3";

        readonly HttpBasicAuthenticator _auth;

        public LexApi(string username, string password)
        {
            this._auth = new HttpBasicAuthenticator(username, password);
        }

        public LexApi(HttpBasicAuthenticator auth)
        {
            this._auth = auth;
        }

        public T Execute<T>(RestRequest request) where T : new()
        {
            var client = new RestClient(location + version);
            client.Authenticator = _auth;

            request.DateFormat = "yyyyMMdd";

            var response = client.Execute<T>(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving LEX API response. Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return response.Data;
        }

        public void Execute(RestRequest request)
        {
            var client = new RestClient(location + version);
            client.Authenticator = _auth;

            var response = client.Execute(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving LEX API response. Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }
        }

        public RestResponse ExecuteWithResponse(RestRequest request)
        {
            var client = new RestClient(location + version);
            client.Authenticator = _auth;

            var response = client.Execute(request);

            if (response.ErrorException != null)
            {
                const string message = "Error retrieving LEX API response. Check inner details for more info.";
                throw new ApplicationException(message, response.ErrorException);
            }

            return (RestResponse) response;
        }
    }
}
