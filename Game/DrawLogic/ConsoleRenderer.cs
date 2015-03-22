using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.DrawLogic
{
    public class ConsoleRenderer : IRenderer
    {

        public void Render(IRenderable obj)
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < obj.Body.GetLength(0); row++)
            {
                for (int col = 0; col < obj.Body.GetLength(1); col++)
                {
                    result.Append(obj.Body[row, col]);
                }
                result.Append('\n');
            }

            Console.WriteLine(result.ToString());
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
