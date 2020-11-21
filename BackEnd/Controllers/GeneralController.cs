using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using Backend.BO;
using Backend.Helpers;
using Backend.Models;
using System.Net.Http.Headers;
using System.Configuration;
using iTextSharp.text.pdf;
using System.Data;
using System.Web.Configuration;

namespace Backend.Controllers
{
    public class GeneralController : ApiController
    {
        Parametro parametros = new Parametro();

        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/GetLogin/{email}/{pass}")]
        public IHttpActionResult GetLogin(string email, string pass)
        {
            parametros.AgregarParametro("@USER", email);
            parametros.AgregarParametro("@PASS", pass);
            string result = JsonConvert.SerializeObject(new DBOServicios().SpQuery("SVC_GET_USUARIO", parametros.ObtenerParametro()));
            return Ok(result);
        }

    }
}