using System;
using System.Collections.Generic;
using RestSharp.Deserializers;

namespace SharpLEX.Contracts
{
    public class Comment
    {
        public int Id { get; private set; }
        [DeserializeAs(Name = "user")]
        public string Username { get; private set; }
        public string Text { get; private set; }
        public DateTime Date { get; private set; }
        [DeserializeAs(Name = "by_author")]
        public bool isAuthor { get; private set; }
        [DeserializeAs(Name = "by_admin")]
        public bool isAdmin { get; private set; }
    }
}
