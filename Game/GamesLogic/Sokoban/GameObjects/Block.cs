using Game.HelperClasses;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.GameObjects
{
    public class Block : IGameObject, IMovable
    {
        private Position currentPosition;
        private char[,] blockBody;
        private Position previousPosition;
        private string direction;

        public Block(Position initialPosition)
        {
            this.CurrentPosition = initialPosition;
            this.blockBody = new char[,] {{'G', 'G'},
                                          {'G', 'G'}};
            this.PreviousPosition = new Position(this.currentPosition.X, this.currentPosition.Y);
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

        public char[,] Body
        {
            get
            {
                return this.blockBody;
            }
            set
            {

            }
        }

        public Position PreviousPosition
        {
            get
            {
                return this.previousPosition;
            }
            set
            {
                this.previousPosition = value;
            }
        }

        public string Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
            }
        }
    }
}
