using LegendofZelda;
using LegendofZelda.Interfaces;

namespace Commands
{
    public class UpRoomCommand : ICommand
    {
        private Game1 myGame;
        private Graph myGraph;
        private GameStateController myStateController;


        public UpRoomCommand(Game1 myGame, Graph myGraph, GameStateController gameStateController)
        {
            this.myGame = myGame;
            this.myGraph = myGraph;
            myStateController = gameStateController;

        }

        public void Execute()
        {
            myStateController.gameState.TransitionUp();
            myGame.currentRoomIndex = myGraph.GetUpRoom(myGame.currentRoomIndex);
            myGraph.AddToVisited(myGame.currentRoomIndex);
            myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];

            var background = myGame.currentRoom.Background as IBackground;
            background.SetTransitionDirection("up");

        }
    }

}


