using Game.DrawLogic;
using Game.GamesLogic.InitialGame.GameObjects;
using Game.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Game.GamesLogic.Sokoban.Engine;
using Game.GamesLogic.Hangman.Engine;
using Game.Interfaces;

namespace Game.GamesLogic.InitialGame
{
    public class InitialGameLogic
    {
        private SokobanGameEngine sokobanGE;
        private HangmanGameEngine hangmanGE;
        private Character charachter;

        public InitialGameLogic(IRenderer renderer, IGameEvents gameEvent)
        {
            this.sokobanGE = new SokobanGameEngine(renderer,gameEvent);
            this.hangmanGE = new HangmanGameEngine(renderer, gameEvent);
            this.PassControlToSomeoneElse = false;
            this.charachter  = new Character();
        }

        public bool PassControlToSomeoneElse { get; set; }

        public void MoveCharachterOnField(GameField field)
        {

            ClrearAroundCharachter(ref field);
            for (int row = 0; row < this.charachter.Body.GetLength(0); row++)
            {
                for (int col = 0; col < this.charachter.Body.GetLength(1); col++)
                {
                    var currentY = this.charachter.CurrentPosition.Y;
                    var currentX = this.charachter.CurrentPosition.X;
                    field.Body[(currentY + row), (currentX + col)] = this.charachter.Body[row, col];
                }
            }
        }

        private void ClrearAroundCharachter(ref GameField field)
        {
            for (int i = 0; i < field.Body.GetLength(0); i++)
            {
                for (int j = 0; j < field.Body.GetLength(1); j++)
                {
                    if (!char.IsLetter(field.Body[i, j]))
                    {
                        field.Body[i, j] = ' ';
                    }
                }
            }
        }


        public void HandleKeyboardInputs(object sender, EventArgs e)
        {
            GameEventArgs keyboardArgs = (GameEventArgs)e;
            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Left)
            {
                if(this.charachter.CurrentPosition.X > 0)
                {
                    this.charachter.CurrentPosition.X--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Right)
            {
                if(this.charachter.CurrentPosition.X < 75)
                {
                    this.charachter.CurrentPosition.X++;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Up)
            {
                if (this.charachter.CurrentPosition.Y > 6)
                {
                    this.charachter.CurrentPosition.Y--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Down)
            {
                if (this.charachter.CurrentPosition.Y < 75)
                {
                    this.charachter.CurrentPosition.Y++;
                }
            }

            if(keyboardArgs.KeyboardCurrentState == KeyboardState.Action)
            {
                this.PassControlToSomeoneElse = true;
                if(this.charachter.CurrentPosition.X <= Console.WindowWidth / 2)
                {
                    sokobanGE.StartSokoban();
                }
                else if (this.charachter.CurrentPosition.X > Console.WindowWidth / 2)
                {
                    hangmanGE.StartGame();
                }
            }

        }

        private void GoToSokobanGameLoop()
        {
            sokobanGE.StartSokoban();
        }
        private void GoToHangmanGameLoop()
        {
            hangmanGE.StartGame();
        }
    }
}
