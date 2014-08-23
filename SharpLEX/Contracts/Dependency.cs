using System;
using System.Collections.Generic;

using RestSharp.Deserializers;

namespace SharpLEX.Contracts
{
    public class Dependency
    {
        public int Id { get; private set; }
        [DeserializeAs(Name = "internal")]
        public bool IsInternal { get; private set; }
        public string Link { get; private set; }
        public string Name { get; private set; }
        public DependencyStatus Status { get; private set; }
    }

    public class DependencyStatus
    {
        [DeserializeAs(Name = "ok")]
        public bool IsOk { get; private set; }
        [DeserializeAs(Name = "deleted")]
        public bool IsDeleted { get; private set; }
        [DeserializeAs(Name = "locked")]
        public bool IsLocked { get; private set; }
        [DeserializeAs(Name = "superceded")]
        public bool IsSuperseded { get; private set; }
        [DeserializeAs(Name = "superceded_by")]
        public int Superseder { get; private set; }
    }


    public class DependencyOverview
    {
        public string Status { get; private set; }
        public int Count { get; private set; }
        public List<Dependency> List { get; private set; }
    }

    public class DependencyString
    {
        public string Dependency { get; private set; }
    }
}
