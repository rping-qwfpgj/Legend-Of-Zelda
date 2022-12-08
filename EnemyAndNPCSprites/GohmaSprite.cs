﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using System.Reflection.Metadata;
using LegendofZelda.SpriteFactories;

namespace Sprites
{
    public class GohmaSprite : IEnemy
    {
        private List<string> droppableItems = new List<string> { "OrangeGemstone", "SmallBlueHeart", "Bomb" };

        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;
        private int deathFrames = 0;
        private int maxDeathFrames = 20;

        // Texture to take sprites from
        private Texture2D texture;
        private Texture2D dyingTexture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }

        private List<Rectangle> sourceRectangles;
        private Rectangle sourceRectangle;

        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        Random random = new Random();
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> { Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN };
        Directions currDirection;
        private int eyeOpenCounter = 0;
        private bool eyeOpen = false;
        private bool isDamaged;
        private int health = 3;
        private int damagedCounter = 0;

        public GohmaSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            dyingTexture = texture2;
            currDirection = directions[random.Next(0, directions.Count)];
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(298, 122, 47, 16));
            sourceRectangles.Add(new Rectangle(347, 122, 47, 16));
            sourceRectangles.Add(new Rectangle(396, 122, 47, 16));
            sourceRectangles.Add(new Rectangle(445, 122, 47, 16));
            sourceRectangles.Add(new Rectangle(0, 0, 15, 16));
            sourceRectangles.Add(new Rectangle(16, 0, 15, 16));
            sourceRectangles.Add(new Rectangle(35, 3, 9, 10));
            sourceRectangles.Add(new Rectangle(51, 3, 9, 10));
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
                eyeOpenCounter++;
                if (random.Next(0, maxFrames) <= (maxFrames / 50))
                {
                    currDirection = directions[random.Next(0, directions.Count)];
                }
                currFrames += 10;
                if (currFrames == maxFrames)
                {
                    currFrames = 0;
                    eyeOpenCounter= 0;
                    eyeOpen = false;
                }
                if ((currFrames / 100) % 4 == 0)
                {
                    sourceRectangle = sourceRectangles[0];
                }
                else if ((currFrames / 100) % 4 == 1)
                {
                    sourceRectangle = sourceRectangles[1];
                }
                else if ((currFrames / 100) % 4 == 2)
                {
                    sourceRectangle = sourceRectangles[2];
                }
                else if ((currFrames / 100) % 4 == 3 && eyeOpenCounter >= 120)
                {
                    sourceRectangle = sourceRectangles[3];
                    eyeOpen = true;
                }

                if (currDirection == Directions.UP)
                {
                    yPosition -= 1;
                }
                else if (currDirection == Directions.LEFT)
                {
                    xPosition -= 1;
                }
                else if (currDirection == Directions.RIGHT)
                {
                    xPosition += 1;
                }
                else // Direction is down
                {
                    yPosition += 1;
                }
            }
            else
            {
                deathFrames++;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            //sourceRectangle = sourceRectangles[0];
            if (!isDead)
            {
                destinationRectangle = new((int)xPosition, (int)yPosition, 94, 32);

                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

                if ((currFrames / 100) % 2 != 0)
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                }
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, 30, 30);
                for (int i = 0; i < 4; i++)
                {
                    if (deathFrames > (i * maxDeathFrames) / 4 && deathFrames <= ((i + 1) * maxDeathFrames) / 4)
                    {
                        sourceRectangle = sourceRectangles[i + 4];
                    }
                    else if (deathFrames > maxDeathFrames)
                    {
                        dyingComplete = true;
                    }
                }

                if (!dyingComplete)
                {
                    spriteBatch.Draw(dyingTexture, destinationRectangle, sourceRectangle, Color.White);
                }

                spriteBatch.End();
            }
        }
        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

        public void TurnAround(string side)
        {
            // Have the Stalfos turn around based on what wall it is running into
            switch (side)
            {
                case "top":
                    currDirection = Directions.DOWN;
                    break;
                case "bottom":
                    currDirection = Directions.UP;
                    break;
                case "left":
                    currDirection = Directions.RIGHT;
                    break;
                case "right":
                    currDirection = Directions.LEFT;
                    break;
                default:
                    break;

            }

        }

        public void TakeDamage(string side)
        {
            if (eyeOpen)
            {
                SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
                if (!isDamaged)
                {
                    isDamaged = true;
                    health -= 1;
                }
                if (health <= 0)
                {
                    isDead = true;
                }
            }
        }

        public ISprite DropItem()
        {
            if (dyingComplete)
            {
                Random random = new Random();
                int rand = random.Next(0, droppableItems.Count);
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(xPosition, yPosition - 150), droppableItems[rand]);
            }
            else
            {
                return null;
            }
        }

        public void PoofIn() { }

    }
}

