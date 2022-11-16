using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWinFormsApp4
{
    /// <summary>
    /// https://www.tutorialsteacher.com/linq/what-is-linq
    /// - while the query syntax is almost a new language within C#, 
    /// - the method syntax looks just like regular C# method calls.
    /// </summary>
    public class LinqTests
    {
        /// <summary>
        /// Toutes les strings de 0 à 8 caractères
        /// </summary>
        public void QueryLength() {
            var listOfNames = new List<string>()
            {
                "John Doe",
                "Jane Doe",
                "Jenna Doe",
                "Joe Doe"
            };


            #region Query syntax
            var qNames = from name in listOfNames where name.Length <= 8 select name;
            #endregion

            #region Method syntax
            var mNames = listOfNames.Where(name => name.Length <= 8);
            #endregion
        }
        public void OnArayOfString() {
            // Data source
            string[] names = { "Bill", "Steve", "James", "Mohan" };

            #region Method syntax
            var resNames = names.Where(name => name.Contains("a"));
            #endregion

            #region Query syntax
            var myLinqQuery = from name in names
                              where name.Contains('a')
                              select name;
            #endregion

            //Query execution
            foreach (var name in myLinqQuery)
                Console.Write(name + " ");
        }
        public void QuertToListObjetcs() {
            var listOfPersons = new List<Person>()
            {
                new Person(){ Name ="John1", Age = 41, ID = 1 },
                new Person(){ Name ="John2", Age = 42, ID = 2 },
                new Person(){ Name ="John3", Age = 43, ID = 3 },
                new Person(){ Name ="John4", Age = 44, ID = 4 }
            };
            #region Linq method
            var res = listOfPersons.Where(pers => pers.Age.Equals(42));
            var reslist = listOfPersons.Where(pers => pers.Age.Equals(42)).ToList<Person>();
            #endregion
            #region Linq Sql
            var res2 = from person in listOfPersons
                       where person.Age.Equals(42)
                       select person;
            #endregion
        }
    }
}
