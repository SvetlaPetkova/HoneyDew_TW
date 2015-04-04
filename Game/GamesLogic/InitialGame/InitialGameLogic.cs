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
        private Character character;
        private Action subGame;

        public Action SubGame
        {
            get { return subGame; }
            set { subGame = value; }
        }

        public Character Character
        {
            get { return character; }
            set { character = value; }
        }
        

        public InitialGameLogic(IRenderer renderer, IGameEvents gameEvent)
        {
            this.sokobanGE = new SokobanGameEngine(renderer,gameEvent);
            this.hangmanGE = new HangmanGameEngine(renderer, gameEvent);
            this.PassControlToSomeoneElse = false;
            this.Character = new Character();
        }

        public bool PassControlToSomeoneElse { get; set; }


        

        public void HandleKeyboardInputs(object sender, EventArgs e)
        {
            GameEventArgs keyboardArgs = (GameEventArgs)e;
            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Left)
            {
                if(this.Character.CurrentPosition.X > 0)
                {
                    this.character.PreviousPosition.Y = this.character.CurrentPosition.Y;
                    this.character.PreviousPosition.X = this.character.CurrentPosition.X;
                    this.Character.CurrentPosition.X--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Right)
            {
                if(this.character.CurrentPosition.X < 75)
                {
                    this.character.PreviousPosition.Y = this.character.CurrentPosition.Y;
                    this.character.PreviousPosition.X = this.character.CurrentPosition.X;
                    this.Character.CurrentPosition.X++;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Up)
            {
                if (this.Character.CurrentPosition.Y > 6)
                {
                    this.character.PreviousPosition.Y = this.character.CurrentPosition.Y;
                    this.character.PreviousPosition.X = this.character.CurrentPosition.X;
                    this.Character.CurrentPosition.Y--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Down)
            {
                if (this.Character.CurrentPosition.Y < 75)
                {
                    this.character.PreviousPosition.Y = this.character.CurrentPosition.Y;
                    this.character.PreviousPosition.X = this.character.CurrentPosition.X;
                    this.Character.CurrentPosition.Y++;
                }
            }

            if(keyboardArgs.KeyboardCurrentState == KeyboardState.Action)
            {
                this.PassControlToSomeoneElse = true;
                if(this.Character.CurrentPosition.X <= Console.WindowWidth / 2)
                {
                    this.subGame = new Action(sokobanGE.StartSokoban);
                }
                else if (this.Character.CurrentPosition.X > Console.WindowWidth / 2)
                {
                    this.subGame = new Action(hangmanGE.StartGame);
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
