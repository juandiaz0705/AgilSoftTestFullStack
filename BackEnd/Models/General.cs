using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Monto
    {
        public int mnt_id { get; set; }
        public int mnt_min { get; set; }
        public int mnt_max { get; set; }
        public int mnt_vig { get; set; }
    }

    public class Comuna{
        public string codComuna { get; set; }
        public string name { get; set; }
    }

    public class Ciudad{
        public string codCiudades { get; set; }
        public string name { get; set; }
    }
}