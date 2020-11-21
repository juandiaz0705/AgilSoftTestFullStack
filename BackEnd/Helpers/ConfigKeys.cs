using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Backend.Helpers
{
    public static class ConfigKeys
    {
        public static string PlantillaContratoPath
        {
            get { return ConfigurationManager.AppSettings["PlantillaContratoPath"].ToString(); }
        }
        public static string DocumentosPath
        {
            get { return ConfigurationManager.AppSettings["DocumentosPath"].ToString(); }
        }

        //public static string OutputPDF
        //{
        //    get { return ConfigurationManager.AppSettings["OutputPDF"].ToString(); }
        //}

        public static string defaultUser
        {
            get { return ConfigurationManager.AppSettings["defaultUSer"].ToString(); }
        }
    }
}