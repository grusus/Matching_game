namespace MatchingGame
{
    public class Board
    {
        public Word[,] BoardOfWords { get; set; }
        private int _size;
        
        public Board(int size)
        {
            _size = size;
        }

        public void GenerateBoard(List<Word> list)
        {
            int index = 0;
            BoardOfWords = new Word[2*_size, 4];
            for (int i = 0 ; i < BoardOfWords.GetLength(0); i++)
            {
                for (int j = 0 ; j < BoardOfWords.GetLength(1) ; j++)
                {
                    BoardOfWords[i, j] = list[index];
                    index++;
                }
            }
        }

        public void WriteOutBoard(int chances)
        {
            Console.Clear();
            Console.WriteLine($"\nChances left: {chances}");
            Console.Write("\n   ");
            for (int i = 1; i <= BoardOfWords.GetLength(1); i++)
            {
                Console.Write($"       {i}       ");
            }
            Console.WriteLine();
            for (int i = 0; i < BoardOfWords.GetLength(0); i++)
            {
                ERows rows = (ERows)i;
                Console.Write($" {rows} ");
                for (int j = 0; j < BoardOfWords.GetLength(1); j++)
                {
                    Console.Write("{0,14}",BoardOfWords[i, j].GetWord());
                    if (j < BoardOfWords.GetLength(1)-1)
                    {
                        Console.Write("|");
                    }
                }
                if (i < BoardOfWords.GetLength(0)-1)
                {
                    Console.Write("\n   ");
                    for (int j = 0; j < BoardOfWords.GetLength(1)*15; j++)
                    {
                        Console.Write("-");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
