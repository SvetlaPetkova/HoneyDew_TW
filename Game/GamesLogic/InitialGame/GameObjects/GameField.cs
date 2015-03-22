﻿using Game.Interfaces;
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
            var field = new char[80, 80];
            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int col = 0; col < field.GetLength(1); col++)
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
