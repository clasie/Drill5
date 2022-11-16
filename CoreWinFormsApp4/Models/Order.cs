using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWinFormsApp4.Models
{
    public class Order
    {
        int Debug;
        public Recipient recipient;
        public Order(int debug)
        {
            Debug = debug;
        }
        public Order() { 
        }
    }
}

