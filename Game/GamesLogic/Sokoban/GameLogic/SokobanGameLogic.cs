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
        private IList<IGameObject> gameObjects;
        public bool ShouldPassControl { get; set; }

        public SokobanGameLogic()
        {
            this.character = new Character();
            this.ShouldPassControl = false;
            this.GameObjects = FillWithBlocks();
        }
        public IList<IGameObject> GameObjects 
        { 
            get {return this.gameObjects; }
            protected set { this.gameObjects = value; } 
        }

        private IList<IGameObject> FillWithBlocks()
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
                        , separateElements[2] == "Horizontal" ? WallDirection.Horizontal : WallDirection.Vertical, int.Parse(separateElements[3])));
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

        public void HandleSokobanKeyboardInputs(object sender, EventArgs e)
        {
            GameEventArgs keyboardArgs = (GameEventArgs)e;
            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Left)
            {
                if (/*this.character.CurrentPosition.X > 1 && */!(CollisionsDetection.MovingLeft(gameObjects, this.character))
                    && !(this.character.CurrentPosition.X == 7 && (this.character.CurrentPosition.Y > 8 && this.character.CurrentPosition.Y <= 20)))
                {
                    this.character.PreviousPosition.Y = this.character.CurrentPosition.Y;
                    this.character.PreviousPosition.X = this.character.CurrentPosition.X;
                    this.character.CurrentPosition.X--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Up && !(CollisionsDetection.MovingUp(gameObjects, this.character)))
            {
                //if (this.character.CurrentPosition.Y > 1)
                //{
                    this.character.PreviousPosition.Y = this.character.CurrentPosition.Y;
                    this.character.PreviousPosition.X = this.character.CurrentPosition.X;
                    this.character.CurrentPosition.Y--;
                //}
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Down)
            {
                if (/*this.character.CurrentPosition.Y < 37 && */!(CollisionsDetection.MovingDown(gameObjects, this.character)))
                {
                    this.character.PreviousPosition.Y = this.character.CurrentPosition.Y;
                    this.character.PreviousPosition.X = this.character.CurrentPosition.X;
                    this.character.CurrentPosition.Y++;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Right)
            {
                if (/*this.character.CurrentPosition.X < 32 &&*/ !(CollisionsDetection.MovingRight(gameObjects, this.character))
                    && !(this.character.CurrentPosition.X == 34 && (this.character.CurrentPosition.Y > 10 && this.character.CurrentPosition.Y <= 20)))
                {
                    this.character.PreviousPosition.Y = this.character.CurrentPosition.Y;
                    this.character.PreviousPosition.X = this.character.CurrentPosition.X;
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
