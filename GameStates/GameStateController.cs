using System;
using Interfaces;
using GameStates;

public class GameStateController
{
    public IGameState gamestate;
    public GameStateController(Game1 game)
    {
        this.gamestate = new GamePlayState(this, game);
    }
    public void GamePlay()
    {
        this.gamestate.GamePlay();
    }
    public void Inventory()
    {
        this.gamestate.Inventory();
    }
    public void GameOver()
    {
        this.gamestate.GameOver();
    }
    public void Pause()
    {
        this.gamestate.Pause();
    }
    public void WinGame()
    {
        this.gamestate.WinGame();
    }
    public void TransitionUp()
    {
        this.gamestate.TransitionUp();
    }
    public void TransitionDown()
    {
        this.gamestate.TransitionDown();
    }
    public void TransitionLeft()
    {
        this.gamestate.TransitionLeft();
    }
    public void TransitionRight()
    {
        this.gamestate.TransitionRight();
    }
}
