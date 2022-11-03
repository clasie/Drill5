using Autofac;
using DBase;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWinFormsApp4
{
    public static class ContainerConfig
    {
        public static IContainer Configure() {
            var builder = new ContainerBuilder();

            builder
                .RegisterType<DataBase>().As<IDataBase>()
                .WithParameter("connectionString", ConfigurationManager.AppSettings["connectionString"]);
            builder
                .RegisterType<BusinesLogic>().As<IBusinesLogic>();

            return builder.Build();
        }
    }
}
