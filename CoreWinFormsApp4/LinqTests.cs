using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public void QueryLength()
        {
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
        public void OnArayOfString()
        {
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
        public void QuertToListObjetcs()
        {
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
        public void JoinQueryComplex()
        {

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
        public void ReturnAnonymousTypes()
        {
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
        public void AllOperateur()
        {
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
        public void ContainsWithCustomClass()
        {

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
        public void Aggregate()
        {
            IList<String> strList = new List<String>() { "One", "Two", "Three", "Four", "Five" };
            #region 
            var commaSeperatedString = strList.Aggregate((s1, s2) => s1 + ", " + s2);
            #endregion
        }
        /// <summary>
        /// https://www.tutorialsteacher.com/linq/linq-aggregation-operator-average
        /// </summary>
        public void AverageBasic()
        {
            IList<int> intList = new List<int>() { 10, 20, 30 };
            #region
            var avg = intList.Average();
            #endregion
        }
        /// <summary>
        /// The Average operator in query syntax is Not Supported in C#. However,
        /// it is supported in VB.Net as shown below.
        /// </summary>
        public void AverageCustomClass()
        {
            IList<Student> studentList = new List<Student>() {
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
        /// 
        /// Max operator is Not Supported in C# Query syntax
        /// 
        /// </summary>
        public void Max()
        {
            IList<Student> studentList = new List<Student>() {
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
        public void MaxComplex()
        {
            // Student collection
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Steve", Age = 15 }
                 };
            //via CompareTo() implemented in Student
            var studentWithLongName = studentList.Max();

            var message =
                $"Student ID: {studentWithLongName.StudentID}, Student Name: {studentWithLongName.StudentName}";
        }
        public void MaxOnPrimiveEVE()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87, 60 };

            var largest = intList.Max();

            var largestEvenElements = intList.Max(i =>
            {
                if (i % 2 == 0)
                    return i;

                return 0;
            });

            var value = $"Largest Even Element: {largestEvenElements}";
        }
        /// <summary>
        /// The following example demonstrates Sum() on primitive collection.
        /// </summary>
        public void SumOnPrimitiveValuesEVE()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };

            var total = intList.Sum();

            var sumOfEvenElements = intList.Sum(i =>
            {
                if (i % 2 == 0)
                    return i;

                return 0;
            });
        }
        /// <summary>
        /// The following example calculates sum of all student's age 
        /// and also number of adult students in a student collection.
        /// 
        /// Sum operator is Not Supported in C# Query syntax
        /// 
        /// </summary>
        public void SumStudentAgeAndAdults()
        {
            IList<Student> studentList = new List<Student>() {
                new Student() { StudentID = 1, StudentName = "John", Age = 13 } ,
                new Student() { StudentID = 2, StudentName = "Moin", Age = 21 } ,
                new Student() { StudentID = 3, StudentName = "Bill", Age = 18 } ,
                new Student() { StudentID = 4, StudentName = "Ram", Age = 20 } ,
                new Student() { StudentID = 5, StudentName = "Ron", Age = 15 }
                 };

            var sumOfAge = studentList.Sum(s => s.Age);

            var res = $"Sum of all student's age: {sumOfAge}";

            var numOfAdults = studentList.Sum(s =>
            {

                if (s.Age >= 18)
                    return 1;
                else
                    return 0;
            });

            var res2 = $"Total Adult Students: {numOfAdults}";
        }
        /// <summary>
        /// The following example demonstrates ElementAt and ElementAtOrDefault 
        /// method on primitive collection.
        /// </summary>
        public void ElementAt()
        {
            IList<int> intList = new List<int>() { 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { "One", "Two", null, "Four", "Five" };
            try
            {
                Debug.WriteLine("1st Element in intList: {0}", intList.ElementAt(0));
                Debug.WriteLine("1st Element in strList: {0}", strList.ElementAt(0));

                Debug.WriteLine("2nd Element in intList: {0}", intList.ElementAt(1));
                Debug.WriteLine("2nd Element in strList: {0}", strList.ElementAt(1));

                Debug.WriteLine("3rd Element in intList: {0}", intList.ElementAtOrDefault(2));
                Debug.WriteLine("3rd Element in strList: {0}", strList.ElementAtOrDefault(2));

                Debug.WriteLine("10th Element in intList: {0} - default int value",
                                intList.ElementAtOrDefault(9));
                Debug.WriteLine("10th Element in strList: {0} - default string value (null)",
                                 strList.ElementAtOrDefault(9));


                Debug.WriteLine("intList.ElementAt(9) throws an exception: Index out of range");
                Debug.WriteLine("-------------------------------------------------------------");
                Debug.WriteLine(intList.ElementAt(9));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// The following example demonstrates First() method.
        /// </summary>
        /// <returns></returns>
        public void First()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();
            try
            {
                Debug.WriteLine("1st Element in intList: {0}", intList.First());
                Debug.WriteLine("1st Even Element in intList: {0}", intList.First(i => i % 2 == 0));

                Debug.WriteLine("1st Element in strList: {0}", strList.First());

                Debug.WriteLine("emptyList.First() throws an InvalidOperationException");
                Debug.WriteLine("-------------------------------------------------------------");
                Debug.WriteLine(emptyList.First());
                /*
                    1st Element in intList: 7
                    1st Even Element in intList: 10
                    1st Element in strList:
                    emptyList.First() throws an InvalidOperationException
                    -------------------------------------------------------------
                    Run-time exception: Sequence contains no elements...                 
                 */
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        public void FirstOrDefault()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            IList<string> emptyList = new List<string>();

            Console.WriteLine("1st Element in intList: {0}", intList.FirstOrDefault());
            Console.WriteLine("1st Even Element in intList: {0}",
                                             intList.FirstOrDefault(i => i % 2 == 0));

            Console.WriteLine("1st Element in strList: {0}", strList.FirstOrDefault());
            Console.WriteLine("1st Element in emptyList: {0}", emptyList.FirstOrDefault());
            /*
                1st Element in intList: 7
                1st Even Element in intList: 10
                1st Element in strList:
                1st Element in emptyList:
             */
        }
        /// <summary>
        /// If a collection includes null element then FirstOrDefault() throws an exception 
        /// while evaluting the specified condition. The following example demonstrates this.
        /// </summary>
        public void FirstOrDefaultWithNullIAnConditions()
        {
            IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
            IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
            try
            {
                Console.WriteLine("1st Element which is greater than 250 in intList: {0}",
                                                intList.First(i => i > 250));

                Console.WriteLine("1st Even Element in intList: {0}",
                                                strList.FirstOrDefault(s => s.Contains("T")));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// The Last() method returns the last element from a collection, 
        /// or the last element that satisfies the specified condition using 
        /// lambda expression or Func delegate. If a given collection is empty 
        /// or does not include any element that satisfied the condition then
        /// it will throw InvalidOperation exception.
        /// </summary>
        public void Last()
        {
            try
            {
                IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
                IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
                IList<string> emptyList = new List<string>();

                Console.WriteLine("Last Element in intList: {0}", intList.Last());

                Console.WriteLine("Last Even Element in intList: {0}", intList.Last(i => i % 2 == 0));

                Console.WriteLine("Last Element in strList: {0}", strList.Last());

                Console.WriteLine("emptyList.Last() throws an InvalidOperationException");
                Console.WriteLine("-------------------------------------------------------------");
                Console.WriteLine(emptyList.Last());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            /*
                Last Element in intList: 87
                Last Even Element in intList: 50
                Last Element in strList: Five
                emptyList.Last() throws an InvalidOperationException
                -------------------------------------------------------------
                Run-time exception: Sequence contains no elements...
             */

        }
        /// <summary>
        /// If a collection includes null element then the LastOrDefault()
        /// throws an exception while evaluting the specified condition.
        /// </summary>
        public void LastOrDefault()
        {
            try
            {
                IList<string> strList1 = new List<string>() { "Two", "Three", "Four", "Five" };
                IList<string> strList2 = new List<string>() { null, "Two", "Three", "Four", "Five" };

                Console.WriteLine(strList1.LastOrDefault(s => s.Contains("T")));
                Console.WriteLine(strList2.LastOrDefault(s => s.Contains("T")));// throws an exception
                /*
                 Run-time exception: Sequence contains no matching element
                 */
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// Single() returns the only element from a collection, or the only element
        /// that satisfies the specified condition. If a given collection includes no 
        /// elements or more than one elements then Single() throws InvalidOperationException.
        /// 
        /// Single() expects one and only one element in the collection.
        /// 
        ///Single() throws an exception when it gets no element or more than one elements in the collection.
        ///If specified a condition in Single() and result contains no element or more than one elements then it throws an exception.
        ///SingleOrDefault() will return default value of a data type of generic collection if there is no elements in a colection or for the specified condition.
        ///SingleOrDefault() will throw an exception if there is more than one elements in a colection or for the specified condition.
        ///
        /// </summary>
        public void Single()
        {
            try
            {
                IList<int> oneElementList = new List<int>() { 7 };
                IList<int> intList = new List<int>() { 7, 10, 21, 30, 45, 50, 87 };
                IList<string> strList = new List<string>() { null, "Two", "Three", "Four", "Five" };
                IList<string> emptyList = new List<string>();

                Debug.WriteLine("The only element in oneElementList: {0}", 
                             oneElementList.Single());
                Debug.WriteLine("The only element in oneElementList: {0}",
                             oneElementList.SingleOrDefault());

                Debug.WriteLine("Element in emptyList: {0}", 
                             emptyList.SingleOrDefault());

                Debug.WriteLine("The only element which is less than 10 in intList: {0}",
                             intList.Single(i => i < 10));

                //Followings throw an exception
                //Console.WriteLine("The only Element in intList: {0}", intList.Single());
                //Console.WriteLine("The only Element in intList: {0}", intList.SingleOrDefault());
                //Console.WriteLine("The only Element in emptyList: {0}", emptyList.Single());

                /*
                    The only element in oneElementList: 7
                    The only element in oneElementList: 7
                    Element in emptyList: 0
                    The only element which is less than 10 in intList: 7
                 */
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// The following example demonstrates the SequenceEqual method with the 
        /// collection of primitive data types.
        /// </summary>
        public void SequenceEqual()
        {
            try
            {
                IList<string> strList1 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

                IList<string> strList2 = new List<string>() { "One", "Two", "Three", "Four", "Three" };

                bool isEqual = strList1.SequenceEqual(strList2); // returns true
                Console.WriteLine(isEqual);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// 
        /// To compare the values of two collection of complex type (reference type or object), 
        /// you need to implement IEqualityComperar<T> interface as shown below.
        /// 
        /// The SequenceEqual method compares the number of items and their values for primitive data types.
        ///The SequenceEqual method compares the reference of objects for complex data types.
        ///Use IEqualityComparer class to compare two colection of complex type using SequenceEqual method.
        ///
        /// </summary>
        public void SequenceEqualOnObjects()
        {
            try
            {
                IList<Student> studentList1 = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
                };

                IList<Student> studentList2 = new List<Student>() {
                    new Student() { StudentID = 1, StudentName = "John", Age = 18 } ,
                    new Student() { StudentID = 2, StudentName = "Steve",  Age = 15 } ,
                    new Student() { StudentID = 3, StudentName = "Bill",  Age = 25 } ,
                    new Student() { StudentID = 4, StudentName = "Ram" , Age = 20 } ,
                    new Student() { StudentID = 5, StudentName = "Ron" , Age = 19 }
                };
                // following returns true
                bool isEqual = studentList1.SequenceEqual(studentList2, new StudentComparer());
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// The Concat() method appends two sequences of the same type 
        /// and returns a new sequence (collection).
        /// 
        /// Concat operator is not supported in query syntax in C#
        /// 
        /// </summary>
        public void Concat()
        {
            try
            {
                IList<string> collection1 = new List<string>() { "One", "Two", "Three" };
                IList<string> collection2 = new List<string>() { "Five", "Six" };

                var collection3 = collection1.Concat(collection2);

                foreach (string str in collection3)
                    Console.WriteLine(str);
                /*
                    One
                    Two
                    Three
                    Five
                    Six
                */
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// ltIfEmpty() method returns a new collection with the default value if the given collection on which DefaultIfEmpty() 
        /// is invoked is empty.
        //  Another overload method of DefaultIfEmpty() takes a value parameter that should be replaced with default value.
        /// </summary>
        public void DefaultEmpty()
        {
            try
            {
                IList<string> emptyList = new List<string>();

                var newList1 = emptyList.DefaultIfEmpty();
                var newList2 = emptyList.DefaultIfEmpty("None");

                Console.WriteLine("Count: {0}", newList1.Count());
                Console.WriteLine("Value: {0}", newList1.ElementAt(0));

                Console.WriteLine("Count: {0}", newList2.Count());
                Console.WriteLine("Value: {0}", newList2.ElementAt(0));
                /*
                    Count: 1
                    Value:
                    Count: 1
                    Value: None                 
                 */
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        public void DefaultEmptyComplex()
        {
            try
            {
                IList<Student> emptyStudentList = new List<Student>();

                var newStudentList1 = emptyStudentList.DefaultIfEmpty();
                var newStudentList2 = emptyStudentList.
                    DefaultIfEmpty(
                    new Student() { StudentID = 0, StudentName = "" });

                Console.WriteLine("Count: {0} ", 
                    newStudentList1.Count());
                Console.WriteLine("Student ID: {0} ", 
                    newStudentList1.ElementAt(0));

                Console.WriteLine("Count: {0} ", 
                    newStudentList2.Count());
                Console.WriteLine("Student ID: {0} ", 
                    newStudentList2.ElementAt(0).StudentID);

                /*
                    Count: 1 
                    Student ID:  
                    Count: 1 
                    Student ID: 0
                 */
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
        /// <summary>
        /// The Empty() method returns an empty collection of a specified 
        /// type as shown below.
        /// </summary>
        public void Empty()
        {
            try {
                var emptyCollection1 = Enumerable.Empty<string>();
                var emptyCollection2 = Enumerable.Empty<Student>();

                Console.WriteLine("Type: {0}", emptyCollection1.GetType().Name);
                Console.WriteLine("Count: {0}", emptyCollection1.Count());

                Console.WriteLine("Type: {0}", emptyCollection2.GetType().Name);
                Console.WriteLine("Count: {0}", emptyCollection2.Count());
                 /*
                    Type: String[]
                    Count: 0
                    Type: Student[]
                    Count: 0
                 */
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
