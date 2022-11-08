using CoreWinFormsApp4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreWinFormsApp4
{
    public class Features
    {
        string _name;
        public string Name {
            get => _name;
            set => _name = value;
        }
        ///
        /// Feature 8
        /// 
        public void TryParse() {
            string strValue = "!#$%&";
            int value;
            if (!int.TryParse(strValue, out value))
            {
                Console.WriteLine(value);
            }
            if (!int.TryParse(strValue, out int value2))
            {
                Console.WriteLine(value2);
            }
            if (!int.TryParse(strValue, out var value3))
            {
                Console.WriteLine(value3);
            }
        }
        //C# 6
        public override string ToString() => $"{_name}";
        //Fire and forget a Task
        public void DoSomething() {
            _ = DoSomethingElse("");
        }
        private async Task<bool> DoSomethingElse(string message) {
            return true;
        }
        //Throws stuff
        public void DoStuff(string name) {
            if (name == null) {
                throw new ArgumentNullException();
            }
            if (name.Length > 0) {
                throw new ArgumentException();
            }
        }
        //-> ?? means if it is null do the right stuff
        public void DoStuffOther(string name) 
        {
            try
            {
                _ = name ?? throw new ArgumentException();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            try
            {
                name = "";
                _ = name.Length > 0 ? name : throw new ArgumentException();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
        public void TestNullObject() {
            Order order = new Order();
            order.recipient = new Recipient();
            order.recipient.EmailAddress = "monMail";
            if (order?.recipient?.EmailAddress != null)
            {
                Console.WriteLine(order.recipient.EmailAddress);
            }
            else {
                Console.WriteLine("Null");
            }
        }
        public void TestNullAndAssign() {
            Order order1 = null;
            if (order1 == null) {
                order1 = new Order(1);
            }
            Order order2 = null;
            order2 ??= new Order(2);

        }
    }
}
