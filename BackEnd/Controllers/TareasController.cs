using Backend.Models;
using Newtonsoft.Json;
using PaymentController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Backend.Controllers
{
    public class TareasController : ApiController
    {
        Parametro parametros = new Parametro();
        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/GetTareas/{userId}")]
        public IHttpActionResult GetTareas(string userId)
        {
            parametros.AgregarParametro("@USER_ID", userId);
            string result = JsonConvert.SerializeObject(new DBOServicios().SpQueryMultiple("SVC_GET_TAREAS", parametros.ObtenerParametro()));
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/data/GrabarTarea/{id}/{nombre}/{estado}/{descripcion}/{usuarioAsignado}")]
        public IHttpActionResult GrabarTarea(string id, string nombre, string estado, string descripcion, string usuarioAsignado)
        {

            parametros.AgregarParametro("@ID", id);
            parametros.AgregarParametro("@NOMBRE", nombre);
            parametros.AgregarParametro("@ESTADO", estado);
            parametros.AgregarParametro("@DESCRIPCION", descripcion);
            parametros.AgregarParametro("@USUARIO_ASIGNADO", usuarioAsignado);
            string result = JsonConvert.SerializeObject(new DBOServicios().SpQuery("SVA_TAREAS", parametros.ObtenerParametro()));
            return Ok(result);

        }


    }
}