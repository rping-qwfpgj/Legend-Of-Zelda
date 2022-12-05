using LegendofZelda.Interfaces;
using LegendofZelda;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;
using SpriteBatch = Microsoft.Xna.Framework.Graphics.SpriteBatch;
using System.Collections.Generic;
using LegendofZelda.SpriteFactories;
using System.Diagnostics;

namespace Sprites
{
	public class Digdogger : IEnemy
	{
		private IDigdogger currentDigdogger;
		
		private bool isDead = false;
		private int health = 3;
		private int deathFrames = 0;
		private bool isDamaged = false;
		private int damagedCounter = 0;
		public bool IsDead { get => isDead; set => isDead = value; }
		private bool dyingComplete = false;
		public bool DyingComplete { get => dyingComplete; set => dyingComplete = value; }
		private int currFrames = 0;

		public enum DigdoggerActions
		{
			BigMovingUp, BigMovingDown, BigMovingLeft, BigMovingRight, SmallStunned
		};

		List<DigdoggerActions> digDoggerActions = new List<DigdoggerActions> {DigdoggerActions.BigMovingUp, DigdoggerActions.BigMovingDown,
		DigdoggerActions.BigMovingRight, DigdoggerActions.BigMovingLeft, DigdoggerActions.SmallStunned};


		private List<string> droppableItems = new List<string> { "Key" };


		private Texture2D texture;
		private Texture2D dyingTexture;

		//  Obsolete variables
		private float xPosition;
		public float XPosition { get => xPosition; set => xPosition = value; }
		private float yPosition;
		public float YPosition { get => yPosition; set => yPosition = value; }
		private int direction = 1;
		public int Direction { get => direction; set => direction = value; }
		//private int prevdirection = 1;
		private float xPos;
		private float yPos;
		private Rectangle destinationRectangle;
		public Rectangle DestinationRectangle { get => destinationRectangle; set => destinationRectangle = value; }

		public Digdogger(Texture2D texture, float xPosition, float yPosition, Texture2D texture2)
		{
			this.texture = texture;
			this.xPos = xPosition;
			this.yPos = yPosition;
			this.dyingTexture = texture2;
			this.destinationRectangle = new Rectangle((int)this.xPos, (int)this.yPos, 39, 48);
			this.currentDigdogger = new DigdoggerGoingDownSprite(texture, this.xPos, this.yPos);
			
		}

		public void Update()
		{

			Debug.WriteLine(this.DestinationRectangle);

			// Decided if the digdogger should change its current action
			if (!isDead)
			{
				++currFrames;
				if (isDamaged)
				{
					damagedCounter++;
					if (damagedCounter >= 60)
					{
						isDamaged = false;
						this.currentDigdogger.IsDamaged = false;
						damagedCounter = 0;
					}
				}

				
				this.currentDigdogger.Update();
				this.destinationRectangle = currentDigdogger.DestinationRectangle;
				// Pick an action to take based on where link is
				Vector2 linkLocation = Link.Instance.currentPosition;
				DigdoggerActions nextAction;
				if (linkLocation.Y > this.currentDigdogger.YPosition)
				{
					nextAction = DigdoggerActions.BigMovingDown;
				}
				else if (linkLocation.X > this.currentDigdogger.XPosition)
				{
					nextAction = DigdoggerActions.BigMovingRight;
				}
				else if (linkLocation.Y < this.currentDigdogger.YPosition)
				{
					nextAction = DigdoggerActions.BigMovingUp;
				}
				else
				{
					nextAction = DigdoggerActions.BigMovingLeft;
				}

				if (this.currentDigdogger is DigdoggerSmallStunnedSprite && this.currFrames % 500 != 0)
				{

				}
				else
				{
					this.switchAction(nextAction);
				}
			}



			else
			{
				deathFrames++;
			}

			


		}

		public void Draw(SpriteBatch spriteBatch)
		{
			Rectangle sourceRectangle = new Rectangle(0, 0, 15, 16);
			if (!isDead)
			{
				//spriteBatch.Begin();
				currentDigdogger.Draw(spriteBatch);
			}
			else
			{
				spriteBatch.Begin();
				this.destinationRectangle = new Rectangle((int)this.currentDigdogger.XPosition, (int)this.currentDigdogger.YPosition, 30, 30);
				if (deathFrames >= 0 && deathFrames <= 5)
				{
					sourceRectangle = new Rectangle(0, 0, 15, 16);

				}
				else if (deathFrames > 5 && deathFrames < 10)
				{
					sourceRectangle = new Rectangle(16, 0, 15, 16);
				}
				else if (deathFrames >= 10 && deathFrames < 15)
				{
					sourceRectangle = new Rectangle(35, 3, 9, 10);

				}
				else if (deathFrames >= 15 && deathFrames < 20)
				{
					sourceRectangle = new Rectangle(51, 3, 9, 10);

				}
				else
				{
					this.dyingComplete = true;
				}
				if (!dyingComplete)
				{
					spriteBatch.Draw(dyingTexture, this.destinationRectangle, sourceRectangle, Color.White);
				}

				spriteBatch.End();
			}
			
		}



		public Rectangle GetHitbox()
		{
			Rectangle hitbox = currentDigdogger.GetHitbox();

			return hitbox;
		}

		public  void switchAction(DigdoggerActions actionToTake)
		{
			// Get the hitbox of the current goriya
			Rectangle currentLocation = currentDigdogger.GetHitbox();
			this.xPos = (float)currentLocation.X;
			this.yPos = (float)currentLocation.Y;

			// Randomly select a goriya state to make
			switch (actionToTake)
			{
				case DigdoggerActions.BigMovingUp:
					this.currentDigdogger = new DigdoggerGoingUpSprite(this.texture, this.xPos, this.yPos);
					break;
				case DigdoggerActions.BigMovingDown:
					this.currentDigdogger = new DigdoggerGoingDownSprite(this.texture, this.xPos, this.yPos);
					break;
				case DigdoggerActions.BigMovingLeft:
					this.currentDigdogger = new DigdoggerGoingLeftSprite(this.texture, this.xPos, this.yPos);
					break;
				case DigdoggerActions.BigMovingRight:
					this.currentDigdogger = new DigdoggerGoingRightSprite(this.texture, this.xPos, this.yPos);
					break;
				case DigdoggerActions.SmallStunned:
					this.currentDigdogger = new DigdoggerSmallStunnedSprite(this.texture, this.xPos, this.yPos);
					break;
				default:
					break;
			}
		}

		public void TurnAround(string side)
		{
			// Get the hitbox of the current goriya
			Rectangle currentLocation = currentDigdogger.GetHitbox();
			this.xPos = (float)currentLocation.X;
			this.yPos = (float)currentLocation.Y;

			// Have the Digdogger turn around based on what wall it is running into
			switch (side)
			{
				case "top":
					this.currentDigdogger = new DigdoggerGoingDownSprite(this.texture, this.xPos, this.yPos);
					break;
				case "bottom":
					this.currentDigdogger = new DigdoggerGoingUpSprite(this.texture, this.xPos, this.yPos);
					break;
				case "left":
					this.currentDigdogger = new DigdoggerGoingRightSprite(this.texture, this.xPos, this.yPos);
					break;
				case "right":
					this.currentDigdogger = new DigdoggerGoingLeftSprite(this.texture, this.xPos, this.yPos);
					break;
				default:
					break;

			}

		}


		public void TakeDamage(string side)
		{
			SoundFactory.Instance.CreateSoundEffect("EnemyHit").Play();
			this.health -= 1;
			this.isDamaged = true;
			this.currentDigdogger.IsDamaged = true;
			if (this.health <= 0)
			{
				this.isDead = true;
			}
		}

		public ISprite DropItem()
		{
			if (dyingComplete)
			{
				Random random = new Random();
				int rand = random.Next(0, droppableItems.Count);
				return ItemSpriteFactory.Instance.CreateItem(new Vector2(this.currentDigdogger.XPosition, this.currentDigdogger.YPosition - 150), droppableItems[rand]);
			}
			else
			{
				return null;
			}
		}

		public void Die()
		{

		}
	}
}
