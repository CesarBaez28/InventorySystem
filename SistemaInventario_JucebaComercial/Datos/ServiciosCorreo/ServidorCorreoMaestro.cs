using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace Datos.ServiciosCorreo
{
    public abstract class ServidorCorreoMaestro
    {
        private SmtpClient smtpClient;

        protected string senderMail { get; set; }
        protected string password { get; set; }
        protected string host { get; set; }
        protected int port { get; set; }
        protected bool ssl { get; set; }

        protected void inicializarSmtpClient()
        {
            smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential(senderMail, password);
            smtpClient.Host = host;
            smtpClient.Port = port;
            smtpClient.EnableSsl = ssl;
        }

        public void enviarCorreo(string asunto, string cuerpo, List<string> correoDestinatario)
        {
            var mailMensaje = new MailMessage();

            try
            {
                mailMensaje.From = new MailAddress(senderMail);

                foreach (string mail in correoDestinatario)
                {
                    mailMensaje.To.Add(mail);
                }

                mailMensaje.Subject = asunto;
                mailMensaje.Body = cuerpo;
                mailMensaje.Priority = MailPriority.Normal;
                smtpClient.Send(mailMensaje);
            }
            catch (Exception)
            { }
            finally
            {
                mailMensaje.Dispose();
                smtpClient.Dispose();
            }
        }
    }
}
