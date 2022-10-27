using DBase.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DBase
{
    public static  class DataBase
    {
        private static string _connectionString = string.Empty;
        public static string ConnectionString {
            get => _connectionString;
            set => _connectionString = value;
        }
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
        public static void TestConnection(ref string err)
        {
            SqlConnection cnn = DBase.DataBase.GetConnection();
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
        public static List<AvionAF> GetDataList(ref string err)
        {
            StringBuilder sb = new StringBuilder();
            List<AvionAF> avionAFs = new List<AvionAF>();
            using (SqlConnection connection = DBase.DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;
                transaction = connection.BeginTransaction("SampleTransaction");
                command.Connection = connection;
                command.Transaction = transaction;

                string req = "SELECT * FROM aviondeaf";

                try
                {
                    command.CommandText = req;
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {                        
                        avionAFs.Add(GetAvnionAF(sqlDataReader));
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    err += ex.ToString();
                    // Attempt to roll back the transaction. 
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        err += ex2.ToString();
                    }
                }
                return avionAFs;
            }
        }
        private static AvionAF GetAvnionAF(SqlDataReader sqlDataReader) {
            var avionAF = new AvionAF();

            avionAF.Immat = sqlDataReader.GetValue(0).ToString();
            avionAF.TypeAvion = sqlDataReader.GetValue(1).ToString();
            if (sqlDataReader.GetValue(2) != DBNull.Value)
            {
                avionAF.NbHVol = (int)sqlDataReader.GetValue(2);
            }

            return avionAF;
        }
        public static void InsertData(ref string err)
        {
            using (SqlConnection connection = DBase.DataBase.GetConnection())
            {
                connection.Open();

                string
                   req = $"INSERT INTO aviondeaf (immat,typeAvion, nbHVol)";
                   req += $"VALUES('CSI-3','csi3-avion',15)";

                SqlCommand command = PrepareCommand(connection, req);

                try
                {
                    command.CommandText = req;
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
        public static void UpdateData(ref string err)
        {
            using (SqlConnection connection = DBase.DataBase.GetConnection())
            {
                connection.Open();

                var req = "UPDATE aviondeaf SET immat = 'CSI-Update1', typeAvion = 'typeAvion-Update' ";
                req += " WHERE nbHVol = 15";

                SqlCommand command = PrepareCommand(connection, req);

                try
                {
                    command.CommandText = req;
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
        public static void Delete(ref string err)
        {
            using (SqlConnection connection = DBase.DataBase.GetConnection())
            {
                connection.Open();

                var req = "DELETE FROM aviondeaf WHERE immat LIKE '%CSI%' ";

                SqlCommand command = PrepareCommand(connection, req);

                try
                {
                    command.CommandText = req;
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
        private static SqlCommand PrepareCommand(SqlConnection connection, string request)
        {
            SqlCommand command = connection.CreateCommand();
            SqlTransaction transaction;
            // Start a local transaction.
            transaction = connection.BeginTransaction("SampleTransaction");
            command.Connection = connection;
            command.Transaction = transaction;
            return command;
        }
    }
}
