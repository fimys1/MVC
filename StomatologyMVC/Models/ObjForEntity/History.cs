using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StomatologyMVC.Models
{
    public class History
    {
        [Key]
        public string IdUser { set; get; }
        public string Date { get; set; }
        public string Complaint { get; set; }
        public string Time { get; set; }
        public string Diagnosis { get; set; }
    }
}