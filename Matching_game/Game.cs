using System.Diagnostics;

namespace MatchingGame
{
    public class Game
    {
        private List<string> _words;
        private List<Word> _gameWords;
        private bool _playerWon;
        private int _difficulty;
        private static int _chances;
        private static int _maxChances;
        private readonly HighScore _highScore;

        public Game()
        {
            _gameWords = new List<Word>();
            _highScore = new HighScore();
        }

        public void Play()
        {
            AskPlayerForDifficulty();
            _highScore.DisplayHighScores2();
            Setchances();
            LoadWordsFromFile();
            GenerateListWithWords(_difficulty);
            Board board = new(_difficulty);
            board.GenerateBoard(_gameWords);
            var timer = new Stopwatch();
            timer.Start();
            do
            {
                MainLoop(board);
            } while (CheckIfPlayerWon() == false && _chances > 0);
            timer.Stop();
            ShowResults(timer);
        }

        private void MainLoop(Board board)
        {
            board.WriteOutBoard(_chances);
            Move move = new();
            move = move.GetMoveAndShowResultToConsole(board, _chances);
            Move move2 = new();
            move2 = move2.GetMoveAndShowResultToConsole(board, _chances);
            board.CheckIfWordsAreEqual(board, move, move2);
            Thread.Sleep(2000);
            _chances--;
            _playerWon = true;
        }

        private void ShowResults(Stopwatch timer)
        {
            if (_chances == 0 && _playerWon == false)
            {
                Console.WriteLine("\nYou are out of chances");
                Thread.Sleep(1500);
            }
            if (_playerWon == true)
            {
                TimeSpan timeTaken = timer.Elapsed;
                var usedChances = _maxChances - _chances;
                Console.WriteLine($"\n\nYou win! I took {usedChances} chances, and took {timeTaken.TotalSeconds} seconds");
                _highScore.HandleHighScores(timeTaken, usedChances);
            }
        }

        private void Setchances()
        {
            switch (_difficulty)
            {
                case (int)ELevel.Easy:
                    _chances = 10;
                    _maxChances = 10;
                    break;
                case (int)ELevel.Hard:
                    _chances = 15;
                    _maxChances = 15;
                    break;
            }
        }
       
        private void AskPlayerForDifficulty()
        {
            Console.Clear();
            Console.WriteLine("\nMEMORY GAME\n\n" 
                             + "Choose difficulty:\n"
                             + "\nPress 1 for easy\n"
                             + "Press 2 for hard\n"
                             + "\nand press enter\n");
            Console.Write("\nYour choice: ");
            do
            {
                while (!int.TryParse(Console.ReadLine(), out _difficulty) || (!(_difficulty == (int)ELevel.Easy || _difficulty == (int)ELevel.Hard)))
                {
                    Console.WriteLine("Invalid input, try again");
                }
            } while (!(_difficulty == (int)ELevel.Easy || _difficulty == (int)ELevel.Hard));
            _highScore.SetFile(_difficulty);
        }

        private void LoadWordsFromFile()
        {
            _words = File.ReadAllLines("..\\..\\..\\DataFiles\\Words.txt").ToList();
            
        }
       
        private void GenerateListWithWords(int size)
        {
            var random = new Random();
            for (int i = 0; i < size*4; i++)
            {
                var newWord = new Word();
                int index = random.Next(_words.Count);
                newWord.HiddenWord = _words[index];
                newWord.X = "X";
                newWord.IsHidden = true;
                if (i>0 && _gameWords.Contains(newWord))
                {
                    i--;
                }
                else
                {
                    _gameWords.Add(newWord);
                }
            }
            List<Word> temp = new();
            foreach (var word in _gameWords)
            {
                temp.Add(new Word { HiddenWord = word.HiddenWord, IsHidden = word.IsHidden, X = word.X });
            }
            temp.AddRange(_gameWords);
            _gameWords = temp.OrderBy(a => random.Next()).ToList();
        }

        private bool CheckIfPlayerWon()
        {
            foreach (var word in _gameWords)
            {
                if (word.IsHidden == true)
                {
                    _playerWon = false;
                }
            }
            return _playerWon;
        }
    }
}