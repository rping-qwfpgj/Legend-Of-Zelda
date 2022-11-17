
using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;
using GameStates;

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
        private int isDamagedCounter = 0;
        public Inventory inventory;
        public Game1 game;
        private SoundEffect throwProjectile;
        private SoundEffect attack;
        public float health;
        private bool canBeDamaged;
        private SoundEffect takeDamage;
    
        public Link()
        {
            this.currentPosition = new Vector2(400, 240);
            this.isDamaged = false;
            //this.game = game;
            this.currentState = new LinkFacingUpState();
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp(this.currentPosition, this.isDamaged);
            this.throwable = Throwables.Boomerang;
            this.currentProjectiles = new();
            this.inventory = new Inventory();
            //this.throwProjectile = game.Content.Load<SoundEffect>("throw_projectile");
            //this.attack = game.Content.Load<SoundEffect>("hee_hee");
            this.health = 3;
            this.canBeDamaged = true;
            //this.takeDamage = game.Content.Load<SoundEffect>("link_damage");
        }

        public void Reset()
        {
            this.game.RoomloaderInit();
            this.currentPosition = new Vector2(400, 240);
            this.isDamaged = false;
            this.currentState = new LinkFacingUpState();
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(this.currentPosition, this.isDamaged);
            this.throwable = Throwables.None;
            this.game.currentRoomIndex = 0;
            this.game.currentRoom = this.game.rooms[this.game.currentRoomIndex];
            this.health = 3;
            this.inventory = new Inventory();
            this.game.gameStateController.gameState = new GamePlayState(this.game.gameStateController, this.game);
        }

        public void UpdatePosition()
        {
            if (this.health > 0)
            {
                Rectangle rectangle = currentLinkSprite.GetHitbox();
                currentPosition = new Vector2(rectangle.X, rectangle.Y);
            }
       
        }
        public void Attack()
        {
            if (this.health > 0)
            {
                attack.Play();
                this.UpdatePosition();
                currentState.Attack();
            }
        }

        public void ThrowProjectile()
        {
            if (this.health > 0)
            {
                throwProjectile.Play();
                this.UpdatePosition();
                currentState.ThrowProjectile();
            }
        }

        public void MoveUp()
        {
            if (this.health > 0)
            {
                this.UpdatePosition();
                currentState.MoveUp();
            }
        }

        public void MoveDown()
        {
            if (this.health > 0)
            {
                this.UpdatePosition();
                currentState.MoveDown();
            }
        }

        public void MoveLeft()
        {
            if (this.health > 0)
            {
                this.UpdatePosition();
                currentState.MoveLeft();
            }
        }

        public void MoveRight()
        {
            if (this.health > 0)
            {
                this.UpdatePosition();
                currentState.MoveRight();
            }

        }
        public void NoInput()
        {
            if (this.health > 0)
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
        }

        public void TakeDamage()
        {
            if (this.canBeDamaged == true && this.health > 0)
            {
                takeDamage.Play();
                this.health -= 0.5f;
                
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
            if (this.canBeDamaged == true && this.health > 0)
            {
                takeDamage.Play();
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
            if (this.health > 0)
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
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            if (this.health > 0)
            {
                currentLinkSprite.Draw(_spriteBatch);
                foreach (var projectile in currentProjectiles)
                {
                    projectile.Draw(_spriteBatch);
                }
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
            throwProjectile = game.Content.Load<SoundEffect>("throw_projectile");
            attack = game.Content.Load<SoundEffect>("hee_hee");
            takeDamage = game.Content.Load<SoundEffect>("link_damage");
        }

       
    }
}
    


