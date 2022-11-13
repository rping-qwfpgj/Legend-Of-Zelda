using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Sprint0;
using Commands;
using Sprites;
using Controllers;
using System.IO;
using System.Xml.Linq;
using LegendofZelda;
using System.Collections.Generic;
using Collision;
using LegendofZelda.SpriteFactories;
using System;
using LegendofZelda.Interfaces;
using Color = Microsoft.Xna.Framework.Color;
using SharpDX.MediaFoundation.DirectX;
using HeadsUpDisplay;
using System.Diagnostics;
using SharpDX.MediaFoundation.DirectX;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;


// Creator: Tuhin Patel
// Brittaney Jin
// DJ "best ever teammate" Young
// Lisha Nawani
// Vishal "good teamate" Kumar
public class Game1 : Game
{
    // Sprite sheet from which all sprites are obtained from
    public Texture2D linkSpriteSheet;
    public Texture2D blockSpriteSheet;
    public IItem currentItem;
    public Texture2D itemSpriteSheet;
    public IEnemy enemy;
    public Texture2D enemySpriteSheet;
    public Texture2D doorSpriteSheet;
    //private Link link;
    public List<Room> rooms;
    public Room currentRoom;
    public int currentRoomIndex;
    public CollisionDetector collisionDetector;
    public ISprite background;
    public KeyboardController keyboardController;
    public MouseController mouseController;
    public Hud hud;
    public SoundEffect enemyHit;
    public Song backgroundMusic;
    public Graph roomsGraph;
    private GameStateController gameStateController;

    // Font for on screen text , the text to display and the class to store it in
    public SpriteFont font;
    public string onScreenText;
    //public TextSprite textSprite;

    public GraphicsDeviceManager _graphics;
    public SpriteBatch _spriteBatch;
        
        
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }
  

    protected override void Initialize()
    {

        _graphics.PreferredBackBufferHeight += 150;
        _graphics.ApplyChanges();
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        gameStateController = new GameStateController(this);
        SpriteFactoriesInit();
        RoomloaderInit();
        GraphInit();
        ControllersInit();
        hud = new Hud();
        collisionDetector = new CollisionDetector(rooms[currentRoomIndex], this);
        
        base.Initialize();
    }


    protected override void LoadContent()
    {
        backgroundMusic = Content.Load<Song>("coconut_mall_mp3");
        MediaPlayer.IsRepeating = true;
        MediaPlayer.Volume = 0.4f;
        MediaPlayer.Play(backgroundMusic);

    }

    protected override void Update(GameTime gameTime)
    {
      
        // Link.Instance.Update();
        // mouseController.Update();
        //collisionDetector.Update();
        //keyboardController.Update();
        //currentRoom.Update(); 
        //hud.Update();
        gameStateController.gameState.Update();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        //GraphicsDevice.Clear(Color.Black);
        //currentRoom.Draw(_spriteBatch);
        //Link.Instance.Draw(_spriteBatch); 
        //hud.Draw(_spriteBatch);
        gameStateController.gameState.Draw(_spriteBatch);
        base.Draw(gameTime);
    }










    //--------HELPER METHODS---------//
    private void ControllersInit()
    {

        keyboardController = new KeyboardController(new NoInputCommand());

        keyboardController.AddCommand(Keys.W, new WalkUpCommand());
        keyboardController.AddCommand(Keys.Up, new WalkUpCommand());
        keyboardController.AddCommand(Keys.S, new WalkDownCommand());
        keyboardController.AddCommand(Keys.Down, new WalkDownCommand());
        keyboardController.AddCommand(Keys.A, new WalkLeftCommand());
        keyboardController.AddCommand(Keys.Left, new WalkLeftCommand());
        keyboardController.AddCommand(Keys.D, new WalkRightCommand());
        keyboardController.AddCommand(Keys.Right, new WalkRightCommand());
        keyboardController.AddCommand(Keys.V, new ThrowRightCommand());
        keyboardController.AddCommand(Keys.E, new TakeDamageCommand());
        keyboardController.AddCommand(Keys.Z, new AttackCommand());
        keyboardController.AddCommand(Keys.N, new AttackCommand());
        keyboardController.AddCommand(Keys.D1, new SwitchToBoomerangCommand());
        keyboardController.AddCommand(Keys.D2, new SwitchToBlueBoomerangCommand());
        keyboardController.AddCommand(Keys.D3, new SwitchToArrowCommand());
        keyboardController.AddCommand(Keys.D4, new SwitchToBlueArrowCommand());
        keyboardController.AddCommand(Keys.D5, new SwitchToFireCommand());
        keyboardController.AddCommand(Keys.D6, new SwitchToBombCommand());
        keyboardController.AddCommand(Keys.Q, new QuitCommand(this));
        keyboardController.AddCommand(Keys.J, new LeftRoomCommand(this, roomsGraph));
        keyboardController.AddCommand(Keys.K, new RightRoomCommand(this, roomsGraph));
        keyboardController.AddCommand(Keys.I, new UpRoomCommand(this, roomsGraph));
        keyboardController.AddCommand(Keys.M, new DownRoomCommand(this, roomsGraph));
        keyboardController.AddCommand(Keys.L, new InventoryCommand(this.gameStateController));


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
    }

    private void RoomloaderInit()
    {
        rooms = new();
        RoomLoader roomloader = new();
        string fileFolder = "\\Content\\RoomXMLs\\Room";
        var enviroment = Environment.CurrentDirectory;
        string directory = Directory.GetParent(enviroment).Parent.Parent.FullName;


        for (int i = 0; i <= 18; i++)
        {
            var roomNumber = i.ToString();
            var FilePath = directory + fileFolder + roomNumber + ".xml";
            XDocument xml = XDocument.Load(FilePath);
            rooms.Add(roomloader.ParseXML(xml));
        }

        currentRoomIndex = 1;
        currentRoom = rooms[currentRoomIndex];
        //link = Link.Instance;
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
    }

}
