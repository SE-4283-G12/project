using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;

namespace CSRMS.Models.EventModel
{
    public class EmailReminderImplementation : ReminderImplementation
    {
        public override void remind(string email, Reminder reminder)
        {
            // Send email
            try
            {
                // Your Gmail credentials
                string gmailAddress = ConfigurationManager.AppSettings["GmailUsername"];
                string gmailPassword = ConfigurationManager.AppSettings["GmailPassword"];

                // Create and configure the SmtpClient
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential(gmailAddress, gmailPassword);
                smtpClient.EnableSsl = true;

                // Create the email message
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(gmailAddress);
                mailMessage.To.Add(email);
                mailMessage.Subject = "CSRMS";
                mailMessage.Body = reminder.GetMessage();


                // Send the email
                smtpClient.Send(mailMessage);
            }
            catch (Exception e)
            {
                Debug.WriteLine("C# Error " + e.Message);
            }
        }
    }
}
