using Game.HelperClasses;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.GameObjects
{
    public class SocobanCharacter : IGameObject, IRenderable, IMovable
    {
        private Position currentPosition;
        private char[,] charachterBody;
        private Position previousPosition;
        private string direction;

        public SocobanCharacter()
        {
            this.CurrentPosition = new Position(8, 8);
            this.charachterBody = new char[,] {{'^', '^'},
                                               {'<', '>'}};
            this.previousPosition = new Position(this.currentPosition.X, this.currentPosition.Y);
            this.Direction = "none";
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

        public override bool Equals(object obj)
        {
            if (!(obj is SocobanCharacter))
            {
                return false;
            }
            if ((obj as SocobanCharacter).Direction != this.Direction)
            {
                return false;
            }
            if ((obj as SocobanCharacter).currentPosition != this.currentPosition)
            {
                return false;
            }
            if ((obj as SocobanCharacter).previousPosition != this.previousPosition)
            {
                return false;
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + this.currentPosition.GetHashCode();
                hash = hash * 23 + this.PreviousPosition.GetHashCode();
                hash = hash * 23 + this.Direction.GetHashCode();
                return hash;
            }
        }
    }
}
