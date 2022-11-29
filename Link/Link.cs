using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using GameStates;
using System.Windows.Forms;

namespace LegendofZelda
{
    public class Link
    {
        private static Link instance = new(new LinkFacingUpState());
        private static Link instance2 = new(new Player2FacingUpState());
        public static Link Instance
        {
            get
            {
                return instance;
            }
        }

        public static Link Instance2
        {
            get
            {
                return instance2;
            }
        }

        public enum Throwables
        {
            BlueBoomerang, Boomerang, BlueArrow, Arrow, Bomb, Fire, None
        }

        //Fields
        public ISprite currentLinkSprite;
        public ILinkState currentState;
        public Vector2 currentPosition;
        public List<ISprite> currentProjectiles;
        public Throwables throwable;

        public float health, maxHealth;
        public bool isDamaged, canBeDamaged;
        private int isDamagedCounter;

        public Inventory inventory = new Inventory();
        public Game1 game;
        private string side;

        
        public Link(ILinkState currState)
        {
            currentPosition = new Vector2(400, 240);
            currentState = currState;
            currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(currentPosition, isDamaged);
            
            throwable = Throwables.None;
            currentProjectiles = new();
            

            this.health = 100;
            this.maxHealth = 100;
            this.isDamaged = false;
        } 

        
        public void Reset()
        {
            currentPosition = new Vector2(400, 240);
            //currentState = new LinkFacingUpState();
            currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(currentPosition, isDamaged);

            throwable = Throwables.Boomerang;
            currentProjectiles = new();
            inventory = new Inventory();

            this.health = 3;
            this.maxHealth = 3;
            this.isDamaged = false;

            game.BackgroundMusicInit();
            game.RoomloaderInit();
            game.gameStateController.gameState = new GamePlayState(game.gameStateController, game);
        }
        public void UpdatePosition()
        {
            Rectangle rectangle = this.currentLinkSprite.GetHitbox();
            this.currentPosition = new Vector2(rectangle.X, rectangle.Y);
        }
        public void Attack()
        {
            SoundFactory.Instance.CreateSoundEffect("LinkAttack").Play();
            UpdatePosition();
            this.currentState.Attack();
        }
        public void ThrowProjectile()
        {
            if (throwable == Throwables.Bomb)
            {
                if (inventory.getItemCount("bomb") > 0)
                {
                    inventory.removeItem("bomb");
                    SoundFactory.Instance.CreateSoundEffect("ThrowProjectile").Play();
                    this.UpdatePosition();
                    this.currentState.ThrowProjectile();
                } else
                {
                    this.throwable = Throwables.None;
                }
            } else if(throwable == Throwables.None)
            {
                // do nothing
            } else { 
                SoundFactory.Instance.CreateSoundEffect("ThrowProjectile").Play();
                this.UpdatePosition();
                this.currentState.ThrowProjectile();
            } 
        }
        public void MoveUp()
        {
            this.UpdatePosition();
            this.currentState.MoveUp();
        }
        public void MoveDown()
        {
            this.UpdatePosition();
            this.currentState.MoveDown();
        }
        public void MoveLeft()
        {
            this.UpdatePosition();
            this.currentState.MoveLeft();
        }
        public void MoveRight()
        {
            this.UpdatePosition();
            this.currentState.MoveRight();
        }
        public void NoInput()
        {
            if (this.currentLinkSprite is IAttackingSprite)
            {
                IAttackingSprite currSprite = currentLinkSprite as IAttackingSprite;
                if (!(currSprite.isAttacking()))
                {
                    this.currentState.NoInput();
                }
            }
            else
            {
                this.currentState.NoInput();
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
                if(this.isDamagedCounter < 30)
                {
                    int knockbackDistance = 3;
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

                if (this.isDamagedCounter > 60)
                {
                    this.isDamagedCounter = 0;
                    this.isDamaged = false;
                    this.UpdatePosition();
                    this.currentState.Redraw();
                }
            }
        }
        
        public void Draw(SpriteBatch _spriteBatch)
        {
            this.currentLinkSprite.Draw(_spriteBatch);
            foreach (var projectile in this.currentProjectiles)
            {
                projectile.Draw(_spriteBatch);
            }
        }
        public void Die()
        {
            SoundFactory.Instance.CreateSoundEffect("LinkDeath").Play();
            game.gameStateController.GameOver();
        }
        public void getGame(Game1 game)
        {
            this.game = game;
        }
    }
}