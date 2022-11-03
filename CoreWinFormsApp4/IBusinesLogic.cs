using DBase;
using DBase.Model;
using System.Collections.Generic;

namespace CoreWinFormsApp4
{
    public interface IBusinesLogic
    {
        IDataBase GetDataBase();
        void TestConnection(ref string err);
        List<AvionAF> GetDataList(ref string err);
        void InsertData(ref string err);
        void UpdateData(ref string err);
        void Delete(ref string err);
    }
}