using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using Backend.Helpers;

namespace Backend.Models
{

    public class DBOReportes
    {
        public static DataTable ObtenerReporteSolicitud(int rut, int id, string fechaInicio, string fechaFin)
        {
            DataTable dt = new DataTable();  //dataset class object

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();

                    //SqlConnection con = new SqlConnection(@"Some Connection String");//connection object
                    SqlDataAdapter da = new SqlDataAdapter("SVC_LST_SOL_PPL_IMP", sqlCon);//SqlDataAdapter class object
                    da.SelectCommand.CommandType = CommandType.StoredProcedure; //command sype

                    da.SelectCommand.Parameters.Add("@RUT", SqlDbType.Int).Value = rut;
                    da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    da.SelectCommand.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = fechaInicio;
                    da.SelectCommand.Parameters.Add("@FECHA_FIN", SqlDbType.DateTime).Value = fechaFin;

                    da.Fill(dt); //call the stored producer
                                                           
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dt.TableName = "Impresión Solicitudes";
            return dt;
        }

        public static DataTable ObtenerReporteCuentaRel(int rut, int id, string fechaInicio, string fechaFin)
        {
            DataTable dt = new DataTable();  //dataset class object

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();

                    SqlDataAdapter da = new SqlDataAdapter("SVC_LST_CTA_RLD_IMP", sqlCon);//SqlDataAdapter class object
                    da.SelectCommand.CommandType = CommandType.StoredProcedure; //command sype

                    da.SelectCommand.Parameters.Add("@RUT", SqlDbType.Int).Value = rut;
                    da.SelectCommand.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                    da.SelectCommand.Parameters.Add("@FECHA_INICIO", SqlDbType.DateTime).Value = fechaInicio;
                    da.SelectCommand.Parameters.Add("@FECHA_FIN", SqlDbType.DateTime).Value = fechaFin;

                    da.Fill(dt); //call the stored producer

                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            dt.TableName = "Impresión Cuentas Relacionadas";
            return dt;
        }

    }
}