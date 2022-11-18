using Autofac;
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
    /// <summary>
    /// On va utiliser Form -> qui va utiliser Business -> qui va utiliser DataBase.
    /// On va se servir des injections Autofac pour cela.
    /// </summary>
    public partial class Form1 : Form
    {
        private string ConnectionString = string.Empty;
        private IBusinesLogic businesLogic;
        public Form1()
        {
            InitializeComponent();

            //Prep injection dependence
            var container = ContainerConfig.Configure();
            using (var scope = container.BeginLifetimeScope()) {
                businesLogic = scope.Resolve<IBusinesLogic>();
            }
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
                businesLogic.TestConnection(ref err);
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
                var dataList = businesLogic.GetDataList(ref err);
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
                businesLogic.InsertData(ref err);
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
                businesLogic.UpdateData(ref err);
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
                businesLogic.Delete(ref err);
                DisplayErrorMessageIfAny(err);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btn_CallDirectSyncAndReturn_Click(object sender, EventArgs e)
        {
            tbx_log.Text = "btn_CallDirectSyncAndReturn_Click";
            var result = businesLogic.GetHugeLoad();
            tbx_log.Text += result.Result;
        }

        /// <summary>
        /// Indirect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_CallDirectAsyncAndReturn_Click(object sender, EventArgs e)
        {
            tbx_log.Text = "btn_CallDirectAsyncAndReturn_Click";
            var result = await Task.Run(() => businesLogic.GetHugeLoad());
            tbx_log.Text += result;
        }
        /// <summary>
        /// Indirect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_CallDirectAsyncAndNoReturn_Click(object sender, EventArgs e)
        {
            tbx_log.Text = "btn_CallDirectAsyncAndNoReturn_Click";
            businesLogic.GetHugeLoad();
        }
        /// <summary>
        /// Direct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_CallIndirectAsyncAndReturn_Click(object sender, EventArgs e)
        {
            tbx_log.Text = "btn_CallIndirectAsyncAndReturn_Click";
            var result = await Task.Run(() => businesLogic.LoadDataHugeProcessAsync());
            tbx_log.Text += result;
        }
        /// <summary>
        /// Direct
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CallIndirectAsyncAndNoReturn_Click(object sender, EventArgs e)
        {
            tbx_log.Text = "btn_CallIndirectAsyncAndNoReturn_Click";
            businesLogic.LoadDataHugeProcessAsync();
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            tbx_log.Clear();
        }

        private void btn_features_Click(object sender, EventArgs e)
        {
            ///
            /// Features
            /// 
            var feature = new Features();
            feature.TryParse();
            feature.DoStuffOther(null);
            feature.DoStuffOther("");
            feature.TestNullObject();
            feature.TestNullAndAssign();
            feature.PrintLengthTest();
            feature.AcceptNullAndTest(null);
            feature.AssurerNotNull();
            feature.TestTuple1();
            feature.TestTuple2();
            feature.EqualityTuples();
            feature.EqualityTuples2();
            feature.TestSwitch1();
            feature.TestSwitchLine();
            feature.TestFileName();
            feature.TestIsNotNull(null);
            ///
            /// Linq tests
            /// 
            var linqTests = new LinqTests();
            linqTests.QueryLength();
            linqTests.OnArayOfString();
            linqTests.QuertToListObjetcs();
            linqTests.JoinQueryComplex();
            linqTests.ReturnAnonymousTypes();
            linqTests.AllOperateur();
            linqTests.ContainsWithCustomClass();
            linqTests.Aggregate();
            linqTests.AverageBasic();
            linqTests.AverageCustomClass();
            linqTests.Max();
            linqTests.MaxComplex();
            linqTests.MaxOnPrimiveEVE();
            linqTests.SumOnPrimitiveValuesEVE();
            linqTests.SumStudentAgeAndAdults();
            linqTests.ElementAt();
            linqTests.First();
            linqTests.FirstOrDefault();
            linqTests.FirstOrDefaultWithNullIAnConditions();
            linqTests.Last();
            linqTests.LastOrDefault();
            linqTests.Single();
            linqTests.SequenceEqual();
            linqTests.SequenceEqualOnObjects();
            linqTests.Concat();
            linqTests.DefaultEmpty();
            linqTests.DefaultEmptyComplex();
            linqTests.Empty();





        }
    }
}
