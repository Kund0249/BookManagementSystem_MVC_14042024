using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookManagementSystem_MVC_14042024.DataLayer.DataEntity;
using BookManagementSystem_MVC_14042024.Utility;
using System.Data.SqlClient;
using System.Configuration;

namespace BookManagementSystem_MVC_14042024.DataLayer
{
    public class PublisherRepository
    {
        string CS = string.Empty;
        public PublisherRepository()
        {
            CS = ConfigurationManager.ConnectionStrings["DbCon"].ConnectionString;
        }
        public bool Save(PublisherEntity entity)
        {
            try
            {
                using(SqlConnection connection = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(SdProcedures.AddPublisher, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RegNo", entity.RegistrationId);
                    cmd.Parameters.AddWithValue("@PublisherName", entity.PublisherName);

                    connection.Open();
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}