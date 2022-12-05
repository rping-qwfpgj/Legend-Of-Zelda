using LegendofZelda.Interfaces;

namespace Commands
{
    public class NextRoomCommand : ICommand
    {
        private Game1 myGame;


        public NextRoomCommand(Game1 myGame)
        {
            this.myGame = myGame;

        }

        public void Execute()
        {

            if (myGame.currentRoomIndex == 23)
            {
                myGame.currentRoomIndex = 0;
            }
            else
            {
                myGame.currentRoomIndex++;
            }

            myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];
        }
    }

}


