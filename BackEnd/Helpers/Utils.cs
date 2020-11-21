using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using iTextSharp.text.pdf;

namespace Backend.Helpers
{
    public struct ConnectedUser
    {
        public string fullName;
        public string userName;
    }

    public static class Utils
    {
        // TODO : obtener de la base el fullName por _userName
        public static string getUserFullName(string _userName)
        {
            return _userName;
        }

        public static ConnectedUser getConnectedUser(bool getFullName = false)
        {
            var connectedUser = new ConnectedUser();
            try
            {

                //string nombreUsuario = string.Empty;
                //WindowsIdentity user = WindowsIdentity.GetCurrent();
                //if (user != null)
                //{
                //    nombreUsuario = user.Name.Split('\\')[1];
                //}


                var userIdentityName = HttpContext.Current.User.Identity.Name;
                //Log.WriteLog(string.Format("getConnectedUser().User_Identity_Name={0}", userIdentityName));

                string _userName = string.Empty;

                if (userIdentityName != null && userIdentityName != string.Empty)
                {
                    _userName = userIdentityName.Split('\\')[1];
                    connectedUser.userName = _userName;

                    if (getFullName)
                        connectedUser.fullName = getUserFullName(_userName);
                    else
                        connectedUser.fullName = ConfigKeys.defaultUser;
                }
                else {
                    connectedUser.userName = ConfigKeys.defaultUser;
                    connectedUser.fullName= ConfigKeys.defaultUser;
                }

                //Log.WriteLog(string.Format("connectedUser.userName : {0}", connectedUser.userName));
                //Log.WriteLog(string.Format("connectedUser.fullName : {0}", connectedUser.fullName));

                return connectedUser;
            }
            catch (Exception ex) {
                Log.WriteLog(string.Format("getConnectedUser(), Not user, Exception : {0}", ex.ToString()));
                connectedUser.userName = "Not user";
                connectedUser.fullName = "Not user";
                return connectedUser;
            }
          
        }
    }
}