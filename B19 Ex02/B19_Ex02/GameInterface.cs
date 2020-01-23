/*
 * This class is responssible for the UI of the game.
 */

using System;
using System.Text;

namespace B19_Ex02
{
    public class GameInterface
    {
        private readonly int r_MaxWordLenWithSpaces = (WordGenerator.LengthOfWord * 2) - 1;
        private GameLogic m_CurrentGame = null;

        private int getNumOfGuessesFromUser()
        {
            string userInputStr = string.Empty;
            bool isValidInput = false;
            bool isInputNumber = false;
            int userInputNumber = GameLogic.GetMinNumberOfGuesses;

            while (!isValidInput)
            {
                Console.WriteLine("Please enter the number of guesses and press ENTER. (number range - {0} to {1}):", GameLogic.GetMinNumberOfGuesses, GameLogic.GetMaxNumberOfGuesses);
                userInputStr = Console.ReadLine();
                if (!(isInputNumber = int.TryParse(userInputStr, out userInputNumber)))
                {
                    Console.WriteLine("This input is invalid, please try again.");
                }
                else if (!GameLogic.ValidNumberOfGuesses(userInputNumber))
                {
                    Console.WriteLine("This number is out of range, please enter a number in range.");
                }
                else
                {
                    isValidInput = true;
                }
            }
            return userInputNumber;
        }

        private string guessFromUser()
        {
            string userInput = string.Empty;
            int legalInputLen = WordGenerator.LengthOfWord;
            bool userResponse = false;
            while (!userResponse)
            {
                Console.WriteLine("Please type your next guess <A B C D> or 'Q' to quit");
                userInput = Console.ReadLine().Replace(" ", string.Empty).ToUpper();
                if (userInput.ToUpper().Equals("Q"))
                {
                    userResponse = true;
                }
                else if (userInput.Length != legalInputLen)
                {
                    Console.WriteLine("Invalid length of guess. Please Try again.");
                }
                else if (!GameLogic.IsValidWord(userInput))
                {
                    Console.WriteLine("Only upper or lower case letters between '{0}' and '{1}' are allowed.", WordGenerator.MinLetterInWord, WordGenerator.MaxLetterInWord);
                }
                else if (GameLogic.HasDuplicates(userInput))
                {
                    Console.WriteLine("Each letter in your guess may appear once. Please Try again.");
                }
                else
                {
                    userResponse = true;
                }
            }

            return userInput;
        }

        private void restartGame()
        {
            string willingToPlayAgain = string.Empty;
            bool userResponse = false;
            Console.WriteLine("Would you like to start a new game? <Y/N>");
            willingToPlayAgain = Console.ReadLine();
            while (!userResponse)
            {
                if (willingToPlayAgain.ToUpper().Equals("Y"))
                {
                    StartNewGame();
                    userResponse = true;
                }
                else if (willingToPlayAgain.ToUpper().Equals("N"))
                {
                    quitState();
                    userResponse = true;
                }
                else
                {
                    Console.WriteLine("Error - please insert Y/N");
                    willingToPlayAgain = Console.ReadLine();
                }
            }
        }

        private void printBoard()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Current board status:");
            printTitleRows();
            printRows();
            Console.WriteLine(" ");
        }

        private void printTitleRows()
        {
            StringBuilder rowTitleString = new StringBuilder();
            rowTitleString.Append("|Pins:    |Result:|");
            Console.WriteLine(rowTitleString);
            printRowSeperator();
            printRow("####", string.Empty);
            printRowSeperator();
        }

        private void printRowSeperator()
        {
            StringBuilder rowSeperator = new StringBuilder();
            rowSeperator.Append("|=========|=======|");
            Console.WriteLine(rowSeperator);
        }

        private void printRows()
        {
            string usersGuess = string.Empty;
            string matchesString = string.Empty;
            int numberOfHits; // hit is a correct guess in the right index
            int numOfCorrectLetterInWrongPositions;
            for (int i = 0; i < m_CurrentGame.GetNumberOfUserGuesses; i++)
            {
                if (i < m_CurrentGame.GetNumberOfRoundsPlayed())
                {
                    usersGuess = m_CurrentGame.GetRoundWordStr(i);
                    numberOfHits = m_CurrentGame.GetNumberOfHits(i);
                    numOfCorrectLetterInWrongPositions = m_CurrentGame.GetNumberOfCorrectLettersInWrongPosition(i);
                    matchesString = createGuessFeedback(numberOfHits, numOfCorrectLetterInWrongPositions);
                }
                else
                {
                    usersGuess = string.Empty;
                    matchesString = string.Empty;
                }
                printRow(usersGuess, matchesString);
                printRowSeperator();
            }
        }

        private string createGuessFeedback(int i_NumOfHits, int i_NumOfCorrectLetterInWrongPositions)
        {
            StringBuilder feedbackString = new StringBuilder();
            feedbackString.AppendFormat(new string('V', i_NumOfHits));
            feedbackString.AppendFormat(new string('X', i_NumOfCorrectLetterInWrongPositions));
            return feedbackString.ToString();
        }

        private void printRow(string i_UserGuess, string i_FeedbackString)
        {
            StringBuilder rowString = new StringBuilder();
            string formattedUserGuessStr = addSpacesBetweenLetters(i_UserGuess);
            string formattedFeedbackStr = addSpacesBetweenLetters(i_FeedbackString);
            rowString.Append("| ");
            rowString.Append(formattedUserGuessStr.PadRight(WordGenerator.LengthOfWord * 2));
            rowString.Append('|');
            rowString.Append(formattedFeedbackStr.PadRight((WordGenerator.LengthOfWord * 2) - 1));
            rowString.Append('|');
            Console.WriteLine(rowString);
        }

        private string addSpacesBetweenLetters(string i_Str)
        {
            StringBuilder spacedStr = new StringBuilder();
            foreach (char letter in i_Str)
            {
                spacedStr.Append(letter);
                spacedStr.Append(' ');
            }
            if (spacedStr.Length != 0)
            {
                spacedStr.Remove(spacedStr.Length - 1, 1);
            }
            return spacedStr.ToString();
        }

        public void StartNewGame()
        {
            Ex02.ConsoleUtils.Screen.Clear();
            m_CurrentGame = new GameLogic(getNumOfGuessesFromUser());
            printBoard();
            while (m_CurrentGame.GameStatus.Equals(GameLogic.eGameStatus.Playing))
            {
                run();
            }
        }

        private void run()
        {
            while (m_CurrentGame.GameStatus.Equals(GameLogic.eGameStatus.Playing))
            {
                playRound();
            }
            switch (m_CurrentGame.GameStatus)
            {
                case GameLogic.eGameStatus.Win:
                    winState();
                    break;
                case GameLogic.eGameStatus.Lose:
                    loseState();
                    break;
                case GameLogic.eGameStatus.Quit:
                    quitState();
                    break;
                default:
                    break;
            }
        }

        private void playRound()
        {
            string userGuess = guessFromUser();
            if (!userGuess.ToUpper().Equals("Q"))
            {
                m_CurrentGame.Play(userGuess);
                printBoard();
            }
            else
            {
                m_CurrentGame.Quit();
            }
        }

        private void winState()
        {
            Console.WriteLine("You guessed after {0} steps!", m_CurrentGame.GetNumberOfRoundsPlayed());
            restartGame();
        }

        private void loseState()
        {
            Console.WriteLine("No more guesses allowed. You Lost.");
            Console.WriteLine("The correct sequence is: {0}", m_CurrentGame.GetRandomGeneratedWord);
            restartGame();
        }

        private void quitState()
        {
            Console.WriteLine("Thanks for playing, see you soon!");
        }
    }
}