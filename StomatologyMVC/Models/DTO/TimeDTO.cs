using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StomatologyMVC.Models.DTO
{
    [DataContract]
    public class TimeDTO
    {
        [DataMember]
        public string valueHiden {get; set;}

        [DataMember]
        public string valueScren {get;set;}
    }
}