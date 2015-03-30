using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Interfaces;
using Game.HelperClasses;

namespace Game.GamesLogic.InitialGame.GameObjects
{
    public class Wall : IGameObject
    {
        private int width;
        private int lenght;
        private bool isFallen;
        private static char fill = '█';

        public Wall(int width, int lenght, Position position)
        {
            this.Width = width;
            this.Lenght = lenght;
            this.CurrentPosition = position;
            ConstructBody();
        }

        public char[,] Body { get; set; }

        public Position CurrentPosition { get; set; }

        public int Width
        {
            get { return width; }
            private set { width = value; }
        }

        public int Lenght
        {
            get { return lenght; }
            private set { lenght = value; }
        }

        public bool State
        {
            get { return isFallen; }
            set { isFallen = value; }
        }
        
        private void ConstructBody()
        {
            int bodyMaxRow;
            int bodyMaxCol;

            if (this.isFallen == false)
            {
                bodyMaxCol = this.Width;
                bodyMaxRow = this.Lenght;
            }
            else
            {
                bodyMaxCol = this.Lenght;
                bodyMaxRow = this.Width;      
            }

            for (int row = 0; row < bodyMaxRow; row++)
            {
                for (int col = 0; col < bodyMaxCol; col++)
                {
                    this.Body[row, col] = Wall.fill;
                }
                
            }
        }

    }
}
