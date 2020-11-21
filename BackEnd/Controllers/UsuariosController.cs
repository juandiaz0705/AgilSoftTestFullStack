using Backend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Backend.Controllers
{
    public class UsuariosController : ApiController
    {
        Parametro parametros = new Parametro();
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/GetUsuarios/")]
        public IHttpActionResult GetUsuarios()
        {
            string result = JsonConvert.SerializeObject(new DBOServicios().SpQueryMultiple("SVC_GET_USUARIOS"));
            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/GrabarUsuario/{id}/{usuario}/{email}/{password}/{idPerfil}/{vig}")]
        public IHttpActionResult GrabarUsuario(string id, string usuario, string email, string password, string idPerfil, string vig)
        {

            parametros.AgregarParametro("@ID", id);
            parametros.AgregarParametro("@NOMBRE", usuario);
            parametros.AgregarParametro("@USER_NAME", email);
            parametros.AgregarParametro("@PASSWORD", password);
            parametros.AgregarParametro("@PERFIL", idPerfil);
            parametros.AgregarParametro("@ESTADO", vig);
            string result = JsonConvert.SerializeObject(new DBOServicios().SpQuery("SVA_USUARIOS", parametros.ObtenerParametro()));
            return Ok(result);

        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/GrabiarPerfil/{id}/{nombre}")]
        public IHttpActionResult GrabiarPerfil(string id, string nombre)
        {
            parametros.AgregarParametro("@ID", id);
            parametros.AgregarParametro("@PERFIL", nombre);
            string result = JsonConvert.SerializeObject(new DBOServicios().SpQuery("SVA_PERFIL", parametros.ObtenerParametro()));
            return Ok(result);

        }
    }
}