
namespace Game.GamesLogic.Sokoban.GameLogic
{
    using Game.GamesLogic.Sokoban.GameObjects;
    using Game.HelperClasses;
    using Game.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class CollisionsDetection
    {
        internal static bool DetectCollission(IGameObject movingObject, IList<IGameObject> objectsToCheck, ref IList<IGameObject> colidedList)
        {
            bool isCollided = false;
            foreach (var obj in objectsToCheck)
            {
                if (!movingObject.Equals(obj))
                {
                    if (DoesIntersect(obj, movingObject))
                    {
                        colidedList.Add(obj);
                        isCollided = true;
                    }
                }
            }

            return isCollided;
        }

        private static bool DoesIntersect(IGameObject obj, IGameObject movingObject)
        {
            int minX = movingObject.CurrentPosition.X;
            int maxX = movingObject.CurrentPosition.X + movingObject.Body.GetLength(1) - 1;
            int minY = movingObject.CurrentPosition.Y ;
            int maxY = movingObject.CurrentPosition.Y + movingObject.Body.GetLength(0) - 1;

            int minObjX = obj.CurrentPosition.X;
            int maxObjX = obj.CurrentPosition.X + obj.Body.GetLength(1) - 1;
            int minObjY = obj.CurrentPosition.Y;
            int maxObjY = obj.CurrentPosition.Y + obj.Body.GetLength(0) - 1;

            if ((minX >= minObjX && minX <= maxObjX) || (maxX >= minObjX && maxX <= maxObjX))
            {
                if ((minY >= minObjY && minY <= maxObjY) || (maxY >= minObjY && maxY <= maxObjY))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
