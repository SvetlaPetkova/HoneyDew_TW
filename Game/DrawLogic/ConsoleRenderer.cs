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

        public void DrawObjects(IRenderable field, IList<IRenderable> objects)
        {

            foreach (IGameObject obj in objects)
            {
                if (obj is IMovable)
                {
                    ClearAroundCharachter(ref field, (IMovable)obj);
                }

                for (int row = 0; row < obj.Body.GetLength(0); row++)
                {

                    for (int col = 0; col < obj.Body.GetLength(1); col++)
                    {
                        var currentY = obj.CurrentPosition.Y;
                        var currentX = obj.CurrentPosition.X;

                        field.Body[row + currentY, col + currentX] = obj.Body[row, col];
                    }
                }
            }
            Render(field);
        }

        private void ClearAroundCharachter(ref IRenderable field, IMovable movingObject)
        {
            for (int i = 0; i < movingObject.Body.GetLength(0); i++)
            {
                for (int j = 0; j < movingObject.Body.GetLength(1); j++)
                {
                    movingObject = movingObject as IMovable;
                    field.Body[i + movingObject.PreviousPosition.Y, j + movingObject.PreviousPosition.X] = ' ';
                }
            }
        }

    }
}
