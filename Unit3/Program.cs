using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unit3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MotherBoard board = new MotherBoard();
            board.Work();
        }
    }
    abstract class ComputerPart
    {
        public abstract void Work();
    }

    class Processor:ComputerPart
    {
        public override void Work()
        {
            throw new NotImplementedException();
            
        }
    }
    class MotherBoard : ComputerPart
    {
        public override void Work()
        {
            
            throw new ArithmeticException();
        }
    }
    class GraphicCard : ComputerPart
    {
        public override void Work()
        {
            throw new NotImplementedException();
        }
    }

}
