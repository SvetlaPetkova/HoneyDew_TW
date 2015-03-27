using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Game.Interfaces
{
    public interface IGameEvents
    {
        event EventHandler OnKeyboardPressed;

        event EventHandler OnGameFinished;

        void ProcessInput();
    }
}
