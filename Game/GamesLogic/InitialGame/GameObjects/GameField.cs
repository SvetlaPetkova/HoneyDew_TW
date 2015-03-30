using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.InitialGame.GameObjects
{
    public class GameField : IRenderable
    {
        private char[,] gameField;

        public GameField()
        {
            this.Body = InitializeGameField();
        }

        private char[,] InitializeGameField()
        {
            var field = new char[50, 100];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
                {
                    field[row, col] = ' ';
                }
            }
            PutPressKeyTextOnField(field);
            return field;
        }

        private void PutPressKeyTextOnField(char[,] field)
        {
            field[4, 10] = 'P';
            field[4, 11] = 'R';
            field[4, 12] = 'E';
            field[4, 13] = 'S';
            field[4, 14] = 'S';
            field[4, 15] = ' ';
            field[4, 16] = '"';
            field[4, 17] = 'E';
            field[4, 18] = 'N';
            field[4, 19] = 'T';
            field[4, 20] = 'E';
            field[4, 21] = 'R';
            field[4, 22] = '"';
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
