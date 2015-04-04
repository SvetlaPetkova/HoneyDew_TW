using Game.HelperClasses;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.GameObjects
{
    public class Character : IGameObject, IRenderable, IMovable
    {
        private Position currentPosition;
        private char[,] charachterBody;
        private Position previousPosition;
        private string direction;

        public Character()
        {
            this.CurrentPosition = new Position(8, 8);
            this.charachterBody = new char[,] {{'^', ' '},
                                               {'<','>'}};
            this.previousPosition = new Position(this.currentPosition.X, this.currentPosition.Y);
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
                return this.charachterBody;
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
