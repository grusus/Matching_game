using Newtonsoft.Json;

namespace MatchingGame
{
    public class ReadWriteFile
    {
        public List<Player> Highscores { get; set; }

        public ReadWriteFile()
        {
            Highscores = new List<Player>();
        }

        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public static List<T> ReadFromJsonFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                reader = new StreamReader(filePath);
                var fileContents = reader.ReadToEnd();
                //return JsonConvert.DeserializeObject<T>(fileContents);
                List<T> items = JsonConvert.DeserializeObject <List<T>>(fileContents);
                return items;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }
    }
}
