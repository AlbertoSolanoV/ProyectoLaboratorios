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
    public class LaboratorioController : ApiController
    {

        [System.Web.Http.HttpPost]
        public string RegistrarLaboratorio(Laboratorio pLaboratorio)
        {
            AdminLaboratorio admin = new AdminLaboratorio();
            return  admin.registrarLaboratorio(pLaboratorio);
        }
        /* public string RegistrarLaboratorio(Object pData)
        {
            var lab1 = pData.ToString();
            dynamic jObject = JObject.Parse(lab1);
            Laboratorio l1 = JsonConvert.DeserializeObject<Laboratorio>(jObject.laboratorio1.ToString());
            Laboratorio l2 = JsonConvert.DeserializeObject<Laboratorio>(jObject.laboratorio2.ToString());
            
            Laboratorio pLaboratorio = l1;
            Laboratorio pLaboratorio2;
            AdminLaboratorio admin = new AdminLaboratorio();
            return  admin.registrarLaboratorio(pLaboratorio);
        }*/
        [System.Web.Http.HttpGet]
        public Laboratorio LaboratorioInformacionAdmin(string pIdAdmin)
        {
            AdminLaboratorio admin = new AdminLaboratorio();
            return admin.devolverInfoLabAdmin(pIdAdmin);
        }

        [System.Web.Http.HttpPost]
        public string ModificarLaboratorio(Laboratorio pLaboratorio)
        {
            AdminLaboratorio admin = new AdminLaboratorio();
            return admin.modificarLaboratorio(pLaboratorio);
        }

        [System.Web.Http.HttpGet]
        public List<Laboratorio> LaboratoriosInformacion()
        {
            AdminLaboratorio admin = new AdminLaboratorio();
            return admin.devolverInfoLabs();
        }
    }
}
