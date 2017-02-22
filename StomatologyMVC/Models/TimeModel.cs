using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StomatologyMVC.Models
{
    public static class TimeModel
    {
        public static IEnumerable<DateTime> GetFreeDateTime(DateTime daty)
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
    }
}