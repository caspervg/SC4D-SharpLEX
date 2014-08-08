using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace SharpLEX.Contracts
{
    [DataContract]
    public class User
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }
        [DataMember(Name = "fullname")]
        public string FullName { get; private set; }
        [DataMember(Name = "username")]
        public string UserName { get; private set; }
        [DataMember(Name = "user_level")]
        public int UserLevel { get; private set; }
        [DataMember(Name = "email")]
        public string Email { get; private set; }
        [DataMember(Name = "login_count")]
        public int LoginCount { get; private set; }
        [DataMember(Name = "is_active")]
        public bool Active { get; private set; }
        [DataMember(Name = "is_donator")]
        public bool Donator { get; private set; }
        [DataMember(Name = "is_rater")]
        public bool Rater { get; private set; }
        [DataMember(Name = "is_uploader")]
        public bool Uploader { get; private set; }
        [DataMember(Name = "is_author")]
        public bool Author { get; private set; }
        [DataMember(Name = "is_admin")]
        public bool Admin { get; private set; }
    }
}
