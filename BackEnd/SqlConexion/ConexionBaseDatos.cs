using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;

/// <summary>
/// Descripción breve de ConexionBaseDatos
/// </summary>
public class ConexionBaseDatos
{

    #region VARIABLES LOCALES

    private string _stringConexion = null;

    #endregion

    #region PROPIEDADES PRIVADAS

    private string StringConexion
    {
        get { return this._stringConexion; }
        set { this._stringConexion = value; }
    }

    #endregion

    #region CONSTRUCTORES

    /// <summary>
    /// Constructor básico para la clase, establece como String de conexión para la base de datos 
    /// SQL Server que se encuentra en el archivo web.config
    /// </summary>
    public ConexionBaseDatos()
	{
        StringConexion = ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString;
	}

    /// <summary>
    /// Constructor para la clase
    /// </summary>
    /// <param name="stringConexion">String de conexión para la base de datos SQL Server</param>
    public ConexionBaseDatos(string stringConexion)
    {
        StringConexion = stringConexion;
    }

    #endregion

    #region MÉTODOS PÚBLICOS

    /// <summary>
    /// Método para la ejecución de un procedimiento que contenga una sentencia Select (con retorno de valores)
    /// </summary>
    /// <param name="procedimiento">Nombre del procedimiento almacenado a ejecutar</param>
    /// <param name="nombreTabla">Nombre asignado a la tabla que devolverá el dataset</param>
    /// <param name="listaParametros">Lista con objetos de tipo Parametros</param>
    /// <returns>Dataset con los registros devueltos por el procedimiento almacenado</returns>
    public DataSet ObtenerRegistros(string procedimiento, string nombreTabla, List<Parametros> listaParametros)
    {
        BaseDatos BD = new BaseDatos(StringConexion);
        DataSet DS = null;

        DS = BD.ObtenerRegistros(procedimiento, nombreTabla, listaParametros);

        return DS;
    }

    public DataSet ObtenerRegistros(string procedimiento, string nombreTabla)
    {
        BaseDatos BD = new BaseDatos(StringConexion);
        DataSet DS = null;

        DS = BD.ObtenerRegistros(procedimiento, nombreTabla);

        return DS;
    }

    /// <summary>
    /// Método para la ejecución de un procedimiento que contenga una sentencia Insert o Update (sin retorno de valores)
    /// </summary>
    /// <param name="procedimiento">Nombre del procedimiento almacenado a ejecutar</param>
    /// <param name="listaParametros">Lista con objetos de tipo Parametros</param>
    public void EjecutarSentencia(string procedimiento, List<Parametros> listaParametros)
    {
        BaseDatos BD = new BaseDatos(StringConexion);

        BD.EjecutarSentencia(procedimiento, listaParametros);
    }

    #endregion

}