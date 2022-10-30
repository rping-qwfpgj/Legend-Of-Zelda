using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;

namespace Sprites
{
    public class GoriyaSprite : IEnemy
    {
        private IEnemy currentGoriya;
        private enum GoriyaActions {MovingUp, MovingDown, MovingRight, MovingLeft, ThrowingUp, ThrowingRight,
        ThrowingLeft, ThrowingDown};

        List<GoriyaActions> goriyaActions = new List<GoriyaActions> {GoriyaActions.MovingUp, GoriyaActions.MovingDown,
        GoriyaActions.MovingRight, GoriyaActions.MovingLeft, GoriyaActions.ThrowingUp, GoriyaActions.ThrowingRight,
        GoriyaActions.ThrowingLeft};
        private Random rand = new Random();

        //  Obsolete variables
        private float xPosition;
        public float XPosition { get => xPosition; set => xPosition = value; }
        private float yPosition;
        public float YPosition { get => yPosition; set => yPosition = value; }
        private int direction = 1;
        public int Direction { get => direction; set => direction = value; }
        private int prevdirection = 1;
        private Texture2D texture;
        private float xPos;
        private float yPos;
        private Rectangle destinationRectangle = new Rectangle(1, 1, 0, 0);
        public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

        public GoriyaSprite(Texture2D texture, float xPosition, float yPosition)
        {
            this.texture = texture;
            //this.xPos = xPosition;
            //this.yPos = yPosition;
            currentGoriya = new GoriyaMovingRightSprite(texture, xPosition, yPosition);
        }

        public void Update()
        {
            // Decided if the goriya should change its current action
            if(rand(0,1000) <= 250)
            {
                // Change the current sprite
            } else
            {
                // Otherwise, update the current sprite
                currentGoriya.Update();
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentGoriya.Draw(spriteBatch);
        }

        public Rectangle GetHitbox()
        {
            Rectangle hitbox = currentGoriya.GetHitbox();

            if (hitbox == null)
            {
                return this.destinationRectangle;
            }
            else
            {
                return hitbox;
            }
        }

        private switchAction()
        {
            // Get the hitbox of the current goriya
            Rectangle currentLocation = currentGoriya.GetHitbox();
            float x = (float)currentLocation.X;
            float y = (float)currentLocation.Y;

            // Randomly select a goriya state to make
            switch(goriyaActions[rand.Next(0, goriyaActions.Count)])
            {
                case GoriyaActions.MovingUp:
                    currentGoriya = new GoriyaMovingUpSprite(this.texture, x, y);
                    break;
                case GoriyaActions.MovingDown:
                    currentGoriya = new GoriyaMovingDownSprite(this.texture, x, y);
                    break;
                case GoriyaActions.MovingLeft:
                    currentGoriya = new GoriyaMovingLeftSprite(this.texture, x, y);
                    break;
                case GoriyaActions.MovingRight:
                    currentGoriya = new GoriyaMovingRightSprite(this.texture, x, y);
                    break;
                case GoriyaActions.ThrowingUp:
                    currentGoriya = new GoriyaThrowingUpSprite(this.texture, x, y);
                    break;
                case GoriyaActions.ThrowingDown:
                    currentGoriya = new GoriyaThrowingDownSprite(this.texture, x, y);
                    break;
                case GoriyaActions.ThrowingLeft:
                    currentGoriya = new GoriyaThrowingLeftSprite(this.texture, x, y);
                    break;
                case GoriyaActions.ThrowingRight;
                    currentGoriya = new GoriyaThrowingRightSprite(this.texture, x, y);
                    break;
                default:
                    break;
            }
        }

        public void TakeDamage(string side)
        {
            currentGoriya.TakeDamage(side);
        }
    }