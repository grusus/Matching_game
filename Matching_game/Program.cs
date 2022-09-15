namespace MatchingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                var game = new Game();
                game.Play();
            } while (PlayAgain());
        }

        private static bool PlayAgain()
        {
            Console.Clear();
            Console.WriteLine("\nWant to play again?\n"
                            + "\nPrees y for yes."
                            + "\nPress any key to exit.\n"
                            + "\nand press enter\n\n");
            Console.Write("Your choice: ");
            string repeat = Console.ReadLine();
            if (repeat.ToLower() == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
