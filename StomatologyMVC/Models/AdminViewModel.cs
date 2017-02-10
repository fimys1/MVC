using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StomatologyMVC.Models
{
    public class AdminViewModel
    {
        [Required]
        [Display(Name = "Change")]
        public string change { get; set; }

        [Required]
        [Display(Name = "Assept")]
        public string assept { get; set; }

        [Required]
        [Display(Name = "Denied")]
        public string denied { get; set; }
        
        [Required]
        [Display(Name = "Time")]
        public string time { get; set; }

        [Required]
        [Display(Name = "Comlaint")]
        public string comlaint { get; set; }
    }
}