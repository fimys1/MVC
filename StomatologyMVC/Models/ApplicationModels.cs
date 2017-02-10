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

namespace StomatologyMVC.Models
{
    public class ApplicationViewModels
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(10, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 9)]
        [Display(Name = "Телефон")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Дата")]
        public string Date { get; set; }

        [Required]
        [Display(Name = "Время")]
        public string Time { get; set; }

        [Required]
        [Display(Name = "Фамилия Имя Отчество")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Жалоба")]
        public string Comlaint { get; set; }
    }
}