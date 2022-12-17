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
    public class ExamenController : ApiController
    {

        [System.Web.Http.HttpPost]
        public void RegistrarExamen(Examen pExamen)
        {
            AdminExamen admin = new AdminExamen();
            admin.registrarExamen(pExamen);
        }

        [System.Web.Http.HttpGet]
        public List<ExamenCliente> mostrarExamenLaboratorio(String idCliente)
        {
            AdminExamen admin = new AdminExamen();
            return admin.devolverExamenesCliente(idCliente);
        }

        [System.Web.Http.HttpGet]
        public ExamenCliente mostrarUnExamen(String idCita)
        {
            AdminExamen admin = new AdminExamen();
            return admin.devolverUnExamen(idCita);
        }

        [System.Web.Http.HttpGet]
        public Examen devolverExamenCita(String idCita)
        {
            AdminExamenCliente admin = new AdminExamenCliente();
            return admin.devolverExamen(idCita);
        }
        [System.Web.Http.HttpGet]
        public List<ExamenCliente> MostrarExamenUsuario(String idUsuario)
        {
            AdminExamen admin = new AdminExamen();
            return admin.devolverExamenUsuarios(idUsuario);
        }

        [System.Web.Http.HttpPost]
        public void ModificarExamen(Examen pMExamen)
        {
            AdminExamen admin = new AdminExamen();
            admin.modificarExamen(pMExamen);
        }

        [System.Web.Http.HttpPost]
        public void EliminarExamen(Examen idTExa)
        {
            AdminExamen admin = new AdminExamen();
            admin.eliminarTipoExamen(idTExa);
        }
    }
}
