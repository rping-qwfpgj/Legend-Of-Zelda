using LegendofZelda.Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.Collections.Generic;
using LegendofZelda.SpriteFactories;
using System.Diagnostics;

namespace Sprites
{
    public class Digdogger : IEnemy
    {
        private IDigdogger currentDigdogger;

        private bool isDead = false;
        private int health = 3;
        private int deathFrames = 0;
        private bool isDamaged = false;
        private int damagedCounter = 0;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        private int currFrames = 0;

        public enum DigdoggerActions
        {
            BigMovingUp, BigMovingDown, BigMovingLeft, BigMovingRight, SmallStunned
        };

        List<DigdoggerActions> digDoggerActions = new List<DigdoggerActions> {DigdoggerActions.BigMovingUp, DigdoggerActions.BigMovingDown,
        DigdoggerActions.BigMovingRight, DigdoggerActions.BigMovingLeft, DigdoggerActions.SmallStunned};
        DigdoggerActions currAction;

        private List<string> droppableItems = new List<string> { "BigHeart" };
        private Texture2D texture;
        private Texture2D dyingTexture;

        //private int prevdirection = 1;
        private float xPos;
        private float yPos;
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public Digdogger(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPos = xPosition;
            this.yPos = yPosition;
            this.dyingTexture = texture2;
            this.destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 39, 48);
            this.currAction = DigdoggerActions.BigMovingDown;
            this.currentDigdogger = new DigdoggerGoingDownSprite(texture, this.xPos, this.yPos);

        }

        public void Update()
        {



            // Decided if the digdogger should change its current action
            if (!isDead)
            {
                ++this.currFrames;
                if (isDamaged)
                {
                    damagedCounter++;
                    if (damagedCounter >= 60)
                    {
                        isDamaged = false;
                        this.currentDigdogger.IsDamaged = false;
                        damagedCounter = 0;
                    }
                }


                this.currentDigdogger.Update();
                this.destinationRectangle = currentDigdogger.DestinationRectangle;
                // Pick an action to take based on where link is
                Vector2 linkLocation = Link.Instance.currentPosition;

                if (!(this.currentDigdogger is DigdoggerSmallStunnedSprite))
                {
                    if (linkLocation.Y > this.currentDigdogger.YPosition)
                    {
                        this.currAction = DigdoggerActions.BigMovingDown;
                    }
                    else if (linkLocation.X > this.currentDigdogger.XPosition)
                    {
                        this.currAction = DigdoggerActions.BigMovingRight;
                    }
                    else if (linkLocation.Y < this.currentDigdogger.YPosition)
                    {
                        this.currAction = DigdoggerActions.BigMovingUp;
                    }
                    else
                    {
                        this.currAction = DigdoggerActions.BigMovingLeft;
                    }
                }
                else
                {
                    if ((this.currFrames % 180) == 0)
                    {
                        this.currAction = DigdoggerActions.BigMovingDown;
                    }
                }


                this.switchAction(this.currAction);


            }



            else
            {
                deathFrames++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 15, 16);
            if (!isDead)
            {
                currentDigdogger.Draw(spriteBatch);
            }
            else
            {
                int maxDeathFrames = 20;
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                var sourceRectangles = new List<Rectangle>();
                sourceRectangles.Add(new Rectangle(0, 0, 15, 16));
                sourceRectangles.Add(new Rectangle(16, 0, 15, 16));
                sourceRectangles.Add(new Rectangle(35, 3, 9, 10));
                sourceRectangles.Add(new Rectangle(51, 3, 9, 10));
                this.destinationRectangle = new Rectangle((int)this.currentDigdogger.XPosition, (int)this.currentDigdogger.YPosition, 30, 30);
                for(int i= 0; i < sourceRectangles.Count; i++){
                    if(deathFrames>i * maxDeathFrames / sourceRectangles.Count && deathFrames<= (i +1)* maxDeathFrames / sourceRectangles.Count)
                    {
                        if (!dyingComplete)
                        {
                            spriteBatch.Draw(dyingTexture, this.destinationRectangle, sourceRectangles[i], Color.White);
                        }
                    }
                }
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            Rectangle hitbox = currentDigdogger.GetHitbox();

            return hitbox;
        }

        public void switchAction(DigdoggerActions actionToTake)
        {
            // Get the hitbox of the current goriya
            Rectangle currentLocation = currentDigdogger.GetHitbox();
            this.xPos = (float)currentLocation.X;
            this.yPos = (float)currentLocation.Y;

            // Randomly select a goriya state to make
            switch (actionToTake)
            {
                case DigdoggerActions.BigMovingUp:
                    this.currentDigdogger = new DigdoggerGoingUpSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DigdoggerActions.BigMovingDown:
                    this.currentDigdogger = new DigdoggerGoingDownSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DigdoggerActions.BigMovingLeft:
                    this.currentDigdogger = new DigdoggerGoingLeftSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DigdoggerActions.BigMovingRight:
                    this.currentDigdogger = new DigdoggerGoingRightSprite(this.texture, this.xPos, this.yPos);
                    break;
                case DigdoggerActions.SmallStunned:
                    this.currentDigdogger = new DigdoggerSmallStunnedSprite(this.texture, this.xPos, this.yPos);
                    break;
                default:
                    break;
            }
        }

        public void TurnAround(string side)
        {
            // Get the hitbox of the current goriya
            Rectangle currentLocation = currentDigdogger.GetHitbox();
            this.xPos = (float)currentLocation.X;
            this.yPos = (float)currentLocation.Y;

            // Have the Digdogger turn around based on what wall it is running into
            switch (side)
            {
                case "top":
                    this.currentDigdogger = new DigdoggerGoingDownSprite(this.texture, this.xPos, this.yPos);
                    this.currAction = DigdoggerActions.BigMovingDown;
                    break;
                case "bottom":
                    this.currentDigdogger = new DigdoggerGoingUpSprite(this.texture, this.xPos, this.yPos);
                    this.currAction = DigdoggerActions.BigMovingUp;
                    break;
                case "left":
                    this.currentDigdogger = new DigdoggerGoingRightSprite(this.texture, this.xPos, this.yPos);
                    this.currAction = DigdoggerActions.BigMovingRight;
                    break;
                case "right":
                    this.currentDigdogger = new DigdoggerGoingLeftSprite(this.texture, this.xPos, this.yPos);
                    this.currAction = DigdoggerActions.BigMovingLeft;
                    break;
                case "stunned":
                    this.currentDigdogger = new DigdoggerSmallStunnedSprite(this.texture, this.xPos, this.yPos);
                    this.currAction = DigdoggerActions.SmallStunned;
                    break;
                default:
                    break;

            }

        }


        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
            if (!isDamaged)
            {
                this.health -= 1;
                this.isDamaged = true;
                this.currentDigdogger.IsDamaged = true;
            }

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
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(this.currentDigdogger.XPosition, this.currentDigdogger.YPosition - 150), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }

        public void PoofIn(SpriteBatch spriteBatch) { }
    }
}
