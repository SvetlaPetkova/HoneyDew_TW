using Game.GamesLogic.Sokoban.GameLogic;
using Game.GamesLogic.Sokoban.GameObjects;
using Game.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Game.GamesLogic.Sokoban.Engine
{
    public class SokobanGameEngine
    {
        private IRenderer renderer;
        private IGameEvents gameEvents;
        private SokobanGameLogic sokobanGameLogic;
        private SokobanGameLevel1 level1;


        public SokobanGameEngine(IRenderer passedRenderer, IGameEvents passedGameEvents)
        {
            this.renderer = passedRenderer;
            this.gameEvents = passedGameEvents;
            this.sokobanGameLogic = new SokobanGameLogic();
            this.level1 = new SokobanGameLevel1();
        }
        
        public void AttachListenersToKeyboard()
        {
            this.gameEvents.OnKeyboardPressed += this.sokobanGameLogic.HandleKeyboardInputs;
            //TODO: attach handlers of other game logics here
        }

        public void StartSokoban()
        {
            this.renderer.Clear();

            AttachListenersToKeyboard();
            while(true)
            {
                this.gameEvents.ProcessInput();

                this.sokobanGameLogic.DrawSokobanGameObjects(this.level1);

                //render all
                renderer.Render(level1);
                Thread.Sleep(70);
                renderer.Clear();
            }
        }
    }
}
