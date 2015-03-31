    using Game.DrawLogic;
    using Game.GamesLogic.Hangman.GameLogic;
    using Game.GamesLogic.Hangman.GameObjects;
    using Game.HelperClasses;
    using Game.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

namespace Game.GamesLogic.Hangman.Engine
{
    public class HangmanGameEngine
    {
        private IRenderer renderer;
        private HangmanGameLogic hangmanGameLogic;
        private IGameEvents gameEvents;
        private GameField field;

        public HangmanGameEngine(IRenderer renderer, IGameEvents gameEvents)
        {
            this.renderer = renderer;
            this.gameEvents = gameEvents;
            this.hangmanGameLogic = new HangmanGameLogic();
            this.field = new GameField();
        }

        public void AttachListenersToKeyboard()
        {
            this.gameEvents.OnKeyboardPressed += this.hangmanGameLogic.HandleHangmanKeyboardInputs;
        }
        public void DetachListenersFromKeyboard()
        {
            this.gameEvents.OnKeyboardPressed -= this.hangmanGameLogic.HandleHangmanKeyboardInputs;
        }
        public void StartGame()
        {
            this.renderer.Clear();

            //AttachListenersToKeyboard();
            this.AttachListenersToKeyboard();

            hangmanGameLogic.ShouldPassControl = false;
            while (true)
            {
                this.gameEvents.ProcessInput();

                //render all
                this.hangmanGameLogic.DrawHangManGameObjects(field);
                renderer.Render(field);

                Thread.Sleep(700);
                renderer.Clear();

                if (this.hangmanGameLogic.ShouldPassControl)
                {
                    DetachListenersFromKeyboard();

                    break;
                }
            }

        }

    }
}

