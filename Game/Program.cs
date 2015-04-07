using Game.GameEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Input;

namespace Game
{
    public class Program
    {
        static void Main(string[] args)
        {
            Game.GameEngine.GameEngine ga = new Game.GameEngine.GameEngine();
            ga.StartGame();
        }
    }
}
