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
        List<IMovable> movingObjects;
        List<IGameObject> staticObjects;

        public void SeparateObjects(List<IGameObject> listOfObj)
        {
            foreach (var obj in listOfObj)
            {
                if (obj is IMovable)
                {
                    this.movingObjects.Add(obj as IMovable);
                }
                else
                {
                    this.staticObjects.Add(obj);
                }
            }
        }

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

        //in engine
        //public void PrintOrder()
        //{
        //    Render(Field);
        //    foreach (var statObj in staticObjects)
        //    {
        //        Render(statObj);
        //    }
        //    foreach (var movObj in movingObjects)
        //    {
        //        Render(movObj);
        //    } 
        //}
    }
}
