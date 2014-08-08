using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace SharpLEX.Contracts.History
{
    [DataContract]
    public class Download
    {
        [DataMember(Name = "record")]
        public Record Record { get; private set; }
        [DataMember(Name = "lot")]
        public Lot Lot { get; private set; }
    }

    [DataContract]
    public class Record
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }
        [DataMember(Name = "last_downloaded")]
        public DateTime LastDownloaded { get; private set; }
        [DataMember(Name = "last_version")]
        public string LastVersion { get; private set; }
        [DataMember(Name = "download_count")]
        public string DownloadCount { get; private set; }
    } 

    [DataContract]
    public class Lot
    {
        [DataMember(Name = "id")]
        public int Id { get; private set; }
        [DataMember(Name = "name")]
        public string Name { get; private set; }
        [DataMember(Name = "update_date")]
        public DateTime? Updated { get; private set; }
        [DataMember(Name = "version")]
        public string Verion { get; private set; }
        [DataMember(Name = "author")]
        public string Author { get; private set; }
    }
}
