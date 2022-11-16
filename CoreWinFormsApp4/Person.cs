using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWinFormsApp4
{
    class Person
    {
        private int _id;
        private string _nom;
        private int _age;
        public string Name { get => _nom; set => _nom = value; }
        public int Age { get => _age; set => _age = value; }
        public int ID { get => _id; set => _id = value; }
    }
}
