
using Microsoft.Xna.Framework;
using States;
using Interfaces;
using static System.Windows.Forms.LinkLabel;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using System.Drawing;
using LegendofZelda.SpriteFactories;

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
        public ISprite currentProjectile;
        public ILinkState currentState;
        public Vector2 currentPosition;
        public bool isDamaged;
        public Throwables throwable;
        private int isDamagedCounter = 0;


        public Link(Vector2 position, GraphicsDeviceManager graphics)
        {
            this.currentPosition = position;
            this.graphics = graphics;
            this.isDamaged = false;
            this.currentState = new LinkFacingUpState(this);
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingUp (this.currentPosition, this.isDamaged);
            this.throwable = Throwables.None;
            this.currentProjectile = ProjectileSpriteFactory.Instance.CreateThrowableUp(this.currentPosition, this.throwable);
        }

        public void Reset()
        {
            this.currentPosition = new Vector2(400, 240);
            this.isDamaged = false;
            this.currentState = new LinkFacingUpState(this);
            this.currentLinkSprite = LinkSpriteFactory.Instance.CreateLinkFacingRight(this.currentPosition, this.isDamaged);
            this.throwable = Throwables.None;
            this.currentProjectile = ProjectileSpriteFactory.Instance.CreateThrowableRight(this.currentPosition, this.throwable);

        }

        public void UpdatePosition()
        {
            Microsoft.Xna.Framework.Rectangle rectangle = this.currentLinkSprite.getHitbox();
            this.currentPosition = new Vector2(rectangle.X, rectangle.Y);
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
            this.isDamaged = true;
            this.currentState.Redraw();
        }

        public void Update()
        {
            this.currentLinkSprite.Update();
            this.currentProjectile.Update();
            this.UpdatePosition();
            // This can be refactored using a decorator pattern
            if (this.isDamaged)
            {
                this.isDamagedCounter++;
                if (this.isDamagedCounter > 60)
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
            this.currentLinkSprite.Draw(_spriteBatch);
            this.currentProjectile.Draw(_spriteBatch);
        }

    }
}

