using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ServiciosCorreo
{
    public class SoporteCorreo : ServidorCorreoMaestro
    {
        public SoporteCorreo() 
        {
            senderMail = "juceba1971@gmail.com";
            password = "Jcb123456";
            host = "smtp.gmail.com";
            port = 587; 
            ssl = true;
            inicializarSmtpClient();
        }
    }
}
