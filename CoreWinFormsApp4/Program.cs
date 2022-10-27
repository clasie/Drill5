using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoreWinFormsApp4
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        //    Console.WriteLine("Hello World!");
        //    List<Person> peopleList1 = new List<Person>();
        //    peopleList1.Add(new Person() { ID = 1 });
        //    peopleList1.Add(new Person() { ID = 2 });
        //    peopleList1.Add(new Person() { ID = 3 });

        //    List<Person> peopleList2 = new List<Person>();
        //    peopleList2.Add(new Person() { ID = 1 });
        //    peopleList2.Add(new Person() { ID = 2 });
        //    peopleList2.Add(new Person() { ID = 3 });
        //    peopleList2.Add(new Person() { ID = 4 });
        //    peopleList2.Add(new Person() { ID = 5 });
        //    var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));

        //    var peopleDifference =
        //              from person2 in peopleList2
        //              where !(
        //                  from person1 in peopleList1
        //                  select person1.ID
        //                ).Contains(person2.ID)
        //              select person2;
        }
    }
}
