using SCIMServer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace SCIMServer.Services
{
    public class GroupService
    {
        static readonly List<Group> groups = new();
        static GroupService()
        {
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var jsonResourceDefinitions = File.ReadAllText("groups.json");
            groups = JsonSerializer.Deserialize<List<Group>>(jsonResourceDefinitions, options);
        }
        public static IEnumerable<Group> GetAll() => groups;
        public static Group Get(string id) => groups.FirstOrDefault(g => g.Id == id);
        public static void Add(Group group) => groups.Add(group);
        public static void Delete(Group group)
        {
            if (group is null) return;
            groups.Remove(group);
        }
    }
}
