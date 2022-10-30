using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.Collections.Generic;

namespace Sprites
{
    public class GoriyaSprite : IEnemy
    {
        private IEnemy currentGoriya;
        private enum GoriyaActions { MovingUp, MovingDown, MovingRight, MovingLeft, ThrowingUp, ThrowingRight,
            ThrowingLeft, ThrowingDown };

        List<GoriyaActions> goriyaActions = new List<GoriyaActions> {GoriyaActions.MovingUp, GoriyaActions.MovingDown,
        GoriyaActions.MovingRight, GoriyaActions.MovingLeft, GoriyaActions.ThrowingUp, GoriyaActions.ThrowingRight,
        GoriyaActions.ThrowingLeft};
        private Random rand = new Random();

        private Texture2D texture;

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

        public GoriyaSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPos = xPosition;
            this.yPos = yPosition;
            this.currentGoriya = new GoriyaMovingRightSprite(texture, this.xPos, this.yPos);
        }

        public void Update()
        {
            // Decided if the goriya should change its current action
            if ((rand.Next(0, 1000)) % 50 == 0)
            {
                this.switchAction();
            }

            currentGoriya.Update();


        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            currentGoriya.Draw(spriteBatch);
            spriteBatch.End();
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
                    break;
                case GoriyaActions.ThrowingDown:
                    this.currentGoriya = new GoriyaThrowingDownSprite(this.texture,this.xPos, this.yPos);
                    break;
                case GoriyaActions.ThrowingLeft:
                    this.currentGoriya = new GoriyaThrowingLeftSprite(this.texture, this.xPos, this.yPos);
                    break;
                case GoriyaActions.ThrowingRight:
                    this.currentGoriya = new GoriyaThrowingRightSprite(this.texture, this.xPos, this.yPos);
                    break;
                default:
                    break;
            }
        }

        public void TakeDamage(string side)
        {
            currentGoriya.TakeDamage(side);
        }
    }
}
