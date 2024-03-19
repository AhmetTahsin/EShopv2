using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EShop.COMMON.Tools
{
    public static class MailService
    {   //Mail servis çalışmayacak sağlayıcıya göre smtp ayarları yapılıp öyle kullanılası lazım testi yapıldı 
        public static void Send(string receiver, string password = "test123", string body = "Test mesajıdır", string subject = "Email Testi", string sender = "test@gmail.com")
        {
            MailAddress senderEmail = new MailAddress(sender);      //gönderici adresi

            MailAddress receiverEmail = new MailAddress(receiver);  //alıcı adresi

            #region GmailSmtp
            SmtpClient smtp = new SmtpClient()//smtp ayarlamaları
            {
                Host = "smtp.gmail.com",
                Port = 587, /*587, //465 */
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,
                Credentials = new NetworkCredential(senderEmail.Address, password),
                
            };
            #endregion Yahoo


            using (MailMessage message = new(senderEmail, receiverEmail)
            {
                Subject = subject,
                Body = body
            })
            {
                try
                {
                    smtp.Send(message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Mail gönderirken bir hata oluştu: " + ex.Message);
                }
            }


        }
    }
}
