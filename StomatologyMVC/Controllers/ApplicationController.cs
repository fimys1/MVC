using Newtonsoft.Json;
using StomatologyMVC.Extensions;
using StomatologyMVC.Models;
using StomatologyMVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Results;

namespace StomatologyMVC.Controllers
{
    [Authorize(Roles = "User")]
    public class ApplicationController : ApiController
    {
        [HttpGet]
        
        public IEnumerable<TimeDTO> Time(string date)
        {

            if (date != null && date != "undefined")
            {
                DateTime dateTime;
                if (DateTime.TryParse(date, out dateTime))
                {
                    int dateCheck = DateTime.Compare(DateTime.Now.Date, dateTime);
                    if (dateCheck < 0)
                    {
                        var Times = TimeModel.GetFreeDateTime(dateTime);
                        var jsonResult = Times.Select(t => new TimeDTO() { valueHiden = t.ToString() , valueScren = t.ToString("HH:mm") });
                        return jsonResult;
                    }                    
                }
            }
            return new List<TimeDTO>();
        }

            

        [HttpGet]
        public UserDTO GetUser()
        {
            string allText = "{'type':'userInfo','user':[{'Name':'"+User.Identity.GetUser().FullName
                +"','Email':'"+User.Identity.GetUser().Email
                +"','Phone':'"+User.Identity.GetUser().PhoneNumber+"'}]}";

            var jsonResult = new UserDTO() { Email = User.Identity.GetUser().Email,
                                            Name = User.Identity.GetUser().FullName,
                                            Phone = User.Identity.GetUser().PhoneNumber };
            return jsonResult;
        }

        [HttpPost]
        public IHttpActionResult Application(ApplicationViewModels model)
        {
            DateTime dateTime;
            string id = "";
            if (DateTime.TryParse(model.Time, out dateTime) && ModelState.IsValid)
            {
                using (EntryRepository rep = new EntryRepository())
                {
                    using (CabinetRepository cab = new CabinetRepository())
                    {
                        Entry entry = new Entry
                        {
                            Couse = null,
                            Complaint = model.Complaint,
                            State = EnumsState.Wait,
                            DateTime = dateTime,
                            UserId = User.Identity.GetUser().Id,
                            Cabinet = cab.GetItem(1).CabinetId
                        };

                        rep.Create(entry);
                        rep.Save();
                        int entrEn = rep.GetItemsList().Where(m => m.DateTime == dateTime
                                                                && m.Complaint == model.Complaint
                                                                && m.UserId == User.Identity.GetUser().Id
                                                                && m.State == EnumsState.Wait).LastOrDefault().Id; //для отправки Ид заявки
                        EmailModel.SendEmail(User.Identity.GetUser().Email, "Ваш номер заявки: " + entrEn);
                        id = entrEn.ToString();
                    }
                }
            }            
            return Ok(id);     
        }
    }
}
