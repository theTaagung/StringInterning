using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringInterning
{
    class Program
    {
        static void Main(string[] args)
        {

            CompareWithoutStringIntern();
            CompareWithStringIntern();
            string myName = "Atul";
            string YourName = "Atul";
            string name1 = "A" + "t" + "u" + "l";
            string name2 = "A" + "tul";
            string name3 = string.Format("{0}", "Atul");
            string name4 = string.Format($"{"Atul"}");

            StringBuilder sb1 = new StringBuilder("A");
            StringBuilder sb2 = new StringBuilder("Atul");
            StringBuilder sb3 = new StringBuilder();

            string name5 = sb1.Append("t").Append("ul").ToString();
            string name6 = sb2.ToString();
            string name7 = sb3.Append("Atul").ToString();

            string name31 = string.Intern(string.Format("{0}", "Atul"));
            string name41 = string.Intern(string.Format($"{"Atul"}"));
            string name51 = string.Intern(name5);
            string name61 = string.Intern(sb2.ToString());
            string name71 = string.Intern(sb3.ToString());

            Console.WriteLine("Static Strings ...");
            Console.WriteLine(object.ReferenceEquals(myName, YourName));
            Console.WriteLine(object.ReferenceEquals(myName, name1));
            Console.WriteLine(object.ReferenceEquals(myName, name2));

            Console.WriteLine("Dynamics Strings ...");
            Console.WriteLine(object.ReferenceEquals(myName, name3));
            Console.WriteLine(object.ReferenceEquals(myName, name4));
            Console.WriteLine(object.ReferenceEquals(myName, name5));
            Console.WriteLine(object.ReferenceEquals(myName, name6));
            Console.WriteLine(object.ReferenceEquals(myName, name7));

            Console.WriteLine("Interned Strings ...");
            Console.WriteLine(object.ReferenceEquals(myName, name31));
            Console.WriteLine(object.ReferenceEquals(myName, name41));
            Console.WriteLine(object.ReferenceEquals(myName, name51));
            Console.WriteLine(object.ReferenceEquals(myName, name61));
            Console.WriteLine(object.ReferenceEquals(myName, name71));

            Console.WriteLine("String Interne methods ...");
            Console.WriteLine("IsInterned Static");
            Console.WriteLine(string.IsInterned(YourName));
            Console.WriteLine(string.IsInterned(name1));
            Console.WriteLine(string.IsInterned(name2));
            Console.WriteLine(string.IsInterned(name3));

            Console.WriteLine("IsInterned Dynamic");
            Console.WriteLine(string.IsInterned(name3));
            Console.WriteLine(string.IsInterned(name4));
            Console.WriteLine(string.IsInterned(name5));
            Console.WriteLine(string.IsInterned(name6));
            Console.WriteLine(string.IsInterned(name7));

            Console.WriteLine("string.IsInterned");

            Console.WriteLine(string.IsInterned(name31));
            Console.WriteLine(string.IsInterned(name41));
            Console.WriteLine(string.IsInterned(name51));
            Console.WriteLine(string.IsInterned(name61));
            Console.WriteLine(string.IsInterned(name1 + "Sharma"));
            Console.WriteLine(string.IsInterned(name71));
            


            Console.WriteLine("string.Intern");
            Console.WriteLine(string.Intern(name31));
            Console.WriteLine(string.Intern(name41));
            Console.WriteLine(string.Intern(name51));
            Console.WriteLine(string.Intern(name61));
            Console.WriteLine(string.Intern(name71));
            Console.WriteLine(string.Intern(name1 + "Sharma"));
            Console.ReadLine();

        }


        static void CompareWithStringIntern()
        {
            Console.WriteLine("CompareWithStringIntern()");
            string source = "Atul";
            string target = string.Intern(string.Format($"{"Atul"}"));
            bool isEqual = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000000; i++)
            {
                if (source == target)
                    isEqual = true;
                else
                    isEqual = false;
            }
            sw.Stop();
            Console.WriteLine($"Time - {sw.ElapsedTicks}");
            Console.WriteLine($"Memory - {GC.GetTotalMemory(true)}");
        }

        static void CompareWithoutStringIntern()
        {
            Console.WriteLine("CompareWithoutStringIntern()");
            string source = "Atul";
            string target = string.Format($"{"Atul"}");
            bool isEqual = false;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 100000000; i++)
            {
                if (source == target)
                    isEqual = true;
                else
                    isEqual = false;
            }

            sw.Stop();
            Console.WriteLine($"Time - {sw.ElapsedTicks}");
            Console.WriteLine($"Memory - {GC.GetTotalMemory(true)}");

        }
    }
}
