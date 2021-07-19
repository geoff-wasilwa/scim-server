using SCIMServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SCIMServer.Services
{
    public class ResourceDefinitionService
    {
        static readonly List<ResourceDefinition> resourceDefinitions = new();
        static ResourceDefinitionService()
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResourceDefinitions = File.ReadAllText("resourceTypes.json");
            resourceDefinitions = JsonSerializer.Deserialize<List<ResourceDefinition>>(jsonResourceDefinitions, options);
        }
        public static List<ResourceDefinition> GetAll() => resourceDefinitions;
        public static ResourceDefinition Get(string id) => resourceDefinitions.FirstOrDefault(r => r.Id == id);
    }

    public class ConfigurationService
    {
        static readonly Configuration configuration;
        static ConfigurationService()
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonConfiguration = File.ReadAllText("serviceProviderConfigurations.json");
            configuration = JsonSerializer.Deserialize<Configuration>(jsonConfiguration, options);
        }

        public static Configuration GetConfiguration() => configuration;
    }
}
