using Sprint0;
using LegendofZelda;
using System.Collections.Generic;
using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using LegendofZelda.Interfaces;
using System.Runtime.CompilerServices;
using LegendofZelda.SpriteFactories;
using GameStates;

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

public class InventoryCommand : ICommand
{
    private GameStateController controller;

    public InventoryCommand(GameStateController controller)
    {
        this.controller = controller;
    }
    public void Execute()
    {

        if (this.controller.gameState is InventoryState)
        {
            this.controller.gameState.GamePlay();
        }
        else
        {
            this.controller.gameState.Inventory();
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


public class LeftRoomCommand : ICommand
{
    private Game1 myGame;
    private Graph myGraph;
    private GameStateController myStateController;


    public LeftRoomCommand(Game1 myGame, Graph myGraph, GameStateController gameStateController)
    {
        this.myGame = myGame;
        this.myGraph = myGraph;
        myStateController = gameStateController;

    }

    public void Execute()
    {

        myStateController.gameState.TransitionLeft();
        myGame.currentRoomIndex = myGraph.GetLeftRoom(myGame.currentRoomIndex);
        myGraph.AddToVisited(myGame.currentRoomIndex);
        myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];
        

        var background = myGame.currentRoom.Background as IBackground;
        background.SetTransitionDirection("left");

    }
}


public class RightRoomCommand : ICommand
{
    private Game1 myGame;
    private Graph myGraph;
    private GameStateController myStateController;

    public RightRoomCommand(Game1 myGame, Graph myGraph,GameStateController gameStateController)
    {
        this.myGame = myGame;
        this.myGraph = myGraph;
        myStateController = gameStateController;
    }

    public void Execute()
    {
        myStateController.gameState.TransitionRight();
        myGame.currentRoomIndex = myGraph.GetRightRoom(myGame.currentRoomIndex);
        myGraph.AddToVisited(myGame.currentRoomIndex);
        myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];
        var background = myGame.currentRoom.Background as IBackground;
        background.SetTransitionDirection("right");

    }
}


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


public class DownRoomCommand : ICommand
{
    private Game1 myGame;
    private Graph myGraph;
    private GameStateController myStateController;


    public DownRoomCommand(Game1 myGame, Graph myGraph, GameStateController gameStateController)
    {
        this.myGame = myGame;
        this.myGraph = myGraph;
        myStateController = gameStateController;

    }

    public void Execute()
    {

        myStateController.gameState.TransitionDown();
        myGame.currentRoomIndex = myGraph.GetDownRoom(myGame.currentRoomIndex);
        myGraph.AddToVisited(myGame.currentRoomIndex);
        myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];

        var background = myGame.currentRoom.Background as IBackground;
        background.SetTransitionDirection("down");

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
      
        if (myGame.currentRoomIndex == 18)
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
            myGame.currentRoomIndex = 18;
        }
        else
        {
            myGame.currentRoomIndex--;
        }

        myGame.currentRoom = myGame.rooms[myGame.currentRoomIndex];
    }

}





