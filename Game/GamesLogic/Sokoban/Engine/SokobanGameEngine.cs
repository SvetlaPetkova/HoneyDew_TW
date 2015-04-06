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
            this.gameEvents.OnKeyboardPressed += this.sokobanGameLogic.HandleSokobanKeyboardInputs;
        }

        public void DetachListenersFromKeyboard()
        {
            this.gameEvents.OnKeyboardPressed -= this.sokobanGameLogic.HandleSokobanKeyboardInputs;
        }

        public void StartSokoban()
        {
            this.renderer.Clear();

            AttachListenersToKeyboard();
            this.sokobanGameLogic.ShouldPassControl = false;
            while(true)
            {
                this.gameEvents.ProcessInput();

                renderer.DrawObjects((IRenderable)level1, sokobanGameLogic.GameObjects.Cast<IRenderable>().ToList());

                if(this.sokobanGameLogic.ShouldPassControl)
                {
                    DetachListenersFromKeyboard();
                    break;
                }
                                
                Thread.Sleep(70);
                renderer.Clear();
            }
        }
    }
}
