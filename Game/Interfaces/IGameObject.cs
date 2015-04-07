using Game.HelperClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IGameObject : IRenderable
    {
        Position CurrentPosition { get; set; }

        bool Equals(System.Object obj);
    }
}
