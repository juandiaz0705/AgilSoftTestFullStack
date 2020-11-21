using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.SessionState;
using Backend.Helpers;
using Backend.Models;


namespace Backend.BO
{
    public class BOSolicitudes
    {
        public static List<CodigoAfinidad> ObtieneCodigoAfinidad()
        {
            var objDocumentos = new DBOSolicitudes();

            var lstCodigoAfinidad = objDocumentos.ObtenerCodigoAfinidad();

            return lstCodigoAfinidad;
        }

        public static List<DiaPago> ObtieneDiaPago()
        {
            var objDocumentos = new DBOSolicitudes();

            var lstDiaPago = objDocumentos.ObtenerDiaPago();

            return lstDiaPago;
        }

        public static List<FormaPago> ObtieneFormaPago()
        {
            var objDocumentos = new DBOSolicitudes();

            var lstFormaPago = objDocumentos.ObtenerFormaPago();

            return lstFormaPago;
        }

        public static List<TipoSolicitud> ObtieneTipoSolicitud()
        {
            var objDocumentos = new DBOSolicitudes();

            var lstTipoSolicitud = objDocumentos.ObtenerTipoSolicitud();

            return lstTipoSolicitud;
        }

        public static RepLegal ObtieneDatosRepLegal(int rut)
        {
            var objDocumentos = new DBOSolicitudes();

            var objRepLegal = objDocumentos.ObtenerDatosRepLegal(rut);

            return objRepLegal;
        }

        public static Ejecutivo ObtieneDatosEjecutivo()
        {
            ConnectedUser connUser = Utils.getConnectedUser();

            var objDocumentos = new DBOSolicitudes();

            var objEjecutivo = objDocumentos.ObtenerDatosEjecutivo(connUser.userName);

            return objEjecutivo;
        }

        public static Solicitud ObtieneDatosEmpresa(int rut)
        {
            var objDocumentos = new DBOSolicitudes();

            var objSolicitud = objDocumentos.ObtenerDatosEmpresa(rut);

            return objSolicitud;
        }

        public static Solicitud ObtieneSolicitud(int id)
        {
            var objDocumentos = new DBOSolicitudes();

            var objSolicitud = objDocumentos.ObtenerSolicitud(id);

            return objSolicitud;
        }

        public static List<Solicitud> ObtieneSolicitudes(int rut)
        {
            var objDocumentos = new DBOSolicitudes();

            //string nombreUsuario = Utils.getConnectedUser().userName;
            //Log.WriteLog(string.Format("ObtieneSolicitudes().nombreUsuario = {0}", nombreUsuario));

            var objSolicitud = objDocumentos.ObtenerSolicitudes(rut);

            return objSolicitud;
        }

        //public static int InsertarDocumentoSubido(string nombreUsuario, string pRuta, int estado, int id)
        //{
        //    var objDocumento = new DBOSolicitudes();
        //    int idGeneracion = objDocumento.InsertarDocumentoSubido(nombreUsuario, pRuta, estado, id);
        //    return idGeneracion;
        //}

        //public static int ObtieneCodigoEjecutivo()
        //{
        //    var objDocumentos = new DBOSolicitudes();
        //    string nombreUsuario = Utils.getConnectedUser().userName;
        //    Log.WriteLog(string.Format("ObtieneSolicitudes().nombreUsuario = {0}", nombreUsuario));

        //    var ObjUsr = BoAcceso.ObtieneCodigoUsr(nombreUsuario);
        //    return ObjUsr.COD_EJEC;
        //}

        //public static int ObtieneOficinaReceptora()
        //{
        //    string nombreUsuario = Utils.getConnectedUser().userName;
        //    Log.WriteLog(string.Format("ObtieneSolicitudes().nombreUsuario = {0}", nombreUsuario));

        //    string ruta = string.Empty;
        //    var ObjUsr = BoAcceso.ObtieneCodigoUsr(nombreUsuario);
            
        //    return ObjUsr.COD_SUC;
        //}

        //public static string ObtenerPdf(int idGeneracion)
        //{
        //    var rutaPdf = DBOSolicitudes.ObtenerPdf(idGeneracion);

        //    return rutaPdf;
        //}
    }
}