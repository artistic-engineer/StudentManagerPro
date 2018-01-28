using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;

using System.Configuration;
using System.IO;

namespace DAL
{
    class SQLHelper
    {
        private static string connString = ConfigurationManager.ConnectionStrings["connString"].ToString();
        //Implement fixed type SQL
        public static int Update(string sql) {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex) {
                WriteLog("There are some exceptions when implementing Update method (Update):" + ex.Message);
                throw ex;
            }
            finally { conn.Close(); }
        }

        public static object GetSingleResult(string sql) {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try
            {
                conn.Open();
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                WriteLog("There are some exceptions when implementing Update method (GetSingleResult):" + ex.Message);
                throw ex;
            }
            finally { conn.Close(); }
        }

        public static SqlDataReader GetReader(string sql)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sql, conn);
            try {
                conn.Open();
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                WriteLog("There are some exceptions when implementing Update method (GetReader):" + ex.Message);
                throw ex;
            }
        }

        //Implement SQL with reference
        public static int Update(string sqlOrProcedureName,SqlParameter[] param,bool isProcedure)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlOrProcedureName, conn);
            if (isProcedure) {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                WriteLog("There are some exceptions when implementing Update method (Update Procedure):" + ex.Message);
                throw ex;
            }
            finally { conn.Close(); }
        }

        public static object GetSingleResult(string sqlOrProcedureName, SqlParameter[] param, bool isProcedure)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlOrProcedureName, conn);
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            } 
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                WriteLog("There are some exceptions when implementing Update method (GetSingleResult Procedure):" + ex.Message);
                throw ex;
            }
            finally { conn.Close(); }
        }

        public static SqlDataReader GetReader(string sqlOrProcedureName, SqlParameter[] param, bool isProcedure)
        {
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(sqlOrProcedureName, conn);
            if (isProcedure)
            {
                cmd.CommandType = CommandType.StoredProcedure;
            }
            try
            {
                conn.Open();
                cmd.Parameters.AddRange(param);
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                WriteLog("There are some exceptions when implementing Update method (GetReader Procedure):" + ex.Message);
                throw ex;
            }
        }

        //Write in log
        private static void WriteLog(string msg) {
            FileStream fs = new FileStream("project.log", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine(DateTime.Now.ToString()+" "+msg);
            sw.Close();
            fs.Close();
        }
    }
}
