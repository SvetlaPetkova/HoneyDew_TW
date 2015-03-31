using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GameEngine;
using Game.Interfaces;
using Game.GamesLogic;
using Game;

namespace Game
{
    class Test
    {
        public static void Main()
        {
            Console.WindowWidth = Console.BufferWidth = 101;
            Console.WindowHeight = Console.BufferHeight = 51;

            GameEngine.GameEngine ga = new GameEngine.GameEngine();
            ga.StartGame();
        }
    }
}
