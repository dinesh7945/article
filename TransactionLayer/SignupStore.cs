using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessLayer;
using System.Configuration;

namespace TransactionLayer
{
   public class SignupStore
    {
        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            con = new SqlConnection(constr);

        }

        public int Save_User_Details(SignUpEntity cmm)
        {
            int res = 0;
            try
            {
             //   SqlDataReader dr;
                connection();
                SqlCommand com = new SqlCommand("iNSER_aRTICLEDETAILS", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FLAG", "6");
                com.Parameters.AddWithValue("@username", cmm.username);
                com.Parameters.AddWithValue("@email", cmm.email);
                com.Parameters.AddWithValue("@password", cmm.password);
                com.Parameters.AddWithValue("@isdeleted", "1");
                com.Parameters.AddWithValue("@isactive", "1");
                con.Open();
                int i = com.ExecuteNonQuery();
               // dr = com.ExecuteReader();
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public List<SignUpEntity> GetUserLogin(SignUpEntity loginModel)
        {
            List<SignUpEntity> UserDetails = new List<SignUpEntity>();
            try
            {
                SqlDataReader dr;
                connection();
                SqlCommand com = new SqlCommand("iNSER_aRTICLEDETAILS", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FLAG", "5");
                com.Parameters.AddWithValue("@email", loginModel.email);
                com.Parameters.AddWithValue("@password ", loginModel.password);
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    SignUpEntity cdm = new SignUpEntity();
                    cdm.email = dr["email"].ToString();
                    cdm.password = dr["password"].ToString();
                    
                    UserDetails.Add(cdm);

                }
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return UserDetails;
        }
    }
}
