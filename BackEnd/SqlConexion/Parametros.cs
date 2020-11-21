using System;
using System.Data;

public class Parametros
{
    #region VARIABLES PRIVADAS

    private ParameterDirection  _direccion;
    private string _nombre;
    private SqlDbType _tipo;
    private object _valor;

    #endregion

    #region CONSTRUCTORES

    /// <summary>
    /// Constructor para el objeto parámetro, por defecto toma la dirección como Input y el tipo de dato como VarChar
    /// </summary>
    /// <param name="nombre">Nombre del parámetro en la base de datos</param>
    /// <param name="valor">Valor que se le quiere asignar al parámetro</param>
    public Parametros(string nombre, object valor)
    {
        Direccion = ParameterDirection.Input;
        Nombre = nombre;
        Tipo = SqlDbType.VarChar;
        Valor = valor;
    }

    /// <summary>
    /// Constructor para el objeto parámetro, por defecto toma la dirección como Input
    /// </summary>
    /// <param name="nombre">Nombre del parámetro en la base de datos</param>
    /// <param name="tipo">Tipo de dato del parámetro en la base de datos</param>
    /// <param name="valor">Valor que se le quiere asignar al parámetro</param>
    public Parametros(string nombre, SqlDbType tipo, object valor)
    {
        Direccion = ParameterDirection.Input;
        Nombre = nombre;
        Tipo = tipo;
        Valor = valor;
    }

    /// <summary>
    /// Constructor para el objeto parámetro, deben ingresarse todos los campos.
    /// Usarse sólo cuando está definida la dirección en los campos del procedimiento almacenado
    /// </summary>
    /// <param name="direccion">Dirección del parámetro en la base de datos</param>
    /// <param name="nombre">Nombre del parámetro en la base de datos</param>
    /// <param name="tipo">Tipo de dato del parámetro en la base de datos</param>
    /// <param name="valor">Valor que se le quiere asignar al parámetro</param>
    public Parametros(ParameterDirection direccion, string nombre, SqlDbType tipo, object valor)
    {
        Direccion = direccion;
        Nombre = nombre;
        Tipo = tipo;
        Valor = valor;
    }

    #endregion

    #region PROPIEDADES PÚBLICAS

    /// <summary>
    /// Propiedad para la dirección (entrada o salida) del parámetro ingresado
    /// </summary>
    public ParameterDirection Direccion
    {
        get { return this._direccion; }
        set { this._direccion = value; }
    }

    /// <summary>
    /// Propiedad para el nombre del parámetro ingresado
    /// </summary>
    public string Nombre
    {
        get { return this._nombre; }
        set { this._nombre = value; }
    }

    /// <summary>
    /// Propiedad para el tipo de dato (de la base de datos) del parámetro ingresado
    /// </summary>
    public SqlDbType Tipo
    {
        get { return this._tipo; }
        set { this._tipo = value; }
    }

    /// <summary>
    /// Propiedad para el valor (como objeto) del parámetro ingresado
    /// </summary>
    public object Valor
    {
        get { return this._valor; }
        set { this._valor = value; }
    }

    #endregion
}
