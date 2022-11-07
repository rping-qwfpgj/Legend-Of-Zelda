﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;

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
        private int deathFrames = 0;

        //private bool movingHorizontally = true;
        //private bool movingVertically = false;


        // On screen location
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
        Random random = new Random();
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> { Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN };
        Directions currDirection;
        public GelSprite(Texture2D texture, float xPosition, float yPosition, SoundEffect sound, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.enemyHit = sound;
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
                if (currFrames == maxFrames)
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
                    sourceRectangle = new Rectangle(1, 16, 8, 8);
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 32, 32);
                }
                else
                {
                    sourceRectangle = new Rectangle(11, 15, 6, 9);
                    this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 24, 36);
                }
                spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
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
                enemyHit.Play();
                this.isDead = true;
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


