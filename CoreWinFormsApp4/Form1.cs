using DBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
        private string ConnectionString = string.Empty;
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
            ConnectionString = ConfigurationManager.AppSettings["connectionString"];
            DBase.DataBase.ConnectionString = ConnectionString;
        }

        private void btn_testConnection_Click(object sender, EventArgs e)
        {
            string err = string.Empty;
            try
            {
                DBase.DataBase.TestConnection(ref err);
                MessageBox.Show("Ok");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_getData_Click(object sender, EventArgs e)
        {
            string err = string.Empty;
            try
            {
                var data =DBase.DataBase.GetData(ref err);
                MessageBox.Show(data);
                MessageBox.Show("Ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_insertData_Click(object sender, EventArgs e)
        {
            string err = string.Empty;
            try
            {
                DBase.DataBase.InsertData(ref err);
                MessageBox.Show("Ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_updateData_Click(object sender, EventArgs e)
        {
            string err = string.Empty;
            try
            {
                DBase.DataBase.UpdateData(ref err);
                MessageBox.Show("Ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string err = string.Empty;
            try
            {
                DBase.DataBase.Delete(ref err);
                MessageBox.Show("Ok");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
