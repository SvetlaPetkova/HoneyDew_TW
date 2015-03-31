using Game.HelperClasses;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.GameObjects
{
    public class Character : IGameObject, IRenderable
    {
        private Position currentPosition;
        private char[,] charachterBody;

        public Character()
        {
            this.CurrentPosition = new Position(8, 8);
            this.charachterBody = new char[,] {{'^', ' '},
                                               {'<','>'}};
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
    }
}
