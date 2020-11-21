using System;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Helpers;

namespace Backend.Models
{
    public class DBOConexion
    {
        public SqlConnection _Con;

        public DBOConexion()
        {
            _Con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
        }
        
    }
}