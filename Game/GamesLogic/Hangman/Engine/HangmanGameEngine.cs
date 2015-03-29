namespace Game.GamesLogic.Hangman.Engine
{
    using Game.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using Game.GamesLogic.Hangman.GameObjects;
    using Game.GamesLogic.Hangman.GameLogic;
    using System.Text;

    public class HangmanGameEngine
    {
        private HangmanGameLogic hangmanGame;

        public HangmanGameEngine(int rows, int cols)
        {
            this.hangmanGame = new HangmanGameLogic(rows, cols);
        }

        public void StartHangman()
        {
            this.hangmanGame.Play();
        }
    }
}

