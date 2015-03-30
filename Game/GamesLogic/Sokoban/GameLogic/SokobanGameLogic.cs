using Game.GamesLogic.Sokoban.GameObjects;
using Game.HelperClasses;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.GameLogic
{
    public class SokobanGameLogic
    {
        private Character character;
        private IEnumerable<IGameObject> gameObjects;
        public bool ShouldPassControl { get; set; }


        public SokobanGameLogic()
        {
            this.character = new Character();
            this.ShouldPassControl = false;
            this.gameObjects = FillWithBlocks();
        }

        private IEnumerable<IGameObject> FillWithBlocks()
        {
            var objs = new List<IGameObject>();
            objs.Add(new Block(new Position(14, 10)));
            objs.Add(new Block(new Position(19, 10)));
            objs.Add(new Block(new Position(24, 10)));
            objs.Add(new Block(new Position(14, 18)));
            objs.Add(new Block(new Position(19, 18)));
            objs.Add(new Block(new Position(24, 18)));
            objs.Add(new Elevator(new Position(17, 5)));
            objs.Add(new Elevator(new Position(20, 3)));
            objs.Add(new Elevator(new Position(22, 5)));
            objs.Add(new Elevator(new Position(17, 23)));
            objs.Add(new Elevator(new Position(20, 25)));
            objs.Add(new Elevator(new Position(22, 23)));

            //drowing the walls

            objs.Add(new Wall(new Position(0, 1), true, 10));
            objs.Add(new Wall(new Position(10, 0), true, 20));
            objs.Add(new Wall(new Position(30, 1), true, 11));
            objs.Add(new Wall(new Position(0, 1), false, 10));
            objs.Add(new Wall(new Position(40, 1), false, 10));
            objs.Add(new Wall(new Position(0, 10), true, 6));
            objs.Add(new Wall(new Position(34, 10), true, 6));
            objs.Add(new Wall(new Position(6, 10), false, 10));
            objs.Add(new Wall(new Position(34, 10), false, 10));
            objs.Add(new Wall(new Position(0, 20), true, 7));
            objs.Add(new Wall(new Position(34, 20), true, 6));
            objs.Add(new Wall(new Position(0, 20), false, 10));
            objs.Add(new Wall(new Position(40, 20), false, 10));
            objs.Add(new Wall(new Position(0, 30), true, 10));
            objs.Add(new Wall(new Position(10, 31), true, 20));
            objs.Add(new Wall(new Position(30, 30), true, 11));
            objs.Add(new Wall(new Position(13, 14), true, 14));
            objs.Add(new Wall(new Position(13, 15), true, 14));
            objs.Add(new Wall(new Position(4, 5), true, 6));
            objs.Add(new Wall(new Position(4, 6), true, 6));
            objs.Add(new Wall(new Position(31, 5), true, 6));
            objs.Add(new Wall(new Position(31, 6), true, 6));
            objs.Add(new Wall(new Position(14, 5), true, 3));
            objs.Add(new Wall(new Position(14, 6), true, 3));
            objs.Add(new Wall(new Position(19, 5), true, 3));
            objs.Add(new Wall(new Position(19, 6), true, 3));
            objs.Add(new Wall(new Position(24, 5), true, 3));
            objs.Add(new Wall(new Position(24, 6), true, 3));
            objs.Add(new Wall(new Position(11, 10), true, 3));
            objs.Add(new Wall(new Position(11, 11), true, 3));
            objs.Add(new Wall(new Position(16, 10), true, 3));
            objs.Add(new Wall(new Position(16, 11), true, 3));
            objs.Add(new Wall(new Position(21, 10), true, 3));
            objs.Add(new Wall(new Position(21, 11), true, 3));
            objs.Add(new Wall(new Position(26, 10), true, 3));
            objs.Add(new Wall(new Position(26, 11), true, 3));
            objs.Add(new Wall(new Position(11, 18), true, 3));
            objs.Add(new Wall(new Position(11, 19), true, 3));
            objs.Add(new Wall(new Position(16, 18), true, 3));
            objs.Add(new Wall(new Position(16, 19), true, 3));
            objs.Add(new Wall(new Position(21, 18), true, 3));
            objs.Add(new Wall(new Position(21, 19), true, 3));
            objs.Add(new Wall(new Position(26, 18), true, 3));
            objs.Add(new Wall(new Position(26, 19), true, 3));
            objs.Add(new Wall(new Position(4, 23), true, 6));
            objs.Add(new Wall(new Position(4, 24), true, 6));
            objs.Add(new Wall(new Position(31, 23), true, 6));
            objs.Add(new Wall(new Position(31, 24), true, 6));
            objs.Add(new Wall(new Position(14, 23), true, 3));
            objs.Add(new Wall(new Position(14, 24), true, 3));
            objs.Add(new Wall(new Position(19, 23), true, 3));
            objs.Add(new Wall(new Position(19, 24), true, 3));
            objs.Add(new Wall(new Position(24, 23), true, 3));
            objs.Add(new Wall(new Position(24, 24), true, 3));

            objs.Add(this.character);
            return objs;
        }

        public void DrawSokobanGameObjects(SokobanGameLevel1 field)
        {
            this.ClrearAroundCharachter(ref field);

            foreach (IGameObject obj in this.gameObjects)
            {
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
        }

        private void ClrearAroundCharachter(ref SokobanGameLevel1 field)
        {
            var rows = 40;
            var cols = 40;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || j == 0 || i == rows || j == cols)
                    {
                        continue;
                    }
                    field.Body[i, j] = ' ';
                }
            }
        }

        public void HandleSokobanKeyboardInputs(object sender, EventArgs e)
        {
            GameEventArgs keyboardArgs = (GameEventArgs)e;
            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Left)
            {
                if (this.character.CurrentPosition.X > 1)
                {
                    this.character.CurrentPosition.X--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Up)
            {
                if (this.character.CurrentPosition.Y > 1)
                {
                    this.character.CurrentPosition.Y--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Down)
            {
                if (this.character.CurrentPosition.Y < 37)
                {
                    this.character.CurrentPosition.Y++;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Right)
            {
                if (this.character.CurrentPosition.X < 37)
                {
                    this.character.CurrentPosition.X++;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Escape)
            {
                this.ShouldPassControl = true;
            }
        }
    }
}
