using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.HelperClasses
{
    public class Position
    {

        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }


        public int X
        {
            get { return this.x; }
            set 
            {
                ValidateValue(value);
                this.x = value; 
            }
        }

        public int Y
        {
            get { return this.y; }
            set
            {
                ValidateValue(value);
                this.y = value;
            }
        }

        private void ValidateValue(int value)
        {
            if (value < 0)
            {
                throw new IndexOutOfRangeException("The value you are trying to set is negative. SET ONLY positive numbers!");
            }
        }

    }
}
