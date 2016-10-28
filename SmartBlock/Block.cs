using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBlock
{
    class Block
    {
        public int x;
        public int y;
        public int light;
        private int boardLength;
        private Board board;

        public Block(Board b)
        {
            x = 0;
            y = 0;
            light = 100;
            boardLength = GlobalConstants.boardLength;
            board = b;
        }
        public string GetLocation()
        {
            return "(" + x + ", " + y + ")";
        }

        private void CheckLight()
        {
            if(board.GetValue(x, y) == 1)
            {
                light--;
            }
            else
            {
                if(light < 100)
                {
                    light++;
                }
            }
        }

        public void MakeMove(int i)
        {
            switch (i)
            {
                case 0:
                    MoveLeft();
                    break;
                case 1:
                    MoveRight();
                    break;
                case 2:
                    MoveUp();
                    break;
                case 3:
                    MoveDown();
                    break;
                default:
                    break;
            }
        }

        private void MoveLeft()
        {
            if(x > 0)
            {
                x--;
            }
            CheckLight();
        }
        private void MoveRight()
        {
            if (x < boardLength - 1)
            {
                x++;
            }
            CheckLight();
        }
        private void MoveUp()
        {
            if (y > 0)
            {
                y--;
            }
            CheckLight();
        }
        private void MoveDown()
        {
            if (y < boardLength - 1)
            {
                y++;
            }
            CheckLight();
        }
    }
}
