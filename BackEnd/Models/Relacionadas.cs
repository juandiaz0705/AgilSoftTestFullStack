using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class CuentaRelacionada
    {
        public string CIUDAD { get; set; }
        public string COMUNA { get; set; }

        public int dat_id { get; set; }
        public int sol_id { get; set; }  
        public string dat_rut { get; set; }
        public string dat_drt { get; set; }
        public string dat_ape_pat { get; set; }
        public string dat_ape_mat { get; set; }
        public string dat_nom { get; set; }
        public string dat_tel_ptl { get; set; }
        public string dat_tel_cel { get; set; }
        public string dat_dir { get; set; }
        public string dat_dir_com { get; set; }
        public string dat_dir_ciu { get; set; }
        public int dat_cup_tar { get; set; }
        public decimal dolarDIA { get; set; }
        public decimal cupoUSD {
            get { return Math.Round(dat_cup_tar / dolarDIA, 2); }
        }
        public string CUPO_FORMAT{
            get { return string.Format("{0:#,#}", dat_cup_tar); }
        }
        public string CUPOUSD_FORMAT
        {
            //get { return string.Format("{0:#,#.00}", cupoUSD); }
            get { return string.Format("{0:#,#}", cupoUSD); }
        }
        public string DOLAR_FORMAT
        {
            get { return string.Format("{0:#,#.00}", dolarDIA); }
        }
        public string NUM_CTA { get; set; }
        public int CAN_TAR { get; set; }
        
        public int TIP_SOL { get; set; }
        public string NUM_CTA_RLD { get; set; }
        public string TIPO_SOLICITUD { get; set; }
    }
}