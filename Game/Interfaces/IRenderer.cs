using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Interfaces
{
    public interface IRenderer
    {
        void Render(IRenderable obj);
        void DrawObjects(IRenderable field,IList<IRenderable> objects);

        void Clear();
    }
}
