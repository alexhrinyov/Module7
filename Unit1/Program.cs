using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit1
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //7.1.6
            Obj obj = new Obj("54545", "lkj;kj", 44, 4);
            
        }

    }
    #region 7.1.4
    public class Employee
    {
        public string Name;
        public int Age;
        public int Salary;
    }
    public class ProjectManager : Employee
    {
        public string ProjectName;
    }

    public class Developer : Employee
    {
        public string ProgrammingLanguage;
    }
    #endregion
    #region 7.1.5
    public class Food
    {
        public int Taste;
        public string Healthy;
    }
    public class Fruit : Food
    {

    }
    public class Vegetable : Food
    {

    }
    public class Apple : Fruit
    {

    }
    public class Banana : Fruit
    {

    }
    public class Pear : Fruit
    {

    }
    public class Potato : Vegetable
    {

    }
    public class Carrot : Vegetable
    {

    }
    #endregion
    #region 7.1.6
    class Obj
    {
        private string name;
        private string owner;
        private int length;
        private int count;

        public Obj(string name, string ownerName, int objLength, int count): this()
        {
            this.name = name;
            owner = ownerName;
            length = objLength;
            this.count = count;
        }
        public Obj()
        {
            Console.WriteLine("Родительский конструктор");
        }
    }
    #endregion
    
}
