using System.Collections.Generic;
using System.Data;

namespace ConexionSqlServer
{
    public class Procedimientos
    {
        #region VARIABLES LOCALES

        private ConexionBaseDatos _con = null;
        private DataSet _DS = null;

        #endregion

        #region PROPIEDADES PRIVADAS
        /// <summary>
        /// Propiedad para llamar al objeto que ejecuta la conexión con la base de datos
        /// </summary>
        private ConexionBaseDatos Con
        {
            get { return this._con; }
            set { this._con = value; }
        }

        private DataSet DS
        {
            get { return this._DS; }
            set { this._DS = value; }
        }

        #endregion

        #region CONSTRUCTORES

        public Procedimientos()
        {
            Con = new ConexionBaseDatos();
        }
        #endregion

       
    //    public void GuardarInter(DtoInterDte dto)
    //    {
    //        string procedimiento = "interDTE_guardar_datos";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@Accion", SqlDbType.VarChar, dto.Accion));
    //        listaParametros.Add(new Parametros("@Enviado_SII", SqlDbType.DateTime, dto.Enviado_SII));
    //        listaParametros.Add(new Parametros("@Fecha", SqlDbType.DateTime, dto.Fecha));
    //        listaParametros.Add(new Parametros("@Folio_doc", SqlDbType.Int, dto.Folio_Doc));
    //        listaParametros.Add(new Parametros("@Generado", SqlDbType.Bit, dto.Generado));
    //        listaParametros.Add(new Parametros("@Hora", SqlDbType.DateTime, dto.Hora));
    //        listaParametros.Add(new Parametros("@Id_terminal", SqlDbType.VarChar, dto.Id_Terminal));
    //        listaParametros.Add(new Parametros("@Id_usuario", SqlDbType.VarChar, dto.Id_Usuario));
    //        listaParametros.Add(new Parametros("@Url_Pdf", SqlDbType.VarChar, dto.Url_PDF));
    //        listaParametros.Add(new Parametros("@Tipo_doc", SqlDbType.VarChar, dto.Tipo_Doc));
    //        listaParametros.Add(new Parametros("@Observaciones", SqlDbType.VarChar, dto.Observaciones));
    //        //listaParametros.Add(new Parametros("@Validado_sii", SqlDbType.DateTime, dto.Validado_SII));

    //        Con.EjecutarSentencia(procedimiento, listaParametros);          
    //    }


    //    public void GuardarLinfman(Dto_Linfman dto)
    //    {
    //        const string procedimiento = "linfman_guardar_datos";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@Origen", SqlDbType.Char, dto.Origen));
    //        listaParametros.Add(new Parametros("@Lf_serial", SqlDbType.Int, dto.Serial));
    //        listaParametros.Add(new Parametros("@Tipo_doc", SqlDbType.Char, dto.TipoDoc));
    //        listaParametros.Add(new Parametros("@Cod_factura", SqlDbType.Int, dto.CodFactura));
    //        listaParametros.Add(new Parametros("@Prvl_grp_ing", SqlDbType.Char, dto.GrupoIngreso));
    //        listaParametros.Add(new Parametros("@Prvl_cdg", SqlDbType.Char, dto.CodPresta));
    //        listaParametros.Add(new Parametros("@Arnc_clase", SqlDbType.Char, dto.Clase));
    //        listaParametros.Add(new Parametros("@Detalle", SqlDbType.Char, dto.Detalle));
    //        listaParametros.Add(new Parametros("@Cantidad", SqlDbType.Int, dto.Cantidad));
    //        listaParametros.Add(new Parametros("@Valor_uni", SqlDbType.Decimal, dto.ValorUnidad));
    //        listaParametros.Add(new Parametros("@Valor_linea", SqlDbType.Decimal, dto.ValorLinea));
    //        listaParametros.Add(new Parametros("@Prvl_cta_ing", SqlDbType.Char, dto.CuentaIngreso));
    //        listaParametros.Add(new Parametros("@Prvl_centro_ing", SqlDbType.Char, dto.CentroIngreso));
    //        listaParametros.Add(new Parametros("@Prsg_serial", SqlDbType.Int, dto.PrsgSerial));
    //        listaParametros.Add(new Parametros("@Prvl_cdg_hom", SqlDbType.Char, dto.CodPresHom));

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void GuardarBoleta(Dto_Boleta dto)
    //    {
    //        string procedimiento = "boleta_guardar_datos";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@Serial_comrec", SqlDbType.Int, dto.Serial));
    //        listaParametros.Add(new Parametros("@Ent_codente", SqlDbType.Decimal, dto.Empresa));
    //        listaParametros.Add(new Parametros("@Cod_oficina", SqlDbType.Int, dto.CodOficina));
    //        listaParametros.Add(new Parametros("@Cod_caja", SqlDbType.Int, dto.CodCaja));
    //        listaParametros.Add(new Parametros("@Cmrc_folio", SqlDbType.Int, dto.Folio));
    //        listaParametros.Add(new Parametros("@Cta_ingoper", SqlDbType.Char, dto.CtaIngoper));
    //        listaParametros.Add(new Parametros("@Cmrc_fecemi", SqlDbType.DateTime, dto.FechaEmision));
    //        listaParametros.Add(new Parametros("@Cmrc_rutcli", SqlDbType.Int, dto.RutCliente));
    //        listaParametros.Add(new Parametros("@Cmrc_dvcli", SqlDbType.Char, dto.DVCliente));
    //        listaParametros.Add(new Parametros("@Pf_grupo", SqlDbType.Char, dto.Grupo));
    //        listaParametros.Add(new Parametros("@Per_conta", SqlDbType.DateTime, dto.PeriodoCtb));
    //        listaParametros.Add(new Parametros("@Comp_ctble", SqlDbType.Char, dto.CompromisoCtb));
    //        listaParametros.Add(new Parametros("@Cmrc_valor", SqlDbType.Decimal, dto.Valor));
    //        listaParametros.Add(new Parametros("@Sw_estado", SqlDbType.Char, dto.Estado));
    //        listaParametros.Add(new Parametros("@Boleta", SqlDbType.Int, dto.Boleta));

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void AnularBoleta(Dto_Boleta dto)
    //    {
    //        string procedimiento = "boleta_anular";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@CodFactura", SqlDbType.Int, dto.Serial));
    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio));
    //        listaParametros.Add(new Parametros("@Estado", SqlDbType.Char, dto.Estado));

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void BorrarBoleta(Dto_Boleta dto)
    //    {
    //        string procedimiento = "boleta_borrar";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@CodFactura", SqlDbType.Int, dto.Serial));
    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio));            

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void GuardarFactura(Dto_Factura dto)
    //    {
    //        string procedimiento = "factura_guardar_datos";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@Cod_factura", SqlDbType.Int, dto.CodigoFactura));
    //        listaParametros.Add(new Parametros("@Ent_codente", SqlDbType.Decimal, dto.Empresa));
    //        listaParametros.Add(new Parametros("@Rutfac", SqlDbType.Int, dto.RutFactura));
    //        listaParametros.Add(new Parametros("@Dvfac", SqlDbType.Char, dto.DVFactura));
    //        listaParametros.Add(new Parametros("@Tipo_doc", SqlDbType.Char, dto.TipoDoc));
    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio));
    //        listaParametros.Add(new Parametros("@Fecemi", SqlDbType.DateTime, dto.FechaEmision));
    //        listaParametros.Add(new Parametros("@Fecven", SqlDbType.DateTime, dto.FechaVencimiento));
    //        listaParametros.Add(new Parametros("@Sw_estado", SqlDbType.Char, dto.Estado));
    //        listaParametros.Add(new Parametros("@Generada", SqlDbType.Char, dto.Generada));
    //        listaParametros.Add(new Parametros("@Valor_neto", SqlDbType.Decimal, dto.ValorNeto));
    //        listaParametros.Add(new Parametros("@Valor_exento", SqlDbType.Decimal, dto.ValorExento));
    //        listaParametros.Add(new Parametros("@Valor_iva", SqlDbType.Decimal, dto.ValorIva));
    //        listaParametros.Add(new Parametros("@Valor_descto", SqlDbType.Decimal, dto.ValorDescuento));
    //        listaParametros.Add(new Parametros("@Valor_despacho", SqlDbType.Decimal, dto.ValorDespacho));
    //        listaParametros.Add(new Parametros("@Valor_factura", SqlDbType.Decimal, dto.ValorFac));
    //        listaParametros.Add(new Parametros("@Valor_netof", SqlDbType.Decimal, dto.ValorNetoFac));
    //        listaParametros.Add(new Parametros("@Codi_caus", SqlDbType.Int, dto.CodCaus));
    //        listaParametros.Add(new Parametros("@Pf_grupo", SqlDbType.Char, dto.Grupo));
    //        listaParametros.Add(new Parametros("@Cta_ingoper", SqlDbType.Char, dto.CtaIngoper));
    //        listaParametros.Add(new Parametros("@Per_conta", SqlDbType.DateTime, dto.PerConta));
    //        listaParametros.Add(new Parametros("@Fec_conta", SqlDbType.DateTime, dto.FecConta));
    //        listaParametros.Add(new Parametros("@Com_identif", SqlDbType.Char, dto.Comident));
    //        listaParametros.Add(new Parametros("@Rut_esp", SqlDbType.Char, dto.RutEsp));
    //        listaParametros.Add(new Parametros("@Tiprel_doc", SqlDbType.Char, dto.TipoRelDoc));
    //        listaParametros.Add(new Parametros("@Folrel_doc", SqlDbType.Char, dto.FolRelDoc));
    //        listaParametros.Add(new Parametros("@O_compra", SqlDbType.Char, dto.Ocompra));
    //        listaParametros.Add(new Parametros("@Pf_impto", SqlDbType.Char, dto.PfImpto));
    //        listaParametros.Add(new Parametros("@Id_ext", SqlDbType.Char, dto.IdExt));
    //        listaParametros.Add(new Parametros("@Ref_int", SqlDbType.Char, dto.RefInt));

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void AnularFactura(Dto_Factura dto)
    //    {
    //        string procedimiento = "Factura_anular";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@CodFactura", SqlDbType.Int, dto.CodigoFactura));
    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio));
    //        listaParametros.Add(new Parametros("@Estado", SqlDbType.Char, dto.Estado));
    //        listaParametros.Add(new Parametros("@TipoDoc", SqlDbType.Char, dto.TipoDoc));

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void BorrarFactura(Dto_Factura dto)
    //    {
    //        string procedimiento = "factura_borrar";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@CodFactura", SqlDbType.Int, dto.CodigoFactura));
    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio));
    //        listaParametros.Add(new Parametros("@TipoDoc", SqlDbType.Char, dto.TipoDoc));

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void GuardarGuia(Dto_Guia dto)
    //    {
    //        string procedimiento = "guia_guardar_datos";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@Ent_codente", SqlDbType.Decimal, dto.Empresa));
    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio));
    //        listaParametros.Add(new Parametros("@Rutfac", SqlDbType.Int, dto.RutFactura));
    //        listaParametros.Add(new Parametros("@Dvfac", SqlDbType.Char, dto.DvFactura));
    //        listaParametros.Add(new Parametros("@Fecemi", SqlDbType.DateTime, dto.FecEmision));
    //        listaParametros.Add(new Parametros("@Fecven", SqlDbType.DateTime, dto.FecVencimiento));
    //        listaParametros.Add(new Parametros("@Sw_estado", SqlDbType.Char, dto.Estado));
    //        listaParametros.Add(new Parametros("@Valor_neto", SqlDbType.Decimal, dto.ValorNeto));
    //        listaParametros.Add(new Parametros("@Pf_grupo", SqlDbType.Char, dto.Grupo));
    //        listaParametros.Add(new Parametros("@Cta_ingoper", SqlDbType.Char, dto.CtaIngoper));
    //        listaParametros.Add(new Parametros("@Per_conta", SqlDbType.DateTime, dto.PeriodoContable));
    //        listaParametros.Add(new Parametros("@Cod_factura", SqlDbType.Int, dto.CodigoFactura));
    //        listaParametros.Add(new Parametros("@Despachar1", SqlDbType.Char, dto.Despachar1));
    //        listaParametros.Add(new Parametros("@Despachar2", SqlDbType.Char, dto.Despachar2));            

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void GuardarGuiaDet(Dto_GuiaDet dto)
    //    {
    //        string procedimiento = "guiadet_guardar_datos";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@Ent_codente", SqlDbType.Int, dto.Empresa));
    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio));
    //        listaParametros.Add(new Parametros("@Prvl_grp_ing", SqlDbType.Char, dto.PrvlCgdIng));
    //        listaParametros.Add(new Parametros("@Prvl_cdg", SqlDbType.Char, dto.PrvlCgd));
    //        listaParametros.Add(new Parametros("@Arnc_clase", SqlDbType.Char, dto.Clase));
    //        listaParametros.Add(new Parametros("@Detalle", SqlDbType.Char, dto.Detalle));
    //        listaParametros.Add(new Parametros("@Cantidad", SqlDbType.Int, dto.Cantidad));
    //        listaParametros.Add(new Parametros("@Valor_uni", SqlDbType.Decimal, dto.ValorUni));
    //        listaParametros.Add(new Parametros("@Valor_linea", SqlDbType.Decimal, dto.ValorLinea));
    //        listaParametros.Add(new Parametros("@Prvl_cta_ing", SqlDbType.Char, dto.CtaIngreso));
    //        listaParametros.Add(new Parametros("@Prvl_centro_ing", SqlDbType.Char, dto.CtroIngreso));
    //        listaParametros.Add(new Parametros("@Prsg_serial", SqlDbType.Int, dto.Serial)); 

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void AnularGuia(Dto_Guia dto)
    //    {
    //        string procedimiento = "guia_anular";
    //        List<Parametros> listaParametros = new List<Parametros>();
            
    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio));
    //        listaParametros.Add(new Parametros("@Estado", SqlDbType.Char, dto.Estado));

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public void BorrarGuia(Dto_Guia dto)
    //    {
    //        string procedimiento = "guia_borrar";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio));            

    //        Con.EjecutarSentencia(procedimiento, listaParametros);
    //    }

    //    public DataSet BuscarReservado(DtoInterDte dto)
    //    {
    //        string procedimiento = "Reserva_BuscarFolio";
    //        List<Parametros> listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, dto.Folio_Doc));
    //        listaParametros.Add(new Parametros("@TipoDoc", SqlDbType.VarChar, dto.Tipo_Doc));

    //        DS = Con.ObtenerRegistros(procedimiento,"reserva", listaParametros);

    //        return DS;
    //    }

    //    public DataSet BuscarInterDte(string tipoDoc, int folio)
    //    {
    //        const string procedimiento = "inter_DTE_BuscarPorTipoDoc";
    //        var listaParametros = new List<Parametros>();

    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.Int, folio));
    //        listaParametros.Add(new Parametros("@TipoDoc", SqlDbType.VarChar, tipoDoc));

    //        DS = Con.ObtenerRegistros(procedimiento, "inter_DTE", listaParametros);

    //        return DS;
    //    }

    //    public void GuardarReservaBoleta(DtoInterDte dto)
    //    {
    //        const string procedimiento = "Reserva_GuardarBoleta";
    //        List<Parametros> listaParametros = new List<Parametros>();
    //        listaParametros.Add(new Parametros("@Folio", SqlDbType.VarChar, dto.Folio_Doc));
    //        listaParametros.Add(new Parametros("@Fecha", SqlDbType.DateTime, dto.Fecha));
    //        listaParametros.Add(new Parametros("@Usuario", SqlDbType.VarChar, dto.Id_Usuario));
    //        listaParametros.Add(new Parametros("@Terminal", SqlDbType.VarChar, dto.Id_Terminal));
    //        listaParametros.Add(new Parametros("@NombreUsu", SqlDbType.VarChar, dto.NombreUsuario));
            
    //       Con.EjecutarSentencia(procedimiento,listaParametros);
    //    }
    }
}
