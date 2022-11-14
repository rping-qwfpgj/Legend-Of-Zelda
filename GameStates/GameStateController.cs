using System;
using Interfaces;
using GameStates;
using Microsoft.Xna.Framework;

public class GameStateController
{
    public IGameState gameState;
    public GameStateController(Game1 game)
    {
        this.gameState = new GamePlayState(this, game);
    }
    public void GamePlay()
    {
        this.gameState.GamePlay();
    }
    public void Inventory()
    {
        this.gameState.Inventory();
    }
    public void GameOver()
    {
        this.gameState.GameOver();
    }
    public void Pause()
    {
        this.gameState.Pause();
    }
    public void WinGame()
    {
        this.gameState.WinGame();
    }
    public void TransitionUp()
    {
        this.gameState.TransitionUp();
    }
    public void TransitionDown()
    {
        this.gameState.TransitionDown();
    }
    public void TransitionLeft()
    {
        this.gameState.TransitionLeft();
    }
    public void TransitionRight()
    {
        this.gameState.TransitionRight();
    }
    
}
