
namespace Game.GamesLogic.Sokoban.GameObjects
{
    using Game.HelperClasses;
    using Game.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Wall : IGameObject, IRenderable
    {
        private Position currentPosition;
        public Wall(Position initialPosition, WallDirection direction, int length)
        {
            this.CurrentPosition = initialPosition;
            this.Direction = direction;
            this.Length = length;
            ConstructBody(1, this.Length, this.Direction);
        }
        public WallDirection Direction { get; private set; }
        public int Length { get; private set; }

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

        public char[,] Body { get; private set; }

        private void ConstructBody(int width, int lenght, WallDirection direction)
        {
            int rowMax;
            int colMax;
            if (direction == WallDirection.Horizontal)
            {
                rowMax = width;
                colMax = lenght;
                this.Body = new char[rowMax, colMax];
            }
            else
            {
                rowMax = lenght;
                colMax = width;
                this.Body = new char[rowMax, colMax];
            }
            for (int row = 0; row < rowMax; row++)
            {
                for (int col = 0; col < colMax; col++)
                {
                    this.Body[row, col] = '█';
                }

            }
        }

    }
}
