using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WOKtch.Utilities
{
    public class DatabaseConnection
    {
        public static string conString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Database.mdf;Integrated Security=True";
        static SqlConnection con = new SqlConnection(conString);
        static SqlCommand cmd;

        public static DataTable ExecuteQuery(string query)
        {
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();

            cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);

            con.Close();
            return dt;
        }

        public static void ExecuteNonQuery(string query)
        {
            if (con.State == ConnectionState.Open) con.Close();
            con.Open();

            cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}