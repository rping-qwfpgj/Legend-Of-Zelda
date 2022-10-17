using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Texture2D = Microsoft.Xna.Framework.Graphics.Texture2D;
using Sprint0;
using Commands;
using Interfaces;
using Sprites;
using SpriteFactories;
using Controllers;
using System.IO;
using System.Xml.Linq;
using LegendofZelda;
using System.Collections.Generic;
using Collision;


// Creator: Tuhin Patel
//Brittaney Jin
// DJ "best ever teammate" Young
//Lisha Nawani
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
        public RoomLoader roomloader;
        public List<Room> rooms;
        //private CollisionDetector collisionDetector;

        private KeyboardController keyboardController;

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
        

        link = new Link(new Vector2(400, 240), _graphics);
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
        
            blockSpriteSheet = Content.Load<Texture2D>("blocks");
            

            itemSpriteSheet = Content.Load<Texture2D>("itemsandweapons");
            currentItem = new Item(itemSpriteSheet);

            keyboardController.AddCommand(Keys.T, new PreviousBlockCommand(currentBlock));
            keyboardController.AddCommand(Keys.Y, new NextBlockCommand(currentBlock));
            keyboardController.AddCommand(Keys.U, new PreviousItemCommand(currentItem));
            keyboardController.AddCommand(Keys.I, new NextItemCommand(currentItem));
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

            enemy = new Enemy();
            keyboardController.AddCommand(Keys.O, new PreviousEnemyCommand(enemy));
            keyboardController.AddCommand(Keys.P, new NextEnemyCommand(enemy));
            keyboardController.AddCommand(Keys.R, new ResetGameCommand(link, enemy, currentBlock, currentItem));
            keyboardController.AddCommand(Keys.Q, new QuitCommand(this));


            var filename = "room.xml";
            var currentDirectory = Directory.GetCurrentDirectory();
            var purchaseOrderFilepath = Path.Combine(currentDirectory, filename);
            XDocument xml = XDocument.Load(purchaseOrderFilepath);
            roomloader = new(xml);
            rooms = roomloader.Parse();

            //this.collisionDetector = new CollisionDetector(this.link, this.rooms[0]);

        base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);   
            font = Content.Load<SpriteFont>("Times New Roman");

            // The spritefactory's fields are now initialized before any sprite classes are able to call it.

    }

    protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            keyboardController.Update();
            link.Update();
            
            currentItem.Update(); 
            enemy.Update();

            //collisionDetector.update();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlueViolet);
            link.Draw(_spriteBatch);
            
            currentItem.Draw(_spriteBatch);
            enemy.Draw(_spriteBatch);           
            base.Draw(gameTime);
        }
    }
