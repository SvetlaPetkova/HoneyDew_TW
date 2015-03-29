using System;
using System.Collections.Generic;
using System.Text;
namespace Game.GamesLogic.Hangman.GameObjects
{
    public class Character
    {
        private const int InitialLives = 7;
        private const int PictureWidth = 50;

        private int lives;

        public Character()
        {
            this.Lives = Character.InitialLives;
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
                
        public void DrawCharacter(int row, int col)
        {

            var picture = new StringBuilder();


            if (this.Lives == 7)
            {
                picture.AppendLine("     __________________");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |________________________");
                picture.AppendLine("       |                       | ");
                picture.AppendLine("       |                       |");
                picture.AppendLine("       |                       |__________");
                picture.AppendLine("       |                                 |");
                picture.AppendLine("       |                                 |");
                picture.AppendLine(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 6)
            {
                picture.AppendLine("     __________________");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |               ( )   ");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |________________________");
                picture.AppendLine("       |                       | ");
                picture.AppendLine("       |                       |");
                picture.AppendLine("       |                       |__________");
                picture.AppendLine("       |                                 |");
                picture.AppendLine("       |                                 |");
                picture.AppendLine(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 5)
            {
                picture.AppendLine("     __________________");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |               ( )   ");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |________________________");
                picture.AppendLine("       |                       | ");
                picture.AppendLine("       |                       |");
                picture.AppendLine("       |                       |__________");
                picture.AppendLine("       |                                 |");
                picture.AppendLine("       |                                 |");
                picture.AppendLine(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 4)
            {
                picture.AppendLine("     __________________");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |               ( )   ");
                picture.AppendLine("       |             \\  |");
                picture.AppendLine("       |              \\ |");
                picture.AppendLine("       |               \\|");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |________________________");
                picture.AppendLine("       |                       | ");
                picture.AppendLine("       |                       |");
                picture.AppendLine("       |                       |__________");
                picture.AppendLine("       |                                 |");
                picture.AppendLine("       |                                 |");
                picture.AppendLine(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 3)
            {
                picture.AppendLine("     __________________");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |               ( )   ");
                picture.AppendLine("       |             \\  |  /");
                picture.AppendLine("       |              \\ | /");
                picture.AppendLine("       |               \\|/");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |________________________");
                picture.AppendLine("       |                       | ");
                picture.AppendLine("       |                       |");
                picture.AppendLine("       |                       |__________");
                picture.AppendLine("       |                                 |");
                picture.AppendLine("       |                                 |");
                picture.AppendLine(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 2)
            {
                picture.AppendLine("     __________________");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |               ( )   ");
                picture.AppendLine("       |             \\  |  /");
                picture.AppendLine("       |              \\ | /");
                picture.AppendLine("       |               \\|/");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |________________________");
                picture.AppendLine("       |                       | ");
                picture.AppendLine("       |                       |");
                picture.AppendLine("       |                       |__________");
                picture.AppendLine("       |                                 |");
                picture.AppendLine("       |                                 |");
                picture.AppendLine(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 1)
            {
                picture.AppendLine("     __________________");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |               ( )   ");
                picture.AppendLine("       |             \\  |  /");
                picture.AppendLine("       |              \\ | /");
                picture.AppendLine("       |               \\|/");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |               /");
                picture.AppendLine("       |              / ");
                picture.AppendLine("       |             / ");
                picture.AppendLine("       |            / ");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |________________________");
                picture.AppendLine("       |                       | ");
                picture.AppendLine("       |                       |");
                picture.AppendLine("       |                       |__________");
                picture.AppendLine("       |                                 |");
                picture.AppendLine("       |                                 |");
                picture.AppendLine(new string('_', Character.PictureWidth));
            }
            else if (this.Lives == 0)
            {
                picture.AppendLine("     __________________");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |               ( )   ");
                picture.AppendLine("       |             \\  |  /");
                picture.AppendLine("       |              \\ | /");
                picture.AppendLine("       |               \\|/");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |                |");
                picture.AppendLine("       |               / \\");
                picture.AppendLine("       |              /   \\");
                picture.AppendLine("       |             /     \\");
                picture.AppendLine("       |            /       \\");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |");
                picture.AppendLine("       |________________________");
                picture.AppendLine("       |                       | ");
                picture.AppendLine("       |                       |");
                picture.AppendLine("       |                       |__________");
                picture.AppendLine("       |                                 |");
                picture.AppendLine("       |                                 |");
                picture.AppendLine(new string('_', Character.PictureWidth));
            }

            Console.SetCursorPosition(col, row);
            Console.WriteLine(picture.ToString());
        }
    }
}
