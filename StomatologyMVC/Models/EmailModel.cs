using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace StomatologyMVC.Models
{
    static public class EmailModel
    {
        public static void SendEmail(string email, string text)
        {
            MailMessage mail = new MailMessage("gerh1995@gmail.com", email);
            mail.Subject = "Стоматология";
            mail.Body = text;
            mail.IsBodyHtml = true;
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = true;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            NetworkCredential basicAuthenticationInfo = new NetworkCredential("", "");
            client.Credentials = basicAuthenticationInfo;
            client.Send(mail);
        }
    }
}