/*
 * This class generates the random word and compares it to the player's guess.
*/

using System;

namespace B19_Ex02
{
    public class WordGenerator
    {
        private const int k_LengthOfWord = 4;
        private const char k_MinLetterInWord = 'A';
        private const char k_MaxLetterInWord = 'H';
        private static Random s_RandomGenerator = new Random();
        private string m_WordStr = string.Empty;

        // generates a random word
        public WordGenerator()
        {
            char currentRandomChar = (char)s_RandomGenerator.Next(k_MinLetterInWord, k_MaxLetterInWord + 1);
            for (int i = 0; i < k_LengthOfWord; i++)
            {
                while (m_WordStr.Contains(currentRandomChar.ToString()))
                {
                    currentRandomChar = (char)s_RandomGenerator.Next(k_MinLetterInWord, k_MaxLetterInWord + 1);
                }

                m_WordStr = string.Concat(m_WordStr, currentRandomChar);
            }
        }

        public WordGenerator(string i_WordStr)
        {
            m_WordStr = i_WordStr;
        }

        public static int LengthOfWord
        {
            get { return k_LengthOfWord; }
        }

        public static char MinLetterInWord
        {
            get { return k_MinLetterInWord; }
        }

        public static char MaxLetterInWord
        {
            get { return k_MaxLetterInWord; }
        }

        public string WordStr
        {
            get { return m_WordStr; }
        }

        // compares the words and check if the positions correct
        public void CheckGuess(WordGenerator i_CompareToWord, out int o_NumberOfHits, out int o_CorrectLettersInWrongPosition)
        {
            int charIndex = 0;
            o_NumberOfHits = 0; // hit is a correct guess in the right index
            o_CorrectLettersInWrongPosition = 0;
            foreach (char c in m_WordStr)
            {
                if (i_CompareToWord.m_WordStr.Contains(c.ToString()))
                {
                    if (charIndex == i_CompareToWord.m_WordStr.IndexOf(c))
                    {
                        o_NumberOfHits++;
                    }
                    else
                    {
                        o_CorrectLettersInWrongPosition++;
                    }
                }
                charIndex++;
            }
        }
    }
}
