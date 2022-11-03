using DBase.Model;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DBase
{
    public interface IDataBase
    {
        string ConnectionString { get; set; }

        void Delete(ref string err);
        SqlConnection GetConnection();
        List<AvionAF> GetDataList(ref string err);
        void InsertData(ref string err);
        void TestConnection(ref string err);
        void UpdateData(ref string err);
    }
}