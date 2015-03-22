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
                if (keyInfo.Key.Equals(ConsoleKey.RightArrow))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Right;
                }
                if (keyInfo.Key.Equals(ConsoleKey.DownArrow))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Down;
                }
                if (keyInfo.Key.Equals(ConsoleKey.UpArrow))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Up;
                }
                if (keyInfo.Key.Equals(ConsoleKey.Escape))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Escape;
                }
                if (keyInfo.Key.Equals(ConsoleKey.E))
                {
                    gameArgs.KeyboardCurrentState = KeyboardState.Action;
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

    //public event RoutedEventHandler onKeyboardEvent;

    //public event EventHandler onGameFinished;

    //public void CheckIfSomeoneAttached()
    //{
    //    if(this.onKeyboardEvent != null)
    //    {
    //        this.onKeyboardEvent.Invoke(new Object(), new RoutedEventArgs(Keyboard.PreviewLostKeyboardFocusEvent));
    //    }
    //}
}
