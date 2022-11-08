using DBase.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DBase
{
    public class DataBase : IDataBase
    {
        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }
        public DataBase(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public void TestConnection(ref string err)
        {
            SqlConnection cnn = this.GetConnection();
            try
            {
                cnn.Open();
            }
            catch (Exception ex)
            {
                err = ex.ToString();
                throw new Exception(err);
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }
        }
        public List<AvionAF> GetDataList(ref string err)
        {
            StringBuilder sb = new StringBuilder();
            List<AvionAF> avionAFs = new List<AvionAF>();

            using (SqlConnection connection = GetConnection())
            {
                connection.Open();

                string req = "SELECT * FROM aviondeaf";

                SqlCommand command = new SqlCommand(req, connection);
                //Transaction
                command.Transaction = connection.BeginTransaction("SampleTransaction"); ;

                try
                {
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        avionAFs.Add(GetAvnionAF(sqlDataReader));
                    }
                    command.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    err += ex.ToString();
                    // Attempt to roll back the transaction. 
                    try
                    {
                        command.Transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        err += ex2.ToString();
                    }
                }
                return avionAFs;
            }
        }
        private AvionAF GetAvnionAF(SqlDataReader sqlDataReader)
        {
            var avionAF = new AvionAF();

            avionAF.Immat = sqlDataReader.GetValue(0).ToString();
            avionAF.TypeAvion = sqlDataReader.GetValue(1).ToString();
            if (sqlDataReader.GetValue(2) != DBNull.Value)
            {
                avionAF.NbHVol = (int)sqlDataReader.GetValue(2);
            }

            return avionAF;
        }
        public void InsertData(ref string err)
        {
            using (SqlConnection connection = GetConnection())
            {
                connection.Open();
                
                string
                   req2 = $"INSERT INTO aviondeaf (immat,typeAvion, nbHVol)" +
                          $"VALUES(@immat,@typeAvion,@heuresDeVol)";

                SqlCommand command = new SqlCommand(req2, connection);
                //Transaction
                command.Transaction = connection.BeginTransaction();
                //Params
                command.Parameters.AddWithValue("@immat", "CSI-3");
                command.Parameters.AddWithValue("@typeAvion", "csi3-avion");
                command.Parameters.AddWithValue("@heuresDeVol", 15);

                try
                {
                    command.ExecuteNonQuery();
                    command.Transaction.Commit();//ok
                }
                catch (Exception ex)
                {
                    err = $"Commit Exception {ex.ToString()}";
                    try
                    {
                        command.Transaction.Rollback();//ko
                    }
                    catch (Exception ex2)
                    {
                        err = $"Rollback Exception {ex2.ToString()}";//ko ko
                    }
                }
            }
        }
        public void UpdateData(ref string err)
        {
            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();

                var req = " UPDATE aviondeaf SET immat = @immat, typeAvion = @typeAvion ";
                   req += " WHERE nbHVol = @nombreHVol";

                SqlCommand command = new SqlCommand(req,connection);
                //Transaction
                command.Transaction = connection.BeginTransaction();
                //Param
                command.Parameters.AddWithValue("@immat", "CSI-Update1");
                command.Parameters.AddWithValue("@typeAvion", "typeAvion-Update");
                command.Parameters.AddWithValue("@nombreHVol", "15");

                try
                {
                    command.ExecuteNonQuery();
                    command.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    err = $"Commit Exception {ex.ToString()}";
                    try
                    {
                        command.Transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        err = $"Rollback Exception {ex2.ToString()}";
                    }
                }
            }
        }
        public void Delete(ref string err)
        {
            using (SqlConnection connection = this.GetConnection())
            {
                connection.Open();

                var req = "DELETE FROM aviondeaf WHERE immat LIKE @immat ";

                SqlCommand command = new SqlCommand(req, connection);
                //Transaction
                command.Transaction = connection.BeginTransaction();
                //Params
                command.Parameters.AddWithValue("@immat", "%CSI%");

                try
                {
                    command.ExecuteNonQuery();
                    command.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    err = $"Commit Exception {ex.ToString()}";
                    try
                    {
                        command.Transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        err = $"Rollback Exception {ex2.ToString()}";
                    }
                }
            }
        }
    }
}
