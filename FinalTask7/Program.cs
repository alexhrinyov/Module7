using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
    static class TimeOfDelivery
    {
        static string time;
        public static void GetTimeOfDelivery<TDelivery>(TDelivery delivery)
        {
            if (delivery.GetType() is HomeDelivery)
            {
                time = "5 - 6 дней";
            }
            if (delivery.GetType() is PickPointDelivery)
            {
                time = "3 - 5 дней";
            }
            if (delivery.GetType() is ShopDelivery)
            {
                time = "2 - 4 дня";
            }
        }

    }



    abstract class Delivery
    {
        public string City;
        
    }

    class HomeDelivery : Delivery
    {
        private string address;
        private string note;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
        
    }

    class PickPointDelivery : Delivery
    {
        public string District;
        public bool ExtendedStorage;
    }

    class ShopDelivery : Delivery
    {
        public string District;
        public string Street;
    }

    class Order<TDelivery,TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.City);
            
        }
        
               
    }

    class Product<TDevice>
    {
        public TDevice TypeOfDevice;

    }
    abstract class Device
    {
        
        private string provider;
        public string Provider
        { 
            get { return provider; }
            set { provider = value; }
            
        }
        private string price;
        public string Price
        {
            get { return price; }
            set { price = value; }

        }
        public double TimeOfLifeActive;
        public double TimeOfLifeSleep;
        public string IP;
        public abstract void DisplayParameters();
        
    }
    
    class Battery
    {
        public bool IsRechargable;
        public int Capacity;
        public string Type;      
        public double TimeOfCharge { get;  set; }
        public void DisplayParameters()
        {
            if (IsRechargable)
            {
                Console.WriteLine("Характеристики элемента питания:");
                Console.WriteLine($"Перезаряжаемый: {IsRechargable.ConvertToYesNo()}");
                Console.WriteLine($"Емкость: {Capacity} мАч");
                Console.WriteLine($"Тип: {Type}");
                Console.WriteLine($"Время зарядки: {TimeOfCharge} ч");
            }
            else
            {
                Console.WriteLine("Характеристики элемента питания:");
                Console.WriteLine($"Перезаряжаемый: {IsRechargable.ConvertToYesNo()}");
                Console.WriteLine($"Тип: {Type}");
            }
        }
        public Battery(bool IsRechargable, string Type)
        {
            this.IsRechargable = IsRechargable;
            this.Type = Type;
        }
        public Battery(bool IsRechargable, string Type, int Capacity, double TimeOfCharge):this(IsRechargable, Type)
        {
            this.Capacity = Capacity;
            this.TimeOfCharge = TimeOfCharge;
        }


    }

    class HeartRateSensor:Device
    {
        public Battery battery;  
        public string Type;
        public override void DisplayParameters()
        {
            Console.WriteLine("Характеристики датчика:");
            Console.WriteLine($"Тип датчика: {Type}");
            Console.WriteLine($"Вермя работы в активном режиме: {TimeOfLifeActive}");
            Console.WriteLine($"Вермя работы в режиме ожидания: {TimeOfLifeSleep}");
            Console.WriteLine($"Степень защиты: {IP}");
        }
        // на батарейках
        public HeartRateSensor(string type, bool IsRechargable, string TypeOfBattary)
        {

            Type = type;
            battery = new Battery(IsRechargable, TypeOfBattary);
        }
        //с аккумулятором
        public HeartRateSensor(string type, bool IsRechargable, string TypeOfBattary,int Capacity,double TimeOfCharge)
        {

            Type = type;
            battery = new Battery(IsRechargable, TypeOfBattary, Capacity,TimeOfCharge);
        }
    }
    class HeartRateMonitor:Device
    {
        
        public string TypeOfSignal;
        public bool HeartRateMax;
        public bool Time;
        Battery battery; 
        public override void DisplayParameters()
        {
            Console.WriteLine("Характеристики пульсометра: ");
            Console.WriteLine($"Тип сигнала: {TypeOfSignal}");           
            Console.WriteLine($"Расчет максимального пульса: {HeartRateMax.ConvertToYesNo()}");
            Console.WriteLine($"Отображение времени: {Time.ConvertToYesNo()}");            
            Console.WriteLine($"Вермя работы в активном режиме: {TimeOfLifeActive}");
            Console.WriteLine($"Вермя работы в режиме ожидания: {TimeOfLifeSleep}");
            Console.WriteLine($"Степень защиты: {IP}");
        }
        // на батарейках
        public HeartRateMonitor(string TypeOfSignal,bool HeartRateMax,bool Time, bool IsRechargable, string TypeOfBattary)
        {

            this.TypeOfSignal = TypeOfSignal;
            this.HeartRateMax = HeartRateMax;
            this.Time = Time;
            battery = new Battery(IsRechargable, TypeOfBattary);
        }
        //с аккумулятором
        public HeartRateMonitor(string TypeOfSignal, bool HeartRateMax, bool Time, bool IsRechargable, string TypeOfBattary, int Capacity, double TimeOfCharge)
        {

            this.TypeOfSignal = TypeOfSignal;
            this.HeartRateMax = HeartRateMax;
            this.Time = Time;
            battery = new Battery(IsRechargable, TypeOfBattary, Capacity, TimeOfCharge);
        }
    }
    static class BoolExtensions
    {
        public static string ConvertToYesNo(this bool source)
        {
            string value;
            if (source)
            {
                value = "Да";
                return value;
            }
            else
            {
                value = "Нет";
                return value;
            }
        }
    }
}
