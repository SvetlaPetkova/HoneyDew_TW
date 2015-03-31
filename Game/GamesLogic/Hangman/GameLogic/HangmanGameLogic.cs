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

        private Character character;
        private Word currentWord;
        private ISet<char> usedLetters;
        public bool ShouldPassControl { get; set; }

        public List<IRenderable> GameObjects { get; set; }

        public HangmanGameLogic()
        {
            InitAlphabet();

            this.character = new Character(new Position(1, 2));
            this.currentWord = new Word(new Position(1, 40), Word.PickWord());
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
                Console.WriteLine("You have already told {0}", letter);
                return;
            }

            //if word contains the letter
            if (this.currentWord.PickedWord.Contains(letter.ToString()) && char.IsLetter(letter))
            {
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
                Console.WriteLine("YOU LOOSE!!!");
                this.ShouldPassControl = true;
            }
            // TO DO return result to the game engine
        }

        private void CheckForWin()
        {
            if (this.currentWord.IsRevield)
            {
                Console.WriteLine("YOU WIN!!!");
                this.ShouldPassControl = true;
            }
            // TO DO return result to the game engine
        }

        public void DrawHangManGameObjects(IRenderable field)
        {
            foreach (IGameObject obj in this.GameObjects)
            {
                for (int row = 0; row < obj.Body.GetLength(0); row++)
                {
                    for (int col = 0; col < obj.Body.GetLength(1); col++)
                    {
                        var currentY = obj.CurrentPosition.Y;
                        var currentX = obj.CurrentPosition.X;
                        field.Body[row + currentY, col + currentX] = obj.Body[row, col];
                    }
                }
            }
        }

    }
}
