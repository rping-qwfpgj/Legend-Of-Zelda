using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.Collections.Generic;
using LegendofZelda.SpriteFactories;
using SharpDX.MediaFoundation.DirectX;

namespace Sprites
{
    public class DodongoSprite : IEnemy
    {
        private IDodongo currentDodongo;
        private bool isDead = false;
        private int health = 2;
        private int deathFrames = 0;
        private bool isDamaged = false;
        private int damagedCounter = 0;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private int switchCounter = 0;
        private enum DodongoActions
        {
            MovingUp, MovingDown, MovingRight, MovingLeft
        };

        List<DodongoActions> dodongoActions = new List<DodongoActions> {DodongoActions.MovingUp, DodongoActions.MovingDown,
        DodongoActions.MovingRight, DodongoActions.MovingLeft};


        private Random rand = new Random();

        private List<string> droppableItems = new List<string> { "SmallRedHeart", "SmallBlueHeart", "OrangeGemstone", "Bomb" };


        private Texture2D texture;
        private Texture2D dyingTexture;

        //  Obsolete variables
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        //private int prevdirection = 1;
        private float xPos;
        private float yPos;
        private Rectangle sourceRectangle;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public DodongoSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPos = xPosition;
            this.yPos = yPosition;
            this.dyingTexture = texture2;
            this.destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 39, 48);
            this.currentDodongo = new DodongoMovingRightSprite(texture, this.xPos, this.yPos);
        }

        public void Update()
        {
            // Decided if the goriya should change its current action
            if (!isDead)
            {
                switchCounter += rand.Next(0, 10);
                if (isDamaged)
                {
                    damagedCounter++;
                    if (damagedCounter >= 120)
                    {
                        isDamaged = false;
                        this.currentDodongo.IsDamaged = false;
                        damagedCounter = 0;
                    }
                }
                if (switchCounter >= 400)
                {
                    this.switchAction();
                    switchCounter = 0;
                }
                currentDodongo.Update();
                this.destinationRectangle = currentDodongo.DestinationRectangle;
            }
            else
            {
                deathFrames++;
            }

            //currentBoomerang.Update();


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sourceRectangle = new Rectangle(0, 0, 15, 16);
            if (!isDead)
            {
                //spriteBatch.Begin();
                currentDodongo.Draw(spriteBatch);
            }
            else
            {
                spriteBatch.Begin();
                this.destinationRectangle = new Rectangle((int)this.currentDodongo.XPosition, (int)this.currentDodongo.YPosition, 30, 30);
                if (deathFrames >= 0 && deathFrames <= 5)
                {
                    sourceRectangle = new Rectangle(0, 0, 15, 16);

                }
                else if (deathFrames > 5 && deathFrames < 10)
                {
                    sourceRectangle = new Rectangle(16, 0, 15, 16);
                }
                else if (deathFrames >= 10 && deathFrames < 15)
                {
                    sourceRectangle = new Rectangle(35, 3, 9, 10);

                }
                else if (deathFrames >= 15 && deathFrames < 20)
                {
                    sourceRectangle = new Rectangle(51, 3, 9, 10);

                }
                else
                {
                    this.dyingComplete = true;
                }
                if (!dyingComplete)
                {
                    spriteBatch.Draw(dyingTexture, this.destinationRectangle, sourceRectangle, Microsoft.Xna.Framework.Color.White);
                }

                spriteBatch.End();
            }
        }



        public Rectangle GetHitbox()
        {
            Rectangle hitbox = currentDodongo.GetHitbox();

            return hitbox;
        }

        private void switchAction()
        {
            // Get the hitbox of the current goriya
            Rectangle currentLocation = currentDodongo.GetHitbox();
            this.xPos = (float)currentLocation.X;
            this.yPos = (float)currentLocation.Y;

            // Randomly select a goriya state to make
            switch (dodongoActions[rand.Next(0, dodongoActions.Count)])
            {
                case DodongoActions.MovingUp:
                    this.currentDodongo = new DodongoMovingUpSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DodongoActions.MovingDown:
                    this.currentDodongo = new DodongoMovingDownSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DodongoActions.MovingLeft:
                    this.currentDodongo = new DodongoMovingLeftSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DodongoActions.MovingRight:
                    this.currentDodongo = new DodongoMovingRightSprite(this.texture, this.xPos, this.yPos);
                    break;
                default:
                    break;
            }
        }

        public void TurnAround(string side)
        {
            // Get the hitbox of the current goriya
            Rectangle currentLocation = currentDodongo.GetHitbox();
            this.xPos = (float)currentLocation.X;
            this.yPos = (float)currentLocation.Y;

            // Have the Goriya turn around based on what wall it is running into
            switch (side)
            {
                case "top":
                    this.currentDodongo = new DodongoMovingDownSprite(this.texture, this.xPos, this.yPos);
                    break;
                case "bottom":
                    this.currentDodongo = new DodongoMovingUpSprite(this.texture, this.xPos, this.yPos);
                    break;
                case "left":
                    this.currentDodongo = new DodongoMovingRightSprite(this.texture, this.xPos, this.yPos);
                    break;
                case "right":
                    this.currentDodongo = new DodongoMovingLeftSprite(this.texture, this.xPos, this.yPos);
                    break;
                default:
                    break;

            }

        }

        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
            this.health -= 1;
            this.isDamaged = true;
            this.currentDodongo.IsDamaged = true;
            if (this.health <= 0)
            {
                this.isDead = true;
            }
        }

        public ISprite DropItem()
        {
            if (dyingComplete)
            {
                Random random = new Random();
                int rand = random.Next(0, droppableItems.Count);
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(this.currentDodongo.XPosition, this.currentDodongo.YPosition - 150), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }

        public void Die()
        {

        }
    }
}
