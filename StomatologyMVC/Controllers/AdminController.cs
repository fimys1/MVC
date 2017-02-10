
using StomatologyMVC.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace StomatologyMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AdminViewModel model)
        {
            using (EntryRepository rep = new EntryRepository())
            {
                DateTime dateTime;
                int id;
                if (model.assept != null && int.TryParse(model.assept, out id))
                {
                    rep.Assept(id);
                    rep.Save();

                    ApplicationUserRepository userApp = new ApplicationUserRepository();
                    var applicationUser = rep.GetItemsList().Where(a => a.Id == id).SingleOrDefault();
                    var user = userApp.GetItemsList().Where(a => a.Id == applicationUser.UserId).SingleOrDefault();
                    EmailModel.SendEmail(user.Email, "Номер заявки: " + id.ToString() + ", была принята. Дата и время приема: " + applicationUser.DateTime);
                }
                else if (model.comlaint != null && model.denied != null && int.TryParse(model.denied, out id))
                {
                    rep.Denied(id, model.comlaint);
                    rep.Save();
                }
                else if (DateTime.TryParse(model.time, out dateTime) && int.TryParse(model.change, out id) && model.change != null)
                {
                    rep.Change(id, dateTime);
                    rep.Save();
                }
            }
            return Redirect("Admin");
        }
    }
}