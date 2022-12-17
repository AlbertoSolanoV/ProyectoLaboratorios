using DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DevCodersApi.Controllers
{
    public class DevCodersApiInteractionController : ApiController
    {
        [HttpPost]
        public string RegistrarUsuario(Usuario registrarDatos)
        {

            var url = ConfigurationManager.AppSettings["DevCodersApi"];
            url = url + "/api/RegistroUsuario/RegistrarUsuario";

            var usuarios = new HttpClient();
            usuarios.BaseAddress= new Uri(url);

            usuarios.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            string jsonData= JsonConvert.SerializeObject(registrarDatos);

            var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            var result = usuarios.PostAsync(url, content).Result;

            if (!result.IsSuccessStatusCode)
            {
                throw new Exception(result.Content.ReadAsStringAsync().Result);
            }
            return "Registro completo";

        }

        [HttpGet]
        public string ObtenerTodosUsuario()
        {

            var url = ConfigurationManager.AppSettings["DevCodersApi"];
            url = url + "/api/RegistroUsuario/InformacionTodosUsuarios";

            var usuarios = new HttpClient();
            usuarios.BaseAddress = new Uri(url);

           
            var result = usuarios.GetAsync(url).Result;

            if (!result.IsSuccessStatusCode)
            {
                var jsonObject = result.Content.ReadAsStringAsync().Result;
                var apiResponse = JsonConvert.DeserializeObject<List<Usuario>>(jsonObject);
            }
            return null;

        }
    }
}