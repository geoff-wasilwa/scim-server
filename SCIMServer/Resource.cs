using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer
{
    public class Resource
    {
        readonly string[] schemas;
        string id;
        public Resource(string[] schemas)
        {
            this.schemas = new string[schemas.Length];
            schemas.CopyTo(this.schemas, 0);
            this.id = Guid.NewGuid().ToString();
        }
        public string[] Schemas { get { return this.schemas; } }
        public string Id { get { return this.id; } set { this.id = value; } }
    }
}
