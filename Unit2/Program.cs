using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit2
{
    internal class Program
    {
        // до 7.2.6
        //public static BaseClass baseCl = new BaseClass("kkk");
        //public static DerivedClass derivCL = new DerivedClass("eee", "333");
        static void Main(string[] args)
        {
            // до 7.2.6
            //derivCL.Display();

            //7.2.7
            //A a = new A();
            //B b = new B();
            //C c = new C();
            //D d = new D();
            //E e = new E();
            //d.Display();//D
            //((A)e).Display(); //C
            //((B)d).Display();//B
            //((A)d).Display();//A

            //7.2.12
            //Obj l = new Obj() { Value = 10 };
            //Obj m = new Obj() { Value = 3 };
            //Obj n = new Obj();
            //n = l + m;
            //Obj o = new Obj();
            //o = l - m;
            //Console.WriteLine(n.Value);
            //Console.WriteLine(o.Value);

            // 7.2.14
            int[] arr = new int[] { 1, 2, 3 };
            IndexingClass collection = new IndexingClass(arr);
            int a = collection[1];
            collection[2] = 5;

        }




    }
    #region 7.2.6 переопределение методов
    class BaseClass
    {
        string Name;
        public virtual int Counter
        {
            get;
            set;
        }
        public BaseClass(string name)
        {
            Name = name;
        }
        public virtual void Display()
        {
            Console.WriteLine("Метод класса BaseClass");
        }
    }

    class DerivedClass : BaseClass
    {
        public string Description;
        public override int Counter
        {
            get
            {
                return Counter;
            }
            set
            {
                if (value < 0)
                    Console.WriteLine("Меньше нуля не допускается");
                else
                    Counter = value;


            }


        }


        public DerivedClass(string name, string description) : base(name)
        {
            Description = description;
        }
        public DerivedClass(string name, string description, int counter) : base(name)
        {
            Description = description;
            Counter = counter;
        }
        public override void Display()
        {
            base.Display();
            Console.WriteLine("Метод класса DerivedClass");
        }
    }
    #endregion

    #region 7.2.7 скрытие методов
    class A { 
    public virtual void Display()
        {
            Console.WriteLine("A");
        }
    }
    class B:A { 
    public new void Display()
        {
            Console.WriteLine("B");
        }
    }
    class C:A {
        public override void Display()
        {
            Console.WriteLine("C");
        }
    }
    class D:B {
        public new void Display()
        {
            Console.WriteLine("D");
        }
    }
    class E:C {
        public new void Display()
        {
            Console.WriteLine("E");
        }
    }


    #endregion

    #region 7.2.12 перегрузка операторов

    public class Obj
    {
        public int Value;

        public static Obj operator +(Obj a, Obj b)
        {
            return new Obj { Value = a.Value + b.Value };
        }
        public static Obj operator -(Obj a, Obj b)
        {
            return new Obj { Value = a.Value - b.Value };
        }
    }

    #endregion

    #region 7.2.14 Индексаторы
    class IndexingClass
    {
        private int[] array;

        public IndexingClass(int[] array)
        {
            this.array = array;
        }

        public int this[int index]
        {
            get
            {
                return array[index];
            }
            set
            {
                array[index] = value;
            }
        }
    }


    #endregion
}
