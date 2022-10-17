﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Sprint0;
using Commands;
using Interfaces;
using Sprites;
using Controllers;
using System.IO;
using System.Xml.Linq;
using LegendofZelda;
using System.Collections.Generic;
using Collision;
using LegendofZelda.SpriteFactories;
using System;


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
    private Link link;
    public List<Room> rooms;
    public Room currentRoom;
    public int currentRoomIndex;
    public CollisionDetector collisionDetector;
    public ISprite background;
    private KeyboardController keyboardController;
    private MouseController mouseController;

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
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        
        LinkSpriteFactory.Instance.loadContent(Content);
        ProjectileSpriteFactory.Instance.loadContent(Content);
        EnemyAndNPCSpriteFactory.Instance.loadContent(Content);
        BlockSpriteFactory.Instance.loadContent(Content);
        ItemSpriteFactory.Instance.loadContent(Content);
        BackgroundSpriteFactory.Instance.loadContent(Content);

        link = new Link(new Vector2(400, 240), _graphics);
        

        //Mouse Controller stuff
        Vector2 center = new(_graphics.PreferredBackBufferWidth / 2,
             _graphics.PreferredBackBufferHeight / 2);
        mouseController = new(this, center);

        // Initalize keyboard controller
        keyboardController = new KeyboardController(new NoInputCommand(link));
        keyboardController.AddCommand(Keys.W, new WalkUpCommand(link));
        keyboardController.AddCommand(Keys.Up, new WalkUpCommand(link));
        keyboardController.AddCommand(Keys.S, new WalkDownCommand(link));
        keyboardController.AddCommand(Keys.Down, new WalkDownCommand(link));
        keyboardController.AddCommand(Keys.A, new WalkLeftCommand(link));
        keyboardController.AddCommand(Keys.Left, new WalkLeftCommand(link));
        keyboardController.AddCommand(Keys.D, new WalkRightCommand(link));
        keyboardController.AddCommand(Keys.Right, new WalkRightCommand(link));
        keyboardController.AddCommand(Keys.V, new ThrowRightCommand(link));
        keyboardController.AddCommand(Keys.E, new TakeDamageCommand(link));
        keyboardController.AddCommand(Keys.Z, new AttackCommand(link));
        keyboardController.AddCommand(Keys.N, new AttackCommand(link));
        keyboardController.AddCommand(Keys.D1, new SwitchToBoomerangCommand(link));
        keyboardController.AddCommand(Keys.D2, new SwitchToBlueBoomerangCommand(link));
        keyboardController.AddCommand(Keys.D3, new SwitchToArrowCommand(link));
        keyboardController.AddCommand(Keys.D4, new SwitchToBlueArrowCommand(link));
        keyboardController.AddCommand(Keys.D5, new SwitchToFireCommand(link));
        keyboardController.AddCommand(Keys.D6, new SwitchToBombCommand(link));
        keyboardController.AddCommand(Keys.Q, new QuitCommand(this));
        background = BackgroundSpriteFactory.Instance.CreateBackground("Background1");
        List<ISprite> roomSprites = new List<ISprite>();
        roomSprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(200, 200), "DepthBlock"));
        roomSprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(new Vector2(600, 250), "OldMan"));
        roomSprites.Add(ItemSpriteFactory.Instance.CreateItem(new Vector2(300, 300), "PurpleTriangle"));
        currentRoom = new Room(roomSprites, background);
        collisionDetector = new CollisionDetector(link, currentRoom);

        //ROOMLOADER STUFF


        //RoomLoader roomloader = new RoomLoader();
        //// string currentDirectory = Directory.GetCurrentDirectory();
        //string fileFolder = "Content/RoomXMLs/Room";
        //string xmlString = ".xml";


        //for (int i = 0; i < 18; i++)
        //{ 
        //    var roomNumber = i.ToString();
        //    var purchaseOrderFilePath = fileFolder + roomNumber + ".xml";    
        //    // var purchaseOrderFilepath = Path.Combine(fileName);
        //    XDocument xml = XDocument.Load(purchaseOrderFilePath);
        //    rooms.Add(roomloader.ParseXML(xml));

        //}
        //currentRoom = rooms[0];
        //currentRoomIndex = 0;
        //this.collisionDetector = new CollisionDetector(this.link, this.rooms[0]);

        base.Initialize();
    }
    
    protected override void LoadContent()
    {

        //nothing in here?????LinkSpriteFactory.Instance.loadContent(Content);
        //Try putting spritefactory stuff in load content
        //ProjectileSpriteFactory.Instance.loadContent(Content);
        //EnemyAndNPCSpriteFactory.Instance.loadContent(Content);
        //BlockSpriteFactory.Instance.loadContent(Content);
        //ItemSpriteFactory.Instance.loadContent(Content);

    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        keyboardController.Update();
        mouseController.Update();
        link.Update();
        currentRoom.Update();

        collisionDetector.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.BlueViolet);
        currentRoom.Draw(_spriteBatch);
        link.Draw(_spriteBatch);     
        base.Draw(gameTime);
    }
}
