
using LegendofZelda.Interfaces;
using CommonReferences;


namespace Commands
{

    public class PreviousRoomCommand : ICommand
    {
        private Game1 myGame;

        public PreviousRoomCommand(Game1 myGame)
        {
            this.myGame = myGame;

        }

        public void Execute()
        {

            if (myGame.currentRoomIndex == 0)
            {
                myGame.currentRoomIndex = Common.Instance.masterSwordRoomIndex;
            }
            else
            {
                myGame.currentRoomIndex--;
            }
            myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];
        }

    }

}


