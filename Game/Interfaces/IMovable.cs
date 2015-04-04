using Game.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IMovable : IGameObject
    {
        Position PreviousPosition{get; set;}
        string Direction { get; set; }
    }
}
