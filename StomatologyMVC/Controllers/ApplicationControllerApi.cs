using StomatologyMVC.Extensions;
using StomatologyMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web.Http;

namespace StomatologyMVC.Controllers
{
    [Authorize]
    public class ApplicationController : ApiController
    {
        [Authorize(Roles = "User")]
        [System.Web.Mvc.ValidateAntiForgeryToken]
        public IHttpActionResult Application(ApplicationViewModels model)
        {
            DateTime date;
            if (DateTime.TryParse(model.Time, out date) && ModelState.IsValid)
            {
                using (EntryRepository rep = new EntryRepository())
                {
                    using (CabinetRepository cab = new CabinetRepository())
                    {
                        Entry entry = new Entry
                        {
                            Couse = null,
                            Complaint = model.Comlaint,
                            State = EnumsState.Wait,
                            DateTime = date,
                            UserId = User.Identity.GetUser().Id,
                            Cabinet = cab.GetItem(1).CabinetId
                        };

                        rep.Create(entry);
                        rep.Save();
                        int entrEn = rep.GetItemsList().Where(m => m.DateTime == date
                                                                && m.Complaint == model.Comlaint
                                                                && m.UserId == User.Identity.GetUser().Id
                                                                && m.State == EnumsState.Wait).LastOrDefault().Id; //для отправки Ид заявки
                        EmailModel.SendEmail(User.Identity.GetUser().Email, "Ваш номер заявки: " + entrEn);
                        ModelState.Clear();
                        return Ok();
                    }
                }
            }
            else
            {
                return NotFound();
            }            
        }
    }
}
