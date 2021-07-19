using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SCIMServer.Models
{
    public class User : Resource
    {
        IReadOnlyDictionary<string, string> properties = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "externalid", "ExternalId" },
            { "name", "Name" },
            { "username", "UserName" }
        };
        public object this[string property]
        {
            get
            {
                properties.TryGetValue(property, out string resolvedPropertyName);
                if (resolvedPropertyName is null) { return null; }
                return typeof(User).GetProperty(resolvedPropertyName).GetValue(this);
            }
            set
            {
                properties.TryGetValue(property, out string resolvedPropertyName);
                if (resolvedPropertyName is null) return;
                typeof(User).GetProperty(resolvedPropertyName).SetValue(this, value);
            }
        }
        public User() : base(new string[] { $"{SchemaUrns.UserResource}" }) { }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string ExternalId { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public Name Name { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string UserName { get; set; }
        public MetadataWithTime Meta { get; set; } = new("User");
    }

    public class Name
    {
        public string Formatted { get; set; }
        public string FamilyName { get; set; }
        public string GivenName { get; set; }
    }
}
