using Sprint0;
using Interfaces;
using LegendofZelda;
using System.Collections.Generic;

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
    private Room currentRoom;
    private List<Room> rooms;
    private int roomNumber;

    public NextRoomCommand(Room currentRoom, List<Room> rooms, int roomNumber)
    {
        this.currentRoom = currentRoom;
        this.rooms = rooms;
        this.roomNumber =  roomNumber;

    }

    public void Execute()
    {
        if (roomNumber == 17)
        {
            roomNumber = 0;
        }
        else
        {
            roomNumber++;

        }
        currentRoom = rooms[roomNumber];
    }


}

public class PreviousRoomCommand : ICommand
{
    private Room currentRoom;
    private List<Room> rooms;
    private int roomNumber;

    public PreviousRoomCommand(Room currentRoom, List<Room> rooms,int roomNumber)
    {
        this.currentRoom = currentRoom;
        this.rooms = rooms;
        this.roomNumber = roomNumber;

    }

    public void Execute()
    {

        if (roomNumber == 0)
        {
            roomNumber = 17;
        }
        else
        {
            roomNumber--;

        }
        currentRoom = rooms[roomNumber];
    }

}





