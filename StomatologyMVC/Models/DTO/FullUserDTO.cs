using System.Runtime.Serialization;

namespace StomatologyMVC.Models.DTO
{
    [DataContract]
    public class FullUserDTO
    {
        [DataMember]
        public string Name { set; get; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Phone { get; set; }

        [DataMember]
        public string Complaint { get; set; }

        [DataMember]
        public string Date { get; set; }

        [DataMember]
        public string Time { get; set; }
    }
}