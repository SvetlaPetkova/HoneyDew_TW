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

            PutPressKeyTextOnField(field);

            return field;
        }
        private void PutPressKeyTextOnField(char[,] field)
        {
            field[2, 2] = 'P';
            field[2, 3] = 'R';
            field[2, 4] = 'E';
            field[2, 5] = 'S';
            field[2, 6] = 'S';
            field[2, 7] = ' ';
            field[2, 8] = '"';
            field[2, 9] = 'E';
            field[2, 10] = 'S';
            field[2, 11] = 'C';
            field[2, 12] = '"';
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
