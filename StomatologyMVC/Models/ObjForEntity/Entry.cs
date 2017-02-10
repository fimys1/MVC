using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StomatologyMVC.Models
{
    public class Entry
    {
        [Key]
        public int Id { get; set; }                 //id заявки        
        public EnumsState State { get; set; }       //состояние заявки
        public string Couse { get; set; }           //причина отказа
        public DateTime DateTime { get; set; }      //дата и время        
        public string Complaint { get; set; }       //жалобы больного

        [ForeignKey(nameof(cabinet))]
        public int Cabinet { get; set; }

        public virtual Cabinet cabinet { get; set; }       //номер кабинета

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }          //id пользователя
        
        public virtual ApplicationUser User { get; set; }
    }
}