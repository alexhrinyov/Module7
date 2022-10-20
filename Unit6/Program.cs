using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Unit6
{
    internal class Program
    {
        
        static void Main(string[] args)
        {

            
        }
        
    }
    //Создайте класс-обобщение Car для автомобиля. Универсальным параметром будет
    //тип двигателя в автомобиле (электрический и бензиновый). Для типов двигателей также создайте классы —
    //ElectricEngine и GasEngine.
    //В классе Car создайте поле Engine в качестве типа которому укажите универсальный параметр.
    class Car<TEngine> where TEngine: Engine       
    {
        public TEngine EngineType;
        
        public virtual void ChangePart<TPart>(TPart newPart) where TPart: PartType 
        {

        }
    }

    class ElectricEngine: Engine
    {

    }
    class GasEngine : Engine
    {

    }
    class Battery: PartType
    {

    }
    class Differentioal : PartType
    {

    }
    class Wheel : PartType
    {

    }
    class Engine
    {

    }
    class PartType
    {

    }

    //7.6.6
    class Record<T1, T2>
    {
        public T1 Id;
        public T2 Value;
        public DateTime Date;
    }



    

}
