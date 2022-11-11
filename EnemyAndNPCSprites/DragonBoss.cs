using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using LegendofZelda.SpriteFactories;

namespace Sprites
{
    public class DragonBossSprite : IEnemy
    {
        private List<string> droppableItems = new List<string> { "Fairy", "BigHeart", "PurpleGemstone", "OrangeGemstone" };

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 480;
        private int deathFrames = 0;
        private int health = 3;
        private bool isDamaged = false;
        private int damagedCounter = 0;

        // Texture to take sprites from
        private Texture2D texture;
        private Texture2D dyingTexture;
        private SoundEffect enemyHit;

        // X and Y positions of the sprite
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }

        // On screen location
        Rectangle dragonDestinationRectangle;
        public Rectangle DestinationRectangle { get => dragonDestinationRectangle; set => dragonDestinationRectangle = value;}

        // Projectile orbs
        private TopDragonAttackOrbSprite topAttackOrb;
        private MiddleDragonAttackOrbSprite middleAttackOrb;
        private BottomDragonAttackOrbSprite bottomAttackOrb;
        
        public DragonBossSprite(Texture2D texture, float xPosition, float yPosition, SoundEffect sound, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.enemyHit = sound;
            this.dyingTexture = texture2;

            this.topAttackOrb = new TopDragonAttackOrbSprite(texture, xPosition, yPosition);
            this.middleAttackOrb = new MiddleDragonAttackOrbSprite(texture, xPosition, yPosition);
            this.bottomAttackOrb = new BottomDragonAttackOrbSprite(texture, xPosition, yPosition);
        }

        public void Update()
        {
            if (!isDead)
            {
                if (isDamaged)
                {
                    damagedCounter++;
                    if (damagedCounter > 60)
                    {
                        isDamaged = false;
                        damagedCounter = 0;
                    }
                }
                // Go the other direction halfway through
                if (currFrames == maxFrames / 2)
                {
                    direction *= -1;
                }

                // Reset motion if at max
                if (currFrames == maxFrames)
                {
                    currFrames = 0;
                    this.topAttackOrb = new TopDragonAttackOrbSprite(texture, xPosition, yPosition);
                    this.middleAttackOrb = new MiddleDragonAttackOrbSprite(texture, xPosition, yPosition);
                    this.bottomAttackOrb = new BottomDragonAttackOrbSprite(texture, xPosition, yPosition);
                }
                else
                {
                    currFrames += 5;
                }

                // Update the x position
                this.xPosition += 1 * direction;
            } else
            {
                deathFrames++;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            Rectangle dragonSourceRectangle = new Rectangle(1, 11, 24, 32);

            if (!isDead)
            {
                this.dragonDestinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 96, 128);

                if (currFrames <= maxFrames / 8)
                {
                    // Dragon to draw
                    dragonSourceRectangle = new Rectangle(1, 11, 24, 32);
                }
                else if (currFrames <= maxFrames / 4)
                {
                    // Dragon rectangle
                    dragonSourceRectangle = new Rectangle(26, 11, 24, 32);
                }
                else if (currFrames <= maxFrames / 2)
                {
                    // Dragon rectangle
                    dragonSourceRectangle = new Rectangle(51, 11, 24, 32);

                }
                else if (currFrames <= maxFrames )
                {
                    // Dragon rectangle
                    dragonSourceRectangle = new Rectangle(76, 11, 24, 32);
                }
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if (isDamaged)
                {
                    spriteBatch.Draw(texture, this.dragonDestinationRectangle, dragonSourceRectangle, Color.Lerp(Color.White, Color.Red, 0.5f)); 
                } else
                {
                    spriteBatch.Draw(texture, this.dragonDestinationRectangle, dragonSourceRectangle, Color.White);

                }
                spriteBatch.End();
                
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                this.dragonDestinationRectangle = new Rectangle((int)this.xPosition + 48, (int)this.yPosition + 64, 60, 60);
                if (deathFrames >= 0 && deathFrames <= 5)
                {
                    dragonSourceRectangle = new Rectangle(0, 0, 15, 16);

                }
                else if (deathFrames > 5 && deathFrames < 10)
                {
                    dragonSourceRectangle = new Rectangle(16, 0, 15, 16);
                }
                else if (deathFrames >= 10 && deathFrames < 15)
                {
                    dragonSourceRectangle = new Rectangle(35, 3, 9, 10);

                }
                else if (deathFrames >= 15 && deathFrames < 20)
                {
                    dragonSourceRectangle = new Rectangle(51, 3, 9, 10);

                }
                else
                {
                    this.dyingComplete = true;
                }
                if (!dyingComplete)
                {
                    spriteBatch.Draw(dyingTexture, this.dragonDestinationRectangle, dragonSourceRectangle, Color.White);
                }

                spriteBatch.End();
            }

            //spriteBatch.End();


        }

        public Rectangle GetHitbox()
       {
            // TEMPORARY, working on what to put here
            return this.dragonDestinationRectangle;
       }

       public void TurnAround(string side)
       {

       }

       // Allows other things in the game to get the projectiles
       public List<ISprite> getEnemyProjectiles()
        {
            // Make a list to return
            List<ISprite> projectileList = new List<ISprite>{topAttackOrb, middleAttackOrb, bottomAttackOrb};
            return projectileList;
        
        }



        public void TakeDamage(string side)
        {
            enemyHit.Play();
            this.isDamaged = true;
            this.health -= 1;
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
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(this.xPosition, this.yPosition - 150), droppableItems[rand]);
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

    public class TopDragonAttackOrbSprite: IEnemyProjectile 
    {
          // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 480;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // Original positions to reset to
        private int originalX;
        private int originalY;

        public bool keepThrowing { get; set; }

        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new List<Rectangle>();
        private Rectangle blueOrb = new Rectangle(128, 14, 8, 10);
        private Rectangle orangeOrb = new Rectangle(119, 14, 8, 10);
        private Rectangle greenOrb = new Rectangle(110, 14, 8, 10);
        private Rectangle multicolorOrb = new Rectangle(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public TopDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.originalX = this.xPosition;
            this.originalY = this.yPosition;
            this.destinationRectangle = new Rectangle(this.xPosition, this.yPosition, 32, 40);

            this.currOrb = 0;
            this.attackOrbs.Add(blueOrb);
            this.attackOrbs.Add(orangeOrb);
            this.attackOrbs.Add(greenOrb);
            this.attackOrbs.Add(multicolorOrb);
        }
        public void Update()
        {
            /* Updated frames in the exact way the dragon is
            if (currFrames == maxFrames)
            {
                //currFrames = 0;
                //this.xPosition = this.originalX;
                this.yPosition = this.originalY;
            }
            else
            {
                currFrames += 10;
            }
            */
            // Update current orb
            currFrames += 5;
            if(currFrames % 500 == 0) { 
                ++this.currOrb;
            }
            if(this.currOrb >= this.attackOrbs.Count)
            {
                this.currOrb = 0;
            } 
            
            // Update x and y so that this orb goes towards the upper left in a diagonal line
            this.xPosition -= 2; // Curr frames is used as it  is a consistently changing number that lets the orb move in a smooth motion
            this.yPosition -= 2; 

            // Update the full location of the orb
            this.destinationRectangle = new((int)this.xPosition, (int)this.yPosition, 32, 40);

        }

         public void Draw(SpriteBatch spriteBatch)
        {
             if(this.currFrames < maxFrames) { 
                spriteBatch.Begin();
                spriteBatch.Draw(texture, this.destinationRectangle, attackOrbs[this.currOrb], Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;

        }

        public void collide()
        {
           this.currFrames = maxFrames;
           
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
        private int xPosition;
        private int yPosition;

        // Original positions to reset to
        private int originalX;
        private int originalY;

       public bool keepThrowing { get; set; }

        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new List<Rectangle>();
        private Rectangle blueOrb = new Rectangle(128, 14, 8, 10);
        private Rectangle orangeOrb = new Rectangle(119, 14, 8, 10);
        private Rectangle greenOrb = new Rectangle(110, 14, 8, 10);
        private Rectangle multicolorOrb = new Rectangle(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public MiddleDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.originalX = this.xPosition;
            this.originalY = this.yPosition;
            this.destinationRectangle = new Rectangle(this.xPosition, this.yPosition, 32, 40);

            this.currOrb = 0;
            this.attackOrbs.Add(blueOrb);
            this.attackOrbs.Add(orangeOrb);
            this.attackOrbs.Add(greenOrb);
            this.attackOrbs.Add(multicolorOrb);
        }
        public void Update()
        {
            /*
            // Updated frames in the exact way the dragon is
            if (currFrames == maxFrames)
            {
                currFrames = 0;
                this.xPosition = this.originalX;
                this.yPosition = this.originalY;
            }
            else
            {
                currFrames += 10;
            }
            */
            // Update current orb
            currFrames+=10;
            if(currFrames % 10 == 0) { 
                ++this.currOrb;
            }
            if(this.currOrb >= this.attackOrbs.Count)
            {
                this.currOrb = 0;
            } 
            
            // Update just x so that this orb goes towards the left in a horizontal line
            this.xPosition -= 2; // Curr frames is used as it  is a consistently changing number that lets the orb move in a smooth motion
           

            // Update the full location of the orb
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 40);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
             if(this.currFrames < maxFrames) {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, this.destinationRectangle, attackOrbs[this.currOrb], Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;

        }

        public void collide()
        {
            this.currFrames = maxFrames;
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
        private int xPosition;
        private int yPosition;

         // Original positions to reset to
        private int originalX;
        private int originalY;

        public bool keepThrowing { get; set; }

        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new List<Rectangle>();
        private Rectangle blueOrb = new Rectangle(128, 14, 8, 10);
        private Rectangle orangeOrb = new Rectangle(119, 14, 8, 10);
        private Rectangle greenOrb = new Rectangle(110, 14, 8, 10);
        private Rectangle multicolorOrb = new Rectangle(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}

        public BottomDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            this.originalX = this.xPosition;
            this.originalY = this.yPosition;
            this.destinationRectangle = new Rectangle(this.xPosition, this.yPosition, 32, 40);

            this.currOrb = 0;
            this.attackOrbs.Add(blueOrb);
            this.attackOrbs.Add(orangeOrb);
            this.attackOrbs.Add(greenOrb);
            this.attackOrbs.Add(multicolorOrb);
        }
        public void Update()
        {
            /* Updated frames in the exact way the dragon is
            if (currFrames == maxFrames)
            {
                currFrames = 0;
                this.xPosition = this.originalX;
                this.yPosition = this.originalY;
            }
            else
            {
                currFrames += 10;
            }
            */
            currFrames += 10;
            // Update current orb
            if(currFrames % 10 == 0) { 
            ++this.currOrb;
            }
            if(this.currOrb >= this.attackOrbs.Count)
            {
                this.currOrb = 0;
            } 
            
            // Update x and y so that this orb goes towards the upper left in a diagonal line
            this.xPosition -= 2; // Curr frames is used as it  is a consistently changing number that lets the orb move in a smooth motion
            this.yPosition += 2; 

            // Update the full location of the orb
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 40);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
             if(this.currFrames < maxFrames) { 
                spriteBatch.Begin();
                spriteBatch.Draw(texture, this.destinationRectangle, attackOrbs[this.currOrb], Color.White);
                spriteBatch.End();
            }
        }

        public Rectangle GetHitbox()
        {
            return this.destinationRectangle;

        }

        public void TakeDamage(string side)
        {

        }

        public void collide()
        {
            this.currFrames = maxFrames;
        }

    }

}

