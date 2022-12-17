using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DevCodersApi.Controllers
{
    public class ValidarOTPController : ApiController
    {

        [HttpPost]
        public Usuario ValidarOTP(Usuario us)
        {
            AdminValidarOTP admin = new AdminValidarOTP();
            return admin.ValidarOTP(us);


        }

    }
}
