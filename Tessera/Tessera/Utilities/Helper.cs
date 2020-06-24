using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Tessera.Properties;

namespace Tessera.Utilities
{
    public static class Helper
    {
        public static string Encode(string sData)
        {
            try
            {
                byte[] encData_byte = new byte[sData.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(sData);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Encode" + ex.Message);
            }
        }

        public static string Decode(string sData)
        {
            try
            {
                var encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();
                byte[] todecodeByte = Convert.FromBase64String(sData);
                int charCount = utf8Decode.GetCharCount(todecodeByte, 0, todecodeByte.Length);
                char[] decodedChar = new char[charCount];
                utf8Decode.GetChars(todecodeByte, 0, todecodeByte.Length, decodedChar, 0);
                string result = new String(decodedChar);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Decode" + ex.Message);
            }
        }

        public static void SendMailFirstAccess(string mail, string pass)
        {
            var fromAddress = new MailAddress(Settings.Default.UserEmailService, "Tessera");
            var toAddress = new MailAddress(mail, "User");
            const string subject = "Welcome to Tessera System - Manage Control Tickets";
            string body = "Dear User, your default password access is: " + pass + "\n \n" +

            "The default password will expire in 24 hours. " + "\n \n" +

            "Click here: http://localhost:63111/Users/ChangePassword to change your password";


            var smtp = new SmtpClient
            {
                Host = Settings.Default.SMTPHostEmailService,
                Port = Settings.Default.SMTPPortEmailService,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, Decode(Settings.Default.UserPasswordService))
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }

        public static void SendMailRememberAccess(string mail, string pass)
        {
            var fromAddress = new MailAddress(Settings.Default.UserEmailService, "Tessera");
            var toAddress = new MailAddress(mail, "User");
            const string subject = "Important message from Tessera System - Manage Control Tickets";
            string body = "Dear User, your password access is: " + pass;

            var smtp = new SmtpClient
            {
                Host = Settings.Default.SMTPHostEmailService,
                Port = Settings.Default.SMTPPortEmailService,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, Decode(Settings.Default.UserPasswordService))
            };

            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }        
    }
}