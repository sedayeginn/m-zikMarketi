using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class mail
    {
        public static void AktivasyonMailiGonder(string mailKullanici, string MailIcerik)
        {
            var _host = "smtp.yandex.com";
            var _port = 587;
            var _defaultCredentials = false;
            var _enableSsl = true;
            var _emailfrom = "yeginseda@yandex.com";

            using (var smtpClient = new SmtpClient(_host, _port))
            {
                smtpClient.EnableSsl = _enableSsl;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.UseDefaultCredentials = _defaultCredentials;
                if (_defaultCredentials == false)
                {
                    smtpClient.Credentials = NC;
                }

                smtpClient.Send(_emailfrom, mailKullanici, "Hot Plak Store Aktivasyonl", MailIcerik);
            }
        }

        public static NetworkCredential NC
        {
            get
            {
                return new NetworkCredential("yeginseda@yandex.com", "789654123");
            }
        }
    }
}
