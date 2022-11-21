using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using GameStates;

namespace LegendofZelda
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

        public Inventory inventory;
        public Game1 game;
        public Link()
        {
            this.currentPosition = new Vector2(400, 240);
            this.currentState = new LinkFacingUpState();
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(this.currentPosition, this.isDamaged);
            
            this.throwable = Throwables.None;
            this.currentProjectiles = new();
            this.inventory = new Inventory();

            this.health = 3;
            this.maxHealth = 3;
            this.isDamaged = false;
            this.canBeDamaged = true;
            this.isDamagedCounter = 0;
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
            this.canBeDamaged = true;
            this.isDamagedCounter = 0;

            this.game.BackgroundMusicInit();
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
            if (this.throwable == Throwables.Bomb)
            {
                if (this.inventory.getItemCount("bomb") > 0)
                {
                    this.inventory.removeItem("bomb");
                    SoundFactory.Instance.CreateSoundEffect("ThrowProjectile").Play();
                    this.UpdatePosition();
                    currentState.ThrowProjectile();
                } else
                {
                    this.throwable = Throwables.None;
                }
            }
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
            if (this.canBeDamaged == true && this.health > 0)
            {
                SoundFactory.Instance.CreateSoundEffect("LinkDamage").Play();
                this.health -= 0.5f;
                if (health <= 0)
                {
                    this.Die();
                }
                else
                {
                    this.isDamaged = true;
                    this.canBeDamaged = false;
                    this.currentState.Redraw();
                    switch (side)
                    {
                        case "top":
                            this.currentPosition.Y += 25;
                            this.currentLinkSprite.DestinationRectangle.Offset(0, 25);
                            break;
                        case "bottom":
                            this.currentPosition.Y -= 25;
                            this.currentLinkSprite.DestinationRectangle.Offset(0, -25);
                            break;
                        case "left":
                            this.currentPosition.X -= 25;
                            this.currentLinkSprite.DestinationRectangle.Offset(25, 0);
                            break;
                        case "right":
                            this.currentPosition.X += 25;
                            this.currentLinkSprite.DestinationRectangle.Offset(0, -25);
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        public void Update()
        {
            this.UpdatePosition();
            this.currentLinkSprite.Update();
            foreach (var projectile in currentProjectiles)
            {
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
                    this.currentState.Redraw();
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