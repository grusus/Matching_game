using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchingGame
{
    public class Game
    {
        public List<string> Words { get; set; }
        public List<Word> GameWords { get; set; }
        private bool PlayerWon { get; set; }

        public Game()
        {
            GameWords = new List<Word>();
        }

        public void Play()
        {
            LoadWordsFromFile();
            GenerateListWithWords(6);
            WriteOutList();
            Board board = new(4);
            board.GenerateBoard(GameWords);
            do
            {
                board.WriteOutBoard();
                Move move = new();
                move.GetMove(board.BoardOfWords.GetLength(1), board.BoardOfWords.GetLength(0));
                Console.WriteLine("{0} {1}", move.Row, move.Col);
                if (board.BoardOfWords[move.Row, move.Col].IsHidden == true)
                    board.BoardOfWords[move.Row, move.Col].IsHidden = false;
                board.WriteOutBoard();
                Move move2 = new();
                move2.GetMove(board.BoardOfWords.GetLength(1), board.BoardOfWords.GetLength(0));
                Console.WriteLine("{0} {1}", move.Row, move.Col);
                if (board.BoardOfWords[move2.Row, move2.Col].IsHidden == true)
                    board.BoardOfWords[move2.Row, move2.Col].IsHidden = false;
                board.WriteOutBoard();
                if (!(board.BoardOfWords[move2.Row, move2.Col].HiddenWord == board.BoardOfWords[move.Row, move.Col].HiddenWord))
                {
                    board.BoardOfWords[move2.Row, move2.Col].IsHidden = true;
                    board.BoardOfWords[move.Row, move.Col].IsHidden = true;
                }
                Thread.Sleep(2000);
                board.WriteOutBoard();
                PlayerWon = true;
            } while (CheckIfPlayerWon()==false);
        }

        public void LoadWordsFromFile()
        {
            Words = File.ReadAllLines(@"Words.txt").ToList();
            
        }
       
        public void GenerateListWithWords(int size)
        {
            var random = new Random();
            for (int i = 0; i <= size/2; i++)
            {
                var newWord = new Word();
                int index = random.Next(Words.Count);
                newWord.HiddenWord = Words[index];
                newWord.X = "X";
                newWord.IsHidden = true;
                if (i>0 && GameWords.Contains(newWord))
                {
                    i--;
                }
                else
                {
                    GameWords.Add(newWord);
                }
            }
            List<Word> temp = new();
            foreach (var word in GameWords)
                temp.Add(new Word { HiddenWord = word.HiddenWord, IsHidden = word.IsHidden, X = word.X });
            temp.AddRange(GameWords);
            GameWords = temp.OrderBy(a => random.Next()).ToList();
           // GameWords = temp;
        }

        public void WriteOutList()
        {
            foreach (var word in GameWords)
                Console.WriteLine(word.GetWord()+ " "+ word.X);
        }
        private bool CheckIfPlayerWon()
        {
            foreach (var word in GameWords)
                if (word.IsHidden == true)
                    PlayerWon = false;
            return PlayerWon;
        }
    }
}