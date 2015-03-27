using Game.HelperClasses;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.GameObjects
{
    public class Block : IGameObject
    {
        private Position currentPosition;
        private char[,] blockBody;

        public Block(Position initialPosition)
        {
            this.CurrentPosition = initialPosition;
            this.blockBody = new char[,] {{'G', 'G'},
                                          {'G', 'G'}};
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
    }
}
