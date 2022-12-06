﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using LegendofZelda;
using Commands;
using Controllers;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using Collision;
using LegendofZelda.SpriteFactories;
using System;
using LegendofZelda.Interfaces;
using HeadsUpDisplay;
using Microsoft.Xna.Framework.Media;
using Interfaces;
using GameStates;
using System.Diagnostics;
using CommonReferences;


// Creator: Tuhin Patel
// Brittaney Jin
// DJ "best ever teammate" Young
// Lisha Nawani
// Vishal "good teamate" Kumar
public class Game1 : Game
{
    public GraphicsDeviceManager _graphics;
    public SpriteBatch _spriteBatch;

    public List<Room> rooms;
    public Room currentRoom;
    public int currentRoomIndex;
    public Graph roomsGraph;

    public KeyboardController keyboardController;
    public MouseController mouseController;
    public GameStateController gameStateController;

    public CollisionDetector collisionDetector;
    public Hud hud;
    public Song backgroundMusic;
    public Song bossRushMusic;
    public Song shrineMusic;
    public IGameState bossRushState; 
    public string currentSong; // keep track of the current song bieng played since media player doesn't do that (smh my head)

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
    protected override void Initialize()
    {
        _graphics.PreferredBackBufferHeight += Common.Instance.heightOfInventory;
        _graphics.ApplyChanges();
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        gameStateController = new GameStateController(this);
        bossRushState = new BossRushState(gameStateController, this);
        SpriteFactoriesInit();
        GraphInit();
        RoomloaderInit();
        ControllersInit();

        hud = new Hud(20, -19);
        collisionDetector = new CollisionDetector(rooms[currentRoomIndex], this);

        base.Initialize();
    }
    protected override void LoadContent()
    {
        backgroundMusic = Content.Load<Song>("Undertale");
        bossRushMusic = Content.Load<Song>("coconut_mall_mp3");
        shrineMusic = Content.Load<Song>("Shrine");
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Volume = 0.3f;
        MediaPlayer.Play(backgroundMusic);
        currentSong = "Undertale";
    }
    protected override void Update(GameTime gameTime)
    {
        if (gameStateController.gameState is ITransitionGameState) { 
            var gameState = gameStateController.gameState as ITransitionGameState;
            gameState.Update(gameTime, gameTime.TotalGameTime);
        } else
        {
            gameStateController.gameState.Update();
        }

        if(currentRoomIndex < Common.Instance.rushRoomsIndex && currentSong != "Undertale")
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(backgroundMusic);
            currentSong = "Undertale";
        } else if(currentRoomIndex >= Common.Instance.rushRoomsIndex && currentRoomIndex < Common.Instance.masterSwordRoomIndex && currentSong != "coconut_mall_mp3")
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(bossRushMusic);
            currentSong = "coconut_mall_mp3";
        } else if (currentRoomIndex == Common.Instance.masterSwordRoomIndex && currentSong != "Shrine")
        {
            MediaPlayer.Stop();
            MediaPlayer.Play(shrineMusic);
            currentSong = "Shrine";
        }

        if (gameStateController.gameState is WinGameState || gameStateController.gameState is GameOverState)
        {
            MediaPlayer.Stop();
        }
        base.Update(gameTime);
    }
    protected override void Draw(GameTime gameTime)
    {
        Debug.WriteLine(gameStateController.gameState);
        gameStateController.gameState.Draw(_spriteBatch);
        base.Draw(gameTime);
    }

    //--------HELPER METHODS---------//
    public void BackgroundMusicInit()
    {
        backgroundMusic = Content.Load<Song>("Undertale");
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Volume = 0.2f;
        MediaPlayer.Play(backgroundMusic);
    }
    private void ControllersInit()
    {
        keyboardController = new KeyboardController(new NoInputCommand());

        keyboardController.AddCommand(Keys.W, new WalkUpCommand(gameStateController));
        keyboardController.AddCommand(Keys.Up, new WalkUpCommand(gameStateController));
        keyboardController.AddCommand(Keys.S, new WalkDownCommand(gameStateController));
        keyboardController.AddCommand(Keys.Down, new WalkDownCommand(gameStateController));
        keyboardController.AddCommand(Keys.A, new WalkLeftCommand(gameStateController));
        keyboardController.AddCommand(Keys.Left, new WalkLeftCommand(gameStateController));
        keyboardController.AddCommand(Keys.D, new WalkRightCommand(gameStateController));
        keyboardController.AddCommand(Keys.Right, new WalkRightCommand(gameStateController));
        keyboardController.AddCommand(Keys.B, new ThrowCommand());
        keyboardController.AddCommand(Keys.Z, new AttackCommand());
        keyboardController.AddCommand(Keys.Q, new QuitCommand(this));
        keyboardController.AddCommand(Keys.L, new InventoryCommand(gameStateController, this));
        keyboardController.AddCommand(Keys.H, new PauseCommand(gameStateController));
        
        Vector2 center = new(_graphics.PreferredBackBufferWidth / 2,
          _graphics.PreferredBackBufferHeight / 2);
        mouseController = new(this, center);
    }
    private void GraphInit()
    {
        roomsGraph = new();

        roomsGraph.AddLeftRightEdge(17, 16);
        roomsGraph.AddLeftRightEdge(16, 15);
        roomsGraph.AddLeftRightEdge(12, 13);
        roomsGraph.AddLeftRightEdge(9, 8);
        roomsGraph.AddLeftRightEdge(8, 7);
        roomsGraph.AddLeftRightEdge(7, 10);
        roomsGraph.AddLeftRightEdge(10, 11);
        roomsGraph.AddLeftRightEdge(5, 4);
        roomsGraph.AddLeftRightEdge(4, 6);
        roomsGraph.AddLeftRightEdge(1, 0);
        roomsGraph.AddLeftRightEdge(0, 2);

        roomsGraph.AddDownUpEdge(5, 8);
        roomsGraph.AddDownUpEdge(0, 3);
        roomsGraph.AddDownUpEdge(3, 4);
        roomsGraph.AddDownUpEdge(4, 7);
        roomsGraph.AddDownUpEdge(7, 14);
        roomsGraph.AddDownUpEdge(14, 15);
        roomsGraph.AddDownUpEdge(6, 10);
        roomsGraph.AddDownUpEdge(11, 12);
        roomsGraph.AddDownUpEdge(17, 16);

        roomsGraph.AddDownUpEdge(9, 19);
        roomsGraph.AddDownUpEdge(23, 24);
        roomsGraph.AddDownUpEdge(24, 25);
        roomsGraph.AddDownUpEdge(25, 9);
    }
    public void RoomloaderInit()
    {
        rooms = new();
        RoomLoader roomloader = new();
        GraphGenerator graphGenerator = new(Common.Instance.numOfRushRooms, 19, this);
        RandomRoomGenerator roomGenerator = new();
        string fileFolder = "\\Content\\RoomXMLs\\Room";
        var enviroment = Environment.CurrentDirectory;
        string directory = Directory.GetParent(enviroment).Parent.Parent.FullName;
        
        for (int i = 0; i < Common.Instance.rushRoomsIndex; i++)
        {
            var roomNumber = i.ToString();
            var FilePath = directory + fileFolder + roomNumber + ".xml";
            XDocument xml = XDocument.Load(FilePath);
            rooms.Add(roomloader.ParseXML(xml));
        }

        var roomsDoors = graphGenerator.newGraph();
        
        foreach(var set in roomsDoors)
        {
            Debug.WriteLine("key"+set.Key);
            foreach (var door in set.Value)
            {
                Debug.WriteLine(door);
            }
        }

        for(int i = Common.Instance.rushRoomsIndex; i < Common.Instance.rushRoomsIndex + Common.Instance.numOfRushRooms; i++)
        {
            rooms.Add(roomGenerator.NewRandomRoom(roomsDoors[i]));
        }

        string specialRooms = "\\Content\\RoomXMLs\\";
        var bossPath = directory + specialRooms+ "OldManBoss" + ".xml";
        XDocument xml1 = XDocument.Load(bossPath);
        rooms.Add(roomloader.ParseXML(xml1));

        var swordPath = directory + specialRooms + "BossSword" + ".xml";
        XDocument xml2 = XDocument.Load(swordPath);
        rooms.Add(roomloader.ParseXML(xml2));

        currentRoomIndex = 0;
        currentRoom = rooms[currentRoomIndex];
        Link.Instance.getGame(this);
    }
    private void SpriteFactoriesInit()
    {
        HudSpriteFactory.Instance.loadContent(Content);
        LinkSpriteFactory.Instance.loadContent(Content);
        ProjectileSpriteFactory.Instance.loadContent(Content);
        EnemyAndNPCSpriteFactory.Instance.loadContent(Content);
        BlockSpriteFactory.Instance.loadContent(Content);
        ItemSpriteFactory.Instance.loadContent(Content);
        BackgroundSpriteFactory.Instance.loadContent(Content);
        SoundFactory.Instance.loadContent(Content);
        TextSpriteFactory.Instance.loadContent(Content);
        MapPieceSpriteFactory.Instance.loadContent(Content);
    }
}
