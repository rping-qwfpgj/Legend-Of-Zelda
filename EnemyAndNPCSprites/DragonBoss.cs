using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;
using System;
using System.Collections.Generic;


namespace Sprites
{
    public class DragonBossSprite : ISprite
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        private int direction = 1;

        // Keep track of which orb to draw 
        private List<Rectangle> attackOrbs = new List<Rectangle>();
        private Rectangle blueOrb = new Rectangle(128, 14, 8, 10);
        private Rectangle orangeOrb = new Rectangle(119, 14, 8, 10);
        private Rectangle greenOrb = new Rectangle(110, 14, 8, 10);
        private Rectangle multicolorOrb = new Rectangle(101, 14, 8, 10);
        private int currOrb; // Represents current orb to draw

        public DragonBossSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.currOrb = 0;
            this.attackOrbs.Add(blueOrb);
            this.attackOrbs.Add(orangeOrb);
            this.attackOrbs.Add(greenOrb);
            this.attackOrbs.Add(multicolorOrb);
        }

        public void Update()
        {
            // Go the other direction halfway through
            if (currFrames == maxFrames / 2)
            {
                direction *= -1;
            }

            // Reset motion if at max
            if (currFrames == maxFrames)
            {
                currFrames = 0;
            }
            else
            {
                currFrames += 10;
            }

            // Update current orb
            ++this.currOrb;
            if(this.currOrb >= this.attackOrbs.Count)
            {
                this.currOrb = 0;
            } 
            // Update the x position
            this.xPosition += 2 * direction;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle dragonSourceRectangle = new Rectangle(1, 11, 24, 32);
            Rectangle attackSourceRectange = this.attackOrbs[this.currOrb];

            Rectangle dragonDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 96, 128);

            // Start the attack destinations at where dragon is.
            // Update projectile positions
            Rectangle topAttackRectangle = new Rectangle((int)this.xPosition - currFrames, (int)this.yPosition - currFrames, 32, 40);
            Rectangle middleAttackRectangle = new Rectangle((int)this.xPosition - currFrames, (int)this.yPosition, 32, 40);
            Rectangle bottomAttackRectangle = new Rectangle((int)this.xPosition - currFrames, (int)this.yPosition + currFrames, 32, 40);



            if (currFrames >= 0 && currFrames < 500)
            {
                // Dragon to draw
                dragonSourceRectangle = new Rectangle(1, 11, 24, 32);
            } else if (currFrames >= 500 && currFrames <1000)
            {
                // Dragon rectangle
                dragonSourceRectangle = new Rectangle(26, 11, 24, 32);
            } else if (currFrames >= 1000 && currFrames < 1500)
            {
                // Dragon rectangle
                dragonSourceRectangle = new Rectangle(51, 11, 24, 32);
                
            } else if (currFrames >= 1500 && currFrames < 2000)
            {
                // Dragon rectangle
                dragonSourceRectangle = new Rectangle(76, 11, 24, 32);
            }
            spriteBatch.Begin();

            spriteBatch.Draw(texture, dragonDestinationRectangle, dragonSourceRectangle, Color.White);
            spriteBatch.Draw(texture, topAttackRectangle, attackSourceRectange, Color.White);
            spriteBatch.Draw(texture, middleAttackRectangle, attackSourceRectange, Color.White);
            spriteBatch.Draw(texture, bottomAttackRectangle, attackSourceRectange, Color.White);

            spriteBatch.End();
            

        }

       public Vector2 getPosition()
       {
            return new Vector2(0, 0);
       }
    }
}

