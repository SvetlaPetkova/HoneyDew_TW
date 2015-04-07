
namespace Game.GamesLogic.Sokoban.GameObjects
{
    using Game.HelperClasses;
    using Game.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Elevator : IGameObject, IRenderable
    {
        private Position currentPosition;
        private char[,] elevatorBody;

        public Elevator(Position initialPosition)
        {
            this.CurrentPosition = initialPosition;
            this.Body = new char[,] {{'X', 'X'},
                                          {'X', 'X'}};
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
        public bool IsFull 
        { 
            get; 
            set; 
        }

        public char[,] Body
        {
            get
            {
                return this.elevatorBody;
            }
            private set
            {
                this.elevatorBody = value;
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Elevator))
            {
                return false;
            }
            if ((obj as Elevator).IsFull != this.IsFull)
            {
                return false;
            }
            if ((obj as Elevator).currentPosition != this.currentPosition)
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
                hash = hash * 23 + this.IsFull.GetHashCode();
                return hash;
            }
        }
    }
}
    
