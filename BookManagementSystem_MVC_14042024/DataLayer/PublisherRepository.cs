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

        public List<PublisherEntity> GetPublishers
        {
            get
            {
                List<PublisherEntity> list = new List<PublisherEntity>();
                try
                {
                    using (SqlConnection connection = new SqlConnection(CS))
                    {
                        SqlCommand cmd = new SqlCommand(SdProcedures.GetPublisher, connection);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        connection.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                list.Add(new PublisherEntity()
                                {
                                    PublisherId = Convert.ToInt32(reader["PublisherId"]),
                                    PublisherName = reader["PublisherName"].ToString(),
                                    RegistrationId = reader["RegNo"].ToString()
                                });
                            }
                        }
                        connection.Close();
                    }
                    return list;
                }
                catch (Exception)
                {
                    return null;
                }

            }
        }
        public PublisherEntity GetPublisher(int PublisherId)
        {
            try
            {
                PublisherEntity entity = null;
                using (SqlConnection connection = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(SdProcedures.GetPublisher, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PublisherId", PublisherId);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            entity = new PublisherEntity()
                            {
                                PublisherId = Convert.ToInt32(reader["PublisherId"]),
                                PublisherName = reader["PublisherName"].ToString(),
                                RegistrationId = reader["RegNo"].ToString()
                            };
                        }
                    }
                    connection.Close();
                    return entity;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public bool Save(PublisherEntity entity,out string StatusCode)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(CS))
                {
                    SqlCommand cmd = new SqlCommand(SdProcedures.AddPublisher, connection);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@RegNo", entity.RegistrationId);
                    cmd.Parameters.AddWithValue("@PublisherName", entity.PublisherName);
                    cmd.Parameters.AddWithValue("@PublisherId", entity.PublisherId);
                    connection.Open();
                    StatusCode = cmd.ExecuteScalar().ToString();
                    connection.Close();
                }
                return true;
            }
            catch (Exception)
            {
                StatusCode = string.Empty;
                return false;
            }
        }
    }
}