using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace BDMapWeb
{
    public class SQLHelper
    {
        private static SqlConnection SqlConn;
        static SQLHelper()
        {
            if (SqlConn == null)
            {
                SqlConn = new SqlConnection();
                SqlConn.ConnectionString = System.Configuration.ConfigurationManager.AppSettings["SqlStr"].ToString();
            }
        }
        public static DataTable GetDataTable(string sql, SqlParameter[] parameters)
        {

            try
            {
                DataTable dt = new DataTable();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                if (parameters != null)
                {
                    sqlCmd.Parameters.AddRange(parameters);
                }
                sqlCmd.Connection = SqlConn;

                SqlDataAdapter da = new SqlDataAdapter(sqlCmd);
                da.Fill(dt);

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConn.Close();
            }
        }

        public static DataTable GetDataTable(string sql)
        {

            try
            {
                return GetDataTable(sql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConn.Close();
            }
        }

        public static int ExecSql(string sql)
        {
            try
            {
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                sqlCmd.Connection = SqlConn;
                int i = sqlCmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConn.Close();
            }
        }

        public static int ExecSql(string sql, SqlParameter[] parameters)
        {
            try
            {
                SqlConn.Open();
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandText = sql;
                if (parameters != null)
                {
                    sqlCmd.Parameters.AddRange(parameters);
                }
                sqlCmd.Connection = SqlConn;
                int i = sqlCmd.ExecuteNonQuery();
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlConn.Close();
            }
        }
    }
}