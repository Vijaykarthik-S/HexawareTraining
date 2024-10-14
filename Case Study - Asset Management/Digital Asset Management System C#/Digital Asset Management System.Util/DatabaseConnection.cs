using System;
using System.Data.SqlClient;
using System.Configuration;

namespace DigitalAssetManagement.Util
{
    public static class DBUtil
    {
        readonly static SqlConnection sqlConnection;

        static DBUtil()
        {
            sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = ConfigurationManager.ConnectionStrings["MyDBConnection"].ConnectionString;
        }

        public static SqlConnection SqlConnection => sqlConnection;

        public static void CloseConnection()
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
                
            }
        }
    }
}
