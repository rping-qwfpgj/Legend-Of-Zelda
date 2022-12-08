using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using LegendofZelda.SpriteFactories;
using System.Runtime.CompilerServices;
using CommonReferences;

namespace Sprites
{
    public class DragonBossSprite : IEnemy
    {
        private List<string> droppableItems = new List<string> { "Fairy" };

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 480;
        private int deathFrames = 0;
        private int maxDeathFrames = 40;

        private int poofCounter = 0;
        private int maxPoofCounter = 15;
        private List<Rectangle> poofRectangles = new() { new Rectangle(236, 270, 16, 16), new Rectangle(253, 270, 16, 16), new Rectangle(272, 272, 16, 16) };

        private int health = 3;
        private bool isDamaged = false;
        private int damagedCounter = 0;

        // Texture to take sprites from
        private Texture2D texture;
        private Texture2D dyingTexture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        private int direction = 1;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }

        // On screen location
        private Rectangle dragonDestinationRectangle;
        private Rectangle sourceRectangle;
        private List<Rectangle> sourceRectangles;

        public Rectangle DestinationRectangle { get => dragonDestinationRectangle; set => dragonDestinationRectangle = value; }

        // Projectile orbs
        private TopDragonAttackOrbSprite topAttackOrb;
        private MiddleDragonAttackOrbSprite middleAttackOrb;
        private BottomDragonAttackOrbSprite bottomAttackOrb;
        public DragonBossSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            dyingTexture = texture2;

            topAttackOrb = new TopDragonAttackOrbSprite(texture, xPosition, yPosition);
            middleAttackOrb = new MiddleDragonAttackOrbSprite(texture, xPosition, yPosition);
            bottomAttackOrb = new BottomDragonAttackOrbSprite(texture, xPosition, yPosition);

            sourceRectangles = new();
            sourceRectangles.Add(new(0, 0, 15, 16));
            sourceRectangles.Add(new(16, 0, 15, 16));
            sourceRectangles.Add(new(35, 3, 9, 10));
            sourceRectangles.Add(new(51, 3, 9, 10));
            sourceRectangle = new();
        }

        public void Update()
        {
            if (!isDead)
            {
                if (poofCounter >= maxPoofCounter)
                {
                    // keeps track of how long sprite stays red
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
                    currFrames += 5;
                    // Reset motion if at max
                    if (currFrames == maxFrames)
                    {
                        currFrames = 0;
                        topAttackOrb = new TopDragonAttackOrbSprite(texture, xPosition, yPosition + 30);
                        middleAttackOrb = new MiddleDragonAttackOrbSprite(texture, xPosition, yPosition + 30);
                        bottomAttackOrb = new BottomDragonAttackOrbSprite(texture, xPosition, yPosition + 30);
                    }
                    // Update the x position
                    xPosition += 1 * direction;

                }
                else
                {
                    poofCounter++;
                    for (int i = 0; i < poofRectangles.Count; i++)
                    {
                        if (poofCounter > i * maxPoofCounter / poofRectangles.Count && poofCounter <= (i + 1) * maxPoofCounter / poofRectangles.Count)
                        {
                            sourceRectangle = poofRectangles[i];
                        }
                    }
                }
            }
            else
            {
                deathFrames++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle dragonSourceRectangle = new Rectangle(1, 11, 24, 32);

            if (!isDead)
            {
                dragonDestinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 80, 100);

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
                else if (currFrames <= maxFrames)
                {
                    // Dragon rectangle
                    dragonSourceRectangle = new Rectangle(76, 11, 24, 32);
                }
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if (poofCounter < maxPoofCounter)
                {
                    dragonSourceRectangle = sourceRectangle;
                }
                if (isDamaged)
                {
                    spriteBatch.Draw(texture, dragonDestinationRectangle, dragonSourceRectangle, Color.Lerp(Color.White, Color.Red, 0.5f));
                }
                else
                {
                    spriteBatch.Draw(texture, dragonDestinationRectangle, dragonSourceRectangle, Color.White);
                }
                spriteBatch.End();

            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                dragonDestinationRectangle = new((int)xPosition + 48, (int)yPosition + 64, 60, 60);
                for (int i = 0; i < 4; i++)
                {
                    if (deathFrames > (i * maxDeathFrames) / 4 && deathFrames <= ((i + 1) * maxDeathFrames) / 4)
                    {
                        sourceRectangle = sourceRectangles[i];
                    }
                    else if (deathFrames > maxDeathFrames)
                    {
                        dyingComplete = true;
                    }
                }

                if (!dyingComplete)
                {
                    spriteBatch.Draw(dyingTexture, dragonDestinationRectangle, sourceRectangle, Color.White);
                }

                spriteBatch.End();
            }

        }

        public Rectangle GetHitbox()
        {
            // TEMPORARY, working on what to put here
            return dragonDestinationRectangle;
        }

        public void TurnAround(string side)
        {
            //dragon can't turn around
        }

        // Allows other things in the game to get the projectiles
        public List<ISprite> getEnemyProjectiles()
        {
            return new List<ISprite> { topAttackOrb, middleAttackOrb, bottomAttackOrb }; ;
        }

        public void TakeDamage(string side)
        {
            SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
            if (!isDamaged) { 
                isDamaged = true;
                health -= 1;
            }
            if (health <= 0)
            {
                isDead = true;
            }
        }

        public ISprite DropItem()
        {
            if (dyingComplete)
            {
                Random random = new Random();
                int rand = random.Next(0, droppableItems.Count);
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(xPosition, yPosition - Common.Instance.heightOfInventory), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }

        public void PoofIn(SpriteBatch spriteBatch) { }

    }

    public class TopDragonAttackOrbSprite : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

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
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public TopDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            originalX = (int)xPosition;
            originalY = (int)yPosition;
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 32, 40);

            currOrb = 0;
            attackOrbs.Add(blueOrb);
            attackOrbs.Add(orangeOrb);
            attackOrbs.Add(greenOrb);
            attackOrbs.Add(multicolorOrb);
            keepThrowing = true;
        }
        public void Update()
        {
            // Update current orb
            currFrames += 1;
            if (currFrames % 2 == 0)
            {
                ++currOrb;
            }
            if (currOrb >= attackOrbs.Count)
            {
                currOrb = 0;
            }

            //update location
            if (currFrames % 3 == 0)
                yPosition -= 5;
            xPosition -= 5;

            // Update the full location of the orb
            destinationRectangle = new((int)xPosition, (int)yPosition, 32, 40);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, attackOrbs[currOrb], Color.White);
            spriteBatch.End();

        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;

        }

        public void collide()
        {
            currFrames = maxFrames;
            keepThrowing = false;

        }

    }

    public class MiddleDragonAttackOrbSprite : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // Original positions to reset to
        private int originalX;
        private int originalY;

        // Keeps track of if the projectile should keep going
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
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public MiddleDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            originalX = (int)xPosition;
            originalY = (int)yPosition;
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 32, 40);

            currOrb = 0;
            attackOrbs.Add(blueOrb);
            attackOrbs.Add(orangeOrb);
            attackOrbs.Add(greenOrb);
            attackOrbs.Add(multicolorOrb);
            keepThrowing = true;
        }
        public void Update()
        {

            // Update current orb
            currFrames += 1;
            if (currFrames % 2 == 0)
            {
                ++currOrb;
            }
            if (currOrb >= attackOrbs.Count)
            {
                currOrb = 0;
            }

            //update position
            xPosition -= 5;

            // Update the full location of the orb
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 32, 40);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //if(currFrames < maxFrames) {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, attackOrbs[currOrb], Color.White);
            spriteBatch.End();
            //} 
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;

        }
        public void collide()
        {
            currFrames = maxFrames;
            keepThrowing = false;
        }

    }

    public class BottomDragonAttackOrbSprite : IEnemyProjectile
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 10000;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private int xPosition;
        private int yPosition;

        // Original positions to reset to
        private int originalX;
        private int originalY;

        // Keep track of if the projectile should keep going
        public bool keepThrowing { get; set; }


        // Orbs will rapidly swap between 4 different version
        private List<Rectangle> attackOrbs = new();
        private Rectangle blueOrb = new(128, 14, 8, 10);
        private Rectangle orangeOrb = new(119, 14, 8, 10);
        private Rectangle greenOrb = new(110, 14, 8, 10);
        private Rectangle multicolorOrb = new(101, 14, 8, 10);
        private int currOrb; // Represents which orb from the list to draw

        // On Screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public BottomDragonAttackOrbSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = (int)xPosition;
            this.yPosition = (int)yPosition;
            originalX = (int)xPosition;
            originalY = (int)yPosition;
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 32, 40);

            currOrb = 0;
            attackOrbs.Add(blueOrb);
            attackOrbs.Add(orangeOrb);
            attackOrbs.Add(greenOrb);
            attackOrbs.Add(multicolorOrb);
            keepThrowing = true;
        }
        public void Update()
        {

            currFrames += 1;
            // Update current orb
            if (currFrames % 2 == 0)
            {
                ++currOrb;
            }
            if (currOrb >= attackOrbs.Count)
            {
                currOrb = 0;
            }

            // Update x and y so that this orb goes towards the upper left in a diagonal line
            if (currFrames % 3 == 0)
                yPosition += 5;
            xPosition -= 5;


            // Update the full location of the orb
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 32, 40);

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            spriteBatch.Draw(texture, destinationRectangle, attackOrbs[currOrb], Color.White);
            spriteBatch.End();

        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;

        }
        public void collide()
        {
            currFrames = maxFrames;
            keepThrowing = false;
        }
    }
}

