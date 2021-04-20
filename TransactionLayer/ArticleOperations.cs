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
    public class ArticleOperations
    {

        private SqlConnection con;
        //To Handle connection related activities
        private void connection()
        {
            string constr = ConfigurationManager.ConnectionStrings["connstring"].ToString();
            con = new SqlConnection(constr);

        }

        public int Save_Details(ArticleEntity cmm)
        {
            int res = 0;
            try
            {
             //   SqlDataReader dr;
                connection();
                SqlCommand com = new SqlCommand("iNSER_aRTICLEDETAILS", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FLAG", "2");
                com.Parameters.AddWithValue("@title", cmm.title);
                com.Parameters.AddWithValue("@subtitle", cmm.subTitle);
                com.Parameters.AddWithValue("@tags", cmm.tags);
                com.Parameters.AddWithValue("@description", cmm.articleDesc);
                com.Parameters.AddWithValue("@isdeleted", "1");
                com.Parameters.AddWithValue("@isactive", "1");
                con.Open();

                int i = com.ExecuteNonQuery();
             //   dr = com.ExecuteReader();
                con.Close();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public int Update_details(ArticleEntity cmm)
        {
            int result = 0;
            try
            {
              //  SqlDataReader dr;
                connection();
                SqlCommand com = new SqlCommand("iNSER_aRTICLEDETAILS", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FLAG", "3");
                com.Parameters.AddWithValue("@id", cmm.tid);
                com.Parameters.AddWithValue("@title", cmm.title);
                com.Parameters.AddWithValue("@subtitle", cmm.subTitle);
                com.Parameters.AddWithValue("@tags", cmm.tags);
                com.Parameters.AddWithValue("@description", cmm.articleDesc);
              
                con.Open();
                int i = com.ExecuteNonQuery();
               // dr = com.ExecuteReader();
                con.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public int Delete_details(ArticleEntity cmm)
        {
            int result = 0;
            try
            {
                connection();
                SqlCommand com = new SqlCommand("iNSER_aRTICLEDETAILS", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FLAG", "4");
                com.Parameters.AddWithValue("@id", cmm.tid);
             
                con.Open();
                int i = com.ExecuteNonQuery();
                // dr = com.ExecuteReader();
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return result;
        }


        public List<ArticleEntity> Select_Details()
        {
            List<ArticleEntity> select_list = new List<ArticleEntity>();
            try
            {

                SqlDataReader dr;
                connection();
                SqlCommand com = new SqlCommand("iNSER_aRTICLEDETAILS", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@FLAG", "1");
                con.Open();
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    ArticleEntity cdm = new ArticleEntity();
                    cdm.tid = Convert.ToInt32(dr["atlID"].ToString());
                    cdm.title = dr["title"].ToString();
                    cdm.subTitle = dr["subtitle"].ToString();
                    cdm.tags = dr["tags"].ToString();
                    cdm.articleDesc = dr["articleDiscription"].ToString();
                    select_list.Add(cdm);

                }
                con.Close();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return select_list;
        }
    }
}
