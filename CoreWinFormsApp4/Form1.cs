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
        private DataBase dataBase;
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
            this.dataBase = new DataBase(ConfigurationManager.AppSettings["connectionString"]);
        }
        private void DisplayErrorMessageIfAny(string err) {
            if (err != "")
            {
                MessageBox.Show(err);
            }
            else {
                MessageBox.Show("Operation completed");
            }
        }
        private void btn_testConnection_Click(object sender, EventArgs e)
        {
            string err = string.Empty;
            try
            {
                dataBase.TestConnection(ref err);
                DisplayErrorMessageIfAny(err);
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
                var dataList = dataBase.GetDataList(ref err);
                StringBuilder sb = new StringBuilder();
                foreach (var item in dataList) {
                    sb.Append(item.ToString()).AppendLine();
                }
                MessageBox.Show(sb.ToString());
                DisplayErrorMessageIfAny(err);
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
                dataBase.InsertData(ref err);
                DisplayErrorMessageIfAny(err);
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
                dataBase.UpdateData(ref err);
                DisplayErrorMessageIfAny(err);
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
                dataBase.Delete(ref err);
                DisplayErrorMessageIfAny(err);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
