using LegendofZelda;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using LegendofZelda.Interfaces;
using System.Runtime.CompilerServices;
using LegendofZelda.SpriteFactories;

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
                myGame.currentRoomIndex = 23;
            }
            else
            {
                myGame.currentRoomIndex--;
            }
            myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];
        }

    }

}


