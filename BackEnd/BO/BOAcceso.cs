using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Backend.Models;
using Backend.Helpers;
using System.Security.Principal;


namespace Backend.BO
{
    public class BoAcceso 
    {
        public static DatosUsrBanco ObtieneCodigoUsr(string login)
        {
            var objAcceso = new DBOAcceso();
            DatosUsrBanco result = objAcceso.ObtieneCodigoUsr(login);

            return result;
        }

        public static string IsAdmin()
        {
            ConnectedUser connUser = Utils.getConnectedUser();

            var objAcceso = new DBOAcceso();
            var result = objAcceso.IsAdmin(connUser.userName);

            return result;
        }

        public static string IsPiloto()
        {
            ConnectedUser connUser = Utils.getConnectedUser();

            var objAcceso = new DBOAcceso();
            var result = objAcceso.IsPiloto(connUser.userName);

            return result;
        }

        public static void RegistraAcceso()
        {
            ConnectedUser connUser = Utils.getConnectedUser();

            Log.WriteLog(string.Format("RegistraAcceso()"));
            Log.WriteLog(string.Format("connUser.userName={0}", connUser.userName));

            var objAcceso = new DBOAcceso();
            objAcceso.RegistraAcceso(connUser.userName);
        }
    }
}