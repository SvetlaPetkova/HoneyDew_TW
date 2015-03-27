using Game.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.Logic
{
    public class SokobanLogic
    {
        public SokobanLogic()
        {

        }

        public void HandleKeyboardInputs(object sender, EventArgs e)
        {
            GameEventArgs keyboardArgs = (GameEventArgs)e;
            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Left)
            {
                if (this.charachter.CurrentPosition.X > 0)
                {
                    this.charachter.CurrentPosition.X--;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Right)
            {
                if (this.charachter.CurrentPosition.X < 75)
                {
                    this.charachter.CurrentPosition.X++;
                }
            }

            if (keyboardArgs.KeyboardCurrentState == KeyboardState.Action)
            {
                this.ExitThisGameAnPassControlToOther = true;
            }
        }
    }
}
