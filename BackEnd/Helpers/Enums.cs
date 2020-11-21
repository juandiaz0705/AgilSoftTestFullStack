using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace Backend.Helpers
{
    public class Enums
    {
        public enum TiposDocumentos
        {
            DeclaracionResidenciaTributariaPersonaNatural = 1,
            DeclaracionResidenciaTributariaEntidadControladores = 2,
            DeclaracionJuradaEstructuraPropiedadParticipaciónBeneficiariosFinales = 3,
            // usar este para uaf ocasional IBFPEJ
            DeclaracionJuradaIdentificacionBeneficiariosFinalesPersonasEscrituras = 4

        }
            public enum Estado
        {
            Activo = 1,
            NoActivo = 2,
        }
    }
}