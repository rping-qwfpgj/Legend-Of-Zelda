﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;
using LegendofZelda.SpriteFactories;

namespace Sprites
{
    public class GelSprite : IEnemy
    {
        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;

        // Texture to take sprites from
        private Texture2D texture;
        private Texture2D dyingTexture;
        
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
        private int deathFrames = 0;

        // On screen location
        private Rectangle destinationRectangle;
        private List<Rectangle> sourceRectangles;
        private Rectangle sourceRectangle;
        private int currFrameIndex;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        Random random = new Random();
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> { Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN };
        Directions currDirection;
        public GelSprite(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.dyingTexture = texture2;
            this.currDirection = directions[random.Next(0, directions.Count)];
        }

        public void Update()
        {
            if (!isDead)
            {
                if (random.Next(0, maxFrames) <= (maxFrames / 50))
                {
                    this.currDirection = directions[random.Next(0, directions.Count)];
                }
                if (currFrames > maxFrames)
                {
                    currFrames = 0;
                }
                else
                {
                    currFrames += 10;
                }

                if (currDirection == Directions.UP)
                {
                    this.yPosition -= 1;
                }
                else if (currDirection == Directions.LEFT)
                {
                    this.xPosition -= 1;
                }
                else if (currDirection == Directions.RIGHT)
                {
                    this.xPosition += 1;
                }
                else // Direction is down
                {
                    this.yPosition += 1;
                }
            } else
            {
                deathFrames++;
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            Rectangle sourceRectangle = new Rectangle(1, 16, 8, 8);
            if (!isDead)
            {

                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                if ((currFrames / 100) % 2 != 0)
                {
                    currFrameIndex = 0;
                }
                else
                {
                    currFrameIndex = 1;
                }
                destinationRectangle = new(sourceRectangle.X, sourceRectangle.Y, sourceRectangle.Width*2, sourceRectangle.Height*2);
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
            else
            {
                spriteBatch.Begin();
                this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 30);
                
                for()
                
                if (deathFrames >= 0 && deathFrames <= 5)
                {
                    currFrameIndex = 2;

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
        }
            public Rectangle GetHitbox()
            {
                return this.destinationRectangle;
            }

            public void TurnAround(string side)
            {
                // Have the Gel turn around based on what wall it is running into
                switch (side)
                {
                    case "top":
                        this.currDirection = Directions.DOWN;
                        break;
                    case "bottom":
                        this.currDirection = Directions.UP;
                        break;
                    case "left":
                        this.currDirection = Directions.RIGHT;
                        break;
                    case "right":
                        this.currDirection = Directions.LEFT;
                        break;
                    default:
                        break;

                }

            }

            public void TakeDamage(string side)
            {
                SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
                this.isDead = true;
            }

            public ISprite DropItem()
            {
                return null;
            }

           
        }
    }


