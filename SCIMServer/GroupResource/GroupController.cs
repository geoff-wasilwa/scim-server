using Microsoft.AspNetCore.Mvc;
using SCIMServer.Models;
using SCIMServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Controllers
{
    [Route("Groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        [HttpGet]
        public ActionResult<PagedResources<Group>> GetAll() {
            var groups = GroupService.GetAll().ToList();
            return new PagedResources<Group>(groups, groups.Count);
        }
        [HttpGet("{id}")]
        public ActionResult<Group> Get(string id) => GroupService.Get(id);
        [HttpPost]
        public ActionResult<Group> Create(Group group)
        {
            GroupService.Add(group);
            return Created("", group);
        }
        [HttpDelete("{id}")]
        public ActionResult<Error> Delete(string id)
        {
            var group = GroupService.Get(id);
            if (group is not null) GroupService.Delete(group);
            return NoContent();
        }
    }
}
