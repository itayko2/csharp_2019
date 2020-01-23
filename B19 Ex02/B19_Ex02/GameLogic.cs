/*
 * This class is responsible for the logical part of the game.
 */

using System.Collections.Generic;
namespace B19_Ex02
{
    public class GameLogic
    {
        public enum eGameStatus
        {
            Playing,
            Win,
            Lose,
            Quit
        }

        private const int k_MinNumberOfGuessses = 4;
        private const int k_MaxNumberOfGuesses = 10;
        private List<Round> m_RoundsPlayed = new List<Round>();
        private WordGenerator m_RandomGeneratedWord = new WordGenerator();
        private eGameStatus m_CurrentGameStatus = eGameStatus.Playing;
        private int m_NumberOfUserGuesses;

        public GameLogic(int i_NumberOfUserGuesses)
        {
            m_NumberOfUserGuesses = i_NumberOfUserGuesses;
        }

        public static int GetMinNumberOfGuesses
        {
            get { return k_MinNumberOfGuessses; }
        }

        public static int GetMaxNumberOfGuesses
        {
            get { return k_MaxNumberOfGuesses; }
        }

        public static bool ValidNumberOfGuesses(int i_NumberOfUserGuesses)
        {
            return (k_MinNumberOfGuessses <= i_NumberOfUserGuesses) && (i_NumberOfUserGuesses <= k_MaxNumberOfGuesses);
        }

        public eGameStatus GameStatus
        {
            get { return m_CurrentGameStatus; }
        }

        public string GetRandomGeneratedWord
        {
            get { return m_RandomGeneratedWord.WordStr; }
        }

        public int GetNumberOfUserGuesses
        {
            get { return m_NumberOfUserGuesses; }
        }

        public int GetNumberOfRoundsPlayed()
        {
            return m_RoundsPlayed.Count;
        }

        public string GetRoundWordStr(int i_Round)
        {
            return m_RoundsPlayed[i_Round].WordStr;
        }

        public int GetNumberOfHits(int i_Round)
        {
            return m_RoundsPlayed[i_Round].GetNumberOfHits;
        }

        public int GetNumberOfCorrectLettersInWrongPosition(int i_RoundInd)
        {
            return m_RoundsPlayed[i_RoundInd].GetCorrectLettersInWrongPosition;
        }

        // check for duplicates in the user's guess
        public static bool HasDuplicates(string i_WordStr)
        {
            bool duplicatesExistence = false;
            int numberOfDuplicates;
            for (int i = 0; i < i_WordStr.Length; i++)
            {
                numberOfDuplicates = 1;
                for (int j = i + 1; j < i_WordStr.Length; j++)
                {
                    if (i_WordStr[i].Equals(i_WordStr[j]))
                    {
                        numberOfDuplicates++;
                    }
                }
                if (numberOfDuplicates > 1)
                {
                    duplicatesExistence = true;
                }
            }
            return duplicatesExistence;
        }

        // checks for a vaild word
        public static bool IsValidWord(string i_WordStr)
        {
            bool wordValidity = true;
            foreach (char c in i_WordStr)
            {
                if (!(c >= WordGenerator.MinLetterInWord && c <= WordGenerator.MaxLetterInWord))
                {
                    wordValidity = false;
                    break;
                }
            }
            return wordValidity;
        }

        // updates each round of the game via the user's input.
        public void Play(string i_UserInput)
        {
            Round currentRound = new Round(i_UserInput);
            currentRound.Play(m_RandomGeneratedWord);
            m_RoundsPlayed.Add(currentRound);
            if (currentRound.GetIsWinningRound)
            {
                m_CurrentGameStatus = eGameStatus.Win;
            }

            if (m_RoundsPlayed.Count >= m_NumberOfUserGuesses)
            {
                m_CurrentGameStatus = eGameStatus.Lose;
            }
        }

        public void Quit()
        {
            m_CurrentGameStatus = eGameStatus.Quit;
        }
    }
}
