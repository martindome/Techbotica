using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servicio
{
    public class Notificacion
    {
        public static void EnviarEmail(string pMensaje, string pAsunto, string pToAddress, string pFrom = "techboticalearning@gmail.com")
        {
            try
            {
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(pFrom);
                message.To.Add(new MailAddress(pToAddress));
                message.Subject = pAsunto;
                message.IsBodyHtml = true;
                message.Body = pMensaje;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("techboticalearning@gmail.com", "todi zmxd wuib ffug");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);


            }
            catch (Exception ex) { /*throw (ex);*/ }
        }
    }
}
