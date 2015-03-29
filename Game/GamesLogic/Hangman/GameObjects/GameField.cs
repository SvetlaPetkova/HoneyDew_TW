namespace Game.GamesLogic.Hangman.GameObjects
{
    using System;

    public class GameField
    {
        private char[,] field;

        public GameField(int rows, int cols)
        {
            Console.BufferHeight = rows;
            Console.BufferWidth = cols;
            this.field = new char[rows, cols];
        }

        public int GetCols()
        {
            return this.field.GetLength(1);
        }

        public int GetRows()
        {
            return this.field.GetLength(0);
        }
    }
}
