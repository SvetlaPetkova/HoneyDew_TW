using Game.HelperClasses;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.InitialGame.GameObjects
{
    public class Character : IGameObject
    {
        private char[,] charachterBody;
        private Position currentPosition;

        public Character()
        {
            this.Body = InitializeCharachterBody();
            this.CurrentPosition = new Position(20, 20);
        }

        private char[,] InitializeCharachterBody()
        {
            return new char[,] {{' ', '0',' ','0',' '},
                                {' ', ' ','^',' ',' '},
                                {'*', ' ',' ',' ','*'},
                                {' ', '*','*','*',' '},};
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
                if (value.GetLength(0) > 6 || value.GetLength(1) > 6)
                {
                    throw new ArgumentException("The body you're trying to set is larger than 6x6 maximum.");
                }
                this.charachterBody = value;
            }
        }
    }
}
