using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBlock
{
    class Simulation
    {
        private Board board;
        private Block block;
        private int totalMovesMade;
        private int cornerA;
        private int cornerB;
        private int cornerC;
        private int cornerD;
        private double cornerAP;
        private double cornerBP;
        private double cornerCP;
        private double cornerDP;
        private Brain brain;

        public Simulation()
        {
            board = new Board();

            for (int i = 0; i < 50; i++)
            {
                board.ClusterBoard();
            }
            board.PrintBoard();

            block = new Block(board);

            totalMovesMade = 0;
            cornerA = 0;
            cornerB = 0;
            cornerC = 0;
            cornerD = 0;

            brain = new Brain(5, 5, 3, 2);
        }
        public void Run()
        {
            while(block.light > 0)
            {
                GenerateCalculatedMove();
                //GenerateRandomMove();
                totalMovesMade++;


                if (totalMovesMade > 50000)
                {
                    break;
                }


                //Console.WriteLine(block.GetLocation());
                //calcLocations();
                //if(totalMovesMade % 10000 == 0)
                //{
                //    //board.PrintBoard();
                //    //Console.WriteLine(block.GetLocation() + " " + block.light);
                //    Console.WriteLine(cornerAP.ToString("0.00") + " " + cornerBP.ToString("0.00") +" " + cornerCP.ToString("0.00") + " " + cornerDP.ToString("0.00"));
                //}
            }
            Console.WriteLine(totalMovesMade);
        }

        //This is just calculating how often the block is in one of the four corners
        public void calcLocations()
        {
            if(block.x == 0 && block.y == 0){
                cornerA++;
                cornerAP = (cornerA * 1.0) / (totalMovesMade * 1.0);
            }
            if (block.x == 0 && block.y == 69)
            {
                cornerB++;
                cornerBP = (cornerB * 1.0) / (totalMovesMade * 1.0);
            }
            if (block.x == 69 && block.y == 0)
            {
                cornerC++;
                cornerCP = (cornerC * 1.0) / (totalMovesMade * 1.0);
            }
            if (block.x == 69 && block.y == 69)
            {
                cornerD++;
                cornerDP = (cornerD * 1.0) / (totalMovesMade * 1.0);
            }
        }

        public void GenerateCalculatedMove()
        {
            List<double> inputs = new List<double>();
            inputs.Add(board.GetValue(block.x, block.y));
            inputs.Add(board.GetValue(block.x, block.y + 1));
            inputs.Add(board.GetValue(block.x + 1, block.y));
            inputs.Add(board.GetValue(block.x, block.y - 1));
            inputs.Add(board.GetValue(block.x - 1, block.y));
            List<double> outputs = brain.Calculate(inputs);
            //I *know* outputs should only have 2 values
            if(Math.Abs(outputs[0]) > Math.Abs(outputs[1]))
            {
                if(outputs[0] < 0)
                {
                    block.MakeMove(0);
                }
                else
                {
                    block.MakeMove(1);
                }
            }
            else
            {
                if (outputs[1] < 0)
                {
                    block.MakeMove(2);
                }
                else
                {
                    block.MakeMove(3);
                }
            }
        }

        public void GenerateRandomMove()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            int r = rand.Next(4);
            block.MakeMove(r);
        }
    }
}
