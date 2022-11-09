using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.Collections.Generic;
using LegendofZelda.SpriteFactories;

namespace Sprites
{
    public class GoriyaSprite : IEnemy
    {
        private IEnemy currentGoriya;
        private IEnemyProjectile currentBoomerang;
        private bool isDead = false;
        private int health = 3;
        private int deathFrames = 0;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }

        private enum GoriyaActions { MovingUp, MovingDown, MovingRight, MovingLeft, ThrowingUp, ThrowingRight,
            ThrowingLeft, ThrowingDown };

        List<GoriyaActions> goriyaActions = new List<GoriyaActions> {GoriyaActions.MovingUp, GoriyaActions.MovingDown,
        GoriyaActions.MovingRight, GoriyaActions.MovingLeft, GoriyaActions.ThrowingUp, GoriyaActions.ThrowingRight,
        GoriyaActions.ThrowingLeft};


        private Random rand = new Random();

      

        private Texture2D texture;
        private Texture2D dyingTexture;

        //  Obsolete variables
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private int prevdirection = 1;
        private float xPos;
        private float yPos;
        private Rectangle destinationRectangle = new Rectangle(100, 100, 0, 0);
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public GoriyaSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPos = xPosition;
            this.yPos = yPosition;
            this.dyingTexture = texture2;
            this.currentGoriya = new GoriyaThrowingRightSprite(texture, this.xPos, this.yPos);
            this.currentBoomerang = new GoriyaBoomerangRightSprite(texture, (int)xPosition, (int)yPosition);
        }

        public void Update()
        {
            // Decided if the goriya should change its current action
            if (!isDead)
            {
                if ((rand.Next(0, 1000)) % 100 == 0)
                {
                    this.switchAction();
                }
                else
                {

                    currentGoriya.Update();
                }
            } else
            {
                deathFrames++;
            }

            //currentBoomerang.Update();


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 15, 16);
            if (!isDead)
            {
                //spriteBatch.Begin();
                currentGoriya.Draw(spriteBatch);
            }
            else
            {
                spriteBatch.Begin();
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 30);
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
                    spriteBatch.Draw(dyingTexture, this.destinationRectangle, sourceRectangle, Color.White);
                }

                spriteBatch.End();
            }
            //currentBoomerang.Draw(spriteBatch);
            //spriteBatch.End();
        }



        public Rectangle GetHitbox()
        {
            Rectangle hitbox = currentGoriya.GetHitbox();

            return hitbox;
        }

        private void switchAction()
        {
            // Get the hitbox of the current goriya
            Rectangle currentLocation = currentGoriya.GetHitbox();
            this.xPos = (float)currentLocation.X;
            this.yPos = (float)currentLocation.Y;

            // Randomly select a goriya state to make
            switch (goriyaActions[rand.Next(0, goriyaActions.Count)])
            {
                case GoriyaActions.MovingUp:
                    this.currentGoriya = new GoriyaMovingUpSprite(this.texture, this.xPos, this.yPos);
                    break;
                case GoriyaActions.MovingDown:
                    this.currentGoriya = new GoriyaMovingDownSprite(this.texture, this.xPos, this.yPos);
                    break;
                case GoriyaActions.MovingLeft:
                    this.currentGoriya = new GoriyaMovingLeftSprite(this.texture, this.xPos, this.yPos);
                    break;
                case GoriyaActions.MovingRight:
                    this.currentGoriya = new GoriyaMovingRightSprite(this.texture, this.xPos, this.yPos);
                    break;
                case GoriyaActions.ThrowingUp:
                    this.currentGoriya = new GoriyaThrowingUpSprite(this.texture, this.xPos, this.yPos);
                    this.currentBoomerang = new GoriyaBoomerangUpSprite(texture, this.xPos, this.yPos);
                    break;
                case GoriyaActions.ThrowingDown:
                    this.currentGoriya = new GoriyaThrowingDownSprite(this.texture,this.xPos, this.yPos);
                    this.currentBoomerang = new GoriyaBoomerangDownSprite(texture, this.xPos, this.yPos);
                    break;
                case GoriyaActions.ThrowingLeft:
                    this.currentGoriya = new GoriyaThrowingLeftSprite(this.texture, this.xPos, this.yPos);
                    this.currentBoomerang = new GoriyaBoomerangLeftSprite(texture, this.xPos, this.yPos);
                    break;
                case GoriyaActions.ThrowingRight:
                    this.currentGoriya = new GoriyaThrowingRightSprite(this.texture, this.xPos, this.yPos);
                    this.currentBoomerang = new GoriyaBoomerangRightSprite(texture, this.xPos, this.yPos);
                    break;
                default:
                    break;
            }
        }

        public void TurnAround(string side)
        {
            // Have the Goriya turn around based on what wall it is running into
            switch (side)
            {
                case "top":
                    this.currentGoriya = new GoriyaMovingDownSprite(this.texture, this.xPos, this.yPos);
                    break;
                case "bottom":
                    this.currentGoriya = new GoriyaMovingUpSprite(this.texture, this.xPos, this.yPos);
                    break;
                case "left":
                    this.currentGoriya = new GoriyaMovingRightSprite(this.texture, this.xPos, this.yPos);
                    break;
                case "right":
                    this.currentGoriya = new GoriyaMovingLeftSprite(this.texture, this.xPos, this.yPos);
                    break;
                default:
                    break;

            }

        }

        public IEnemyProjectile GetCurrentBoomerang()
        {
            return this.currentBoomerang;
        }

        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
            this.health -= 1;
            if (this.health <= 0)
            {
                this.isDead = true;
            }
        }

        public ISprite DropItem()
        {
            return null;
        }

        public void Die()
        {

        }
    }
}
