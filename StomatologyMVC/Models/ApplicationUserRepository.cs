using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StomatologyMVC.Models
{
    public class ApplicationUserRepository : IDisposable
    {
        ApplicationDbContext appContext = null;
        public ApplicationUserRepository()
        {
            appContext = ApplicationDbContext.Create();
        }

        public void Dispose()
        {
            appContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ApplicationUser> GetItemsList()
        {
            return appContext.Users;
        }
    }
}