﻿using System.Net.Mail;
using System.Text.Encodings.Web;
using appProperties = Prototype.Properties.appProperties;

namespace Prototype.Controllers
{
    public class MailHelper
    { 
        public bool SendEmail(string userEmail, string returnUrl)
        {
          /*  appProperties = new appProperties();
            Console.WriteLine(appProperties.Email);
            Console.WriteLine(appProperties.Password);*/
            Console.WriteLine("Sending email to " + userEmail);
            Console.WriteLine("Return URL: " + returnUrl);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("coucouetnk@hotmail.com");
            mailMessage.To.Add(new MailAddress(userEmail));



            mailMessage.Subject = "Confirm your email";
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = $"Please confirm your email address by clicking the link below: <br><a href='{HtmlEncoder.Default.Encode(returnUrl)}'> Confirm Email</a>";

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(/*appProperties.Email*/"coucouetnk@hotmail.com", "123456789ES!"/*appProperties.Password*/);
            client.Host = "smtp.office365.com";
            client.Port = 587;
            client.EnableSsl = true;
            



            try
            {
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return false;
        }
    }
}
