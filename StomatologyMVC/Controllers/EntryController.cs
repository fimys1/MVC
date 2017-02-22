using StomatologyMVC.Extensions;
using StomatologyMVC.Models;
using StomatologyMVC.Models.DTO;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StomatologyMVC.Controllers
{
    [Authorize(Roles = "User")]
    public class EntryController : ApiController
    {
        [HttpGet]
        public IEnumerable<EntryDTO> Entrys()
        {
            EntryRepository rep = new EntryRepository();
            IEnumerable<Entry> entry = rep.GetItemsList().Where(a => a.UserId == User.Identity.GetUser().Id);
            var jsonResult = entry.Select(e => new EntryDTO()
            {
                Id = e.Id.ToString(),
                DateTime = e.DateTime.ToString("dd.MM.yyyy hh.mm"),
                State = StateName.getName(e.State),
                Couse = e.Couse != null ? "Причина: " + e.Couse : ""
            });
            return jsonResult;
        }

        [HttpPost]
        public FullUserDTO Entry(int id)
        {
            EntryRepository rep = new EntryRepository();
            Entry entry = rep.GetItem(id);            
            if (entry!=null&& entry.UserId == User.Identity.GetUser().Id)
            {
                var jsonResult = new FullUserDTO()
                {
                    Name = User.Identity.GetUser().FullName,
                    Email = User.Identity.GetUser().Email,
                    Phone = User.Identity.GetUser().PhoneNumber,
                    Complaint = entry.Complaint,
                    Date = entry.DateTime.ToString("dd.MM.yyyy"),
                    Time = entry.DateTime.ToString("HH:mm")
                };
                return jsonResult;
            }
            else
            {
                return null;
            }
        }
    }
}