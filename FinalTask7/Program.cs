using System;
using System.Collections.Generic;
using System.Linq;
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

    abstract class Delivery
    {
        public string Address;
        
    }

    class HomeDelivery : Delivery
    {
        
    }

    class PickPointDelivery : Delivery
    {
        
    }

    class ShopDelivery : Delivery
    {
        
    }

    class Order<TDelivery,TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
            
        }
        
        class Product<TDevice>
        {
            public TDevice TypeOfDevice;

        }
        
    }
    abstract class Device
    {
        public string ScreenTechnology;
        public string TypeOfSignal;
        public double TimeOfLifeActive { get; set; }
        public double TimeOfLifeSleep { get; set; }
    }
    
    class Battary
    {
        public int Capacity;
        public string Type;
        public string Manufacturer;
        
        public double TimeOfCharge { get; private set; }

    }

    class HeartRateSensor
    {

    }
    class HeartRateMonitor
    {

    }
}
