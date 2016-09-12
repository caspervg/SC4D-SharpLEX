using System;
using RestSharp.Deserializers;

namespace SharpLEX.Contracts.History
{
    public class Download
    {
        public Record Record { get; private set; }
        public Lot Lot { get; private set; }
    }

    public class Record
    {
        public int Id { get; private set; }
        public DateTime LastDownloaded { get; private set; }
        public string LastVersion { get; private set; }
        public string DownloadCount { get; private set; }
    } 

    public class Lot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Version { get; private set; }
        public string Author { get; private set; }

        [DeserializeAs(Name = "update_date")]
        public DateTime? Updated { get; private set; }
    }
}
