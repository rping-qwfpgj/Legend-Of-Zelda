//using LegendofZelda.Interfaces;
//using Microsoft.Xna.Framework;
//using Microsoft.Xna.Framework.Graphics;
//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace LegendofZelda.EnemyAndNPCSprites
//{
//    public class DyingAnimation : IEnemy
//    {
//        private int deathFrames = 0;
//        private Rectangle sourceRectangle = new Rectangle(0, 0, 15, 16);
//        private Rectangle destinationRectangle;
//        private Texture2D dyingTexture;
//        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }
//        private float xPosition;
//        public float XPosition { get => xPosition; set => xPosition = value; }
//        private float yPosition;
//        public float YPosition { get => yPosition; set => yPosition = value; }
//        private bool isDead = false;
//        public bool IsDead { get => isDead; set => isDead = value; }
//        private bool dyingComplete = false;
//        public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
//        private int direction = 1;
//        public int Direction { get => direction; set => direction = value; }
//        public bool done = false;

//        public DyingAnimation(Texture2D texture, float xPos, float yPos)
//        {
//            this.dyingTexture = texture;
//            this.xPosition = xPos;
//            this.yPosition = yPos;
//            this.destinationRectangle = new Rectangle((int)this.xPosition, (int)this.yPosition, 30, 30);
//        }

//        public void Update()
//        {
//            if (!done)
//            {
//                deathFrames++;
//                Debug.WriteLine("deathFrames = " + deathFrames);
//                if (deathFrames >= 0 && deathFrames <= 5)
//                {
//                    sourceRectangle = new Rectangle(0, 0, 15, 16);

//                }
//                else if (deathFrames > 5 && deathFrames < 10)
//                {
//                    sourceRectangle = new Rectangle(16, 0, 15, 16);
//                }
//                else if (deathFrames >= 10 && deathFrames < 15)
//                {
//                    sourceRectangle = new Rectangle(35, 3, 9, 10);
//                }
//                else if (deathFrames >= 15 && deathFrames < 20)
//                {
//                    sourceRectangle = new Rectangle(51, 3, 9, 10);
//                }
//                if (deathFrames > 25)
//                {
//                    done = true;
//                }
//            }

//        }
//        public void Draw(SpriteBatch spriteBatch)
//        {
            

//                spriteBatch.Begin();


//                spriteBatch.Draw(dyingTexture, this.destinationRectangle, sourceRectangle, Color.White);

//                spriteBatch.End();
            
//        }

//        public Rectangle GetHitbox()
//        {
//            return this.destinationRectangle;
//        }

//        public void TakeDamage(String side)
//        {

//        }

//        public void Die()
//        {

//        }
//    }
//}
