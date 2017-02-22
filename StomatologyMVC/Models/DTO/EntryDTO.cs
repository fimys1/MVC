using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StomatologyMVC.Models.DTO
{
    [DataContract]
    public class EntryDTO
    {
        [DataMember]
        public string Id { set; get; }

        [DataMember]
        public string DateTime { set; get; }

        [DataMember]
        public string State { set; get; }

        [DataMember]
        public string Couse { set; get; }
    }
}