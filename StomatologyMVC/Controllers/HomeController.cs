using Microsoft.AspNet.Identity;
using StomatologyMVC.Extensions;
using StomatologyMVC.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace StomatologyMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public IEnumerable<DateTime> GetFreeDateTime(DateTime daty)
        {
            if (daty.Date != null)
            {
                EntryRepository rep = new EntryRepository();
                DateTime day = new DateTime(daty.Year, daty.Month, daty.Day).Date;
                DateTime startTime = day.AddHours(8);
                DateTime endTime = day.AddHours(17);
                int interval = 30;
                List<DateTime> dateTime = new List<DateTime>();
                for (DateTime t = startTime; t < endTime; t = t.AddMinutes(interval))
                {
                    dateTime.Add(t);
                }
                IEnumerable<DateTime> busyTime = rep.GetItemsList().Where(a => a.State != EnumsState.Denied && a.DateTime.Date == day).Select(a => a.DateTime);
                List<DateTime> freeTime = new List<DateTime>();
                foreach (var d in dateTime)
                {
                    if (!busyTime.Contains(d))
                    {
                        freeTime.Add(d);
                    }
                }
                rep.Dispose();
                return freeTime;
            }
            else
                return null;
        }

        [Authorize]
        public ActionResult Time(string date, string role)
        {
            if (Request.IsAjaxRequest() && Request.IsAuthenticated && date!=null)
            {
                DateTime dateTime;
                if (DateTime.TryParse(date,out dateTime))
                {
                    int dateCheck = DateTime.Compare(DateTime.Now.Date, dateTime);
                    if (dateCheck < 0)
                    {
                        if (User.IsInRole("Admin"))
                        {
                            ViewBag.Role = "Admin";
                        }
                        ViewBag.Times = GetFreeDateTime(dateTime);
                        
                        return PartialView("Time");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Вы ввели не соответствующую дату.");
                        ViewBag.Times = null;
                        return PartialView();
                    }
                }
            }
            return null; 
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public ActionResult Application()
        {
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        [Authorize(Roles = "User")]
        public ActionResult ShowApplication()
        {
            return View();
        }
    }
}