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
    public class DBORelacionadas
    {
        public static void grabaImpCuentaRelacionada(CuentaRelacionada objCuentaRelacionada)
        {
            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand("SVA_GBR_ADC_IMP", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = objCuentaRelacionada.sol_id;
                        cmd.Parameters.Add("@RUT", SqlDbType.Int).Value = objCuentaRelacionada.dat_rut.Replace(".", string.Empty);
                        cmd.Parameters.Add("@DV", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_drt;
                        cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_nom ?? string.Empty;
                        cmd.Parameters.Add("@AP_PAT", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_ape_pat ?? string.Empty;
                        cmd.Parameters.Add("@AP_MAT", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_ape_mat ?? string.Empty;
                        cmd.Parameters.Add("@TEL", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_tel_ptl ?? string.Empty;
                        cmd.Parameters.Add("@CEL", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_tel_cel ?? string.Empty;
                        cmd.Parameters.Add("@DIR", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_dir ?? string.Empty;
                        cmd.Parameters.Add("@COM", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_dir_com ?? string.Empty;
                        cmd.Parameters.Add("@CIU", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_dir_ciu ?? string.Empty;
                        cmd.Parameters.Add("@CUPO", SqlDbType.Int).Value = objCuentaRelacionada.dat_cup_tar;
                        cmd.Parameters.Add("@NUM_CTA", SqlDbType.VarChar).Value = objCuentaRelacionada.NUM_CTA ?? string.Empty;
                        cmd.Parameters.Add("@CAN_TAR", SqlDbType.Int).Value = objCuentaRelacionada.CAN_TAR;

                        cmd.Parameters.Add("@TIP_SOL", SqlDbType.Int).Value = objCuentaRelacionada.TIP_SOL;
                        cmd.Parameters.Add("@NUM_CTA_RLD", SqlDbType.VarChar).Value = objCuentaRelacionada.NUM_CTA_RLD ?? string.Empty;

                        cmd.ExecuteNonQuery();
                    }

                    sqlCon.Close();
                    sqlCon.Dispose();

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public static void eliminaCuentaRelacionada(int ID, int rut)
        {
            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();

                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("SVA_ELI_ADC", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = ID;
                        cmd.Parameters.Add("@rut", SqlDbType.Int).Value = rut;

                        cmd.ExecuteNonQuery();

                        sqlCon.Close();
                        sqlCon.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public static CuentaRelacionada ObtenerCuentaRelacionada(int dat_id)
        {
            var objCuentaRelacionada = new CuentaRelacionada();

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();

                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("SVC_DAT_CTA_RLD", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@dat_id", SqlDbType.Int).Value = dat_id;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            objCuentaRelacionada.sol_id = Convert.ToInt32(dr["sol_id"]);
                            objCuentaRelacionada.dat_id = Convert.ToInt32(dr["dat_id"]);
                            objCuentaRelacionada.dat_rut = String.Format("{0:#,#}", dr["dat_rut"]);
                            objCuentaRelacionada.dat_drt = dr["dat_drt"].ToString();
                            objCuentaRelacionada.dat_ape_pat = dr["dat_ape_pat"].ToString();
                            objCuentaRelacionada.dat_ape_mat = dr["dat_ape_mat"].ToString();
                            objCuentaRelacionada.dat_nom = dr["dat_nom"].ToString();
                            objCuentaRelacionada.dat_tel_ptl = dr["dat_tel_ptl"].ToString();
                            objCuentaRelacionada.dat_tel_cel = dr["dat_tel_cel"].ToString();
                            objCuentaRelacionada.dat_dir = dr["dat_dir"].ToString();
                            objCuentaRelacionada.dat_dir_com = dr["dat_dir_com"].ToString();
                            objCuentaRelacionada.dat_dir_ciu = dr["dat_dir_ciu"].ToString();
                            objCuentaRelacionada.dat_cup_tar = Convert.ToInt32(dr["dat_cup_tar"]);
                            objCuentaRelacionada.dolarDIA = Convert.ToDecimal(dr["dolarDIA"]);
                            objCuentaRelacionada.TIP_SOL = Convert.ToInt32(dr["dat_tip_sol"] != DBNull.Value ? dr["dat_tip_sol"] : "1");
                            objCuentaRelacionada.NUM_CTA_RLD = dr["dat_num_cta_rld"].ToString();
                            objCuentaRelacionada.TIPO_SOLICITUD = dr["tip_des"].ToString();
                            objCuentaRelacionada.CIUDAD = dr["CIUDAD"].ToString();
                            objCuentaRelacionada.COMUNA = dr["COMUNA"].ToString();

                        }
                    }
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
            return objCuentaRelacionada;
        }
        
       public static List<CuentaRelacionada> ObtenerCuentasRelacionadas(int sol_id)
        {
            var lstCuentasRelacionadas = new List<CuentaRelacionada>();

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();

                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("SVC_DAT_EMP_SOL_PPL", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = sol_id;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            var objCuentaRelacionada = new CuentaRelacionada();

                            objCuentaRelacionada.dat_id = Convert.ToInt32(dr["dat_id"].ToString());
                            objCuentaRelacionada.dat_rut = String.Format("{0:#,#}", dr["dat_rut"]);
                            objCuentaRelacionada.dat_drt = dr["dat_drt"].ToString();
                            objCuentaRelacionada.dat_ape_pat = dr["dat_ape_pat"].ToString();
                            objCuentaRelacionada.dat_ape_mat = dr["dat_ape_mat"].ToString();
                            objCuentaRelacionada.dat_nom = dr["dat_nom"].ToString();
                            objCuentaRelacionada.dat_tel_ptl = dr["dat_tel_ptl"].ToString();
                            objCuentaRelacionada.dat_tel_cel = dr["dat_tel_cel"].ToString();
                            objCuentaRelacionada.dat_dir = dr["dat_dir"].ToString();
                            objCuentaRelacionada.dat_dir_com = dr["dat_dir_com"].ToString();
                            objCuentaRelacionada.dat_dir_ciu = dr["dat_dir_ciu"].ToString();
                            objCuentaRelacionada.dat_cup_tar = Convert.ToInt32(dr["dat_cup_tar"].ToString());
                            objCuentaRelacionada.dolarDIA = Convert.ToDecimal(dr["dolarDIA"]);

                            lstCuentasRelacionadas.Add(objCuentaRelacionada);
                        }
                    }
                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return lstCuentasRelacionadas;
        }

       public static int grabaCuentaRelacionada(CuentaRelacionada objCuentaRelacionada)
        {
            int dat_id = 0;

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand("SVA_GBR_ADC", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = objCuentaRelacionada.sol_id;
                        cmd.Parameters.Add("@RUT", SqlDbType.Int).Value = objCuentaRelacionada.dat_rut;
                        cmd.Parameters.Add("@DV", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_drt;
                        cmd.Parameters.Add("@NOM", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_nom;
                        cmd.Parameters.Add("@AP_PAT", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_ape_pat;
                        cmd.Parameters.Add("@AP_MAT", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_ape_mat;
                        cmd.Parameters.Add("@TEL", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_tel_ptl;
                        cmd.Parameters.Add("@CEL", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_tel_cel;
                        cmd.Parameters.Add("@DIR", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_dir;
                        cmd.Parameters.Add("@COM", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_dir_com;
                        cmd.Parameters.Add("@CIU", SqlDbType.VarChar).Value = objCuentaRelacionada.dat_dir_ciu;
                        cmd.Parameters.Add("@CUPO", SqlDbType.Int).Value = objCuentaRelacionada.dat_cup_tar;
                        cmd.Parameters.Add("@NUM_CTA", SqlDbType.VarChar).Value = objCuentaRelacionada.NUM_CTA;
                        cmd.Parameters.Add("@CAN_TAR", SqlDbType.Int).Value = objCuentaRelacionada.CAN_TAR;
                        cmd.Parameters.Add("@TIP_SOL", SqlDbType.Int).Value = objCuentaRelacionada.TIP_SOL;
                        cmd.Parameters.Add("@NUM_CTA_RLD", SqlDbType.VarChar).Value = (objCuentaRelacionada.TIP_SOL==2?objCuentaRelacionada.NUM_CTA_RLD:string.Empty);

                        dat_id = (int)cmd.ExecuteScalar();
                    }

                    sqlCon.Close();
                    sqlCon.Dispose();

                }

                return dat_id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public static CuentaRelacionada ObtenerDatosAdicional(int rut)
        {
            var objCuentaRelacionada = new CuentaRelacionada();
            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();

                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("SVC_DAT_ADC", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@sol_rut", SqlDbType.Int).Value = rut;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            objCuentaRelacionada.dat_rut = dr["dat_rut"].ToString();
                            objCuentaRelacionada.dat_drt = dr["dat_drt"].ToString();
                            objCuentaRelacionada.dat_ape_pat = dr["dat_ape_pat"].ToString();
                            objCuentaRelacionada.dat_ape_mat = dr["dat_ape_mat"].ToString();
                            objCuentaRelacionada.dat_nom = dr["dat_nom"].ToString();
                            objCuentaRelacionada.dat_tel_ptl = dr["dat_tel_ptl"].ToString();
                            objCuentaRelacionada.dat_tel_cel = dr["dat_tel_cel"].ToString();
                            objCuentaRelacionada.dat_dir = dr["dat_dir"].ToString();
                            objCuentaRelacionada.dat_dir_com = dr["dat_dir_com"].ToString();
                            objCuentaRelacionada.dat_dir_ciu = dr["dat_dir_ciu"].ToString();
                            objCuentaRelacionada.dat_cup_tar = Convert.ToInt32(dr["dat_cup_tar"].ToString());
                            objCuentaRelacionada.dolarDIA = Convert.ToDecimal(dr["dolarDIA"]); 
                            //objCuentaRelacionada.dolarDIA = String.Format("{0:#,#.00}", dr["dolarDIA"]); 
                        }
                    }

                    sqlCon.Close();
                    sqlCon.Dispose();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return objCuentaRelacionada;
        }
    }
}
