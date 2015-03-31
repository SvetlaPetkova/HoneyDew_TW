using Game.DrawLogic;
using Game.GamesLogic.Hangman.Engine;
using Game.GamesLogic.InitialGame;
using Game.GamesLogic.InitialGame.GameObjects;
using Game.GamesLogic.Sokoban.Engine;
using Game.HelperClasses;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.GameEngine
{
    public class GameEngine
    {
        private GameField field;
        private IRenderer renderer;
        private InitialGameLogic initialGameLogic;
        private GameEvents gameEvents;
        //
        //

        public void StartGame()
        {
            InitializeVariables();
            StartGameLoop();
        }

        public void AttachListenersToKeyboard()
        {
            gameEvents.OnKeyboardPressed += initialGameLogic.HandleKeyboardInputs;
        }
        public void DetachistenersFromKeyboard()
        {
            gameEvents.OnKeyboardPressed -= initialGameLogic.HandleKeyboardInputs;
        }

        private void StartGameLoop()
        {
            AttachListenersToKeyboard();
            while (true)
            {
                gameEvents.ProcessInput();
                //move character on field charachter to field
                initialGameLogic.MoveCharachterOnField(field);

                
                if (initialGameLogic.PassControlToSomeoneElse)
                {
                    DetachistenersFromKeyboard();
                    //GoToHangmanGameLoop();
                    AttachListenersToKeyboard();
                    initialGameLogic.PassControlToSomeoneElse = false;
                }
              

                //render all
                renderer.Render(field);
                Thread.Sleep(20);
                renderer.Clear();
            }
        }

        private void InitializeVariables()
        {
            this.field = new GameField();
            this.renderer = new ConsoleRenderer();
            this.gameEvents = new GameEvents();
            this.initialGameLogic = new InitialGameLogic(renderer, gameEvents);
        }
    }
}
