﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;


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
        private Texture2D dyingTexture;

        private List<Rectangle> sourceRectangles;
        private Rectangle sourceRectangle;

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
        private int maxDeathFrames = 20;


        // On screen position
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        Random random = new Random();
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> { Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN };
        Directions currDirection;
    

        public KeeseSprite(Texture2D texture, float xPosition, float yPosition, SoundEffect sound, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.enemyHit = sound;
            this.dyingTexture = texture2;
            this.currDirection = directions[random.Next(0, directions.Count)];
            sourceRectangles = new();
            sourceRectangles.Add(new Rectangle(183, 15, 16, 8));
            sourceRectangles.Add(new Rectangle(203, 15, 10, 10));
            sourceRectangles.Add(new Rectangle(0, 0, 15, 16));
            sourceRectangles.Add(new Rectangle(16, 0, 15, 16));
            sourceRectangles.Add(new Rectangle(35, 3, 9, 10));
            sourceRectangles.Add(new Rectangle(51, 3, 9, 10));

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
            }
            else
            {
                deathFrames++;
            }


        }

        public void Draw(SpriteBatch spriteBatch)
        {

            if (!isDead)
            {
                sourceRectangle = sourceRectangles[(currFrames / 100) % 2];
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, sourceRectangle.Width * 2, sourceRectangle.Height * 2);
                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
            else
            {
                for(int i = 0; i<4; i++)
                {
                    if(deathFrames>(i*maxDeathFrames)/4 && deathFrames <= ((i + 1) * maxDeathFrames) / 4)
                    {
                        sourceRectangle = sourceRectangles[i + 2];
                    }
                    else if(deathFrames>maxDeathFrames)
                    {
                        dyingComplete = true;
                    }
                }
                destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition,30, 30);
                if (!dyingComplete)
                {
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                    spriteBatch.Draw(dyingTexture, this.destinationRectangle, sourceRectangle, Color.White);
                    spriteBatch.End();
                }
            }
        }
            public Rectangle GetHitbox()
            {
                return this.destinationRectangle;
            }

            public void TurnAround(string side)
            {
                // Have the Keese turn around based on what wall it is running into
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


