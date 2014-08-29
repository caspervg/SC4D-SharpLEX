using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using RestSharp;

using SharpLEX.Contracts;

namespace SharpLEX.Endpoints
{
    public class SearchRoute
    {
        private Hashtable filters = new Hashtable();

        public CategoryOverview GetCategories()
        {
            var api = new LexApi(null);
            var request = new RestRequest(Route.ALL_CATEGORY.endpoint());

            return api.Execute<CategoryOverview>(request);
        }

        public List<File> DoSearch()
        {
            var api = new LexApi(null);
            var request = new RestRequest(Route.SEARCH.endpoint());

            foreach(string key in filters.Keys) {
                request.AddParameter(key, filters[key], ParameterType.QueryString);
            }

            return api.Execute<List<File>>(request);
        }

        public void AddFilter(Filter filter, Object value)
        {
            filters.Add(filter.Representation(), value.ToString().ToLower());
        }

        public void RemoveFilter(Filter filter)
        {
            filters.Remove(filter.Representation());
        }
    }
}