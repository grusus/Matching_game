namespace MatchingGame
{
    public class HighScore
    {
        private string _filePath;
        private ReadWriteFile _fileHandler;

        public HighScore()
        {
            _fileHandler = new ReadWriteFile();
        }

        public void SetFile(int difficulty)
        {
            if (difficulty == (int)ELevel.Easy)
                _filePath = "..\\..\\..\\DataFiles\\HighScoresEasy.json";
            else
                _filePath = "..\\..\\..\\DataFiles\\HighScoresHard.json";
        }

        public void HandleHighScores(TimeSpan timeTaken, int tries)
        {
            _fileHandler.Highscores = ReadHighScores();
            AddToHighScore(timeTaken, tries);
            DisplayHighScores(_fileHandler.Highscores);
        }

        public void DisplayHighScores2()
        {
            _fileHandler.Highscores = ReadHighScores();
            DisplayHighScores(_fileHandler.Highscores);
        }

        private void AddToHighScore(TimeSpan timeTaken, int tries)
        {
            Console.WriteLine("Enter your name for Highscores! (max 10 characters)");
            string name = Console.ReadLine();
            if (name.Length > 10)
            {
                name = name.Substring(0, 10);
            }
            var player = new Player() { Name = name, DateTime = DateTime.Now, Duration = timeTaken.TotalSeconds, Tries = tries};
            _fileHandler.Highscores.Add(player);
            ReadWriteFile.WriteToJsonFile(_filePath, _fileHandler.Highscores);
        }

        private List<Player> ReadHighScores()
        {
            return ReadWriteFile.ReadFromJsonFile<Player>(_filePath);
        }

        private void DisplayHighScores(List<Player> HighScores)
        {
            Console.Clear();
            Console.WriteLine("------------------------HIGHSCORES-------------------------\n"
                            + "   |     Name   |         Date        |   Duration  | Tries");
            if (HighScores.Count > 0)
            {
                var sorted = HighScores.OrderBy(x => x.Tries).ToList();
                var sorted2 = sorted.OrderBy(x => x.Duration).ToList();
                HighScores = sorted2;
                int count;
                if (HighScores.Count < 10)
                {
                    count = HighScores.Count;
                }
                else
                {
                    count = 10;
                }

                for (int i = 0; i < count; i++)
                {
                    Console.WriteLine("{0,2} | {1,10} | {2,19} | {3,10}s | {4,3}", i + 1, HighScores[i].Name, HighScores[i].DateTime, HighScores[i].Duration, HighScores[i].Tries);
                }
            }
            Console.Write("Press enter to continue...");
            Console.ReadLine();
        }
    }
}
