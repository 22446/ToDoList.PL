using DataAccessLayer.Models;
using System.Net;
using System.Net.Mail;

namespace ToDoList.PL.Helper
{
    public static class EmailSend
    {
        public static void SendEmail(Email email)
        {
            var Client = new SmtpClient("smtp.gmail.com", 587);
            Client.EnableSsl = true;
            Client.Credentials = new NetworkCredential("mazin.safwat34@gmail.com", "kxgc haub pcwl ueoj");
            Client.Send("mazin.safwat34@gmail.com",email.To,email.Subject,email.Body);
        }
    }
}
