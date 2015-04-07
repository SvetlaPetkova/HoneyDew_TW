using Game.GamesLogic.Sokoban.GameObjects;
using Game.HelperClasses;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.GameLogic
{
    public class SokobanGameLogic
    {
        private SocobanCharacter character;
        private IList<IGameObject> gameObjects;
        public bool ShouldPassControl { get; set; }

        public SokobanGameLogic()
        {
            this.character = new SocobanCharacter();
            this.ShouldPassControl = false;
            this.GameObjects = FillWithBlocks();
        }
        public IList<IGameObject> GameObjects
        {
            get { return this.gameObjects; }
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
                    case "Elevators\r": inWalls = false; inBlocks = false; inElevators = true; continue;
                    case "Blocks\r": inWalls = false; inBlocks = true; inElevators = false; continue;

                    default:
                        break;
                }

                if (inWalls)
                {
                    var separateElements = separateLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    objs.Add(new Wall(new Position(int.Parse(separateElements[0]), int.Parse(separateElements[1]))
                        , separateElements[2] == "Horizontal" ? WallDirection.Horizontal : WallDirection.Vertical, int.Parse(separateElements[3])));
                }

                if (inElevators)
                {
                    var separateElements = separateLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    objs.Add(new Elevator(new Position(int.Parse(separateElements[0]), int.Parse(separateElements[1]))));
                }

                if (inBlocks)
                {
                    var separateElements = separateLines[i].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    objs.Add(new Block(new Position(int.Parse(separateElements[0]), int.Parse(separateElements[1]))));
                }
            }


            objs.Add(this.character);
            return objs;
        }

        public void HandleSokobanKeyboardInputs(object sender, EventArgs e)
        {
            GameEventArgs keyboardArgs = (GameEventArgs)e;
            string direction = "none";

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Escape)
            {
                this.ShouldPassControl = true;
            }
            else if (keyboardArgs.KeyboardCurrentState == KeyboardState.Left)
            {
                direction = "left";
            }
            else if (keyboardArgs.KeyboardCurrentState == KeyboardState.Right)
            {
                direction = "right";
            }
            else if (keyboardArgs.KeyboardCurrentState == KeyboardState.Up)
            {
                direction = "up";
            }
            else if (keyboardArgs.KeyboardCurrentState == KeyboardState.Down)
            {
                direction = "down";
            }

            if (direction != "none")
            {
                MoveObject(this.character, direction);
                ManageCollisions();
            }

        }

        private void MoveObject(IMovable movingObject, string direction)
        {
            if (direction != "none")
            {
                movingObject.PreviousPosition.Y = movingObject.CurrentPosition.Y;
                movingObject.PreviousPosition.X = movingObject.CurrentPosition.X;
                movingObject.Direction = direction;

                if (direction == "left")
                {
                    movingObject.CurrentPosition.X--;
                }
                else if (direction == "right")
                {
                    movingObject.CurrentPosition.X++;
                }
                else if (direction == "up")
                {
                    movingObject.CurrentPosition.Y--;
                }
                else if (direction == "down")
                {
                    movingObject.CurrentPosition.Y++;
                }
            }

        }

        private void ManageCollisions()
        {
            IList<IGameObject> collisionObjectsList = new List<IGameObject>();
            bool hasColided = CollisionsDetection.DetectCollission(this.character, this.GameObjects, ref collisionObjectsList);

            if (!hasColided)
            {
                return;
            }

            foreach (var collisionObject in collisionObjectsList)
            {
                if (collisionObject is Block)
                {
                    //mpve the block in the direction of the character's movement
                    MoveObject((IMovable)collisionObject, this.character.Direction);

                    //check if a block hits somethig else
                    IList<IGameObject> indirectCollisionObjectList = new List<IGameObject>();
                    bool hasBlockColided = CollisionsDetection.DetectCollission(collisionObject, this.GameObjects, ref indirectCollisionObjectList);
                    foreach (var indirectCollisionObject in indirectCollisionObjectList)
                    {
                        if (hasBlockColided && !(indirectCollisionObject is Elevator))
                        {
                            ReturnObjectToPreviousPosition(this.character);
                            ReturnObjectToPreviousPosition((IMovable)collisionObject);
                        }
                        //check for win if a block hits an elevator
                        if (hasBlockColided && (indirectCollisionObject is Elevator))
                        {
                            CheckForWin();
                        }
                    }
                }
                if (collisionObject is Wall)
                {
                    ReturnObjectToPreviousPosition(this.character);
                }
            }
        }

        private void CheckForWin()
        {
            List<Elevator> elevatorList = this.gameObjects.Where(obj => obj is Elevator).Cast<Elevator>().ToList();
            List<Block> blockList = this.gameObjects.Where(obj => obj is Block).Cast<Block>().ToList();

            foreach (var elevator in elevatorList)
            {
                foreach (var block in blockList)
                {
                    if (elevator.CurrentPosition.Equals(block.CurrentPosition))
                    {
                        elevator.IsFull = true;
                    }
                    else
                    {
                        elevator.IsFull = false;
                    }
                }
            }

            bool allFull = AreElevatorsFull(elevatorList);

            if (allFull)
            {
                Console.Clear();
                Console.WriteLine("YOU WIN!!!");

                this.ShouldPassControl = true;

                Thread.Sleep(2000);
            }
        }

        private bool AreElevatorsFull(List<Elevator> elevatorList)
        {
            foreach (var elevator in elevatorList)
            {
                if (!elevator.IsFull)
                {
                    return false;
                }
            }

            return true;
        }

        private void ReturnObjectToPreviousPosition(IMovable gameObject)
        {
            gameObject.CurrentPosition.X = gameObject.PreviousPosition.X;
            gameObject.CurrentPosition.Y = gameObject.PreviousPosition.Y;
        }

    }
}
