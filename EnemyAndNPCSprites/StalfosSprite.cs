using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;
using System.Reflection.Metadata;
using System.Collections.Generic;
using LegendofZelda.SpriteFactories;

namespace Sprites
{
    public class StalfosSprite : IEnemy
    {
        private List<string> droppableItems = new List<string> { "Clock", "BigHeart", "PurpleGemstone", "OrangeGemstone" };
        
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
        private bool isDead = false;
        public bool IsDead { get => isDead; set => isDead = value; }
        private bool dyingComplete = false;
        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
        
        //private bool movingHorizontally = true;
        //private bool movingVertically = false;

        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value;}
        Random random = new Random();
        public enum Directions { UP, RIGHT, LEFT, DOWN };
        List<Directions> directions = new List<Directions> { Directions.UP, Directions.RIGHT, Directions.LEFT, Directions.DOWN };
        Directions currDirection;
        public StalfosSprite(Texture2D texture, float xPosition, float yPosition, SoundEffect sound, Texture2D texture2)
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
            Rectangle sourceRectangle = new Rectangle(2, 59, 15, 16);

            if (!isDead)
            {
                this.destinationRectangle = new((int)this.xPosition, (int)this.yPosition, 30, 32);

                spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);

                if ((currFrames / 100) % 2 != 0)
                {
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, this.destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
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
            // Have the Stalfos turn around based on what wall it is running into
            switch(side)
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
            //switch (side)
            //{
            //    case "top":
            //        this.yPosition += 37;
            //        break;
            //    case "bottom":
            //        this.yPosition -= 37;
            //        break;
            //    case "left":
            //        this.xPosition += 37;
            //        break;
            //    case "right":
            //        this.xPosition -= 37;
            //        break;
            //    default:
            //        break;
            //}
        }

        public ISprite DropItem()
        {
            if (dyingComplete) {
                Random random = new Random();
                int rand = random.Next(0, droppableItems.Count);
                return ItemSpriteFactory.Instance.CreateItem(new Vector2(this.xPosition, this.yPosition - 150), droppableItems[rand]);
            } else
            {
                return null;
            }
            
        }

        public void Die()
        {

        }
    }
}

