using SCIMServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIMServer.Services
{
    public class UserService
    {
        static List<User> Users { get; }
        static UserService()
        {
            Users = new List<User>
            {
                new User { ExternalId = Guid.NewGuid().ToString(), Name = new Name { Formatted = "Ms. Barbara J Jensen III", FamilyName = "Jensen", GivenName = "Barbara" }, UserName = "bjensen", Meta = new("User") }
            };
        }
        public static List<User> GetAll() => Users;
        public static User Get(string id) => Users.FirstOrDefault(u => u.Id == id);
        public static User GetByUsername(string username) => Users.FirstOrDefault(u => string.Equals(u.UserName, username, StringComparison.OrdinalIgnoreCase));
        public static void Add(User user)
        {
            Users.Add(user);
        }
        public static void Delete(User user)
        {
            if (user is null) return;
            Users.Remove(user);
        }
        public static void Update(User user)
        {
            var index = Users.FindIndex(u => u.Id == user.Id);
            if (index == -1) return;
            Users[index] = user;
        }
    }
}
