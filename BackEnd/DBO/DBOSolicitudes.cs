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

    public class DBOSolicitudes
    {
        //const string PA_OBTIENE_SOLICITUDES = "SVC_LST_DAT_SOL_PPL";
        const string PA_OBTIENE_DATOS_EMPRESA = "SVC_DAT_EMP";
        const string PA_OBTIENE_DATOS_EJECUTIVO = "SVC_DAT_EJC";
        const string PA_OBTIENE_DATOS_REPLEGAL = "SVC_DAT_RLG";
        const string PA_OBTIENE_LST_TIPOSOLICITUD = "SVC_LST_TIP_SOL";
        const string PA_OBTIENE_LST_FORMAPAGO = "SVC_LST_FRM_PGO";
        const string PA_OBTIENE_LST_DIAPAGO = "SVC_LST_DIA_PGO_CCL_FAC";
        const string PA_OBTIENE_LST_CODAFINIDAD = "SVC_LST_COD_AFN";
        const string PA_GRABA_CUENTA_PRINCIPAL = "SVA_GRB_SOL_CTA_PPL";
        const string PA_CAMBIA_ESTADO_SOLICITUD = "SVC_GRB_EST_SOL_PPL";

        const string PA_OBTIENE_LISTA_CIUDADES = "SVC_LST_CIU";
        const string PA_OBTIENE_LISTA_COMUNAS = "SVC_LST_COM";

        public static List<Ciudad> ObtenerCiudades()
        {
            var listaResultado = new List<Ciudad>();

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(PA_OBTIENE_LISTA_CIUDADES, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            var objLista = new Ciudad();

                            objLista.codCiudades = dr["com_cod_ciu"].ToString();
                            objLista.name = dr["com_gls_ciu"].ToString();

                            listaResultado.Add(objLista);
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
            return listaResultado;
        }

        public static List<Comuna> ObtenerComunas()
        {
            var listaResultado = new List<Comuna>();

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(PA_OBTIENE_LISTA_COMUNAS, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            var objLista = new Comuna();

                            objLista.codComuna = dr["com_cod"].ToString();
                            objLista.name = dr["com_nom"].ToString();

                            listaResultado.Add(objLista);
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
            return listaResultado;
        }

        public static void cambiaEstado(int sol_id, int estado)
        {
            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand(PA_CAMBIA_ESTADO_SOLICITUD, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@sol_id", SqlDbType.Int).Value = sol_id;
                        cmd.Parameters.Add("@estado", SqlDbType.Int).Value = estado;
                    

                        cmd.ExecuteNonQuery();
                    }

                    sqlCon.Close();
                    sqlCon.Dispose();

                }
            }
            catch (Exception ex)
            {

                Log.WriteLog(string.Format("DBOSolicitudes.cambiaEstado Exception : {0}", ex.ToString()));

                throw ex;
            }
        }

        public static void grabaNroCtaPpal(int solID, string NRO_CTA) {
            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand("SVA_GBR_NUM_CTA_PPL", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = solID;
                        cmd.Parameters.Add("@NUM_CTA", SqlDbType.VarChar).Value = NRO_CTA;

                        cmd.ExecuteNonQuery();
                    }

                    sqlCon.Close();
                    sqlCon.Dispose();

                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(string.Format("DBOSolicitudes.cambiaEstado Exception : {0}", ex.ToString()));
                throw ex;
            }
        }

        public static int grabaSolicitud(Solicitud objSolicitud)
        {
            int id_sol = 0;

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();

                    using (SqlCommand cmd = new SqlCommand(PA_GRABA_CUENTA_PRINCIPAL, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.Add("@BOTON", SqlDbType.Int).Value = objSolicitud.BOTON;
                        cmd.Parameters.Add("@sol_id", SqlDbType.Int).Value = objSolicitud.ID;
                        cmd.Parameters.Add("@sol_rut", SqlDbType.Int).Value = objSolicitud.sol_rut;
                        cmd.Parameters.Add("@sol_drt", SqlDbType.Char).Value = objSolicitud.sol_drt;
                        cmd.Parameters.Add("@sol_nom", SqlDbType.Char).Value = objSolicitud.NOMBRE;
                        cmd.Parameters.Add("@sol_nom_fan", SqlDbType.Char).Value = objSolicitud.sol_nom_fan;
                        cmd.Parameters.Add("@sol_dir", SqlDbType.Char).Value = objSolicitud.sol_dir;
                        cmd.Parameters.Add("@sol_dir_num", SqlDbType.Char).Value = objSolicitud.sol_dir_num;
                        cmd.Parameters.Add("@sol_dir_dpt", SqlDbType.Char).Value = objSolicitud.sol_dir_dpt;
                        cmd.Parameters.Add("@sol_dir_com", SqlDbType.Char).Value = objSolicitud.sol_dir_com;
                        cmd.Parameters.Add("@sol_dir_ciu", SqlDbType.Char).Value = objSolicitud.sol_dir_ciu;
                        cmd.Parameters.Add("@sol_rlg_nom_001", SqlDbType.Char).Value = objSolicitud.sol_rlg_nom_001;
                        cmd.Parameters.Add("@sol_rlg_ape_pat_001", SqlDbType.Char).Value = objSolicitud.sol_rlg_ape_pat_001;
                        cmd.Parameters.Add("@sol_rlg_ape_mat_001", SqlDbType.Char).Value = objSolicitud.sol_rlg_ape_mat_001;
                        cmd.Parameters.Add("@sol_rlg_rut_001", SqlDbType.Int).Value = objSolicitud.sol_rlg_rut_001;
                        cmd.Parameters.Add("@sol_rlg_drt_001", SqlDbType.Char).Value = objSolicitud.sol_rlg_drt_001;
                        cmd.Parameters.Add("@sol_rlg_nom_002", SqlDbType.Char).Value = objSolicitud.sol_rlg_nom_002;
                        cmd.Parameters.Add("@sol_rlg_ape_pat_002", SqlDbType.Char).Value = objSolicitud.sol_rlg_ape_pat_002;
                        cmd.Parameters.Add("@sol_rlg_ape_mat_002", SqlDbType.Char).Value = objSolicitud.sol_rlg_ape_mat_002;

                        if (objSolicitud.sol_rlg_rut_002.Trim() != string.Empty)
                        {
                            cmd.Parameters.Add("@sol_rlg_rut_002", SqlDbType.Int).Value = objSolicitud.sol_rlg_rut_002;
                            cmd.Parameters.Add("@sol_rlg_drt_002", SqlDbType.Char).Value = objSolicitud.sol_rlg_drt_002;
                        }

                        cmd.Parameters.Add("@sol_nom_cct_emp", SqlDbType.Char).Value = objSolicitud.sol_nom_cct_emp;
                        cmd.Parameters.Add("@sol_tel_fij", SqlDbType.Char).Value = objSolicitud.sol_tel_fij;
                        cmd.Parameters.Add("@sol_tel_mvl", SqlDbType.Char).Value = objSolicitud.sol_tel_mvl;
                        cmd.Parameters.Add("@sol_cup_gen_pes", SqlDbType.Int).Value = objSolicitud.CUPO_GENERAL.Replace(".", string.Empty);

                        cmd.Parameters.Add("@sol_dol_dia", SqlDbType.Decimal).Value = objSolicitud.sol_dol_dia;
                        cmd.Parameters.Add("@sol_fpo", SqlDbType.Int).Value = objSolicitud.sol_fpo;
                        cmd.Parameters.Add("@sol_num_cta_cgo", SqlDbType.Char).Value = objSolicitud.sol_num_cta_cgo;
                        cmd.Parameters.Add("@sol_dia_pgo_ccl_fac", SqlDbType.Int).Value = objSolicitud.sol_dia_pgo_ccl_fac;
                        cmd.Parameters.Add("@sol_tip_sol", SqlDbType.Int).Value = objSolicitud.sol_tip_sol;
                        cmd.Parameters.Add("@sol_cod_suc", SqlDbType.Int).Value = (objSolicitud.SUCURSAL != string.Empty ? objSolicitud.SUCURSAL : "0"); 
                        cmd.Parameters.Add("@sol_cod_ejc", SqlDbType.Int).Value = (objSolicitud.sol_cod_ejc != string.Empty ? objSolicitud.sol_cod_ejc: "0");
                        cmd.Parameters.Add("@sol_nom_ejc", SqlDbType.Char).Value = objSolicitud.EJECUTIVO;
                        cmd.Parameters.Add("@sol_cod_afn", SqlDbType.Int).Value = objSolicitud.sol_cod_afn;

                        id_sol = (int)cmd.ExecuteScalar();
                    }

                    sqlCon.Close();
                    sqlCon.Dispose();

                }

                return id_sol;
            }
            catch (Exception ex)
            {

                Log.WriteLog(string.Format("grabaSolicitud Exception : {0}", ex.ToString()));

                throw ex;
            }
        }

        public static List<CodigoAfinidad> ObtenerCodigoAfinidad()
        {
            var listaCodAfinidad = new List<CodigoAfinidad>();

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(PA_OBTIENE_LST_CODAFINIDAD, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            var objCodAfinidad = new CodigoAfinidad();

                            objCodAfinidad.cod_id = Convert.ToInt32(dr["cod_id"].ToString());
                            objCodAfinidad.cod_afn_des = dr["cod_afn_des"].ToString();

                            listaCodAfinidad.Add(objCodAfinidad);
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
            return listaCodAfinidad;
        }

        public static List<DiaPago> ObtenerDiaPago()
        {
            var listaDiaPago = new List<DiaPago>();

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(PA_OBTIENE_LST_DIAPAGO, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            var objDiaPago = new DiaPago();

                            objDiaPago.dia_id = Convert.ToInt32(dr["dia_id"].ToString());
                            objDiaPago.dia_pgo = Convert.ToInt32(dr["dia_pgo"].ToString());
                            objDiaPago.dia_ccl_fac = dr["dia_ccl_fac"].ToString();

                            listaDiaPago.Add(objDiaPago);
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
            return listaDiaPago;
        }

        public static List<FormaPago> ObtenerFormaPago()
        {
            var listaFormaPago = new List<FormaPago>();

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(PA_OBTIENE_LST_FORMAPAGO, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            var objFormaPago = new FormaPago();

                            objFormaPago.frm_id = Convert.ToInt32(dr["frm_id"].ToString());
                            objFormaPago.frm_des = dr["frm_des"].ToString();

                            listaFormaPago.Add(objFormaPago);
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
            return listaFormaPago;
        }

        public static List<TipoSolicitud> ObtenerTipoSolicitud()
        {
            var listaTipoSolicitud = new List<TipoSolicitud>();

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(PA_OBTIENE_LST_TIPOSOLICITUD, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            var objTipoSolicitud = new TipoSolicitud();

                            objTipoSolicitud.tip_id = Convert.ToInt32(dr["tip_id"].ToString());
                            objTipoSolicitud.tip_des = dr["tip_des"].ToString();

                            listaTipoSolicitud.Add(objTipoSolicitud);
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
            return listaTipoSolicitud;
        }

        public static RepLegal ObtenerDatosRepLegal(int rut)
        {
            var objRepLegal = new RepLegal();
            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();

                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(PA_OBTIENE_DATOS_REPLEGAL, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@sol_rut", SqlDbType.Int).Value = rut;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            objRepLegal.nombre = dr["nombre"].ToString();
                            objRepLegal.rep_ape_pat = dr["rep_ape_pat"].ToString();
                            objRepLegal.rep_ape_mat = dr["rep_ape_mat"].ToString();
                            objRepLegal.rep_rut = dr["rep_rut"].ToString();
                            objRepLegal.rep_dv = dr["rep_dv"].ToString();
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
            return objRepLegal;
        }

        public static Ejecutivo ObtenerDatosEjecutivo(string username)
        {
            var objEjecutivo = new Ejecutivo();
            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();

                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(PA_OBTIENE_DATOS_EJECUTIVO, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@LOGIN", SqlDbType.Char).Value = username;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            objEjecutivo.cod_ejecutivo = dr["cod_ejecutivo"].ToString();
                            objEjecutivo.nombre_ejc = dr["nombre_ejc"].ToString();
                            objEjecutivo.cod_oficina = dr["cod_oficina"].ToString();
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
            return objEjecutivo;
        }

        public static Solicitud ObtenerDatosEmpresa(int rut)
        {
            var objSolicitud = new Solicitud();
            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();

                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(PA_OBTIENE_DATOS_EMPRESA, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@sol_rut", SqlDbType.Int).Value = rut;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            objSolicitud.ID = 0;
                            objSolicitud.FECHA_INGRESO = Convert.ToDateTime(dr["FECHA_INGRESO"]).ToString("dd/MM/yyyy");
                            objSolicitud.NOMBRE = dr["NOMBRE"].ToString();
                            objSolicitud.CUPO_GENERAL = String.Format("{0:#,#}", dr["CUPO_GENERAL"]);
                            objSolicitud.sol_cup_gen_pes = Convert.ToInt32(dr["CUPO_GENERAL"].ToString()!=string.Empty?dr["CUPO_GENERAL"].ToString():"0");

                            //objSolicitud.SUCURSAL = dr["SUCURSAL"].ToString();
                            //objSolicitud.EJECUTIVO = dr["EJECUTIVO"].ToString();
                            //objSolicitud.ESTADO = dr["ESTADO"].ToString();

                            //objSolicitud.sol_rut = dr["sol_rut"].ToString();
                            //objSolicitud.sol_drt = dr["sol_drt"].ToString();
                            objSolicitud.sol_nom_fan = dr["sol_nom_fan"].ToString();
                            objSolicitud.sol_dir = dr["sol_dir"].ToString();
                            objSolicitud.sol_dir_num = dr["sol_dir_num"].ToString();
                            objSolicitud.sol_dir_dpt = dr["sol_dir_dpt"].ToString();
                            objSolicitud.sol_dir_com = dr["sol_dir_com"].ToString();
                            objSolicitud.sol_dir_ciu = dr["sol_dir_ciu"].ToString();
                            objSolicitud.sol_rlg_nom_001 = dr["sol_rlg_nom_001"].ToString();
                            objSolicitud.sol_rlg_ape_pat_001 = dr["sol_rlg_ape_pat_001"].ToString();
                            objSolicitud.sol_rlg_ape_mat_001 = dr["sol_rlg_ape_mat_001"].ToString();
                            objSolicitud.sol_rlg_rut_001 = String.Format("{0:#,#}", dr["sol_rlg_rut_001"]);
                            objSolicitud.sol_rlg_drt_001 = dr["sol_rlg_drt_001"].ToString();
                            objSolicitud.sol_rlg_nom_002 = dr["sol_rlg_nom_002"].ToString();
                            objSolicitud.sol_rlg_ape_pat_002 = dr["sol_rlg_ape_pat_002"].ToString();
                            objSolicitud.sol_rlg_ape_mat_002 = dr["sol_rlg_ape_mat_002"].ToString();
                            objSolicitud.sol_rlg_rut_002 = String.Format("{0:#,#}", dr["sol_rlg_rut_002"]);
                            objSolicitud.sol_rlg_drt_002 = dr["sol_rlg_drt_002"].ToString();
                            objSolicitud.sol_nom_cct_emp = dr["sol_nom_cct_emp"].ToString();
                            objSolicitud.sol_tel_fij = dr["sol_tel_fij"].ToString();
                            objSolicitud.sol_tel_mvl = dr["sol_tel_mvl"].ToString();
                            objSolicitud.sol_dol_dia = dr["sol_dol_dia"].ToString();
                            objSolicitud.sol_fpo = dr["sol_fpo"].ToString();
                            objSolicitud.sol_num_cta_cgo = dr["sol_num_cta_cgo"].ToString();

                            var arrCuentaCargo = dr["sol_num_cta_cgo"].ToString().Split('-');
                            objSolicitud.NRO_CUENTA_CARGO = arrCuentaCargo[0];
                            objSolicitud.DIG_CUENTA_CARGO = (arrCuentaCargo.Length > 1 ? arrCuentaCargo[1] : string.Empty);

                            objSolicitud.sol_dia_pgo_ccl_fac = dr["sol_dia_pgo_ccl_fac"].ToString();
                            objSolicitud.sol_tip_sol = dr["sol_tip_sol"].ToString();
                            //objSolicitud.sol_cod_ejc = dr["sol_cod_ejc"].ToString();
                            objSolicitud.sol_cod_afn = dr["sol_cod_afn"].ToString();
                            //objSolicitud.sol_fec_ult_est = Convert.ToDateTime(dr["sol_fec_ult_est"]).ToString("dd/MM/yyyy");

                            //switch (Convert.ToInt32(dr["ESTADO"].ToString()))
                            //{
                            //    case 1:
                                    objSolicitud.editable = true;
                            //        break;
                            //    case 2:
                            //    default:
                            //        objSolicitud.editable = false;
                            //        break;
                            //}

                            //objSolicitud.CUPO_DOLAR = String.Format("{0:#,#.00}", dr["CUPO_DOLAR"]);
                            objSolicitud.CUPO_DOLAR = String.Format("{0:#,#}", dr["CUPO_DOLAR"]);
                            //objSolicitud.fono_movil = dr["fono_movil"].ToString();
                            //objSolicitud.fono_fijo = dr["fono_fijo"].ToString();
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
            return objSolicitud;
        }

        public static Solicitud ObtenerSolicitud(int id, string doc_tip = null)
        {
            var objSolicitud = new Solicitud();
            string storeProcedure = string.Empty;

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();

                switch (doc_tip)
                {
                    case "AC":
                        storeProcedure = "SVC_LST_DAT_DOC_ANX_CTT";
                    break;
                    case "RC":
                        storeProcedure = "SVC_LST_DAT_DOC_RES_024";
                    break;
                    default:
                        storeProcedure = "SVC_LST_DAT_SOL_PPL";
                    break;
                }

                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand(storeProcedure, sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            objSolicitud.ID = Convert.ToInt32(dr["ID"].ToString());
                          
                            if(dr["FECHA_INGRESO"].ToString() != string.Empty){
                                objSolicitud.FECHA_INGRESO = Convert.ToDateTime(dr["FECHA_INGRESO"]).ToString("dd/MM/yyyy");
                            }

                            objSolicitud.NOMBRE = dr["NOMBRE"].ToString();

                            objSolicitud.CUPO_GENERAL = String.Format("{0:#,#}", dr["CUPO_GENERAL"]);
                            //objSolicitud.CUPO_DOLAR =  String.Format("{0:#,#.00}", dr["CUPO_DOLAR"]);
                            objSolicitud.CUPO_DOLAR = dr["CUPO_DOLAR"].ToString().Split(',')[0]; 

                            objSolicitud.SUCURSAL = dr["SUCURSAL"].ToString();
                            objSolicitud.EJECUTIVO = dr["EJECUTIVO"].ToString();
                            objSolicitud.ESTADO = dr["ESTADO"].ToString();

                            var arrCuenta_cargo = dr["sol_num_cta_cgo"].ToString().Split('-');
                            objSolicitud.NRO_CUENTA_CARGO = arrCuenta_cargo[0];
                            if (arrCuenta_cargo.Length > 1)
                            {
                                objSolicitud.DIG_CUENTA_CARGO = arrCuenta_cargo[1];
                            }
                            else {
                                objSolicitud.DIG_CUENTA_CARGO = string.Empty;
                            }

                            objSolicitud.COMUNA = dr["COMUNA"].ToString();
                            objSolicitud.CIUDAD = dr["CIUDAD"].ToString();
                            if(doc_tip == "AC"){
                                objSolicitud.CIUDAD_001 = dr["CIUDAD_001"].ToString();
                            }
                            objSolicitud.TIPO_SOLICITUD = dr["TIPO_SOLICITUD"].ToString();
                            objSolicitud.FORMA_PAGO = dr["FORMA_PAGO"].ToString();
                            objSolicitud.DIA_CICLO_FACTURACION = dr["DIA_CICLO_FACTURACION"].ToString();
                            objSolicitud.CODIGO_AFINIDAD = dr["CODIGO_AFINIDAD"].ToString();

                            objSolicitud.sol_rut = String.Format("{0:#,#}", dr["sol_rut"]);
                            objSolicitud.sol_drt = dr["sol_drt"].ToString();
                            objSolicitud.sol_nom_fan = dr["sol_nom_fan"].ToString();
                            objSolicitud.sol_dir = dr["sol_dir"].ToString();
                            objSolicitud.sol_dir_num = dr["sol_dir_num"].ToString();
                            objSolicitud.sol_dir_dpt = dr["sol_dir_dpt"].ToString();
                            objSolicitud.sol_dir_com = dr["sol_dir_com"].ToString();
                            objSolicitud.sol_dir_ciu = dr["sol_dir_ciu"].ToString();
                            objSolicitud.sol_rlg_nom_001 = dr["sol_rlg_nom_001"].ToString();
                            objSolicitud.sol_rlg_ape_pat_001 = dr["sol_rlg_ape_pat_001"].ToString();
                            objSolicitud.sol_rlg_ape_mat_001 = dr["sol_rlg_ape_mat_001"].ToString();
                            objSolicitud.sol_rlg_rut_001 = String.Format("{0:#,#}", dr["sol_rlg_rut_001"]);
                            objSolicitud.sol_rlg_drt_001 = dr["sol_rlg_drt_001"].ToString();
                            objSolicitud.sol_rlg_nom_002 = dr["sol_rlg_nom_002"].ToString();
                            objSolicitud.sol_rlg_ape_pat_002 = dr["sol_rlg_ape_pat_002"].ToString();
                            objSolicitud.sol_rlg_ape_mat_002 = dr["sol_rlg_ape_mat_002"].ToString();
                            objSolicitud.sol_rlg_rut_002 = String.Format("{0:#,#}", dr["sol_rlg_rut_002"]);
                            objSolicitud.sol_rlg_drt_002 = dr["sol_rlg_drt_002"].ToString();
                            objSolicitud.sol_nom_cct_emp = dr["sol_nom_cct_emp"].ToString();
                            objSolicitud.sol_tel_fij = dr["sol_tel_fij"].ToString();
                            objSolicitud.sol_tel_mvl = dr["sol_tel_mvl"].ToString();
                            objSolicitud.sol_dol_dia = String.Format("{0:#,#.00}", dr["sol_dol_dia"]);

                            objSolicitud.sol_fpo = dr["sol_fpo"].ToString();

                            var arrCuentaCargo = dr["sol_num_cta_cgo"].ToString().Split('-');
                            objSolicitud.NRO_CUENTA_CARGO = arrCuentaCargo[0];
                            objSolicitud.DIG_CUENTA_CARGO = (arrCuentaCargo.Length > 1 ? arrCuentaCargo[1] : string.Empty);

                            objSolicitud.sol_dia_pgo_ccl_fac = dr["sol_dia_pgo_ccl_fac"].ToString();
                            objSolicitud.sol_tip_sol = dr["sol_tip_sol"].ToString();
                            objSolicitud.sol_cod_ejc = dr["sol_cod_ejc"].ToString();
                            objSolicitud.sol_cod_afn = dr["sol_cod_afn"].ToString();
                            objSolicitud.sol_fec_ult_est = Convert.ToDateTime(dr["sol_fec_ult_est"]).ToString("dd/MM/yyyy");

                            objSolicitud.DIA_FAC_DSD = Convert.ToInt32(dr["dia_fac_dsd"]);
                            objSolicitud.DIA_FAC_HST = Convert.ToInt32(dr["dia_fac_hst"]);

                            switch (Convert.ToInt32(dr["ESTADO"].ToString()))
                            {
                                case 1:
                                    objSolicitud.editable = true;
                                    break;
                                case 2:
                                default:
                                    objSolicitud.editable = false;
                                    break;
                            }

                            objSolicitud.sol_num_cta_ppl =  dr["sol_num_cta_ppl"].ToString();
                            objSolicitud.sol_can_tar_rld = Convert.ToInt32(dr["sol_can_tar_rld"].ToString());
                            
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
            return objSolicitud;
        }

        public static List<Solicitud> ObtenerSolicitudes(int rut)
        {
            var listaSolicitud = new List<Solicitud>();

            try
            {
                string ConnectionPath = ConfigurationManager.ConnectionStrings["DbConnection"].ToString();
                using (var sqlCon = new SqlConnection(ConnectionPath))
                {
                    sqlCon.Open();
                    using (SqlCommand cmd = new SqlCommand("SVC_LST_DAT_SOL_PPL", sqlCon))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@RUT", SqlDbType.Int).Value = rut;
                        SqlDataReader dr = cmd.ExecuteReader();

                        foreach (DbDataRecord c in dr.Cast<DbDataRecord>())
                        {
                            var objSolicitud = new Solicitud();
                         
                            objSolicitud.ID = Convert.ToInt32(dr["ID"].ToString());
                            objSolicitud.FECHA_INGRESO = Convert.ToDateTime(dr["FECHA_INGRESO"]).ToString("dd/MM/yyyy");
                            objSolicitud.NOMBRE = dr["NOMBRE"].ToString();
                            objSolicitud.CUPO_GENERAL = String.Format("{0:#,#}", dr["CUPO_GENERAL"]);
                            //objSolicitud.CUPO_DOLAR = String.Format("{0:#,#.00}", dr["CUPO_DOLAR"]);
                            objSolicitud.CUPO_DOLAR = String.Format("{0:#,#}", dr["CUPO_DOLAR"]);

                            objSolicitud.SUCURSAL = dr["SUCURSAL"].ToString();
                            objSolicitud.EJECUTIVO = dr["EJECUTIVO"].ToString();
                            //objSolicitud.EJECUTIVO_SHORT = dr["EJECUTIVO_SHORT"].ToString();
                            objSolicitud.ESTADO = dr["ESTADO"].ToString();

                            switch(Convert.ToInt32(dr["ESTADO"].ToString())){
                                case 1:
                                    objSolicitud.editable = true;
                                    break;
                                case 2:
                                default:
                                    objSolicitud.editable = false;
                                    break;
                            }
                            listaSolicitud.Add(objSolicitud);
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
            return listaSolicitud;
        }

    }
}