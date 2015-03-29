namespace Game.GamesLogic.Hangman.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    using Game.GamesLogic.Hangman.GameObjects;

    public class HangmanGameLogic
    {
        private const int TakeRowsForTitle = 9;

        private Character character;
        private GameField field;
        private string word;
        private ISet<char> usedLetters = new HashSet<char>();
        private ISet<char> notGuessedLetters = new HashSet<char>();

        public HangmanGameLogic(int rows, int cols)
        {
            this.character = new Character();
            this.field = new GameField(rows, cols);
            this.word = Word.PickWord();
        }

        public void Play()
        {
            HangmanTitle.Print(this.field.GetRows() - HangmanGameLogic.TakeRowsForTitle, this.field.GetCols());
            int printRow = this.field.GetRows() / 2;
            int printCol = this.field.GetCols() / 2 + (this.field.GetCols() / 4 - word.Length);

            while (true)
            {
                // Console.Clear();
                // character.DrawCharacter(this.field.GetRows() / 4, 2);
                // Console.SetCursorPosition(printCol, printRow);
                string guessedWord = Word.GetInvisibleWord(usedLetters, word);
                // Console.WriteLine(guessedWord);



                if (word == guessedWord.Replace(" ", string.Empty))
                {
                    // Console.Clear();
                    // character.DrawCharacter(this.field.GetRows() / 4, 2);
                    // Console.SetCursorPosition(printCol, printRow);
                    // Console.WriteLine("YOU WIN!");
                    // HangmanTitle.Print(this.field.GetRows() - HangmanGameLogic.TakeRowsForTitle, this.field.GetCols());
                    return;
                }

               // Console.SetCursorPosition(printCol - "Used letters: ".Length, printRow + 2);
               // Console.WriteLine(Word.TakeNotGuessedLettersAsString(notGuessedLetters));

                // HangmanTitle.Print(this.field.GetRows() - HangmanGameLogic.TakeRowsForTitle, this.field.GetCols());

                char letter = this.TakeInputLetter(0, 0);

                if (this.usedLetters.Contains(letter))
                {
                    // Console.SetCursorPosition(0, 1);
                    // Console.WriteLine("You have already told {0}", letter);
                }
                else if (!this.usedLetters.Contains(letter) && !word.Contains(letter.ToString()))
                {
                    this.notGuessedLetters.Add(letter);
                    character.Lives--;
                }

                this.usedLetters.Add(letter);

                if (character.IsLose())
                {
                    // Console.Clear();
                    // character.DrawCharacter(this.field.GetRows() / 4, 2);
                    // Console.SetCursorPosition(printCol, printRow);
                    // Console.WriteLine("GAME OVER!");
                    // Console.SetCursorPosition(printCol, printRow + 1);
                    // Console.WriteLine("WORD: {0}", word);
                    // HangmanTitle.Print(this.field.GetRows() - HangmanGameLogic.TakeRowsForTitle, this.field.GetCols());
                    return;
                }

                Thread.Sleep(700);
            }
        }

        private char TakeInputLetter(int row, int col)
        {
           // Console.SetCursorPosition(row, col);
           // Console.Write("Enter a letter: ");
            ConsoleKeyInfo guessedLetter = Console.ReadKey();
            string letter = guessedLetter.KeyChar.ToString().ToUpper();


            return letter[0];
        }

        private void Clear(int row, int col)
        {
            Console.SetCursorPosition(row, col);
            Console.WriteLine(new string(' ', col));
        }
    }
}
