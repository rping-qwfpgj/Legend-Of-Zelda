
using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using LegendofZelda;

namespace Sprint0
{// im gonna get rid of the magic numbers
    public class Link
    {
        public enum Throwables
        {
            BlueBoomerang,
            Boomerang,
            BlueArrow,
            Arrow,
            Bomb,
            Fire,
            None
        }

        //Fields
        public GraphicsDeviceManager graphics; // Used to bound link when he walks
        public ISprite currentLinkSprite;
        public List<ISprite> currentProjectiles;
        public ILinkState currentState;
        public Vector2 currentPosition;
        public bool isDamaged;
        public Throwables throwable;
        private int isDamagedCounter = 0;
        public Game1 game;
        private string side;
      

        public Link(Vector2 position, GraphicsDeviceManager graphics, Game1 game)
        {
            this.currentPosition = position;
            this.graphics = graphics;
            this.isDamaged = false;
            this.game = game;
            this.currentState = new LinkFacingUpState(this);
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp (this.currentPosition, this.isDamaged);
            this.throwable = Throwables.None;
            this.currentProjectiles = new List<ISprite>();
        }

        public void Reset()
        {
            this.currentPosition = new Vector2(400, 240);
            this.isDamaged = false;
            this.currentState = new LinkFacingUpState(this);
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(this.currentPosition, this.isDamaged);
            this.throwable = Throwables.None;

        }
        
        public void UpdatePosition()
        {
            Rectangle rectangle = currentLinkSprite.GetHitbox();
            currentPosition = new Vector2(rectangle.X, rectangle.Y);
        }
        public void Attack()
        {
            this.UpdatePosition();
            currentState.Attack();
        }

        public void ThrowProjectile()
        {
            this.UpdatePosition();
            currentState.ThrowProjectile();
        }

        public void MoveUp()
        {
            this.UpdatePosition();
            currentState.MoveUp();
        }

        public void MoveDown()
        {
            this.UpdatePosition();
            currentState.MoveDown();
        }

        public void MoveLeft()
        {
            this.UpdatePosition();
            currentState.MoveLeft();
        }

        public void MoveRight()
        {
            this.UpdatePosition();
            currentState.MoveRight();

        }
        public void NoInput()
        {
            //this.UpdatePosition();

            if (currentLinkSprite is IAttackingSprite)
            {
                IAttackingSprite currSprite = currentLinkSprite as IAttackingSprite;
                if (!(currSprite.isAttacking()))
                {
                    currentState.NoInput();
                }
            }
            else
            {
                currentState.NoInput();
            }
        }

         public void TakeDamage()
        {
            this.isDamaged = true;
            this.currentState.Redraw();
           
        }

        public void TakeDamage(string side)
        {
            if(!this.isDamaged)
            {
                this.isDamaged = true;
                this.currentState.Redraw();
                this.side = side;                
            }                     
        }

        public void Update()
        {
            this.UpdatePosition();
            this.currentLinkSprite.Update();
            foreach (var projectile in currentProjectiles) { 
                projectile.Update();
            }

            // This can be refactored using a decorator pattern
            if (this.isDamaged)
            {   
                this.isDamagedCounter++;

                // Take knockback for the first 20 frames
                if(this.isDamagedCounter < 20)
                {
                    int knockbackDistance = 10;
                    switch(this.side)
                    {   
                    case "top":
                        this.currentPosition.Y += knockbackDistance;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 40, 42);
                        break;
                    case "bottom":
                        this.currentPosition.Y -= knockbackDistance;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 40, 42);
                        break;
                    case "left":
                        this.currentPosition.X += knockbackDistance;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 40, 42);
                        
                        break;
                    case "right":
                        this.currentPosition.X -= knockbackDistance;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 40, 42);
                        break;
                    default:
                    break;
                    }
                }
                
                if (this.isDamagedCounter > 180)
                {
                    this.isDamagedCounter = 0;
                    this.isDamaged = false;
                    this.UpdatePosition();

                    //Check if current sprite is an attacking sprite
                    if (currentLinkSprite is IAttackingSprite)
                    {
                        IAttackingSprite currSprite = currentLinkSprite as IAttackingSprite;
                        if (!currSprite.isAttacking())
                        {
                            this.currentState.Redraw();
                        }
                    }
                    else
                    {
                        this.currentState.Redraw();
                    }
                }
            }
        }
        public void Draw(SpriteBatch _spriteBatch)
        {
            this.currentLinkSprite.Draw(_spriteBatch);
            foreach (var projectile in currentProjectiles)
            {
                projectile.Draw(_spriteBatch);
            }
        }
    }
}

