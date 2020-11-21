using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Oferta {
        public int ID { get; set; }
        public int RUT { get; set; }
        public string CPD { get; set; }
        public string MONTO { get; set; }
        public string TASA { get; set; }
        public string N_CUOTAS { get; set; }
        public string MONTO_CUOTA { get; set; }
        public string PLAZO { get; set; }
        public string FECHA_VENCIMIENTO { get; set; }
        public string DIA_PAGO { get; set; }
        public string DIRECCION { get; set; }
        public string EMAIL { get; set; }
    }
}