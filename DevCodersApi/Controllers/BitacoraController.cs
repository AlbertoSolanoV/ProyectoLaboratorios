using AppLogic;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DevCodersApi.Controllers
{
    public class BitacoraController : ApiController
    {
        [System.Web.Http.HttpGet]
        public List<Bitacora> DevolverBitacora()
        {
            AdminBitacora admin = new AdminBitacora();
            return admin.devolverInfoBitacora();
        }
    }
}