using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace Backend.Models
{

    public class Parametro
    {
        private DataTable parametro;

        public Parametro() {
            parametro = new DataTable();
            parametro.Columns.Add("Nombre");
            parametro.Columns.Add("Valor");
        }

        public void AgregarParametro(string nombre, string valor) {
            parametro.Rows.Add(nombre, valor);
        }

        public DataTable ObtenerParametro() {
            return parametro;
        }
    }

}