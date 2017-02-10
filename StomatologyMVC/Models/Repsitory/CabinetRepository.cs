using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StomatologyMVC.Models
{
    public class CabinetRepository : IDisposable
    {
        ApplicationDbContext appContext = new ApplicationDbContext();

        public Cabinet GetItem(int id)
        {
            return appContext.Cabinets.Find(id);
        }

        public void Dispose()
        {
            appContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}