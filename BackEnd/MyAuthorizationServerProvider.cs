﻿using System.Linq.Expressions;
using System.Security.Principal;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Backend.BO;

namespace Backend
{
    public class MyAuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // 
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            string nombreUsuario = string.Empty;
            WindowsIdentity user = WindowsIdentity.GetCurrent();
            if (user != null)
            {
                nombreUsuario = user.Name.Split('\\')[1]; ;
            }

             //nombreUsuario = HttpContext.Current.User.Identity.Name.Split('\\')[1];
            var ObjUsr = BoAcceso.ObtieneCodigoUsr(nombreUsuario);
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            if (ObjUsr.COD_EJEC!= 0)
            //if (context.UserName == "admin" && context.Password == "admin")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Ejecutivo"));
                context.Validated(identity);
                //identity.AddClaim(new Claim(ClaimTypes.Role, "admin"));
                //identity.AddClaim(new Claim("username", "admin"));
                //identity.AddClaim(new Claim(ClaimTypes.Name, "Sourav Mondal"));
                //context.Validated(identity);
            }
            else if (context.UserName == "user" && context.Password == "user")
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, "user"));
                identity.AddClaim(new Claim("username", "user"));
                identity.AddClaim(new Claim(ClaimTypes.Name, "Suresh Sha"));
                context.Validated(identity);
            }
            else
            {
                context.SetError("invalid_grant", "Provided username and password is incorrect");
                return;
            }
        }
    }
}