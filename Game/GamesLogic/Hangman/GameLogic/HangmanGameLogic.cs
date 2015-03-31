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
        private bool gameEnded;

        public List<IRenderable> GameObjects { get; set; }

        public HangmanGameLogic()
        {
            InitAlphabet();

            this.character = new Character(new Position(1, 2));
            this.currentWord = new Word(new Position(1, 30), Word.PickWord());
            this.GameObjects = new List<IRenderable> { character, currentWord };

            this.usedLetters = new HashSet<char>();
            this.GameEnded = false;

        }

        private static void InitAlphabet()
        {
            if (!Alphabet.isInitialised)
            {
                Alphabet.InitialiseAlphabet();
            }
        }

        public bool GameEnded
        {
            get { return gameEnded; }
            private set { gameEnded = value; }
        }

        public void HandleHangmanKeyboardInputs(object sender, EventArgs e)
        {
            //get console input
            GameEventArgs keyboardArgs = (GameEventArgs)e;
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
                Thread.Sleep(2000);

                this.GameEnded = true;
            }
            // TO DO return result to the game engine
        }

        private void CheckForWin()
        {
            if (this.currentWord.IsRevield)
            {
                Console.Clear();
                Console.WriteLine("YOU WIN!!!");
                Thread.Sleep(2000);
                this.GameEnded = true;
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
