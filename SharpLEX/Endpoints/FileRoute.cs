using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

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

        public File GetFile(int fileid)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.LOT.endpoint());
            request.AddParameter("id", fileid, ParameterType.UrlSegment);

            return api.Execute<File>(request);
        }

        public List<File> GetAllFiles()
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.ALL_LOT.endpoint());

            return api.Execute<List<File>>(request);
        }

        public void DownloadFile(int fileid, string directory)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.DOWNLOAD_LOT.endpoint());
            request.AddParameter("id", fileid, ParameterType.UrlSegment);

            RestResponse response = api.ExecuteWithResponse(request);
            var contentDisposition = response.Headers.FirstOrDefault(h => h.Name == "Content-Disposition");
            var fileName = "file-" + fileid + ".zip";

            if (contentDisposition != null)
            {
                // Content-Disposition: attachment; filename="Install_CSX Farm SF - Veronique.zip"
                fileName = contentDisposition.ToString().Split(';')[1].Split('=')[1].Replace('\"', ' ').Trim();
            }

            try {
                System.IO.File.WriteAllBytes(directory + fileName, response.RawBytes);
            } catch (Exception ex) {
                const string message = "Error retrieving the downloaded file. Check inner details for more info.";
                throw new ApplicationException(message, ex);
            }
        }

        public void AddToDownloadList(int fileid)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.DOWNLOAD_LIST_LOT.endpoint());
            request.AddParameter("id", fileid, ParameterType.UrlSegment);

            api.Execute(request);
        }

        public void DeleteFromDownloadList(int fileid)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.DOWNLOAD_LIST_LOT.endpoint());
            request.Method = Method.DELETE;
            request.AddParameter("id", fileid, ParameterType.UrlSegment);

            api.Execute(request);
        }

        public List<Comment> GetComments(int fileid)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.COMMENT.endpoint());
            request.AddParameter("id", fileid, ParameterType.UrlSegment);

            return api.Execute<List<Comment>>(request);
        }

        public void AddComment(int fileid, int rating, string comment)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.COMMENT.endpoint());
            request.AddParameter("id", fileid, ParameterType.UrlSegment);

            if (rating > 0) {
                request.AddParameter("rating", rating);
            }

            if (comment.Length > 0)
            {
                request.AddParameter("comment", comment);
            }

            api.Execute(request);
        }

        public DependencyOverview GetDependencyOverview(int fileid)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.DEPENDENCY.endpoint());
            request.AddParameter("id", fileid, ParameterType.UrlSegment);

            return api.Execute<DependencyOverview>(request);
        }

        public string GetDependencyString(int fileid)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.DEPENDENCY_STRING.endpoint());
            request.AddParameter("id", fileid, ParameterType.UrlSegment);

            DependencyString depString = api.Execute<DependencyString>(request);
            return depString.Dependency;
        }

        public void UpdateDependencyString(int fileid, string dependencies)
        {
            var api = new LexApi(auth);
            var request = new RestRequest(Route.DEPENDENCY_STRING.endpoint());
            request.AddParameter("id", fileid, ParameterType.UrlSegment);
            request.AddParameter("string", dependencies);

            api.Execute(request);
        }
    }
}
