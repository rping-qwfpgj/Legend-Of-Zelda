﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;

namespace Sprites
{
    public class KeeseSprite : IEnemy
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;
        private SoundEffect enemyHit;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private bool movingHorizontally = true;
        private bool movingVertically = false;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }

        // On screen position
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public KeeseSprite(Texture2D texture, float xPosition, float yPosition, SoundEffect sound)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.enemyHit = sound;
        }

        public void Update()
        {
            if (currFrames == maxFrames / 2)
            {
                direction *= -1;
                movingHorizontally = !movingHorizontally;
                movingVertically = !movingVertically;
            }
            if (currFrames == maxFrames)
            {
                currFrames = 0;
            }
            else
            {
                currFrames += 10;
            }

            if (movingVertically && !movingHorizontally)
            {
                if (this.yPosition < 0 || this.yPosition > 480) { direction *= -1; }
                this.yPosition += (1 * direction);
            }
            if (movingHorizontally && !movingVertically)
            {
                if (this.xPosition < 0 || this.xPosition > 800) { direction *= -1; }
                this.xPosition += (1 * direction);
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle sourceRectangle;
            

            spriteBatch.Begin();
            if ((currFrames / 100) % 2 != 0)
            {
                sourceRectangle = new Rectangle(183, 15, 16, 8);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 64, 32);
            }
            else
            {
                sourceRectangle = new Rectangle(203, 15, 10, 10);
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 40, 40);
            }
            spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;
        }

        public void TakeDamage(string side)
        {

        }

        public void Die()
        {

        }
    }
}

