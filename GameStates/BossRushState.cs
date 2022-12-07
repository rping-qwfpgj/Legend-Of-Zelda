
using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using CommonReferences;
using LegendofZelda.Blocks;
using Microsoft.Xna.Framework;
using LegendofZelda.SpriteFactories;

namespace GameStates

{
    public class BossRushState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        private int roomsRemaining;
        bool alreadyChecked;
   
        public BossRushState(GameStateController controller, Game1 game)
        {
            //roomsRemaining = Common.Instance.numOfRushRooms;
            roomsRemaining = 1;
            this.controller = controller;
            this.game = game;
            alreadyChecked = false;
        }
        public void GamePlay()
        {
            controller.gameState = new GamePlayState(controller, game);
        }
        public void Inventory()
        {
            controller.gameState = new InventoryState(controller, game, game.hud);
        }
        public void GameOver()
        {
            controller.gameState = new GameOverState(controller, game);
        }
        public void Pause()
        {
            controller.gameState = new PauseState(controller, game);
        }
        public void WinGame()
        {
            controller.gameState = new WinGameState(controller, game);
        }
        public void BossRush()
        {
            // already in boss rush state
        }
        public void TransitionUp()
        {
            controller.gameState = new TransitionUpState(controller, game);
        }
        public void TransitionDown()
        {
            controller.gameState = new TransitionDownState(controller, game);
        }
        public void TransitionLeft()
        {
            controller.gameState = new TransitionLeftState(controller, game);
        }
        public void TransitionRight()
        {
            controller.gameState = new TransitionRightState(controller, game);
        }
        public void Update()
        {
            if(game.currentRoom.isFinished && !game.currentRoom.externallyChecked)
            {
                game.currentRoom.externallyChecked = true;
                roomsRemaining--;
            }

            if (roomsRemaining == 0 && !alreadyChecked)
            {
                alreadyChecked = true;
                game.roomsGraph.RemoveDownUpEdge(game.currentRoomIndex);
                game.roomsGraph.AddDownUpEdge(game.currentRoomIndex, Common.Instance.rushRoomsIndex + Common.Instance.numOfRushRooms);
                game.currentRoom.AddObject(BlockSpriteFactory.Instance.CreateBlock(new Vector2(350,40),"PuzzleDoorBlockTop"));
            }

            if (game.currentRoomIndex < 19 || game.currentRoomIndex== Common.Instance.rushRoomsIndex + Common.Instance.numOfRushRooms || game.currentRoomIndex== Common.Instance.rushRoomsIndex + Common.Instance.numOfRushRooms+1)
            {
                GamePlay();
            }

            Link.Instance.Update();
            game.mouseController.Update();
            game.collisionDetector.Update();
            game.keyboardController.Update();
            game.currentRoom.Update();
            game.hud.Update();

        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.currentRoom.Draw(_spriteBatch);
            Link.Instance.Draw(_spriteBatch);
            game.hud.Draw(_spriteBatch);
        }

    }
}

