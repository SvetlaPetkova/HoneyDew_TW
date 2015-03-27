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
            objs.Add(new Block(new Position(5, 5)));
            objs.Add(new Block(new Position(15, 5)));
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
            var rows = 20;
            var cols = 20;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (i == 0 || j==0 || i == rows || j == cols)
                    {
                        continue;
                    }
                    field.Body[i, j] = ' ';
                }
            }
        }

        public void HandleKeyboardInputs(object sender, EventArgs e)
        {
            GameEventArgs keyboardArgs = (GameEventArgs)e;
            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Left)
            {
                if (this.character.CurrentPosition.X > 0)
                { 
                    this.character.CurrentPosition.X--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Up)
            {
                if (this.character.CurrentPosition.X < 75)
                {
                    this.character.CurrentPosition.Y--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Down)
            {
                if (this.character.CurrentPosition.Y < 75)
                {
                    this.character.CurrentPosition.Y++;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Right)
            {
                if (this.character.CurrentPosition.Y < 75)
                {
                    this.character.CurrentPosition.X++;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Action)
            {
                this.ShouldPassControl = true;
            }
        }
    }
}
