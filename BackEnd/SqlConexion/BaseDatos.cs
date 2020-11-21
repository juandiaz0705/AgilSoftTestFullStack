using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
    
public class BaseDatos
{
    #region VARIABLES PRIVADAS

    private string _stringConexion;
    private SqlConnection _conexionBD;

    #endregion

    #region PROPIEDADES PRIVADAS

    /// <summary>
    /// Propiedad que define el String de conexión a utilizar
    /// </summary>
    private string StringConexion
    {
        get { return this._stringConexion; }
        set { this._stringConexion = value; }
    }

    /// <summary>
    /// Propiedad que establece la conexión (real) con la base de datos
    /// </summary>
    private SqlConnection ConexionBD
    {
        get { return this._conexionBD; }
        set { this._conexionBD = value; }
    }

    #endregion

    #region CONSTRUCTORES

    /// <summary>
    /// Constructor de la clase de conexión y ejecución de sentencias para SQL Server
    /// </summary>
    /// <param name="stringConexion">String de conexión a la base de datos (SQL Server)</param>
    public BaseDatos(string stringConexion)
    {
        StringConexion = stringConexion;
        ConexionBD = new SqlConnection(StringConexion);
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
        DataSet DS = null;
        SqlDataAdapter DA = null;
        SqlParameter parametroBD = null;

        try
        {
            DA = new SqlDataAdapter(procedimiento, ConexionBD);
            DA.SelectCommand.CommandType = CommandType.StoredProcedure;

            if (listaParametros.Count != 0)
            {
                foreach (Parametros p in listaParametros)
                {
                    parametroBD = new SqlParameter();
                    parametroBD.Direction = p.Direccion;
                    parametroBD.ParameterName = p.Nombre;
                    parametroBD.SqlDbType = p.Tipo;
                    parametroBD.Value = p.Valor;

                    DA.SelectCommand.Parameters.Add(parametroBD);

                }
            }

            DS = new DataSet();
            DA.Fill(DS, nombreTabla);

            
        }
        finally
        {
            if (DA != null)
            {
                DA.Dispose();
            }
            if (DS != null)
            {
                DS.Dispose();
            }
            ConexionBD.Close();
        }

        return DS;
    }

    public DataSet ObtenerRegistros(string procedimiento, string nombreTabla)
    {
        DataSet DS = null;
        SqlDataAdapter DA = null;
        try
        {
            DA = new SqlDataAdapter(procedimiento, ConexionBD);
            DA.SelectCommand.CommandType = CommandType.StoredProcedure;

            DS = new DataSet();
            DA.Fill(DS, nombreTabla);


        }
        finally
        {
            if (DA != null)
            {
                DA.Dispose();
            }
            if (DS != null)
            {
                DS.Dispose();
            }
            ConexionBD.Close();
        }

        return DS;
    }

    /// <summary>
    /// Método para la ejecución de un procedimiento que contenga una sentencia Insert o Update (sin retorno de valores)
    /// </summary>
    /// <param name="procedimiento">Nombre del procedimiento almacenado a ejecutar</param>
    /// <param name="listaParametros">Lista con objetos de tipo Parametros</param>
    public void EjecutarSentencia(string procedimiento, List<Parametros> listaParametros)
    {
        int flag = 0;
        SqlCommand comando = null;
        SqlParameter parametroBD = null;
        SqlTransaction transaccion = null;

        try
        {
            ConexionBD.Open();

            comando = new SqlCommand(procedimiento, ConexionBD);
            comando.CommandType = CommandType.StoredProcedure;

            if (listaParametros.Count != 0)
            {
                foreach (Parametros p in listaParametros)
                {
                    parametroBD = new SqlParameter();
                    parametroBD.Direction = ParameterDirection.Input;
                    parametroBD.ParameterName = p.Nombre;
                    parametroBD.SqlDbType = p.Tipo;
                    parametroBD.Value = p.Valor;

                    comando.Parameters.Add(parametroBD);
                }
            }

            transaccion = ConexionBD.BeginTransaction(IsolationLevel.ReadCommitted);
            comando.Transaction = transaccion;

            comando.ExecuteNonQuery();
            comando.Transaction.Commit();
        }
        catch(SqlException exSql)
        {
            comando.Transaction.Rollback();
            throw exSql;
        }
        finally
        {
            ConexionBD.Close();
        }

    }


    #endregion
}
