using SCIMServer.Models;
using SCIMServer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Schemas
{
    [ApiController]
    public class SchemaController : ControllerBase
    {
        [HttpGet("Schemas")]
        public ActionResult<PagedResources<ResourceDefinition>> GetAll()
        {
            var resourceDefinitions = ResourceDefinitionService.GetAll();
            return new PagedResources<ResourceDefinition>(resourceDefinitions, resourceDefinitions.Count);
        }
        [HttpGet("Schemas/{id}")]
        public ActionResult<ResourceDefinition> Get(string id)
        {
            var resources = ResourceDefinitionService.Get(id);
            if (resources == null)
            {
                return NotFound();
            }
            return resources;
        }
        [HttpGet("ServiceProviderConfig")]
        public ActionResult<Configuration> GetConfiguration() => ConfigurationService.GetConfiguration();
    }
}
