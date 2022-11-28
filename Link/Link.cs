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
            currentPosition = new Vector2(400, 240);
            currentState = new LinkFacingUpState();
            currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(currentPosition, isDamaged);
            
            throwable = Throwables.None;
            currentProjectiles = new();
            inventory = new Inventory();

            health = 700000000;
            maxHealth = 700000000;
            canBeDamaged = true;
            isDamagedCounter = 0;
        }
        public void Reset()
        {
            currentPosition = new Vector2(400, 240);
            currentState = new LinkFacingUpState();
            currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(currentPosition, isDamaged);

            throwable = Throwables.Boomerang;
            currentProjectiles = new();
            inventory = new Inventory();

            health = 3;
            maxHealth = 3;
            isDamaged = false;
            canBeDamaged = true;
            isDamagedCounter = 0;

            game.BackgroundMusicInit();
            game.RoomloaderInit();
            game.gameStateController.gameState = new GamePlayState(game.gameStateController, game);
        }
        public void UpdatePosition()
        {
            Rectangle rectangle = currentLinkSprite.GetHitbox();
            currentPosition = new Vector2(rectangle.X, rectangle.Y);
        }
        public void Attack()
        {
            SoundFactory.Instance.CreateSoundEffect("LinkAttack").Play();
            UpdatePosition();
            currentState.Attack();
        }
        public void ThrowProjectile()
        {
            if (throwable == Throwables.Bomb)
            {
                if (inventory.getItemCount("bomb") > 0)
                {
                    inventory.removeItem("bomb");
                    SoundFactory.Instance.CreateSoundEffect("ThrowProjectile").Play();
                    UpdatePosition();
                    currentState.ThrowProjectile();
                } else
                {
                    throwable = Throwables.None;
                }
            }
            SoundFactory.Instance.CreateSoundEffect("ThrowProjectile").Play();
            UpdatePosition();
            currentState.ThrowProjectile();
        }
        public void MoveUp()
        {
            UpdatePosition();
            currentState.MoveUp();
        }
        public void MoveDown()
        {
            UpdatePosition();
            currentState.MoveDown();
        }
        public void MoveLeft()
        {
            UpdatePosition();
            currentState.MoveLeft();
        }
        public void MoveRight()
        {
            UpdatePosition();
            currentState.MoveRight();
        }
        public void NoInput()
        {
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
            if (canBeDamaged == true && health > 0)
            {
                SoundFactory.Instance.CreateSoundEffect("LinkDamage").Play();
                health -= 0.5f;
                if (health <= 0)
                {
                    Die();
                }
                else
                {
                    isDamaged = true;
                    canBeDamaged = false;
                    currentState.Redraw();
                    //switch (side)
                    //{
                    //    case "top":
                    //        currentPosition.Y += 25;
                    //        currentLinkSprite.DestinationRectangle.Offset(0, 25);
                    //        break;
                    //    case "bottom":
                    //        currentPosition.Y -= 25;
                    //        currentLinkSprite.DestinationRectangle.Offset(0, -25);
                    //        break;
                    //    case "left":
                    //        currentPosition.X -= 25;
                    //        currentLinkSprite.DestinationRectangle.Offset(25, 0);
                    //        break;
                    //    case "right":
                    //        currentPosition.X += 25;
                    //        currentLinkSprite.DestinationRectangle.Offset(0, -25);
                    //        break;
                    //    default:
                    //        break;
                    //}
                }
            }
        }
        public void Update()
        {
            UpdatePosition();
            currentLinkSprite.Update();
            foreach (var projectile in currentProjectiles)
            {
                projectile.Update();
            }
            // This can be refactored using a decorator pattern
            if (isDamaged)
            {
                isDamagedCounter++;
                if (isDamagedCounter > 60)
                {
                    canBeDamaged = true;
                    isDamagedCounter = 0;
                    isDamaged = false;
                    UpdatePosition();
                    currentState.Redraw();
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
            game.gameStateController.GameOver();
        }
        public void getGame(Game1 game)
        {
            this.game = game;
        }
    }
}