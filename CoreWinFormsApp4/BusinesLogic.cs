using DBase;
using DBase.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreWinFormsApp4
{

    public class BusinesLogic : IBusinesLogic
    {
        public string ConcatText = "";
        public IDataBase dataBase;
        /// <summary>
        /// Ijection de dependence
        /// </summary>
        /// <param name="dataBase"></param>
        public BusinesLogic(IDataBase dataBase)
        {
            this.dataBase = dataBase;
        }
        public IDataBase GetDataBase()
        {
            return dataBase;
        }
        public void TestConnection(ref string err)
        {
            dataBase.TestConnection(ref err);
        }
        public List<AvionAF> GetDataList(ref string err) {
            return dataBase.GetDataList(ref err);
        }
        public void InsertData(ref string err) {
            dataBase.InsertData(ref err);
        }
        public void UpdateData(ref string err) {
            dataBase.UpdateData(ref err);
        }
        public void Delete(ref string err) {
            dataBase.Delete(ref err);
        }
        public async Task<string> LoadDataHugeProcessAsync()
        {
            var text = await Task.Run(() => GetHugeLoad());
            return text;
        }
        public async Task<string> GetHugeLoad() {
            System.Threading.Thread.Sleep(5000);
            ConcatText = " -> Résultat ... ";
            return ConcatText;
        }
        public string GetConcatText() {
            return ConcatText;
        }
    }
}
