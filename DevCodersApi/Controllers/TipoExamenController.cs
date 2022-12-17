using AppLogic;
using DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace DevCodersApi.Controllers
{
    public class TipoExamenController : ApiController
    {

        [System.Web.Http.HttpPost]
        public void RegistrarTipoExamen(TipoExamen pExamen)
        {
            AdminTipoExamen admin = new AdminTipoExamen();
            admin.registrarTipoExamen(pExamen);
        }


        [System.Web.Http.HttpPost]
        public void ModificarTipoExamen(TipoExamen pMTExamen)
        {
            AdminTipoExamen admin = new AdminTipoExamen();
            admin.modificarTipoExamen(pMTExamen);
        }


        [System.Web.Http.HttpGet]
        public List<TipoExamen> MostrarTodosTExamen(string idCliente)
        {
            AdminTipoExamen admin = new AdminTipoExamen();
            return admin.devolverTodosTExamenes(idCliente);
        }


        [System.Web.Http.HttpPost]
        public void EliminarTExamen(TipoExamen idTExa)
        {
            AdminTipoExamen admin = new AdminTipoExamen();
            admin.eliminarTipoExamen(idTExa);
        }


        [System.Web.Http.HttpGet]
        public TipoExamen DevolverTExamen(string idTExamen)
        {
            AdminTipoExamen admin = new AdminTipoExamen();
            return admin.devolverUnTExamen(idTExamen);
        }

    }
}
