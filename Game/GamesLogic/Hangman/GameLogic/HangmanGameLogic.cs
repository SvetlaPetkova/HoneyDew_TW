namespace Game.GamesLogic.Hangman.GameLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading;

    using Game.GamesLogic.Hangman.GameObjects;
    using Game.HelperClasses;
    using ConsoleApplication1;
    using Game.Interfaces;

    public class HangmanGameLogic
    {
        private const int TakeRowsForTitle = 9;

        private HangmanCharacter character;
        private Word currentWord;
        private ISet<char> usedLetters;
        public bool ShouldPassControl { get; set; }

        public IList<IRenderable> GameObjects { get; set; }

        public HangmanGameLogic()
        {
            InitAlphabet();

            this.character = new HangmanCharacter(new Position(1, 2));
            this.currentWord = new Word(new Position(1, 30), Word.PickWord());
            this.GameObjects = new List<IRenderable> { character, currentWord };
            this.ShouldPassControl = false;

            this.usedLetters = new HashSet<char>();
        }

        private static void InitAlphabet()
        {
            if (!Alphabet.isInitialised)
            {
                Alphabet.InitialiseAlphabet();
            }
        }
        

        public void HandleHangmanKeyboardInputs(object sender, EventArgs e)
        {
            
            //get console input
            GameEventArgs keyboardArgs = (GameEventArgs)e;
            bool flag = keyboardArgs.KeyboardCurrentState == KeyboardState.Escape;
            if (flag)
            {
                while (Console.KeyAvailable)
                {
                    Console.ReadKey(false);
                }
                this.ShouldPassControl = true;
                return;
            }

            ConsoleKeyInfo pressedKeyInfo = keyboardArgs.KeyInfo;

            char input = pressedKeyInfo.KeyChar;
            //check if entered character is a letter
            if (!char.IsLetter(input))
            {
                return;
            }
            char letter = Char.ToUpper(input);

            //check if entered letter is entered before
            if (this.usedLetters.Contains(letter))
            {
                this.character.usedLetterFlag = true;
                this.character.usedLetter = letter;
                this.character.UpdateBody();
                this.character.usedLetterFlag = false;
                //Console.WriteLine("You have already told {0}", letter);
                //Thread.Sleep(2000);

                return;
            }
            //else this.character.usedLetter = false;
            

            //if word contains the letter
            if (this.currentWord.PickedWord.Contains(letter.ToString()) && char.IsLetter(letter))
            {
                this.character.UpdateBody();
                this.usedLetters.Add(letter);
                this.currentWord.UpdateWord(letter);
                CheckForWin();
                return;
            }

            //if word does not contain the letter
            if (char.IsLetter(letter))
            {
                this.usedLetters.Add(letter);
                character.Lives--;
                CheckForLoss();
                this.character.UpdateBody();
                return;
            }
        }

        private void CheckForLoss()
        {
            if (character.IsLose())
            {
                Console.Clear();
                Console.WriteLine("YOU LOOSE!!!");

                this.ShouldPassControl = true;
                Thread.Sleep(2000);
            }
            // TO DO return result to the game engine
        }

        private void CheckForWin()
        {
            if (this.currentWord.IsRevield)
            {
                Console.Clear();
                Console.WriteLine("YOU WIN!!!");

                this.ShouldPassControl = true;

                Thread.Sleep(2000);
            }
            // TO DO return result to the game engine
        }

       

    }
}
