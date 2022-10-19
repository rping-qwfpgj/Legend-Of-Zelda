using Sprint0;
using LegendofZelda;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using LegendofZelda.Interfaces;

namespace Commands
{
    public class QuitCommand : ICommand
    {
        private Game1 currGame;

        public QuitCommand(Game1 currGame)
        {
            this.currGame = currGame;
        }
        public void Execute()
        {
            currGame.Exit();
        }
    }
}

public class ResetGameCommand : ICommand
{
    private Link currLink;
    private IEnemy currEnemy;
    private IBlock currBlock;
    private IItem currItem;

    public ResetGameCommand(Link link, IEnemy enemy, IBlock block, IItem item)
    {
        this.currLink = link;
        this.currEnemy = enemy;
        this.currBlock = block;
        this.currItem = item;
    }

    public void Execute()
    {
        currLink.Reset();
    }

}

public class NextRoomCommand : ICommand
{
    private Game1 myGame;

    public NextRoomCommand(Game1 myGame)
    {
        this.myGame = myGame;
    }

    public void Execute()
    {
      
        if (myGame.currentRoomIndex == 17)
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

public class PreviousRoomCommand : ICommand
{
    private Game1 myGame;

    public PreviousRoomCommand(Game1 myGame)
    {
        this.myGame=myGame;

    }

    public void Execute()
    {

        if (myGame.currentRoomIndex == 0)
        {
            myGame.currentRoomIndex = 17;
        }
        else
        {
            myGame.currentRoomIndex--;
        }

        myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];
    }

}





