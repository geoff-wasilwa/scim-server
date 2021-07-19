using SCIMServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SCIMServer
{
    public class PagedResources<T>
    {
        readonly int totalResults;
        readonly int startIndex = 0;
        readonly int itemsPerPage = 0;
        readonly IReadOnlyCollection<T> items;
        public PagedResources(IReadOnlyCollection<T> items, int totalResults)
        {
            this.items = items;
            this.totalResults = totalResults;
            // Add paging information only when items need paging
            if (totalResults > items.Count)
            {
                this.itemsPerPage = items.Count;
                this.startIndex = 1;
            }

        }
        public string[] Schemas { get { return new string[] { $"{SchemaUrns.UrnPrefix}ListResources" }; } }
        public int TotalResults { get { return this.totalResults; } }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int StartIndex { get { return this.startIndex;  } }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
        public int ItemsPerPage { get { return this.itemsPerPage; } }
        public IReadOnlyCollection<T> Resources { get { return this.items; } }
    }
}
