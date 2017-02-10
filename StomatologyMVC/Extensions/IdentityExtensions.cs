using Microsoft.AspNet.Identity;
using StomatologyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace StomatologyMVC.Extensions
{
    public static class IdentityExtensions
    {
        static ApplicationDbContext db = ApplicationDbContext.Create();
        public static ApplicationUser GetUser(this IIdentity identity)
        {
            return db.Users.Find(identity.GetUserId());
        }
    }
}