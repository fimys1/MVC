using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StomatologyMVC.Models
{
    public static class StateName
    {
        public static string getName(EnumsState state)
        {
            if (state == EnumsState.Wait)
                return "В ожидании";
            else if (state == EnumsState.Accepted)
                return "Принято";
            else if (state == EnumsState.Denied)
                return "Отказано";
            else return "";
        }
    }
}