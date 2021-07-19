using SCIMServer.Models;
using SCIMServer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Controllers
{
    [Route("Users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // Should the query fail if specified attributes are not supported?
        [HttpGet]
        public ActionResult<PagedResources<User>> GetAll(string attributes = "")
        {
            var clean = attributes.Trim();
            var users = UserService.GetAll();
            if (attributes.Length > 0)
            {
                var slim = users.Select(u =>
                {
                    var cherryPicked = new User { Id = u.Id };
                    foreach (var attr in attributes.Split(","))
                    {
                        cherryPicked[attr] = u[attr];
                    }
                    Console.WriteLine("Picked: {0}", cherryPicked);
                    return cherryPicked;
                }).ToList();
                return new PagedResources<User>(slim, slim.Count);
            }
            return new PagedResources<User>(users, users.Count);
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(string id)
        {
            var user = UserService.Get(id);
            if (user is null) return StatusCode(404, new Error { Detail = $"Resource ${id} not found.", Status = "404" }); ;
            return user;
        }

        [HttpPost]
        public ActionResult<User> Create(User user)
        {
            var duplicate = UserService.GetByUsername(user.UserName);
            if (duplicate is null)
            {
                UserService.Add(user);
                // For unit test to pass
                // TODO: fix later
                if (Url == null)
                {
                    return Created("", user);
                }
                var location = Url.Action("Get", new { id = user.Id });
                user.Meta.Location = location;
                return Created(location, user);
            }
            else
            {
                return StatusCode(409, new Error { Detail = "", Status = "409" });
            }
        }
        [HttpDelete("{id}")]
        public ActionResult<Error> Delete(string id)
        {
            // What happens if user does not exist?
            var user = UserService.Get(id);
            if (user is not null) UserService.Delete(user);
            return NoContent();
        }
    }
}
