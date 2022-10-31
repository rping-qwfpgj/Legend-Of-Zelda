
using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using LegendofZelda;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;

namespace Sprint0
{
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
        private SoundEffect throwProjectile;
        private SoundEffect attack;
        public float health;
        private bool canBeDamaged;
      

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
            this.throwProjectile = game.Content.Load<SoundEffect>("throw_projectile");
            this.attack = game.Content.Load<SoundEffect>("hee_hee");
            this.health = 3;
            this.canBeDamaged = true;

            //this.currentProjectiles.Add(ProjectileSpriteFactory.Instance.CreateThrowableUp(this.currentPosition, this.throwable));
        }

        public void Reset()
        {
            this.currentPosition = new Vector2(400, 240);
            this.isDamaged = false;
            this.currentState = new LinkFacingUpState(this);
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(this.currentPosition, this.isDamaged);
            this.throwable = Throwables.None;
            //this.currentProjectiles.Add(ProjectileSpriteFactory.Instance.CreateThrowableRight(this.currentPosition, this.throwable));

        }
        
        public void UpdatePosition()
        {
            Microsoft.Xna.Framework.Rectangle rectangle = this.currentLinkSprite.GetHitbox();
            this.currentPosition = new Vector2(rectangle.X, rectangle.Y);
        }
        public void Attack()
        {
            attack.Play();
            this.UpdatePosition();
            currentState.Attack();
        }

        public void ThrowProjectile()
        {
            throwProjectile.Play();
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
            this.UpdatePosition();

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
            if (this.canBeDamaged == true)
            {
                this.health -= 0.5f;
                Debug.WriteLine("link health = " + health);
                if (health <= 0)
                {
                    this.Die();
                }
                this.isDamaged = true;
                this.currentState.Redraw();
                this.canBeDamaged = false;
            }
            
           
        }

        public void TakeDamage(string side)
        {
            if (this.canBeDamaged == true)
            {
                this.health -= 0.5f;
                Debug.WriteLine("link health = " + health);
                if (health <= 0)
                {
                    this.Die();

                }
                this.isDamaged = true;
                this.currentState.Redraw();
                this.canBeDamaged = false;
                switch (side)
                {
                    case "top":
                        this.currentPosition.Y += 25;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 40, 42);
                        break;
                    case "bottom":
                        this.currentPosition.Y -= 25;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 40, 42);
                        break;
                    case "left":
                        this.currentPosition.X += 25;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 40, 42);
                        break;
                    case "right":
                        this.currentPosition.X -= 25;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 40, 42);
                        break;
                    default:
                        break;
                }
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
                if (this.isDamagedCounter > 60)
                {
                    this.canBeDamaged = true;
                    this.isDamagedCounter = 0;
                    this.isDamaged = false;
                    this.UpdatePosition();

                    // Check if current sprite is an attacking sprite
                    if (currentLinkSprite is IAttackingSprite)
                    {
                        IAttackingSprite currSprite = currentLinkSprite as IAttackingSprite;
                        if (!(currSprite.isAttacking()))
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

        public void Die()
        {
            //this.game.currentState = gameOverState;
            //this.Reset();
        }

    }
}

