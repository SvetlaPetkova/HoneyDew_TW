using Game.DrawLogic;
using Game.GamesLogic.InitialGame.GameObjects;
using Game.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Game.GamesLogic.InitialGame
{
    public class InitialGameLogic
    {

        private Character charachter;

        public InitialGameLogic()
        {
            this.ExitThisGameAnPassControlToOther = false;
            this.charachter  = new Character();
        }
        //DEMO rewrite later
        public bool ExitThisGameAnPassControlToOther { get; set; }

        public void MoveCharachterOnField(GameField field)
        {

            ClrearAroundCharachter(ref field);
            for (int row = 0; row < this.charachter.Body.GetLength(0); row++)
            {
                for (int col = 0; col < this.charachter.Body.GetLength(1); col++)
                {
                    var currentY = this.charachter.CurrentPosition.Y;
                    var currentX = this.charachter.CurrentPosition.X;
                    field.Body[(currentY + row), (currentX + col)] = this.charachter.Body[row, col];
                }
            }
        }

        private void ClrearAroundCharachter(ref GameField field)
        {
            for (int i = 0; i < field.Body.GetLength(0); i++)
            {
                for (int j = 0; j < field.Body.GetLength(1); j++)
                {
                    field.Body[i, j] = ' ';
                }
            }
        }


        public void HandleKeyboardInputs(object sender, EventArgs e)
        {
            GameEventArgs keyboardArgs = (GameEventArgs)e;
            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Left)
            {
                if(this.charachter.CurrentPosition.X > 0)
                {
                    this.charachter.CurrentPosition.X--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Right)
            {
                if(this.charachter.CurrentPosition.X < 75)
                {
                    this.charachter.CurrentPosition.X++;
                }
            }

            if(keyboardArgs.KeyboardCurrentState == KeyboardState.Action)
            {
                this.ExitThisGameAnPassControlToOther = true;
            }
        }
    }
}
