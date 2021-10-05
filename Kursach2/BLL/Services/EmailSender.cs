using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Servises
{
    public class EmailSender : IEmailSender
    {
        public async Task SendEmailAsync(string userEmail, string subject, string htmlMessage)
        {
            MailAddress from = new MailAddress("kdaniilm@gmail.com", "Admin");

            MailAddress to = new MailAddress(userEmail);

            MailMessage message = new MailMessage(from, to);

            message.Subject = "Email confirmation";

            message.Body = subject + $"<a href='{htmlMessage}'>" + htmlMessage + "</a>";

            message.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);

            smtp.Credentials = new NetworkCredential("kdaniilm@gmail.com", "Danchikus2000");

            smtp.EnableSsl = true;
            await Task.Run(() => smtp.Send(message));
        }
    }
}
