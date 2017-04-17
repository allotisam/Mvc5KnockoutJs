using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BootstrapIntro.Models
{
    public static class AuthenticatedUsers
    {
        private static List<User> _users = new List<User>
        {
            new User("jamie", "munro", null, new List<string> { "::1" })
        };

        public static List<User> Users { get { return _users; } }
    }
}