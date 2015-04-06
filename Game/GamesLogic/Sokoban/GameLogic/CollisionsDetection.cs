
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
        public static bool MovingLeft(IEnumerable<IGameObject> objects, Character character)
        {
            bool cannotMove = false;
            var horisontalWlls = objects.Where(x => x is Wall).Where(y => (y as Wall).Direction == WallDirection.Horizontal).ToList();

            foreach (Wall walls in horisontalWlls)
            {
                if(character.CurrentPosition.X - walls.Length == walls.CurrentPosition.X
                   // && character.CurrentPosition.Y >= walls.CurrentPosition.Y +1
                    && (character.CurrentPosition.Y == walls.CurrentPosition.Y
                    || character.CurrentPosition.Y + 1 == walls.CurrentPosition.Y))
                {
                    cannotMove = true;
                }
            }

            return cannotMove;
        }
        public static bool MovingUp(IEnumerable<IGameObject> objects, Character character)
        {
            bool cannotMove = false;
            var horisontalWlls = objects.Where(x => x is Wall).Where(y => (y as Wall).Direction == WallDirection.Horizontal).ToList();

            foreach (Wall walls in horisontalWlls)
            {
                if (character.CurrentPosition.Y - 1 == walls.CurrentPosition.Y
                    && (character.CurrentPosition.X >= walls.CurrentPosition.X - 1
                    && character.CurrentPosition.X <= walls.CurrentPosition.X + walls.Length - 1))
                    
                {
                    cannotMove = true;
                }
            }


            return cannotMove;
        }

        public static bool MovingDown(IEnumerable<IGameObject> objects, Character character)
        {
            bool cannotMove = false;
            var horisontalWlls = objects.Where(x => x is Wall).Where(y => (y as Wall).Direction == WallDirection.Horizontal).ToList();

            foreach (Wall walls in horisontalWlls)
            {
                if (character.CurrentPosition.Y + 2 == walls.CurrentPosition.Y
                    && (character.CurrentPosition.X + 1 >= walls.CurrentPosition.X
                    && character.CurrentPosition.X < walls.CurrentPosition.X + walls.Length))
                    
                {
                    cannotMove = true;
                }
            }

            return cannotMove;
        }

        public static bool MovingRight(IEnumerable<IGameObject> objects, Character character)
        {
            bool cannotMove = false;
            var horisontalWlls = objects.Where(x => x is Wall).Where(y => (y as Wall).Direction == WallDirection.Horizontal).ToList();

            foreach (Wall walls in horisontalWlls)
            {
                if (character.CurrentPosition.X + 2 == walls.CurrentPosition.X
                    && (character.CurrentPosition.Y == walls.CurrentPosition.Y
                    || character.CurrentPosition.Y == walls.CurrentPosition.Y - 1))
                {
                    cannotMove = true;
                }
            }

            return cannotMove;
        }
    }
}
