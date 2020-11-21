using System;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Backend.Models;
using Backend.Helpers;
using System.Collections.Generic;

namespace Backend.Models
{
    public class DBOServicios
    {
        private DBOConexion con = new DBOConexion();
        private SqlCommand _cmd;
        private DataTable _dt = new DataTable();

        public DataTable SpQuery(string nombreServicio) {
            _cmd = new SqlCommand(nombreServicio, con._Con);
            _cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con._Con.Open();
                _dt.Load(_cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            {
                con._Con.Close();
            }

            return _dt;
        }
        public List<DataTable> SpQueryMultiple(string nombreServicio)
        {
            List<DataTable> dtList = new List<DataTable>();
            
            _cmd = new SqlCommand(nombreServicio, con._Con);
            _cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                con._Con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(_cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    dtList.Add(ds.Tables[i]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con._Con.Close();
            }

            return dtList;
        }
        public List<DataTable> SpQueryMultiple(string nombreServicio, DataTable parametros)
        {
            List<DataTable> dtList = new List<DataTable>();
            _cmd = new SqlCommand(nombreServicio, con._Con);
            _cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (DataRow row in parametros.Rows)
                {
                    _cmd.Parameters.AddWithValue(row["Nombre"].ToString(), row["Valor"].ToString());
                }
                con._Con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(_cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                for (int i = 0; i < ds.Tables.Count; i++)
                {
                    dtList.Add(ds.Tables[i]);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con._Con.Close();
            }

            return dtList;
        }
        public DataTable SpQuery(string nombreServicio, DataTable parametros)
        {
            _cmd = new SqlCommand(nombreServicio, con._Con);
            _cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (DataRow row in parametros.Rows)
                {
                    _cmd.Parameters.AddWithValue(row["Nombre"].ToString(), row["Valor"].ToString());
                }
                con._Con.Open();
                _dt.Load(_cmd.ExecuteReader());
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con._Con.Close();
            }

            return _dt;
        }
        public void EjecutarSp(string nombreServicio, DataTable parametros)
        {
            _cmd = new SqlCommand(nombreServicio, con._Con);
            _cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                foreach (DataRow row in parametros.Rows)
                {
                    _cmd.Parameters.AddWithValue(row["Nombre"].ToString(), row["Valor"].ToString());
                }
                con._Con.Open();
                _cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con._Con.Close();
            }

        }
    }
}