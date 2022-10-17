using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;
using System;
using System.Collections.Generic;


namespace Sprites
{
    public class DragonBossSprite : IEnemy
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
        
        // Projectile orbs
        private TopDragonAttackOrbSprite topAttackOrb;
        private MiddleDragonAttackOrbSprite middleAttackOrb;
        private BottomDragonAttackOrbSprite bottomAttackOrb;
         // On Screen location
        private Rectangle destinationRectangle;
        public DragonBossSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;

            topAttackOrb = new TopDragonAttackOrbSprite(texture, xPosition, yPosition);
            middleAttackOrb = new MiddleDragonAttackOrbSprite(texture, xPosition, yPosition);
            bottomAttackOrb = new BottomDragonAttackOrbSprite(texture, xPosition, yPosition);
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

            // Update the x position
            this.xPosition += 2 * direction;

            // Update the orbs
            topAttackOrb.Update();
            middleAttackOrb.Update();
            bottomAttackOrb.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle dragonSourceRectangle = new Rectangle(1, 11, 24, 32);
            

            Rectangle dragonDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 96, 128);

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
            topAttackOrb.Draw(spriteBatch);
            middleAttackOrb.Draw(spriteBatch);
            bottomAttackOrb.Draw(spriteBatch);
           
            spriteBatch.End();
            

        }

       public Rectangle getHitbox()
       {
            // TEMPORARY, working on what to put here
            return this.attackOrbs[this.currOrb];
       }
    }

    public class TopDragonAttackOrbSprite: IEnemyProjectile 
    {
          // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new List<Rectangle>();
        private Rectangle blueOrb = new Rectangle(128, 14, 8, 10);
        private Rectangle orangeOrb = new Rectangle(119, 14, 8, 10);
        private Rectangle greenOrb = new Rectangle(110, 14, 8, 10);
        private Rectangle multicolorOrb = new Rectangle(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;

        public TopDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition =xPosition;
            this.yPosition =yPosition;
            this.destinationRectangle = (this.xPosition, this.yPosition, 32, 40);

            this.currOrb = 0;
            this.attackOrbs.Add(blueOrb);
            this.attackOrbs.Add(orangeOrb);
            this.attackOrbs.Add(greenOrb);
            this.attackOrbs.Add(multicolorOrb);
        }
        public void Update()
        {
            // Updated frames in the exact way the dragon is
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
            
            // Update x and y so that this orb goes towards the upper left in a diagonal line
            this.xPosition -= currFrames; // Curr frames is used as it  is a consistently changing number that lets the orb move in a smooth motion
            this.yPosition -= currFrames; 

            // Update the full location of the orb
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 40);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, this.destinationRectangle, attackOrbs[this.currOrb], Color.White);
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return this.destinationRectangle;

        }

    }

     public class MiddleDragonAttackOrbSprite: IEnemyProjectile 
     {
          // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new List<Rectangle>();
        private Rectangle blueOrb = new Rectangle(128, 14, 8, 10);
        private Rectangle orangeOrb = new Rectangle(119, 14, 8, 10);
        private Rectangle greenOrb = new Rectangle(110, 14, 8, 10);
        private Rectangle multicolorOrb = new Rectangle(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;

        public MiddleDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = (this.xPosition, this.yPosition, 32, 40);

            this.currOrb = 0;
            this.attackOrbs.Add(blueOrb);
            this.attackOrbs.Add(orangeOrb);
            this.attackOrbs.Add(greenOrb);
            this.attackOrbs.Add(multicolorOrb);
        }
        public void Update()
        {
            // Updated frames in the exact way the dragon is
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
            
            // Update just x so that this orb goes towards the left in a horizontal line
            this.xPosition -= currFrames; // Curr frames is used as it  is a consistently changing number that lets the orb move in a smooth motion
           

            // Update the full location of the orb
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 40);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, this.destinationRectangle, attackOrbs[this.currOrb], Color.White);
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return this.destinationRectangle;

        }

    }

     public class BottomDragonAttackOrbSprite: IEnemyProjectile 
     {
          // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new List<Rectangle>();
        private Rectangle blueOrb = new Rectangle(128, 14, 8, 10);
        private Rectangle orangeOrb = new Rectangle(119, 14, 8, 10);
        private Rectangle greenOrb = new Rectangle(110, 14, 8, 10);
        private Rectangle multicolorOrb = new Rectangle(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;

        public BottomDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.destinationRectangle = (this.xPosition, this.yPosition, 32, 40);

            this.currOrb = 0;
            this.attackOrbs.Add(blueOrb);
            this.attackOrbs.Add(orangeOrb);
            this.attackOrbs.Add(greenOrb);
            this.attackOrbs.Add(multicolorOrb);
        }
        public void Update()
        {
            // Updated frames in the exact way the dragon is
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
            
            // Update x and y so that this orb goes towards the upper left in a diagonal line
            this.xPosition -= currFrames; // Curr frames is used as it  is a consistently changing number that lets the orb move in a smooth motion
            this.yPosition -= currFrames; 

            // Update the full location of the orb
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 40);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, this.destinationRectangle, attackOrbs[this.currOrb], Color.White);
            spriteBatch.End();
        }

        public Rectangle getHitbox()
        {
            return this.destinationRectangle;

        }

    }

}

