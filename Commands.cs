using System;
using System.Windows.Forms;
using Sprint0;
using Interfaces;
using Sprites;

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

public class NextBlockCommand : ICommand
{
    private IBlock currentBlock;

    public NextBlockCommand(IBlock block)
    {
        this.currentBlock = block;
    }

    public void Execute()
    {
        if (currentBlock.currentBlockNum == 10)
        {
            currentBlock.currentBlockNum = 0;
        }
        else
        {
            currentBlock.currentBlockNum++;
        }
    }
}

    public class PreviousBlockCommand : ICommand
{
    private IBlock currentBlock;

    public PreviousBlockCommand(IBlock block)
    {
        this.currentBlock = block;
    }

    public void Execute()
    {
        if (currentBlock.currentBlockNum == 0)
        {
            currentBlock.currentBlockNum = 10;
        }
        else
        {
            currentBlock.currentBlockNum--;
        }

    }

       }


public class NextItemCommand : ICommand
{
    private IItem currentItem;

    public NextItemCommand(IItem item)
    {
        this.currentItem = item;
    }

    public void Execute()
    {
        if (currentItem.currentItemNum == 13)
        {
            currentItem.currentItemNum = 0;
        }
        else
        {
            currentItem.currentItemNum++;
        }



    }
}

public class PreviousItemCommand : ICommand
{
    private IItem currentItem;

    public PreviousItemCommand(IItem item)
    {
        this.currentItem = item;
    }

    public void Execute()
    {
        if (currentItem.currentItemNum == 0)
        {
            currentItem.currentItemNum = 13;
        }
        else
        {
            currentItem.currentItemNum--;
        }

    }




}

public class NextEnemyCommand : ICommand
{
    private IEnemy currentEnemy;

    public NextEnemyCommand(IEnemy enemy)
    {
        this.currentEnemy = enemy;
    }

    public void Execute()
    {
        if (currentEnemy.currentEnemyNum == 5)
        {
            currentEnemy.currentEnemyNum = 0;
        }
        else
        {
            currentEnemy.currentEnemyNum++;
        }



    }
}

public class PreviousEnemyCommand : ICommand
{
    private IEnemy currentEnemy;

    public PreviousEnemyCommand(IEnemy enemy)
    {
        this.currentEnemy = enemy;
    }

    public void Execute()
    {
        if (currentEnemy.currentEnemyNum == 0)
        {
            currentEnemy.currentEnemyNum = 5;
        }
        else
        {
            currentEnemy.currentEnemyNum--;
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
        currEnemy.Reset();
        currBlock.Reset();
        currItem.Reset();
    }
    
    
}


