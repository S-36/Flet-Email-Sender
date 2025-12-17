
using Backend_Flet.Email_sender.Interface;
using DotNetEnv;
using MongoDB.Driver;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
namespace Backend_Flet.Email_sender.EmailCollection
{
    public class Email_collection : InEmail
    {
        public async Task SendEmail(string to, string subject, string body)
        {
            //Load the ENV
            Env.Load();
            // Implementation for sending the email
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUser = Environment.GetEnvironmentVariable("EMAIL_USER") ?? throw new InvalidOperationException("EMAIL_USER not set in environment variables.");
            string smtpPassword = Environment.GetEnvironmentVariable("EMAIL_PASSWORD") ?? throw new InvalidOperationException("EMAIL_PASSWORD not set in environment variables.");
            string fromAddress = Environment.GetEnvironmentVariable("EMAIL_FROM") ?? throw new InvalidOperationException("EMAIL_FROM not set in environment variables.");
            
            // logic to enter to the mail server
            var client = new SmtpClient();
            client.UseDefaultCredentials = false;
            client.Host = smtpServer;
            client.Port = smtpPort;
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(smtpUser, smtpPassword);

            // logic to create and send the email 
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromAddress),
                To = { new MailAddress(to) },
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };
            //send the email
            await client.SendMailAsync(mailMessage);
        }
    }
}