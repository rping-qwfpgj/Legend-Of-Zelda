using System;
using Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework.Graphics;
using Color = Microsoft.Xna.Framework.Color;
using System.Diagnostics;
using LegendofZelda.Interfaces;

namespace GameStates

{
    public class BossRushState : IGameState
    {
        private GameStateController controller;
        private Game1 game;
        RoomGenerator roomGen;
        bool roomIsComplete;
        int roomsRemaining;
        public BossRushState(GameStateController controller, Game1 game)
        {
            roomsRemaining = 5;
            this.controller = controller;
            this.game = game;
            roomGen = new();
            roomIsComplete = true;
            game.currentRoomIndex = 19;
           
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
            if (roomIsComplete)
            {
                roomIsComplete = false;
                game.currentRoom = roomGen.NewRoom();
                roomsRemaining--;
            }

            if (roomsRemaining ==0)
            {
                controller.gameState.GamePlay();
                game.currentRoom = game.rooms[22];
                game.currentRoomIndex = 22;
            }

            Link.Instance.Update();
            game.mouseController.Update();
            game.collisionDetector.Update();
            game.keyboardController.Update();
            game.currentRoom.Update();
            game.hud.Update();

            roomIsComplete = CheckIfFinished();
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            game.GraphicsDevice.Clear(Color.Black);
            game.currentRoom.Draw(_spriteBatch);
            Link.Instance.Draw(_spriteBatch);
            game.hud.Draw(_spriteBatch);
        }

        private bool CheckIfFinished()
        {
            foreach (var sprite in game.currentRoom.ReturnObjects())
            {
                if (sprite is IEnemy)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

