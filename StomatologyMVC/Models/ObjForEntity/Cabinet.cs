using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StomatologyMVC.Models
{
    public class Cabinet
    {
        [Key]
        public int CabinetId { get; set; }
        public int CabinetNumber { get; set; }
        public string NamdeDoctor { get; set; }

        public virtual ICollection<Entry> Entryes { get; set; }
        public Cabinet()
        {
            Entryes = new List<Entry>();
        }
    }
}