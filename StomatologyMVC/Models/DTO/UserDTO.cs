using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace StomatologyMVC.Models.DTO
{
    [DataContract]
    public class UserDTO
    {
        [DataMember]
        public string Name {set; get;}

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }
    }
}