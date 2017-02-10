using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StomatologyMVC.Models
{
    public class ShowApplicationModel
    {
            [Required]
            [EmailAddress]
            [Display(Name = "ID заявки")]
            public string ID { get; set; }

            [Required]
            [Display(Name = "Статус")]
            public string State { get; set; }
        
    }
}