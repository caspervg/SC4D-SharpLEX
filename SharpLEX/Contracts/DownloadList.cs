using System;
using RestSharp.Deserializers;

namespace SharpLEX.Contracts.Future
{
    public class Download
    {
        public Record Record { get; private set; }
        public Lot Lot { get; private set; }
    }

    public class Record
    {
        public int Id { get; private set; }
    }

    public class Lot
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Version { get; private set; }
        public string Author { get; private set; }
        [DeserializeAs(Name = "update_date")]
        public DateTime? LastUpdated { get; private set; }
    }
}
