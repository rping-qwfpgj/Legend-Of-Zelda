using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using LegendofZelda.SpriteFactories;
using System.Collections.Generic;

namespace Sprites
{
    public class WallMasterSprite : IEnemy
    {
        private List<string> droppableItems = new List<string> { "BigHeart", "OrangeGemstone", "Bomb" };


        // Keep track of frames
        private int currFrames = 0;
        private int maxFrames = 2000;
        private int deathFrames = 0;
        private SoundEffect enemyHit;

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
        private bool movingHorizontally = true;
        private bool movingVertically = false;

        private Rectangle destinationRectangle;
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        // Handles deciding enemy movement
        Random random;
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> { Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN };
        Directions currDirection;
       
        public WallMasterSprite(Texture2D texture, float xPosition, float yPosition, SoundEffect sound, Texture2D texture2)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
            this.enemyHit = sound;
            this.dyingTexture = texture2;
            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 60, 60);
            this.random = new Random();
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
            Rectangle sourceRectangle = new Rectangle(393, 11, 16, 16);
            if (!isDead)
            {
                // By default, draw the hand without the pinch

                this.destinationRectangle = new((int)this.xPosition, (int)this.yPosition, 60, 60);

                // Otherwise, have it pinch
                if (currFrames % 5 == 0)
                {
                    sourceRectangle = new Rectangle(410, 12, 14, 15);

                } else
                {
                    sourceRectangle = new Rectangle(393, 11, 16, 16);
                }

                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
                spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }

            else {
                    spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

            if (deathFrames > 5 && deathFrames < 10)
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
    

        public Vector2 getPosition()
        {
            return new Vector2(this.xPosition, this.yPosition);
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
}

