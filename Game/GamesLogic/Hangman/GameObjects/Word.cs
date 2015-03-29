namespace Game.GamesLogic.Hangman.GameObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Word
    {
        private static string[] words = new string[] {
                                                      "COMPLY", "THREE", "VACATION", "INFORMATION", "TECHNOLOGY", "ORLANDO",
                                                      "COMPUTER", "ROUTER", "PRINTER", "SOFTWARE", "HARDWARE", "OBJECTIVE",
                                                      "FILE", "EMPLOYEE", "SECURITY", "DATA", "REPORT", "PROPERTY", "OWNERSHIP" 
                                                     };

        public static string PickWord()
        {
            var random = new Random();
            int index = random.Next(0, words.Length);
            return words[index];
        }

        public static string GetInvisibleWord(ISet<char> usedLetters, string word)
        {
            var output = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                if (usedLetters.Contains(word[i]))
                {
                    output.Append(word[i].ToString() + " ");
                }
                else
                {
                    output.Append("_ ");
                }
            }
            return output.ToString();
        }

        public static string TakeNotGuessedLettersAsString(ISet<char> usedLetters)
        {
            var output = new StringBuilder();
            return output.Append(string.Format("Used letters: {0}", string.Join(", ", usedLetters))).ToString();
        }
    }
}
