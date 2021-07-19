using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SCIMServer.Models
{
    public class SchemaUrns
    {
        public static string UrnPrefix = "urn:ietf:params:scim:schemas:core:2.0:";
        public static string UserResource = $"{UrnPrefix}User";
        public static string GroupResource = $"{UrnPrefix}Group";
        public static string ServiceProviderConfig = $"{UrnPrefix}ServiceProviderConfig";
    }
    public class ResourceDefinition
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Id { get; set; }
        public AttributeDefinition[] Attributes { get; set; }
        public Metadata Meta { get; set; }
    }
    public class AttributeDefinition
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool MultiValued { get; set; }
        public bool Required { get; set; }
        public bool CaseExact { get; set; }
        public string Mutability { get; set; }
        public string Returned { get; set; }
        public string Uniqueness { get; set; }
        public string Description { get; set; }
        public string[] ReferenceType { get; set; }
        public AttributeDefinition[] SubAttributes { get; set; }
    }
    public class Configuration : Resource
    {
        public Configuration() : base(new string[] { SchemaUrns.ServiceProviderConfig }) { }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DocumentationUri { get; set; }
        public IReadOnlyDictionary<string, Object> Patch { get; set; }
        public IReadOnlyDictionary<string, Object> Bulk { get; set; }
        public IReadOnlyDictionary<string, Object> Filter { get; set; }
        public IReadOnlyDictionary<string, Object> ChangePassword { get; set; }
        public IReadOnlyDictionary<string, Object> Sort { get; set; }
        public IReadOnlyDictionary<string, Object> Etag { get; set; }
        public AuthenticationScheme[] AuthenticationSchemes { get; set; }
        public MetadataWithTime Meta { get; set; } = new("ServiceProviderConfig");
    }
    public class AuthenticationScheme
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string SpecUri { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string DocumentationUri { get; set; }
        public string Type { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string Primary { get; set; }
    }
}
