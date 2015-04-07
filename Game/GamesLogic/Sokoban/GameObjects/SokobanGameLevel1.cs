using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.GameObjects
{
    public class SokobanGameLevel1 : IRenderable
    {
        private char[,] gameField;

        public SokobanGameLevel1()
        {
            this.Body = InitializeGameField();
        }

        private char[,] InitializeGameField()
        {
            var field = new char[42, 42];
            var rows = 40;
            var cols = 40;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = ' ';
                }
            }

            return field;
        }

        public char[,] Body
        {
            get
            {
                return this.gameField;
            }
            set
            {
                this.gameField = value;
            }
        }
    }
}
