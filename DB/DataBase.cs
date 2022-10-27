using System;
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
        public static string GetData(ref string err)
        {
            StringBuilder sb = new StringBuilder();
            using (SqlConnection connection = DBase.DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.Connection = connection;
                string req = "SELECT * FROM aviondeaf";
                try
                {
                    command.CommandText = req;
                    SqlDataReader sqlDataReader = command.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        sb.Append($"{sqlDataReader.GetValue(0)} - {sqlDataReader.GetValue(1)}").AppendLine();
                    }
                    return sb.ToString();
                }
                catch (Exception ex)
                {
                    err = ex.ToString();
                    return sb.ToString();
                }
            }
        }
        public static void InsertData(ref string err)
        {
            using (SqlConnection connection = DBase.DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                string
                     req = $"INSERT INTO aviondeaf (immat,typeAvion, nbHVol)";
                     req += $"VALUES('CSI-3','csi3-avion',15)";

                try
                {
                    command.CommandText = req;
                    command.ExecuteNonQuery();

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);

                    // Attempt to roll back the transaction. 
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
            }
        }
        public static void UpdateData(ref string err)
        {
            using (SqlConnection connection = DBase.DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                var req = "UPDATE aviondeaf SET immat = 'CSI-Update1', typeAvion = 'typeAvion-Update' ";
                req += " WHERE nbHVol = 15";

                try
                {
                    command.CommandText = req;
                    command.ExecuteNonQuery();

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);

                    // Attempt to roll back the transaction. 
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
            }
        }
        public static void Delete(ref string err)
        {
            using (SqlConnection connection = DBase.DataBase.GetConnection())
            {
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction;

                // Start a local transaction.
                transaction = connection.BeginTransaction("SampleTransaction");

                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = connection;
                command.Transaction = transaction;

                var req = "DELETE FROM aviondeaf WHERE immat LIKE '%CSI%' ";
                try
                {
                    command.CommandText = req; 
                    command.ExecuteNonQuery();
                    command.CommandText = req;
                    command.ExecuteNonQuery();

                    // Attempt to commit the transaction.
                    transaction.Commit();
                    Console.WriteLine("Both records are written to database.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Commit Exception Type: {0}", ex.GetType());
                    Console.WriteLine("  Message: {0}", ex.Message);

                    // Attempt to roll back the transaction. 
                    try
                    {
                        transaction.Rollback();
                    }
                    catch (Exception ex2)
                    {
                        // This catch block will handle any errors that may have occurred 
                        // on the server that would cause the rollback to fail, such as 
                        // a closed connection.
                        Console.WriteLine("Rollback Exception Type: {0}", ex2.GetType());
                        Console.WriteLine("  Message: {0}", ex2.Message);
                    }
                }
            }
        }
    }
}
