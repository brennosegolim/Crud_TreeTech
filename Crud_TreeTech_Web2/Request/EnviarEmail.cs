using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace Crud_TreeTech_Web2.Request
{
    public class EnviarEmail
    {
        public bool sendEmailAviso(string nomeAlarme)
        {
            bool aux = false;
            try
            {
                Base baseConfig = new Base();
                MailMessage mail = new MailMessage(baseConfig.getRemetenteEmail(), baseConfig.getEmailEnvioAlerta());

                mail.Subject = string.Format("Alarme {0} Ativado",nomeAlarme);
                mail.IsBodyHtml = true;
                mail.Body = string.Format("<b>Atenção!!!</b><br/><p>Alarme {0} foi acionado!</p>",nomeAlarme);
                mail.SubjectEncoding = Encoding.UTF8;
                mail.BodyEncoding = Encoding.UTF8;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential(baseConfig.getRemetenteEmail(), baseConfig.getSenhaRemetenteEmail());

                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                aux = true;
            }
            catch (Exception ex)
            {
                //
            }
            return aux;
        }
    }
}