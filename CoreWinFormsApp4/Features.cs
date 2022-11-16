using CoreWinFormsApp4.Models;
using System;
using System.Collections.Generic;
using System.IO;
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
        //How to set a variable has nullable?
        public void PrintLengthTest() {
            string? value = null;
            PrintLength(value);

        }
        //If we need to have a possible nullable thing passed in...just do this
        public void PrintLength(string? value) {
            try
            {
                Console.WriteLine(value.Length);
                var l = value.Length;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
        }
        //Ici on accepte la valeur nulle, puis on teste 
        public void AcceptNullAndTest(string? value)
        {
             Console.WriteLine(value?.Length?? 1);
            var l = value?.Length ?? 1; //l == 1
        }
        public void AssurerNotNull()
        {
            string value = "test";
            var l = value!.Length; //l == 4
        }
        //C#4 Tuples
        public void TestTuple1() { 
            var res = Tuple1();
            var val1 = res.Item1;
            var val2 = res.Item2;

        }
        public (bool, string) Tuple1() {
            return (true, "ok");
        }
        //C#7 Tuples
        public void TestTuple2()
        {
            //1
            var res = Tuple2();
            var val1 = res.IsSuccess;
            var val2 = res.Response;
            //2
            (bool isSuccess2, string response2) = Tuple2();
            if (isSuccess2) { 
             }
            //3
            var (isSuccess3, response3) = Tuple2();
            if (isSuccess3)
            {
            }
            //4 don't care
            var (isSuccess4, _) = Tuple2();
            if (isSuccess4)
            {
            }
        }
        public (bool IsSuccess, string Response) Tuple2()
        {
            return (true, "ok");
        }
        public void EqualityTuples() {
            var x = (x: 10, y: "Banana");
            var y = (x:10, y:"Banana");
            var res1 = x == y;//true
            var res2 = x != y;//false
        }
        public void EqualityTuples2()
        {
            var x = (x: 10, y: "Banana");
            var y = (Count: 10, Product: "Banana");
            var res1 = x == y;//true
            var res2 = x != y;//false
        }
        public void TestSwitch1() {
            var myLoggable = new MyLoggable();
            //Error
            myLoggable.myLogLevelEnum = MyLogLevelEnum.Error;
            Switch(myLoggable);
            //Warn
            myLoggable.myLogLevelEnum = MyLogLevelEnum.Warn;
            Switch(myLoggable);
            //null
            Switch(null);
        }
        private void Switch(object item) {
            switch (item)
            {
                case null:
                case "":
                    return;
                case string str:
                    break;
                case MyLoggable myLoggable when myLoggable.myLogLevelEnum == MyLogLevelEnum.Error:
                    break;
                case MyLoggable myLoggable when myLoggable.myLogLevelEnum == MyLogLevelEnum.Debug:
                    break;
                case MyLoggable:
                    break;
                default:
                    break;
            }
        }
        public void TestSwitchLine() {

            var myLoggable = new MyLoggable();
            //Error
            myLoggable.myLogLevelEnum = MyLogLevelEnum.Error;
            Switch(myLoggable);
            //Warn
            myLoggable.myLogLevelEnum = MyLogLevelEnum.Warn;
            Switch(myLoggable);
            //null
            Switch(null);
        }
        private string SwitchLine(object item) => item switch { 
            null=>"",
            ""=>"",
            MyLoggable myLoggable when myLoggable.myLogLevelEnum == MyLogLevelEnum.Error => "",
            MyLoggable myLoggable when myLoggable.myLogLevelEnum == MyLogLevelEnum.Debug => "",
            _=>"UNKNOWN"
        };

        public void TestFileName()
        {
            var resultBool = TestFileNameLine("tutu.doc");
        }
        private bool TestFileNameLine(string fileName) =>
            fileName.All(
                   x => x is
                   (>= 'a' and <= 'z') or
                   (>= 'A' and <= 'Z') or
                   '-' or
                   '.'
                   &&
                   Path.GetExtension(fileName).Length is (>= 2 and <= 4)
            );
        public void TestIsNotNull(object item) {
            if (item is not null) {
                int i = 1;
            }
            if(item is null) {
                int i = 1;
            }
        }
    }
}
