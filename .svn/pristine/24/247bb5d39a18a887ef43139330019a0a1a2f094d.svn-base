using System.Net;
using System.Net.Mail;
using System.Threading;

namespace FuncionesCore
{
    public class FMails
    {
        /// <summary>
        ///     Si no hay adjunto, cc o cco envicar un nulo("")
        /// </summary>
        /// <param name="pCuentaDeEnvio"></param>
        /// <param name="pPwdDeEnvio"></param>
        /// <param name="pCuentaDeDestino"></param>
        /// <param name="pAsunto"></param>
        /// <param name="pMensaje"></param>
        /// <param name="pSMTP"></param>
        /// <param name="pModulo"></param>
        /// <param name="pMetodo"></param>
        /// <param name="pPathAdjunto"></param>
        /// <param name="pCuentasDeDestinoCC"></param>
        /// <param name="pCuentasDeDestinoCCO"></param>
        /// <returns></returns>
        public static void Enviar(string pCuentaDeEnvio,
            string pPwdDeEnvio,
            string pCuentaDeDestino,
            string pAsunto,
            string pMensaje,
            string pSMTP,
            string pModulo,
            string pMetodo,
            string pPathAdjunto = "",
            string pCuentasDeDestinoCC = "",
            string pCuentasDeDestinoCCO = "")
        {
            var client = new SmtpClient(pSMTP);
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(pCuentaDeEnvio, pPwdDeEnvio);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;

            var mail = new MailMessage(pCuentaDeEnvio, pCuentaDeDestino);
            mail.IsBodyHtml = true;
            mail.Subject = pAsunto;
            mail.Body = pMensaje;

            if (pPathAdjunto != "")
            {
                var Att = new Attachment(pPathAdjunto);
                mail.Attachments.Add(Att);
            }

            if (pCuentasDeDestinoCC != "") mail.CC.Add(pCuentasDeDestinoCC);
            if (pCuentasDeDestinoCCO != "") mail.Bcc.Add(pCuentasDeDestinoCCO);

            client.Send(mail);
        }

        public static void EnviarmailAsync(string pCuentaDeEnvio,
            string pPwdDeEnvio,
            string pCuentaDeDestino,
            string pAsunto,
            string pMensaje,
            string pSMTP,
            string pModulo,
            string pMetodo,
            string pPathAdjunto = "",
            string pCuentasDeDestinoCC = "",
            string pCuentasDeDestinoCCO = "")
        {
            var thread = new Thread(() => Enviar(pCuentaDeEnvio,
                pPwdDeEnvio,
                pCuentaDeDestino,
                pAsunto,
                pMensaje,
                pSMTP,
                pModulo,
                pMetodo,
                pPathAdjunto,
                pCuentasDeDestinoCC,
                pCuentasDeDestinoCCO));
            thread.IsBackground = true;
            thread.Start();
        }
    }
}