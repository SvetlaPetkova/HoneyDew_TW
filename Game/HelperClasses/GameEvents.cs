using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Game.HelperClasses
{
    public class GameEvents : IGameEvents
    {
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                var gameArgs = new GameEventArgs();

                if (keyInfo.Key.Equals(ConsoleKey.LeftArrow))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Left;
                }
                else if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Right;
                }
                else if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Down;
                }
                else if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Up;
                }
                else if (keyInfo.Key.Equals(ConsoleKey.Escape))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Escape;
                }
                else if (keyInfo.Key.Equals(ConsoleKey.Enter))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Action;
                }
                else
                {
                    gameArgs.KeyInfo = keyInfo;
                    gameArgs.KeyboardCurrentState = KeyboardState.None;
                }

                if (this.OnKeyboardPressed != null)
                {
                    this.OnKeyboardPressed(this, gameArgs);
                }
            }
        }

        public event EventHandler OnKeyboardPressed;

        public event EventHandler OnGameFinished;
    }
}
