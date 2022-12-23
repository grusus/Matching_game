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
                Console.Write("\n\nEnter number of row, then numer of column (ex A1): ");
                string userInput = Console.ReadLine().ToLower();
                ValidateUserInput(nRows, nCols, userInput);

            } while (GoodRow==false || GoodCol == false);
        }

        private void ValidateUserInput(int nRows, int nCols, string userInput)
        {
            if (userInput.Length == 2)
            {
                ParseToEnum(userInput);
                if (Row > nRows - 1)
                {
                    GoodRow = false;
                }
                if (!int.TryParse(userInput.Remove(0, 1), out int column))
                {
                    GoodCol = false;
                }
                if (column > 0 && column <= nCols)
                {
                    GoodCol = true;
                    Col = int.Parse(userInput[1].ToString()) - 1;
                }
                else
                {
                    GoodCol = false;
                }
            }
            if (userInput.Length != 2 || GoodCol == false || GoodRow == false)
            {
                Console.WriteLine("Invalid input");
            }
        }

        private void ParseToEnum(string userInput)
        {
            switch (userInput[0])
            {
                case 'a':
                    {
                        Row = (int)ERows.A;
                        GoodRow = true;
                        break;
                    }
                case 'b':
                    {
                        Row = (int)ERows.B;
                        GoodRow = true;
                        break;
                    }
                case 'c':
                    {
                        Row = (int)ERows.C;
                        GoodRow = true;
                        break;
                    }
                case 'd':
                    {
                        Row = (int)ERows.D;
                        GoodRow = true;
                        break;
                    }
                default:
                    {
                        GoodRow = false;
                        break;
                    }
            }
        }

        public Move GetMoveAndShowResultToConsole(Board board, int chances)
        {
            Move move = new();
            move.GetMove(board.BoardOfWords.GetLength(0), board.BoardOfWords.GetLength(1));
            if (board.BoardOfWords[move.Row, move.Col].IsHidden == false)
            {
                Console.WriteLine("Field already visible");
                move = GetMoveAndShowResultToConsole(board, chances);
            }
            else
            {
                if (board.BoardOfWords[move.Row, move.Col].IsHidden == true)
                {
                    board.BoardOfWords[move.Row, move.Col].IsHidden = false;
                }
            }
            board.WriteOutBoard(chances);
            return move;
        }
    }
}
