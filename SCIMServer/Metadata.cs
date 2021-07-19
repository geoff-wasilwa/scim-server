using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Models
{
    public class Metadata
    {
        public Metadata(string ResourceType)
        {
            this.ResourceType = ResourceType;
        }
        public string ResourceType { get; set; }
        public string Location { get; set; }
    }

    public class MetadataWithTime : Metadata
    {
        public MetadataWithTime(string ResourceType) : base(ResourceType)
        {
            this.ResourceType = ResourceType;
            this.Created = this.LastModified = DateTime.Now;
        }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
        public string Version { get; set; }
    }
}
