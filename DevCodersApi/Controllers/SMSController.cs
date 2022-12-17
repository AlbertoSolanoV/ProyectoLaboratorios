using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

using Twilio.TwiML;
using Twilio.Types;
using Twilio.AspNet.Mvc;
using Microsoft.Ajax.Utilities;
using System.Web.Http;

namespace DevCodersApi.Controllers
{
    public class SMSController : ApiController
    {
        [System.Web.Http.HttpPost]
        public string sendSMS(string pTelefono ,string pOTP)
        {
            var accountSID = "AC4c7b147e64ec4d3e4b6d18c99df3f440";
            var authToken = "36e886ccf7116ee129a2f83f28250ae9";
            TwilioClient.Init(accountSID, authToken);

            var to = new PhoneNumber("+506"+ pTelefono);
            var from = new PhoneNumber("MGf46387b799297fcb3d1f4b3f8a7e9324");
                
            
            var message = MessageResource.Create(
                to:to,
                from:from,
                body: "Bienvenido a CLINNIX, para terminar su registro y activar su cuenta, por favor ingrese este código: "+pOTP +
                " Atentamente: Equipo CLINNIX :)"
                );
            return ((message.Body));
        }

        
    }
}