using System.Net.Mail;
using System.Net;

namespace EndProject.Models
{
    public class mail
    {
        public void Mail(string sendMailAdress, string subject, string body)
        {
            SmtpClient client = new SmtpClient();
            MailAddress from = new MailAddress("sanan.r@itbrains.edu.az");
            MailAddress to = new MailAddress("sanan.r@itbrains.edu.az");
            MailMessage msg = new MailMessage(from, to);
            msg.IsBodyHtml = true;
            msg.Subject = subject;
            msg.Body += "" + to + " | <h1> " + body + " </h1>"; 
            msg.CC.Add(sendMailAdress);
            NetworkCredential info = new NetworkCredential("sanan.r@itbrains.edu.az", "vclidtlgwfhfejzl");
            client.Port = 587;
            client.Host = "smtp.yandex.com";
            client.EnableSsl = true;
            client.Credentials = info;
            client.Send(msg);

        }
    }
}
