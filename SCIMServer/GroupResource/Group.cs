using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SCIMServer.Models
{
    public class Group : Resource
    {
        public Group() : base(new string[] { SchemaUrns.GroupResource }) { }
        public string ExternalId { get; set; }
        public string DisplayName { get; set; }
        public Member[] Members { get; set; }
        public MetadataWithTime Meta { get; set; } = new("Group");
    }

    public struct Member
    {
        public string Value { get; set; }
        [JsonPropertyName("$ref")]
        public string Reference { get; set; }
        public string Display { get; set; }
    }
}
