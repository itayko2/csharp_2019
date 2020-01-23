/*
 * This class is the entry point to our program.
 */

namespace B19_Ex02
{
    public class Program
    {
        public static void Main()
        {
            runGameInterface();
        }

        private static void runGameInterface()
        {
            GameInterface userInterface = new GameInterface();
            userInterface.StartNewGame();
        }
    }
}