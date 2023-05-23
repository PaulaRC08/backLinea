using BCProyecto.Models;
using System.Net.Mail;

namespace BCProyecto.Utils
{
    public class Correo
    {

        public static void EnviarCorreo(TbUsuario usuario, string token)
        {
            string EmailOrigen = "paularodriguezc08@gmail.com";
            string Pass = "wtvzmzmahutwqhez";
            //string EmailDestino = "parodriguezcuervo@gmail.com";
            string EmailDestino = usuario.Email;
            string UserName = usuario.Usuario;

            string url = "http://localhost:4200/cambiarPass?t=" + token;

            string BodyCorreo =
                "<!DOCTYPE html>\r\n<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n<head>\r\n  <meta charset=\"utf-8\">\r\n  <meta name=\"viewport\" content=\"width=device-width,initial-scale=1\">\r\n  <meta name=\"x-apple-disable-message-reformatting\">\r\n  <link rel=\"preconnect\" href=\"https://fonts.googleapis.com\">\r\n<link rel=\"preconnect\" href=\"https://fonts.gstatic.com\" crossorigin>\r\n<link href=\"https://fonts.googleapis.com/css2?family=Josefin+Sans:ital,wght@0,100;0,200;0,300;0,400;0,500;0,600;0,700;1,100;1,200;1,300;1,400;1,500;1,600;1,700&display=swap\" rel=\"stylesheet\">\r\n  <title></title>\r\n  <!--[if mso]>\r\n  <style>\r\n    table {border-collapse:collapse;border-spacing:0;border:none;margin:0;}\r\n    div, td {padding:0;}\r\n    div {margin:0 !important;}\r\n  </style>\r\n  <noscript>\r\n    <xml>\r\n      <o:OfficeDocumentSettings>\r\n        <o:PixelsPerInch>96</o:PixelsPerInch>\r\n      </o:OfficeDocumentSettings>\r\n    </xml>\r\n  </noscript>\r\n  <![endif]-->\r\n  <style>\r\n    table, td, div, h1, p {\r\n      font-family: 'Josefin Sans', sans-serif;\r\n    }\r\n    @media screen and (max-width: 530px) {\r\n      .unsub {\r\n        display: block;\r\n        padding: 8px;\r\n        margin-top: 14px;\r\n        border-radius: 6px;\r\n        background-color: #555555;\r\n        text-decoration: none !important;\r\n        font-weight: bold;\r\n      }\r\n      .col-lge {\r\n        max-width: 100% !important;\r\n      }\r\n    }\r\n    @media screen and (min-width: 531px) {\r\n      .col-sml {\r\n        max-width: 27% !important;\r\n      }\r\n      .col-lge {\r\n        max-width: 73% !important;\r\n      }\r\n    }\r\n  </style>\r\n</head>\r\n<body style=\"margin:0;padding:0;word-spacing:normal;background-color:#C5C5C5;\">\r\n  <div role=\"article\" aria-roledescription=\"email\" lang=\"en\" style=\"text-size-adjust:100%;-webkit-text-size-adjust:100%;-ms-text-size-adjust:100%;background-color:#C5C5C5;\">\r\n    <table role=\"presentation\" style=\"width:100%;border:none;border-spacing:0;\">\r\n      <tr>\r\n        <td align=\"center\" style=\"padding:0;\">\r\n          <!--[if mso]>\r\n          <table role=\"presentation\" align=\"center\" style=\"width:600px;\">\r\n          <tr>\r\n          <td>\r\n          <![endif]-->\r\n          <table role=\"presentation\" style=\"margin-top:5px;width:94%;max-width:600px;border:none;border-spacing:0;text-align:left;font-size:16px;line-height:22px;color:#363636;\">\r\n            <tr>\r\n              <td style=\"padding:30px;background-color:#ffffff;\">\r\n                <h1 style=\"margin-top:0;margin-bottom:5px;font-size:26px;line-height:32px;font-weight:bold;letter-spacing:-0.02em; text-align: center;\">RECUPERAR CONTRASEÑA</h1>\r\n                <p style=\"margin-top:0;margin-bottom:12px; text-align: center;\">Hola "+ UserName + "</p>\r\n              </td>\r\n            </tr>\r\n            <tr>\r\n              <td style=\"padding:0;font-size:24px;line-height:28px;font-weight:bold;\">\r\n                <a style=\"text-decoration:none;\"><img src=\"https://i.ibb.co/DCcr7t3/correo1.jpg\" width=\"600\" alt=\"\" style=\"width:100%;height:auto;display:block;border:none;text-decoration:none;color:#363636;\"></a>\r\n              </td>\r\n            </tr>\r\n            <tr>\r\n              <td style=\"padding:35px 30px 11px 30px;font-size:0;background-color:#ffffff;border-bottom:1px solid #f0f0f5;border-color:rgba(201,201,207,.35);\">\r\n                <!--[if mso]>\r\n                <table role=\"presentation\" width=\"100%\">\r\n                <tr>\r\n                <td style=\"width:145px;\" align=\"left\" valign=\"top\">\r\n                <![endif]-->\r\n                <div class=\"col-sml\" style=\"display:inline-block;width:100%;max-width:145px;vertical-align:top;text-align:left;font-family:Arial,sans-serif;font-size:14px;color:#363636;\">\r\n                  <img src=\"https://i.ibb.co/Gnghb5x/correo2.png\" width=\"115\" alt=\"\" style=\"width:115px;max-width:80%;margin-bottom:20px;\">\r\n                </div>\r\n                <!--[if mso]>\r\n                </td>\r\n                <td style=\"width:395px;padding-bottom:20px;\" valign=\"top\">\r\n                <![endif]-->\r\n                <div class=\"col-lge\" style=\"display:inline-block;width:100%;max-width:395px;vertical-align:top;padding-bottom:20px;font-family:Arial,sans-serif;font-size:16px;line-height:22px;color:#363636;\">\r\n                  <p style=\"margin-top:0;margin-bottom:12px;\">Olvidaste tu contraseña y pediste recuperacion... <br> Para cambiar la contraseña de tu cuenta da click en el siguiente boton.</p>\r\n                  <p style=\"margin:0;\"><a" +
                " href=\""+url+"\" style=\"background: #2e7d31; text-decoration: none; padding: 10px 25px; color: #ffffff; border-radius: 4px; display:inline-block; mso-padding-alt:0;text-underline-color:#ff3884\"><!--[if mso]><i style=\"letter-spacing: 25px;mso-font-width:-100%;mso-text-raise:20pt\">&nbsp;</i><![endif]--><span style=\"mso-text-raise:10pt;font-weight:bold;\">Cambiar Contraseña</span><!--[if mso]><i style=\"letter-spacing: 25px;mso-font-width:-100%\">&nbsp;</i><![endif]--></a></p>\r\n                </div>\r\n                <!--[if mso]>\r\n                </td>\r\n                </tr>\r\n                </table>\r\n                <![endif]-->\r\n              </td>\r\n            </tr>\r\n            <tr>\r\n              <td style=\"padding:30px;text-align:center;font-size:12px;background-color:#404040;color:#cccccc;\">\r\n                <p style=\"margin:0;font-size:14px;line-height:20px;\">&reg; Proyecto, Proyecto 2023<br></p>\r\n              </td>\r\n            </tr>\r\n          </table>\r\n          <!--[if mso]>\r\n          </td>\r\n          </tr>\r\n          </table>\r\n          <![endif]-->\r\n        </td>\r\n      </tr>\r\n    </table>\r\n  </div>\r\n</body>\r\n</html>";

            MailMessage onMailMessage = new MailMessage(EmailOrigen, EmailDestino, "Recuperacion de Contraseña", BodyCorreo);
            onMailMessage.IsBodyHtml = true;

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            smtpClient.Credentials = new System.Net.NetworkCredential(EmailOrigen, Pass);
            
            smtpClient.Send(onMailMessage);
            smtpClient.Dispose();

        }

    }
}
