using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBlock
{
    class Board
    {

        private List<List<int>> board;
        private int boardLength;

        public Board()
        {
            boardLength = GlobalConstants.boardLength;
            board = new List<List<int>>();
            FillBoard();
        }

        private void FillBoard()
        {
            Random rand = new Random();
            for(int i = 0; i < boardLength; i++)
            {
                List<int> line = new List<int>();
                for (int j = 0; j < boardLength; j++)
                {
                    line.Add(Convert.ToInt16(rand.NextDouble()));
                }
                board.Add(line);
            }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < boardLength; i++)
            {
                for (int j = 0; j < boardLength; j++)
                {
                    Console.Write(board.ElementAt(i).ElementAt(j));
                }
                Console.WriteLine();
            }
        }

        public void ClusterBoard()
        {
            double chanceStaySame = 0.5;
            Random rand = new Random();
            double randDbl = 0;
            for (int i = 0; i < boardLength; i++)
            {
                for (int j = 0; j < boardLength; j++)
                {
                    int val = board[i][j];
                    if(!LeftSame(i,j) && !UpSame(i, j))
                    {
                        randDbl = rand.NextDouble();
                        if(randDbl > chanceStaySame)
                        {
                            if (val == 0)
                            {
                                board[i][j] = 1;
                            }
                            else
                            {
                                board[i][j] = 0;
                            }
                        }
                    }
                }
            }
        }

        public int GetValue(int x, int y)
        {
            if(x >= 0 && x < boardLength && y >= 0 && y < boardLength)
            {
                return board[y][x];
            }
            return -1;
        }

        private bool LeftSame(int i, int j)
        {
            if(j > 0)
            {
                if(board.ElementAt(i).ElementAt(j - 1) == board.ElementAt(i).ElementAt(j))
                {
                    return true;
                }
            }
            return false;
        }

        private bool UpSame(int i, int j)
        {
            if(i > 0)
            {
                if(board.ElementAt(i - 1).ElementAt(j) == board.ElementAt(i).ElementAt(j))
                {
                    return true;
                }
            }
            return false;
        }

        private bool RightSame(int i, int j)
        {
            if(j < boardLength - 1)
            {
                if(board.ElementAt(i).ElementAt(j + 1) == board.ElementAt(i).ElementAt(j))
                {
                    return true;
                }
            }
            return false;
        }

        private bool DownSame(int i, int j)
        {
            if(i < boardLength - 1)
            {
                if(board.ElementAt(i + 1).ElementAt(j) == board.ElementAt(i).ElementAt(j))
                {
                    return true;
                }
            }
            return false;
        }

        private int GetLeft(int i, int j)
        {
            if (j > 0)
            {
                return board.ElementAt(i).ElementAt(j - 1);
            }
            return -1;
        }

        private int GetUp(int i, int j)
        {
            if (i > 0)
            {
                return board.ElementAt(i - 1).ElementAt(j);
            }
            return -1;
        }

        private int GetRight(int i, int j)
        {
            if (j < boardLength - 1)
            {
                return board.ElementAt(i).ElementAt(j + 1);
            }
            return -1;
        }

        private int GetDown(int i, int j)
        {
            if (i < boardLength - 1)
            {
                return board.ElementAt(i + 1).ElementAt(j);
            }
            return -1;
        }
    }
}
