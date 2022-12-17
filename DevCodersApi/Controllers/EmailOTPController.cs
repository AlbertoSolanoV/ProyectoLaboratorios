﻿using SendGrid.Helpers.Mail;
using SendGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

namespace DevCodersApi.Controllers
{
    public class EmailOTPController : ApiController
    {

        [System.Web.Http.HttpPost]
        public async Task Execute(string pCorreo, string pOTP)
        {
            string body = @"<!DOCTYPE html>
<html>

<style>
    body {
        margin: 0 auto !important;
        padding: 0 !important;
        height: 100% !important;
        width: 100% !important;
        background: #f1f1f1;
    }

    .primary {
        background: #00A6E3;
    }

    .bg_white {
        background: #ffffff;
    }

    .bg_light {
        background: #fafafa;
    }

    .bg_black {
        background: #000000;
    }

    .bg_dark {
        background: rgba(0,0,0,.8);
    }

    .email-section {
        padding: 2.5em;
    }

    /*BUTTON*/


    h1, h2, h3, h4, h5, h6 {
        font-family: 'Lato', sans-serif;
        color: #000000;
        margin-top: 0;
        font-weight: 400;
        font-weight: bold;
    }

    body {
        font-family: 'Lato', sans-serif;
        font-weight: 400;
        font-size: 15px;
        line-height: 1.8;
        color: rgba(0,0,0,.4);
    }

    a {
        color: #00A6E3;
    }

    .logo h1 {
        margin: 0;
    }

        .logo h1 a {
            color: #00A6E3;
            font-size: 24px;
            font-weight: 700;
        }

    /*FOOTER*/

    .footer {
        border-top: 1px solid rgba(0,0,0,.05);
        color: rgba(0,0,0,.5);
    }

        .footer .heading {
            color: #000;
            font-size: 20px;
        }

        .footer ul {
            margin: 0;
            padding: 0;
        }

            .footer ul li {
                list-style: none;
                margin-bottom: 10px;
            }

                .footer ul li a {
                    color: rgba(0,0,0,1);
                }


    @media screen and (max-width: 500px) {
    }
</style>
<head>
    <meta charset=""utf-8"" />
    <title></title>
</head>

<body>
    <div style=""max-width: 600px; margin: 0 auto;"" class=""email-container"">
        <!-- BEGIN BODY -->
        <table align=""center"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""margin: auto;"">
            <tr>
                <td valign=""top"" class=""bg_white"" style=""padding: 1em 2.5em 0 2.5em;"">
                    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
                        <tr>
                            <td class=""logo"" style=""text-align: center;"">
                                <h1><a href=""/Home/LandingProduct"">DevCoders Team</a></h1>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            
            <tr>
                <td valign = ""middle"" class=""hero bg_white"" style=""padding: 2em 0 4em 0;"">
                    <table>
                        <tr>
                            <td>
                                <div class=""text"" style=""padding: 0 2.5em; text-align: center;"" >
                                    <h2>Confirmacion de cuenta OTP</h2>
                                    <h3>Para poder acceder y activar su cuenta, por favor utilice el siguiente código para terminar el proceso de registro, a su teléfono también le estará llegando el mismo código para que confirme su cuenta.</h3>
                                    <br />
                                    <h2>" + pOTP+@"</h2>
                               </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr><!-- end tr -->
            <!-- 1 Column Text + Button : END -->
        </table>
        <table align = ""center"" role= ""presentation"" cellspacing= ""0"" cellpadding= ""0"" border= ""0"" width= ""100%"" style= ""margin: auto;"">


            <tr>
                <td class=""bg_light pt-3"" style=""text-align: center"">
                    <p>Equipo CLINNIX</p>
                    <p> Todos los derechos reservados 2022</p>
                </td>
            </tr>

        </table>

    </div>

</body>
</html>";

            var client = new SendGridClient("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");
            var from = new EmailAddress("clinnixdevcoders@gmail.com", "CLINNIX Soporte de cuentas");
            var subject = "Confirmacion de cuenta OTP";
            var to = new EmailAddress(pCorreo);
            var plainTextContent = body + pOTP;
            var htmlContent = body + pOTP;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }
    }
}
