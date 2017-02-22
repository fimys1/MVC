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

        public ActionResult Time(string date)
        {
            bool ajax = Request.IsAjaxRequest();
            if (Request.IsAuthenticated && date!=null && date!= "undefined")
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
                        ViewBag.Times = TimeModel.GetFreeDateTime(dateTime);
                        
                        return PartialView("Time");
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