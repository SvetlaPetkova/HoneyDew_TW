using Game.GamesLogic.Hangman.GameObjects;
using Game.GamesLogic.InitialGame.GameObjects;
using Game.GamesLogic.Sokoban.GameObjects;
using Game.DrawLogic;
using Game.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DrawLogic
{
    public class ConsoleBuilder
    {
        public GameField StartGameDraw(GameField gameField, Character character)
        {
            int halfField = Console.BufferWidth / 2;
            int startRow = 0;
            int startColHangmanTitle = halfField + (halfField / 2 - HangmanTitle.title.GetLength(1) / 2);
            int startColSocobanTitle = halfField - (halfField / 2 + SocobanTitle.title.GetLength(1) / 2);
            gameField = this.DrawBorder(halfField, gameField, character );
            this.StartGameTitle(startRow, startColSocobanTitle, SocobanTitle.title, gameField);
            this.StartGameTitle(startRow, startColHangmanTitle, HangmanTitle.title, gameField);

            return gameField;
        }

        private GameField StartGameTitle(int row, int col, char[,] title, GameField obj)
        {
            for (int i = row; i < title.GetLength(0); i++)
            {
                for (int j = col; j < col + title.GetLength(1); j++)
                {
                    obj.Body[i + 1, j] = title[i, j - col];
                }
            }

            return obj;
        }

        private GameField DrawBorder(int col, GameField obj, Character charachter)
        {
            for (int i = 0; i < obj.Body.GetLength(0)- charachter.Body.GetLength(0) ; i++)
            {
                obj.Body[i, col] = '|';
            }

            return obj;
        }
    }
}
