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
            var field = new char[22, 22];
            var rows = 20;
            var cols = 20;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    field[row, col] = ' ';
                }
            }
            for (int row = 0, col = 0; row < rows; row++, col++)
            {
                field[row, 0] = '0';
                field[row, cols] = '0';
                field[0, col] = '0';
                field[cols, col] = '0';
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
