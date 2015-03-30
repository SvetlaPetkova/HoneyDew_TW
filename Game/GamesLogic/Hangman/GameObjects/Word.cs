namespace Game.GamesLogic.Hangman.GameObjects
{
    using ConsoleApplication1;
    using Game.HelperClasses;
    using Game.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Word : IGameObject
    {
        private static string[] words = new string[] {
                                                      "COMPLY", "THREE", "VACATION", "INFORMATION", "TECHNOLOGY", "ORLANDO",
                                                      "COMPUTER", "ROUTER", "PRINTER", "SOFTWARE", "HARDWARE", "OBJECTIVE",
                                                      "FILE", "EMPLOYEE", "SECURITY", "DATA", "REPORT", "PROPERTY", "OWNERSHIP" 
                                                     };
        private string pickedWord;
        private char[,] body;
        private List<bool> lettersState; //if letter is hidden its position in this list is set to false
        private Position currentPosition;

        public Word(Position wordPosition, string pickedWord)
        {
            this.PickedWord = pickedWord;
            this.CurrentPosition = wordPosition;
            SetLettersInitialState(pickedWord.Length);
            this.UpdateBody();
        }

        public Word()
        {

        }

        public string PickedWord
        {
            get { return pickedWord; }
            private set { pickedWord = value; }
        }

        public Position CurrentPosition
        {
            get
            {
                return this.currentPosition;
            }
            set
            {
                this.currentPosition = value;
            }
        }

        public bool IsRevield { get; private set; }

        public char[,] Body
        {
            get
            {
                return this.body;
            }
            set
            {
                this.body = value;
            }
        }

        public void UpdateBody()
        {
            if (this.PickedWord == null)
            {
                throw new ArgumentException("Word must be picked before a body can be created.");
            }

            List<char[,]> newWordRepresentation = GetWordPicture();

            int newbodyHeight = 0;
            int newBodyLenght = 0;
            foreach (var letter in newWordRepresentation)
            {
                newBodyLenght += letter.GetLength(1);
                newbodyHeight = Math.Max(newbodyHeight, letter.GetLength(0));
            }

            char[,] newBody = new char[newbodyHeight, newBodyLenght];
            int currentLetterPosition = 0;
            foreach (var letter in newWordRepresentation)
            {
                PutLetterIntoWord(newBody, currentLetterPosition, letter);
                currentLetterPosition += letter.GetLength(1);
            }
            this.body = newBody;
        }
        private void PutLetterIntoWord(char[,] body, int index, char[,] letter)
        {
            for (int i = 0; i < letter.GetLength(0); i++)
            {
                for (int j = 0; j < letter.GetLength(1); j++)
                {
                    body[i, index + j] = letter[i, j];
                }
            }
        }
        private List<char[,]> GetWordPicture()
        {
            List<char[,]> newWordRepresentation = new List<char[,]>();

            for (int letterIndex = 0; letterIndex < this.PickedWord.Length; letterIndex++)
            {
                char letter = this.PickedWord[letterIndex];
                char[,] letterRepresentation;

                if (this.lettersState[letterIndex] == true)
                {
                    letterRepresentation = Alphabet.GetLetter(letter);
                }
                else
                {
                    letterRepresentation = Alphabet.GetLetter(' ');
                }

                newWordRepresentation.Add(letterRepresentation);

            }
            return newWordRepresentation;
        }

        private void SetLettersInitialState(int p)
        {
            this.lettersState = new List<bool>();
            foreach (var letter in this.PickedWord)
            {
                this.lettersState.Add(false);
            }
        }

        public static string PickWord()
        {
            var random = new Random();
            int index = random.Next(0, words.Length);
            return words[index];
        }

        public void UpdateWord(char letter)
        {
            for (int i = 0; i < this.PickedWord.Length; i++)
            {
                if (PickedWord[i] == letter)
                {
                    this.lettersState[i] = true;
                }
            }
            this.UpdateBody();

            if (!this.lettersState.Contains(false))
            {
                this.IsRevield = true;
            }
        }
    }
}
