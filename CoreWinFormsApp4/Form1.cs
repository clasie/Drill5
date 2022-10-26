using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreWinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var logingUI = new LoginUI();
            logingUI.ShowDialog();
            if (!logingUI.IsLogged)
            {
                Application.Exit();
            }
        }

        private void btn_testConnection_Click(object sender, EventArgs e)
        {
            SqlConnection cnn = getConnection();
            try
            {
                cnn.Open();
                MessageBox.Show("Conn ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally {
                if (cnn != null) {
                    cnn.Close();
                }
            }
        }
        private void btn_getData_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = getConnection();
            try
            {
                sqlConnection.Open();
                var request = "SELECT * FROM aviondeaf";
                SqlCommand sqlCommand = new SqlCommand(request, sqlConnection);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                StringBuilder sb = new StringBuilder();
                while (sqlDataReader.Read())
                {
                    sb.Append($"{sqlDataReader.GetValue(0)} - {sqlDataReader.GetValue(1)}").AppendLine();
                }
                MessageBox.Show(sb.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }
        private void btn_insertData_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = getConnection();
            try
            {
                sqlConnection.Open();
                string 
                    req = $"INSERT INTO aviondeaf (immat,typeAvion, nbHVol)";
                    req += $"VALUES('CSI-3','csi3-avion',15)";

                SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                sqlDataAdapter.InsertCommand = sqlCommand;
                sqlDataAdapter.InsertCommand.ExecuteNonQuery();

                sqlCommand.Dispose();
                MessageBox.Show("InsertAjouté");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }
            }
        }
        private void btn_updateData_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = getConnection();
            try
            {
                sqlConnection.Open();
                var req  = "UPDATE aviondeaf SET immat = 'CSI-Update1', typeAvion = 'typeAvion-Update' ";
                req += " WHERE nbHVol = 13";
                SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                sqlDataAdapter.UpdateCommand = sqlCommand;
                sqlDataAdapter.UpdateCommand.ExecuteNonQuery();
                sqlCommand.Dispose();

                MessageBox.Show("Update ok");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
            finally {
                if (sqlConnection != null) {
                    sqlConnection.Close();
                }
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = getConnection();
            try
            {
                sqlConnection.Open();
                sqlConnection.BeginTransaction();
                var transaction = sqlConnection.BeginTransaction();
                transaction.Commit();
                transaction.Rollback();
                var req = "DELETE FROM aviondeaf WHERE immat LIKE '%CSI%' ";
                SqlCommand sqlCommand = new SqlCommand(req, sqlConnection);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.DeleteCommand = sqlCommand;
                sqlDataAdapter.DeleteCommand.ExecuteNonQuery();
                sqlCommand.Dispose();
                MessageBox.Show("Ok delete");
            }
            catch (Exception ex)
            {
                MessageBox.Show(e.ToString());
            }
            finally {
                if (sqlConnection != null) {
                    sqlConnection.Close();
                }
            }
        }
        //Utils
        private SqlConnection getConnection()
        {
            var connString = "Server=PC1224;DataBase=Aviation;Trusted_Connection=True";
            SqlConnection cnn = new SqlConnection(connString);
            return cnn;
        }


    }
}
