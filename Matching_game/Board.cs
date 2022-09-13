using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame
{
    public class Board
    {
        public Word[,] BoardOfWords { get; set; }
        public Board(int size)
        {
            
        }
        public void GenerateBoard(List<Word> list)
        {
            int index = 0;
            BoardOfWords = new Word[2, 4];
            for (int i = 0 ; i < BoardOfWords.GetLength(0); i++)
            {
                for (int j = 0 ; j < BoardOfWords.GetLength(1) ; j++)
                {
                    BoardOfWords[i, j] = list[index];
                    index++;
                }
            }
        }
        public void WriteOutBoard()
        {
            Console.Clear();
            Console.Write("   ");
            for (int i = 1; i <= BoardOfWords.GetLength(1); i++)
            {
                Console.Write($"      {i}      ");
            }
            Console.WriteLine();
            for (int i = 0; i < BoardOfWords.GetLength(0); i++)
            {
                ERows rows = (ERows)i;
                Console.Write($" {rows} ");
                for (int j = 0; j < BoardOfWords.GetLength(1); j++)
                {
                    Console.Write("{0,12}",BoardOfWords[i, j].GetWord());
                    if (j < BoardOfWords.GetLength(1)-1)
                    {
                        Console.Write("|");
                    }
                }
                if (i < BoardOfWords.GetLength(0)-1)
                {
                    Console.Write("\n   ");
                    for (int j = 0; j < BoardOfWords.GetLength(1)*13; j++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
