using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.HelperClasses
{
    public class GameEventArgs : EventArgs
    {
        public bool IsGameFinished { get; set; }

        public KeyboardState KeyboardCurrentState { get; set; }
    }
}
