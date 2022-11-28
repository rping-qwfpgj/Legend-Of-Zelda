using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using GameStates;
using System.Windows.Forms;

namespace Sprint0
{
    public class Link
    {

        private static Link instance = new();
        public static Link Instance
        {
            get
            {
                return instance;
            }
        }
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
        public ISprite currentLinkSprite;
        public List<ISprite> currentProjectiles;
        public ILinkState currentState;
        public Vector2 currentPosition;
        public bool isDamaged;
        public Throwables throwable;
        public int isDamagedCounter = 0;
        public Inventory inventory;
        public Game1 game;
        public float health;
        public float maxHealth;
        private string side;

        
        public Link()
        {
            this.currentPosition = new Vector2(400, 240);
            this.currentState = new LinkFacingUpState();
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(this.currentPosition, this.isDamaged);
            
            this.throwable = Throwables.Boomerang;
            this.currentProjectiles = new();
            this.inventory = new Inventory();

            this.health = 100;
            this.maxHealth = 100;
            this.isDamaged = false;
        }

        public void Reset()
        {
            this.currentPosition = new Vector2(400, 240);
            this.currentState = new LinkFacingUpState();
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(this.currentPosition, this.isDamaged);

            this.throwable = Throwables.Boomerang;
            this.currentProjectiles = new();
            this.inventory = new Inventory();

            this.health = 3;
            this.maxHealth = 3;
            this.isDamaged = false;

            this.game.RoomloaderInit();
            this.game.gameStateController.gameState = new GamePlayState(this.game.gameStateController, this.game);
        }

        public void UpdatePosition()
        {
            Rectangle rectangle = currentLinkSprite.GetHitbox();
            currentPosition = new Vector2(rectangle.X, rectangle.Y);
        }
        public void Attack()
        {
            SoundFactory.Instance.CreateSoundEffect("LinkAttack").Play();
            this.UpdatePosition();
            currentState.Attack();
        }

        public void ThrowProjectile()
        {
            SoundFactory.Instance.CreateSoundEffect("ThrowProjectile").Play();
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
        
        public void TakeDamage(string side)
        {
            if (!this.isDamaged && this.health > 0)
            {
                this.isDamaged = true;
                this.currentState.Redraw();
                this.side = side;
                SoundFactory.Instance.CreateSoundEffect("LinkDamage").Play();
                this.health -= 0.5f;
                if (health <= 0)
                {
                    this.Die();

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

                // Take knockback for the first x frames
                if(this.isDamagedCounter < 15)
                {
                    int knockbackDistance = 10;
                    switch(this.side)
                    {
                    case "top":
                        this.currentPosition.Y += knockbackDistance;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 24, 32);
                        break;
                    case "bottom":
                        this.currentPosition.Y -= knockbackDistance;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 24, 32);
                        break;
                    case "left":
                        this.currentPosition.X += knockbackDistance;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 24, 32);                        
                        break;
                    case "right":
                        this.currentPosition.X -= knockbackDistance;
                        this.currentLinkSprite.DestinationRectangle = new((int)this.currentPosition.X, (int)this.currentPosition.Y, 24, 32);
                        break;
                    default:
                    break;
                    }
                }
                this.UpdatePosition();
                
                if (this.isDamagedCounter > 90)
                {
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
            currentLinkSprite.Draw(_spriteBatch);
            foreach (var projectile in currentProjectiles)
            {
                projectile.Draw(_spriteBatch);
            }
        }

        public void Die()
        {
            SoundFactory.Instance.CreateSoundEffect("LinkDeath").Play();
            this.game.gameStateController.GameOver();
        }

        public void getGame(Game1 game)
        {
            this.game = game;
            
        }

       
    }
}
    


