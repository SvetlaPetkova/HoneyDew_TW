using Game.DrawLogic;
using Game.GamesLogic.InitialGame;
using Game.GamesLogic.InitialGame.GameObjects;
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
    public static class GameEngine
    {
        private static GameField field;
        private static IRenderer renderer;
        private static InitialGameLogic initialGameLogic;
        private static GameEvents gameEvents;

        public static void StartGame()
        {
            InitializeVariables();
            StartGameLoop();
        }

        public static void AttachListenersToKeyboard()
        {
            gameEvents.OnKeyboardPressed += initialGameLogic.HandleKeyboardInputs;
            //TODO: attach handlers of other game logics here
        }

        private static void StartGameLoop()
        {
            AttachListenersToKeyboard();
            while(true)
            {
                gameEvents.ProcessInput();
                //move character on field charachter to field
                initialGameLogic.MoveCharachterOnField(field);

                if(initialGameLogic.ExitThisGameAnPassControlToOther)
                {
                    GoIntoAnotherGameLoop();
                }

                //render all
                renderer.Render(field);
                Thread.Sleep(20);
                renderer.Clear();
            }
        }

        private static void GoIntoAnotherGameLoop()
        {
            //AnotherGame.Start();
            Console.Clear();
            while (true)
            {
                //if(endGameCondition)
                //{
                //    break;
                //}
            }
        }

        private static void InitializeVariables()
        {
            field = new GameField();
            renderer = new ConsoleRenderer();
            initialGameLogic = new InitialGameLogic();
            gameEvents = new GameEvents();
        }
    }
}
