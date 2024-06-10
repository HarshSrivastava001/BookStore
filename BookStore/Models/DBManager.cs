using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class DBManager
    {
        public DataTable Crud(string sp, SqlParameter[] parameters)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            SqlCommand cmd = new SqlCommand(sp, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddRange(parameters);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            return dt;
        }
    }
}