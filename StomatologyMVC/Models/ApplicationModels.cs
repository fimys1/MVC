using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using StomatologyMVC.Extensions;
using System.Runtime.Serialization;

namespace StomatologyMVC.Models
{
    [DataContract]
    public class ApplicationViewModels
    {
        [DataMember]
        public string Time { get; set; }

        [DataMember]
        public string Complaint { get; set; }
    }
}