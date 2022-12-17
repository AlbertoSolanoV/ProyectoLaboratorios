using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace DevCodersUI.Helpers
{
    public class APIHelper
    {
        public string GetAPIUrl(string host)
        {
            return host.ToLower().Equals("localhost") ? ConfigurationManager.AppSettings["app-api-uri"] : ConfigurationManager.AppSettings["app-api-uri-azure"];
        }
    }
}
