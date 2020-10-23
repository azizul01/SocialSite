using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Application.Models
{
    public class DataManager
    {
        public static SqlConnection cnConnection = new SqlConnection("Data Source=DESKTOP-410IC22\\SQLEXPRESS; Initial Catalog=SocialSiteDB; user id=sa; password=123");
        public static DataTable ExecuteQuery(string sQuery)
        {
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter myAdapter = new SqlDataAdapter(sQuery, cnConnection);
                myAdapter.Fill(dt);
            }
            catch
            {

            }

            return dt;
        }
        public static DataTable ExecuteQuerySqlCommand(SqlCommand cmd)
        {
            DataTable dt = new DataTable();
            try
            {
                cmd.Connection = cnConnection;
                cnConnection.Open();
                SqlDataAdapter myAdapter = new SqlDataAdapter(cmd);
                myAdapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                cnConnection.Close();
            }

            return dt;
        }
        public static void CloseOracleDB(SqlConnection MyOrclConn)
        {
            if (MyOrclConn.State == ConnectionState.Open)
            {
                MyOrclConn.Close();
                MyOrclConn.Dispose();
                MyOrclConn = null;
            }
        }
    }
    public class QUERY
    {
        public string SQL { get; set; }
        public Dictionary<string, string> PARAMETER { get; set; }
        public Dictionary<string, byte[]> BYTEPARAMETER { get; set; }
    }
}