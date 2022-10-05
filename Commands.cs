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
    private Block currentBlock;

    public NextBlockCommand(Block block)
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
    private Block currentBlock;

    public PreviousBlockCommand(Block block)
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
    private Item currentItem;

    public NextItemCommand(Item item)
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
    private Item currentItem;

    public PreviousItemCommand(Item item)
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
    private Enemy currentEnemy;

    public NextEnemyCommand(Enemy enemy)
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
    private Enemy currentEnemy;

    public PreviousEnemyCommand(Enemy enemy)
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
    private Enemy currEnemy;
    private Block currBlock;
    private Item currItem;

    public ResetGameCommand(Link link, Enemy enemy, Block block, Item item)
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


