
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

        public char[,] Body { get; private set; }


    }
}

