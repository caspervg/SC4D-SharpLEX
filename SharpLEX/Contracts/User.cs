using System;
using RestSharp.Deserializers;

namespace SharpLEX.Contracts
{
    public class User
    {
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Username { get; private set; }
        public int UserLevel { get; private set; }
        public string Email { get; private set; }
        public DateTime Registered { get; private set; }
        public int LoginCount { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsDonator { get; private set; }
        public bool IsRater { get; private set; }
        public bool IsUploader { get; private set; }
        public bool IsAuthor { get; private set; }
        public bool IsAdmin { get; private set; }
    }
}
