using System;

using RestSharp.Deserializers;

namespace SharpLEX.Contracts
{
    public class File
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Version { get; private set; }
        [DeserializeAs(Name = "num_downloads")]
        public int DownloadCount { get; private set; }
        public string Author { get; private set; }
        public bool IsExclusive { get; private set; }
        [DeserializeAs(Name = "maxis_category")]
        public string BroadCategory { get; private set; }
        public string Description { get; private set; }
        public FileImages Images { get; private set; }
        public string Link { get; private set; }
        public bool IsCertified { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime UploadDate { get; private set; }
        public DateTime? UpdateDate { get; private set; }
        public DependencyOverview Dependencies { get; private set; }
    }

    public class FileImages
    {
        public string Primary { get; private set; }
        public string Secondary { get; private set; }
        public string Extra { get; private set; }
    }

}
