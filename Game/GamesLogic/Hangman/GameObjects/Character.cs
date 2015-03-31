using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Game.HelperClasses;

namespace Game.GamesLogic.Hangman.GameObjects
{
    public class Character : IGameObject
    {
        //TO DO initialize in the constructor using values from file and set maximum restrictions
        private const int InitialLives = 7;
        private const int PictureWidth = 50;

        private char[,] characterBody;
        private Position currentPosition;
        public bool usedLetterFlag = false;
        public char usedLetter;
        private int lives;

        public Character(Position position)
        {
            this.Lives = Character.InitialLives;
            this.CurrentPosition = position;
            UpdateBody();
        }
        public char[,] Body
        {
            get
            {
                return this.characterBody;
            }
            set
            {
                this.characterBody = value;
            }
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

        public int Lives
        {
            get
            {
                return this.lives;
            }
            set
            {
                this.lives = value;
            }
        }

        public bool IsLose()
        {
            if (this.Lives == 0)
            {
                return true;
            }

            return false;
        }

        public void UpdateBody()
        {
            //create new body
            List<string> picture = GetCharackterBody();
            int pictureHight = picture.Count;
            int pictureWidth = picture.Last().Length;
            char[,] newBody = new char[pictureHight, pictureWidth];

            for (int i = 0; i < pictureHight; i++)
            {
                string row = picture[i];
                for (int j = 0; j < row.Length; j++)
                {
                    newBody[i, j] = row[j];
                }
            }

            //update the old body with the new 
            this.characterBody = newBody;
        }

        // TO DO read from files the picture states   
        public List<string> GetCharackterBody()
        {

            var picture = new List<string>();
            if (this.usedLetterFlag == true) picture.Add("You have already told this letter " + usedLetter);
            else picture.Add("");            
            if (this.Lives == 7)
            {
                picture.Add("     __________________");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |________________________");
                picture.Add("       |                       | ");
                picture.Add("       |                       |");
                picture.Add("       |                       |__________");
                picture.Add("       |                                 |");
                picture.Add("       |                                 |");
                picture.Add(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 6)
            {
                picture.Add("     __________________");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |               ( )   ");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |________________________");
                picture.Add("       |                       | ");
                picture.Add("       |                       |");
                picture.Add("       |                       |__________");
                picture.Add("       |                                 |");
                picture.Add("       |                                 |");
                picture.Add(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 5)
            {
                picture.Add("     __________________");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |               ( )   ");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |________________________");
                picture.Add("       |                       | ");
                picture.Add("       |                       |");
                picture.Add("       |                       |__________");
                picture.Add("       |                                 |");
                picture.Add("       |                                 |");
                picture.Add(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 4)
            {
                picture.Add("     __________________");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |               ( )   ");
                picture.Add("       |             \\  |");
                picture.Add("       |              \\ |");
                picture.Add("       |               \\|");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |________________________");
                picture.Add("       |                       | ");
                picture.Add("       |                       |");
                picture.Add("       |                       |__________");
                picture.Add("       |                                 |");
                picture.Add("       |                                 |");
                picture.Add(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 3)
            {
                picture.Add("     __________________");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |               ( )   ");
                picture.Add("       |             \\  |  /");
                picture.Add("       |              \\ | /");
                picture.Add("       |               \\|/");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |________________________");
                picture.Add("       |                       | ");
                picture.Add("       |                       |");
                picture.Add("       |                       |__________");
                picture.Add("       |                                 |");
                picture.Add("       |                                 |");
                picture.Add(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 2)
            {
                picture.Add("     __________________");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |               ( )   ");
                picture.Add("       |             \\  |  /");
                picture.Add("       |              \\ | /");
                picture.Add("       |               \\|/");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |________________________");
                picture.Add("       |                       | ");
                picture.Add("       |                       |");
                picture.Add("       |                       |__________");
                picture.Add("       |                                 |");
                picture.Add("       |                                 |");
                picture.Add(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 1)
            {
                picture.Add("     __________________");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |               ( )   ");
                picture.Add("       |             \\  |  /");
                picture.Add("       |              \\ | /");
                picture.Add("       |               \\|/");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |               /");
                picture.Add("       |              / ");
                picture.Add("       |             / ");
                picture.Add("       |            / ");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |________________________");
                picture.Add("       |                       | ");
                picture.Add("       |                       |");
                picture.Add("       |                       |__________");
                picture.Add("       |                                 |");
                picture.Add("       |                                 |");
                picture.Add(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 0)
            {
                picture.Add("     __________________");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |               ( )   ");
                picture.Add("       |             \\  |  /");
                picture.Add("       |              \\ | /");
                picture.Add("       |               \\|/");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |                |");
                picture.Add("       |               / \\");
                picture.Add("       |              /   \\");
                picture.Add("       |             /     \\");
                picture.Add("       |            /       \\");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |");
                picture.Add("       |________________________");
                picture.Add("       |                       | ");
                picture.Add("       |                       |");
                picture.Add("       |                       |__________");
                picture.Add("       |                                 |");
                picture.Add("       |                                 |");
                picture.Add(new string('_', Character.PictureWidth));
            }

            return picture;
        }

    }
}
