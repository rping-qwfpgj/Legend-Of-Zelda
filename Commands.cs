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


