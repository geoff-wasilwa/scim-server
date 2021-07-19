using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Models
{
    public class Error : Resource
    {
        public Error() : base(new string[] { $"{SchemaUrns.UrnPrefix}Error" }) { }
        public string ScimType { get; set; }
        public string Detail { get; set; }
        public string Status { get; set; }
    }
}
