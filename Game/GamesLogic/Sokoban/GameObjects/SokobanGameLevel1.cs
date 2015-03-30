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

            // This cycle fill the old walls with '0' so we don't need it any more
            //for (int row = 0, col = 0; row < rows; row++, col++)
            //{
            //    field[row, 0] = '0';
            //    field[row, cols] = '0';
            //    field[0, col] = '0';
            //    field[cols, col] = '0';
            //}
            PutPressKeyTextOnField(field);

            return field;
        }
        private void PutPressKeyTextOnField(char[,] field)
        {
            field[21, 2] = 'P';
            field[21, 3] = 'R';
            field[21, 4] = 'E';
            field[21, 5] = 'S';
            field[21, 6] = 'S';
            field[21, 7] = ' ';
            field[21, 8] = '"';
            field[21, 9] = 'E';
            field[21, 10] = 'S';
            field[21, 11] = 'C';
            field[21, 12] = '"';
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
