using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class RatingDL : IRatingDL
    {


        public async Task insert(Rating rating)
        {
            string query = "INSERT INTO RATING(HOST, METHOD, PATH, REFERER,USER_AGENT, Record_Date)" +
               "VALUES(@HOST, @METHOD, @PATH, @REFERER, @USER_AGENT, @Record_Date)";

            string connection = "Data Source=DESKTOP-0T014UV;Initial Catalog=Coffee Shop;Integrated Security=True";


            using (SqlConnection cn = new SqlConnection(connection))
            using (SqlCommand cmd = new SqlCommand(query, cn))
            {
                cmd.Parameters.Add("@HOST", SqlDbType.NVarChar, 50).Value = rating.Host;
                cmd.Parameters.Add("@METHOD", SqlDbType.NVarChar, 50).Value = rating.Method;
                cmd.Parameters.Add("@PATH", SqlDbType.NVarChar, 50).Value = rating.Path;
                cmd.Parameters.Add("@REFERER", SqlDbType.NVarChar, 50).Value = rating.Referer;
                cmd.Parameters.Add("@USER_AGENT", SqlDbType.NVarChar, 50).Value = rating.UserAgent;
                cmd.Parameters.Add("@Record_Date", SqlDbType.DateTime).Value = rating.RecordDate;
                cn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                cn.Close();            }
        }


    }
}
