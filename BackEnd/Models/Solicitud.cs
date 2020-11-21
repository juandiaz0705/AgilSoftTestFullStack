using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    //[Serializable]
    public class Solicitud
    {
       public int BOTON { get; set; }
       public int ID { get; set; }
       public string FECHA_INGRESO { get; set; }
       public string NOMBRE { get; set; }
       public string CUPO_GENERAL { get; set; }
       public string SUCURSAL { get; set; }
       public string EJECUTIVO { get; set; }
       public string EJECUTIVO_SHORT { get; set; }
       public string CUPO_DOLAR { get; set; }
       public string ESTADO { get; set; }
       public string TIPO_SOLICITUD { get; set; }
       public string FORMA_PAGO { get; set; }
       public string DIA_CICLO_FACTURACION { get; set; }
       public string CODIGO_AFINIDAD { get; set; }
       public string NRO_CUENTA_CARGO { get; set; }
       public string DIG_CUENTA_CARGO { get; set; }
       public string COMUNA { get; set; }
       public string CIUDAD { get; set; }
       public string CIUDAD_001 { get; set; }
       public int DIA_FAC_DSD { get; set; }
       public int DIA_FAC_HST { get; set; }

       public string sol_rut { get; set; }
       public string sol_drt { get; set; }
       public string sol_nom_fan { get; set; }
       public string sol_dir { get; set; }
       public string sol_dir_num { get; set; }
       public string sol_dir_dpt { get; set; }
       public string sol_dir_com { get; set; }
       public string sol_dir_ciu { get; set; }
       public string sol_rlg_nom_001 { get; set; }
       public string sol_rlg_ape_pat_001 { get; set; }
       public string sol_rlg_ape_mat_001 { get; set; }
       public string sol_rlg_rut_001 { get; set; }
       public string sol_rlg_drt_001 { get; set; }
       public string sol_rlg_nom_002 { get; set; }
       public string sol_rlg_ape_pat_002 { get; set; }
       public string sol_rlg_ape_mat_002 { get; set; }
       public string sol_rlg_rut_002 { get; set; }
       public string sol_rlg_drt_002 { get; set; }
       public string sol_nom_cct_emp { get; set; }
       public string sol_tel_fij { get; set; }
       public string sol_tel_mvl { get; set; }
       public string sol_dol_dia { get; set; }
       public string sol_fpo { get; set; }
       public string sol_num_cta_cgo { get; set; }
       public string sol_dia_pgo_ccl_fac { get; set; }
       public string sol_tip_sol { get; set; }
       public string sol_cod_ejc { get; set; } 
       public string sol_cod_afn { get; set; }
       public string sol_fec_ult_est { get; set; }
       public bool editable { get; set; }

       public string sol_num_cta_ppl { get; set; }
       public int sol_can_tar_rld { get; set; }

       public int sol_cup_gen_pes { get; set; }

    }

    public class CodigoAfinidad
    {
        public int cod_id { get; set; }
        public string cod_afn_des { get; set; }
    }

    public class DiaPago
    {
        public int dia_id { get; set; }
        public int dia_pgo { get; set; }
        public string dia_ccl_fac { get; set; }
    }

    public class FormaPago
    {
        public int frm_id { get; set; }
        public string frm_des { get; set; }
    }

    public class TipoSolicitud
    {
        public int tip_id { get; set; }
        public string tip_des { get; set; }
    }

    public class RepLegal
    {
        public string nombre { get; set; }
        public string rep_ape_pat { get; set; }
        public string rep_ape_mat { get; set; }
        public string rep_rut { get; set; }
        public string rep_dv { get; set; }
    }

    public class Ejecutivo
    {
        public string cod_ejecutivo { get; set; }
        public string nombre_ejc { get; set; }
        public string cod_oficina { get; set; }
    }

}