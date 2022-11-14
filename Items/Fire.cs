using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.Interfaces;


namespace LegendofZelda.Items
{
    public class Fire : IItem
    {
        // frame count for animating the fire
        private int currFrames = 0;
        private int maxFrames = 2500;

        // Texture to take sprites from
        private Texture2D texture;

        // X and Y positions of the sprite
        private float xPosition;
        private float yPosition;

        private int width = 16;
        private int height = 16;

        // On screen position 
        private Rectangle destinationRectangle;
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public Fire(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            this.xPosition = xPosition;
            this.yPosition = yPosition;
        }


        public void Update()
        {

            currFrames += 50;

            if (currFrames >= maxFrames) { currFrames = 0; }


        }

        // NOTE: All of these source Rectangles are using placeholder values for now
        public void Draw(SpriteBatch spriteBatch)
        {
            // Create source and destination rectangles
            Rectangle sourceRectangle = new Rectangle(191, 185, width, height); // fire
            destinationRectangle = new Rectangle((int)xPosition, (int)yPosition, width * 4, height * 4); // Where to draw on screen

            // Draw the sprite
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.None, RasterizerState.CullCounterClockwise);
            if (currFrames < maxFrames)
            {

                if (currFrames / 100 % 2 == 0)
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
                }
                else
                {
                    spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0, 0), SpriteEffects.FlipHorizontally, 1);
                }

            }

            spriteBatch.End();
        }

        public Rectangle GetHitbox()
        {
            return destinationRectangle;
        }

        public string toString()
        {
            return "fire";
        }

    }


}
