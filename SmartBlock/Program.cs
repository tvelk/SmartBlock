using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBlock
{
    public class GlobalConstants
    {
        public static int boardLength = 70;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Simulation sim = new Simulation();
            sim.Run();
            Console.ReadKey();

            //Random Simulation Code
            //for(int i = 0; i < 100; i++)
            //{
            //    Simulation sim = new Simulation();
            //    sim.Run();
            //}
            //Console.ReadKey();
        }
    }
}
