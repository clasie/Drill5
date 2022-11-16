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
        public class Student : IComparable<Student> 
        {
            public int StudentID { get; set; }
            public string StudentName { get; set; }
            public int StandardID { get; set; }
            public int Age { get; set; }

            public int CompareTo(Student other)//Pour Max
            {
                if (this.StudentName.Length >= other.StudentName.Length)
                    return 1;

                return 0;
            }
        }

        public class Standard
        {
            public int StandardID { get; set; }
            public string StandardName { get; set; }
        }
        /// <summary>
        /// Join operator
        /// </summary>
        public void JoinQueryBasic()
        {
            IList<string> strList1 = new List<string>() {
                "One",
                "Two",
                "Three",
                "Four"
            };

            IList<string> strList2 = new List<string>() {
                "One",
                "Two",
                "Five",
                "Six"
            };

            #region Linq Method
            var innerJoin = strList1.Join(strList2,
                                  str1 => str1,
                                  str2 => str2,
                                  (str1, str2) => str1);
            #endregion
        }
        /// <summary>
        /// Join operator sur StandardID
        /// </summary>
        public void JoinQueryComplex() {

            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", StandardID =1 },
            new Student() { StudentID = 2, StudentName = "Moin", StandardID =1 },
            new Student() { StudentID = 3, StudentName = "Bill", StandardID =2 },
            new Student() { StudentID = 4, StudentName = "Ram" , StandardID =2 },
            new Student() { StudentID = 5, StudentName = "Ron"  }
            };

            IList<Standard> standardList = new List<Standard>() {
            new Standard(){ StandardID = 1, StandardName="Standard 1"},
            new Standard(){ StandardID = 2, StandardName="Standard 2"},
            new Standard(){ StandardID = 3, StandardName="Standard 3"}
            };

            #region Linq method
            var innerJoin = studentList.Join(// outer sequence 
                                  standardList,  // inner sequence 
                                  student => student.StandardID,    // outerKeySelector
                                  standard => standard.StandardID,  // innerKeySelector
                                  (student, standard) => new  // result selector
                      {
                                      StudentName = student.StudentName,
                                      StandardName = standard.StandardName
                                  });
            #endregion

            #region linq SQL
            var innerJoin2 = from s in studentList // outer sequence
                             join st in standardList //inner sequence 
                             on s.StandardID equals st.StandardID // key selector 
                             select new
                             { // result selector 
                                 StudentName = s.StudentName,
                                 StandardName = st.StandardName
                             };
            #endregion
        }
        public void ReturnAnonymousTypes() {
            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
            new Student() { StudentID = 2, StudentName = "Moin",  Age = 21 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 18 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 15 }
};

            // returns collection of anonymous objects with Name and Age property
            #region Linq SQL
            var selectResult = from s in studentList
                               select new { Name = "Mr. " + s.StudentName, Age = s.Age };
            #endregion
            // iterate selectResult
            foreach (var item in selectResult)
                Console.WriteLine("Student Name: {0}, Age: {1}", item.Name, item.Age);
        }
        /// <summary>
        /// The All operator evalutes each elements in the given collection on a 
        /// specified condition and returns True if all the elements satisfy a condition.
        /// 
        /// Any checks whether any element satisfy given condition or not? In the following example, 
        /// Any operation is used to check whether any student is teen ager or not.
        /// FR
        /// Des vérifications pour savoir si un élément satisfait ou non à une condition donnée ? 
        /// Dans l'exemple suivant, toute opération est utilisée pour vérifier si un élève 
        /// est adolescent ou non.
        /// </summary>
        public void AllOperateur() {
            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            // checks whether all the students are teenagers    
            #region Linq method All
            bool areAllStudentsTeenAger = studentList.All(s => s.Age > 12 && s.Age < 20);
            #endregion

            #region Linq method Any
            bool areAnyStudentsTeenAger = studentList.Any(s => s.Age > 12 && s.Age < 20);
            #endregion
        }
        class StudentComparer : IEqualityComparer<Student>
        {
            public bool Equals(Student x, Student y)
            {
                if (x.StudentID == y.StudentID &&
                            x.StudentName.ToLower() == y.StudentName.ToLower())
                    return true;

                return false;
            }

            public int GetHashCode(Student obj)
            {
                return obj.GetHashCode();
            }
        }
        public void ContainsWithCustomClass() {

            IList<Student> studentList = new List<Student>() {
            new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
            new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
            new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
            new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
            new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
            };

            Student std = new Student() { StudentID = 3, StudentName = "Bill" };
            #region
            bool result = studentList.Contains(std, new StudentComparer()); //returns true
            #endregion
        }
        /// <summary>
        /// https://www.tutorialsteacher.com/linq/linq-aggregation-operator-aggregate
        /// </summary>
        public void Aggregate() {
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };
            #region 
            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);
            #endregion
        }
        /// <summary>
        /// https://www.tutorialsteacher.com/linq/linq-aggregation-operator-average
        /// </summary>
        public void AverageBasic() {
            IList<int> intList = new List<int> () { 10, 20, 30 };
            #region
            var avg = intList.Average();
            #endregion
        }
        /// <summary>
        /// The Average operator in query syntax is Not Supported in C#. However,
        /// it is supported in VB.Net as shown below.
        /// </summary>
        public void AverageCustomClass() {
            IList<Student> studentList = new List<Student> () {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
             };
            #region
            var avgAge = studentList.Average(s => s.Age);
            #endregion
        }
        /// <summary>
        /// https://www.tutorialsteacher.com/linq/linq-aggregation-operator-max
        /// </summary>
        public void Max() {
            IList<Student> studentList = new List<Student> () {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
                 };
            #region
            var oldest = studentList.Max(s => s.Age);
            #endregion
        }
        public void MaxComplex() {
            // Student collection
            IList<Student> studentList = new List<Student> () {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Steve", Age = 15 }
                 };

            var studentWithLongName = studentList.Max();

            var message = 
                $"Student ID: {studentWithLongName.StudentID}, Student Name: {studentWithLongName.StudentName}";
        }
    }
}
