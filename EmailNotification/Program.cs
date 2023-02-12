using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace EmailNotificationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Email Notification Application");

            List<string> recipients = new List<string>();
            recipients.Add("recipient1@example.com");
            recipients.Add("recipient2@example.com");

            Console.WriteLine("Enter the subject of the email:");
            string subject = Console.ReadLine();

            Console.WriteLine("Enter the body of the email:");
            string body = Console.ReadLine();

            foreach (string recipient in recipients)
            {
                try
                {
                    MailMessage message = new MailMessage();
                    SmtpClient smtp = new SmtpClient();
                    message.From = new MailAddress("sender@example.com");
                    message.To.Add(new MailAddress(recipient));
                    message.Subject = subject;
                    message.Body = body;
                    smtp.Port = 587;
                    smtp.Host = "smtp.example.com";
                    smtp.EnableSsl = true;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new System.Net.NetworkCredential("sender@example.com", "password");
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                    Console.WriteLine("Email sent to " + recipient);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Could not send email to " + recipient);
                    Console.WriteLine("Error message: " + ex.Message);
                }
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
