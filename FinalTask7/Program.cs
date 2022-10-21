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
        public static HeartRateMonitor[] heartRateMonitors = new HeartRateMonitor[3];
        public static HeartRateSensor[] heartRateSensors = new HeartRateSensor[2];
        static void Main(string[] args)
        {
            Console.WriteLine("Приветствуем вас в нашем интернет-магазине! Из-за сложившейся" +
                "геополитеческой обстановки объявляем распродажу!");
            Console.WriteLine("В настоящее время в нашем магазине представлены следующие модели устройств:");
            Console.WriteLine("Пульсометры:");
            FillProductRange();
            for (int i = 0; i < heartRateMonitors.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {heartRateMonitors[i].Name}");
            }
            Console.WriteLine("Датчики измерения ЧСС:");
            for (int i = 0; i < heartRateSensors.Length; i++)
            {
                Console.WriteLine($"{i + 4}. {heartRateSensors[i].Type},{heartRateSensors[i].IP}");
            }
            Console.WriteLine("Для совершения заказа нажмите соответствующую цифру: ");
            ConsoleKeyInfo Choose = Console.ReadKey();
            for (int i = 0; i < heartRateMonitors.Length; i++)
            {
                if (Choose.Key == (ConsoleKey)(i+49))
                {
                    Console.WriteLine($"Вы выбрали {heartRateMonitors[i].Name}");

                }
            }
            for (int i = 0; i < heartRateSensors.Length; i++)
            {
                if (Choose.Key == (ConsoleKey)(i + 52))
                {
                    Console.WriteLine($"Вы выбрали датчик {heartRateSensors[i].Type}");

                }
            }
            /// и т.д.

        }
        static void FillProductRange()
        {
            HeartRateMonitor hm1 = new HeartRateMonitor("Polar H178", "Цифровой", true, true, true, "Li-ion", 150,1.5);
            hm1.IP = "IP68";
            HeartRateMonitor hm2 = new HeartRateMonitor("Polar H125", "Аналоговый", true, true, false, "CR2032");
            hm2.IP = "IP68";
            HeartRateMonitor hm3 = new HeartRateMonitor("Sigma 15.11", "Аналоговый", true, true, false, "CR2032");
            hm3.IP = "IP68";
            HeartRateSensor sens1 = new HeartRateSensor("Нагрудный", true, "Li-ion", 100, 1);
            sens1.IP = "IP68";
            HeartRateSensor sens2 = new HeartRateSensor("Оптический", true, "Ni-Ca",150, 5.5);
            sens2.IP = "IP68";
            heartRateMonitors[0] = hm1;
            heartRateMonitors[1] = hm2;
            heartRateMonitors[2] = hm3;
            heartRateSensors[0] = sens1;
            heartRateSensors[1]= sens2;

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
        protected string Address
        {
            get { return address; }
            set { address = value; }
        }
        protected string Note
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
        public void GetProduct()
        {

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
        public string Name;
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
        public HeartRateMonitor(string Name,string TypeOfSignal,bool HeartRateMax,bool Time, bool IsRechargable, string TypeOfBattary)
        {
            this.Name = Name;
            this.TypeOfSignal = TypeOfSignal;
            this.HeartRateMax = HeartRateMax;
            this.Time = Time;
            battery = new Battery(IsRechargable, TypeOfBattary);
        }
        //с аккумулятором
        public HeartRateMonitor(string Name,string TypeOfSignal, bool HeartRateMax, bool Time, bool IsRechargable, string TypeOfBattary, int Capacity, double TimeOfCharge)
        {
            this.Name = Name;
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
