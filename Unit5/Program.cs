using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //7.5.3
            //int num1 = 1;
            //int num2 = 55;
            //Helper.Swap(ref num1, ref num2);
            //Console.WriteLine(num1);
            //Console.WriteLine(num2);

            //7.5.9
            int num1 = 7;
            int num2 = -13;
            int num3 = 0;
            Console.WriteLine(num1.GetNegative());
            Console.WriteLine(num1.GetPositive()); 
            Console.WriteLine(num2.GetNegative()); 
            Console.WriteLine(num2.GetPositive()); 
            Console.WriteLine(num3.GetNegative()); 
            Console.WriteLine(num3.GetPositive()); 


        }
    }

    //7.5.2
    class Obj
    {
        public string Name;
        public string Description;
        public static string Parent;
        public static int DaysInWeek;
        public static int MaxValue;
        static Obj()
        {
            Parent = "System.Object";
            DaysInWeek = 7;
            MaxValue = 2000;
        }

    }
    //7.5.3
    internal class Helper
    {
        public static void Swap(ref int num1, ref int num2)
        {
            int temp;
            temp = num1;
            num1 = num2;
            num2 = temp;
        }
    }

    //7.5.9
    static class IntExtensions
    {
        public static int GetNegative(this int source)
        {
            if (source > 0)
                return -source;
            else
                return source;
        }
        public static int GetPositive(this int source)
        {
            if (source < 0)
                return -source;
            else
                return source;
        }

    }
}
