using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame
{
    public class Move
    {
        public int Row { get; set; }
        public int Col { get; set; }
        private bool GoodRow { get; set; }
        private bool GoodCol { get; set; }
        public void GetMove(int nRows, int nCols)
        {
            do
            {
                Console.WriteLine("\nEnter number of row, then numer of column: (ex A1)");
                string s = Console.ReadLine();
                if (s.Count() == 2)
                {
                    switch (s[0])
                    {
                        case 'A':
                            Row = (int)ERows.A;
                            GoodRow = true;
                            break;
                        case 'B':
                            Row = (int)ERows.B;
                            GoodRow = true;
                            break;
                        case 'C':
                            Row = (int)ERows.C;
                            GoodRow = true;
                            break;
                        case 'D':
                            Row = (int)ERows.D;
                            GoodRow = true;
                            break;
                        case 'E':
                            Row = (int)ERows.E;
                            GoodRow = true;
                            break;
                        case 'F':
                            Row = (int)ERows.F;
                            GoodRow = true;
                            break;
                        case 'G':
                            Row = (int)ERows.G;
                            GoodRow = true;
                            break;
                        default:
                            {
                                GoodRow = false;
                                Console.WriteLine("Invalid Input");
                                break;
                            }
                    }
                    if (Row > nRows)
                    {
                        GoodRow = false;
                    }
                    int column=0;
                    if (!int.TryParse(s.Remove(0, 1), out column))
                    {
                        GoodCol = false;
                    }
                    else
                    {
                        if (column > 0 || column < nCols)
                        {
                            GoodCol = true;
                            Col = int.Parse(s[1].ToString()) - 1;
                        }
                        else
                            GoodCol = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input");
                }
            } while (GoodRow==false || GoodCol == false);
        }
    }
}
