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

            File inputFile = new File(@"..\..\..\objects.txt");
            var separateLines = inputFile.ReadFile().ToString().Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            bool inWalls = false;
            bool inBlocks = false;
            bool inElevators = false;
            string currentObject = string.Empty;

            for (int i = 0; i < separateLines.Length; i++)
            {
                switch (separateLines[i])
                {
                    case "Walls\r": inWalls = true; inBlocks = false; inElevators = false; continue;
                    case "Blocks\r": inWalls = false; inBlocks = true; inElevators = false; continue;
                    case "Elevators\r": inWalls = false; inBlocks = false; inElevators = true; continue;

                    default:
                        break;
                }

                if (inWalls)
                {
                    var separateElements = separateLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    objs.Add(new Wall(new Position(int.Parse(separateElements[0]), int.Parse(separateElements[1]))
                        , separateElements[2] == "true" ? true : false, int.Parse(separateElements[3])));
                }

                if (inBlocks)
                {
                    var separateElements = separateLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    objs.Add(new Block(new Position(int.Parse(separateElements[0]), int.Parse(separateElements[1]))));
                }

                if (inElevators)
                {
                    var separateElements = separateLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    objs.Add(new Elevator(new Position(int.Parse(separateElements[0]), int.Parse(separateElements[1]))));
                }
            }
            

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
