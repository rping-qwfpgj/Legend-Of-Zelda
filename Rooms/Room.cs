using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Sprites;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Blocks;
using System.Linq;
using Microsoft.Xna.Framework;

namespace LegendofZelda
{
    public class Room
    {
        public List<ISprite> sprites;
        private ISprite background;
        public ISprite Background { get => background; set => background = value; }
        private readonly List<ISprite> doors;
        public bool isFinished { get; set; }
        private bool alreadyChecked;

        private readonly ISprite topBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "HorizontalBoundingBlock");
        private readonly ISprite bottomBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 392), "HorizontalBoundingBlock");
        private readonly ISprite leftBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "VerticalBoundingBlock");
        private readonly ISprite rightBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 44), "VerticalBoundingBlock");

        public Room(List<ISprite> sprites, ISprite background, bool isBoshRushRoom)
        {
            this.sprites = sprites;
            this.background = background;
            doors = new();
            isFinished = false;
            alreadyChecked = false;
            if (isBoshRushRoom)
                RoomIncomplete();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            var ibackground = background as IBackground;
            if (!ibackground.IsTransitioning)
            {
                foreach (var sprite in sprites)
                {
                    //If the object is link , then don't draw it, will cause duplicates otherwise
                    if (!(sprite is IAttackingSprite) && !(sprite is INonAttackingSprite))
                    {
                        sprite.Draw(spriteBatch);
                    }
                }
            }
        }

        public void Update()
        {
            List<ISprite> copy = new List<ISprite>(sprites);
            background.Update();

            if (CheckIfFinished() && !alreadyChecked)
            {
                alreadyChecked = true;
                RoomComplete();
            }
            var ibackground = background as IBackground;
            if (!ibackground.IsTransitioning)
            {
                foreach (var sprite in copy)
                {
                    DealWithEnemies(sprite);
                    DealWithLinkProjectiles(sprite);
                    sprite.Update();
                }
            }
        }
        private void RoomIncomplete()
        {
            sprites.Add(topBoundBlock);
            sprites.Add(bottomBoundBlock);
            sprites.Add(rightBoundBlock);
            sprites.Add(leftBoundBlock);
            foreach (var sprite in sprites.ToList())
            {
                if (sprite is OpenDoorBlock || sprite is LockedDoorBlock)
                {
                    doors.Add(sprite);
                    sprites.Remove(sprite);
                }
            }
        }
        private void RoomComplete()
        {
            sprites.Remove(topBoundBlock);
            sprites.Remove(bottomBoundBlock);
            sprites.Remove(rightBoundBlock);
            sprites.Remove(leftBoundBlock);
            sprites.AddRange(doors);
        }
        private bool CheckIfFinished()
        {
            foreach (var sprite in sprites.ToList())
            {
                if (sprite is IEnemy)
                {
                    return false;
                }
            }
            isFinished = true;
            return true;
        }

        public List<ISprite> ReturnObjects()
        {
            List<ISprite> copyOfSprites = new List<ISprite>(sprites);
            return copyOfSprites;
        }

        public void RemoveObject(ISprite sprite)
        {
            sprites.Remove(sprite);
        }

        public void AddObject(ISprite sprite)
        {
            sprites.Add(sprite);
        }

        private void DealWithLinkProjectiles(ISprite sprite)
        {
            List<ISprite> toRemove = new();
            if (sprite is ILinkProjectile)
            {
                var projectile = sprite as ILinkProjectile;
                if (projectile.IsDone)
                {
                    toRemove.Add(sprite);
                }
            }
            foreach (var spr in toRemove)
            {
                RemoveObject(spr);
            }
        }

        private void DealWithEnemies(ISprite sprite)
        {
            HashSet<ISprite> toRemove = new();
            HashSet<ISprite> toAdd = new();
            if (sprite is IEnemy && sprite != null)
            {
                IEnemy enemy = sprite as IEnemy;

                if (enemy is DragonBossSprite)
                {
                    DragonBossSprite dragonBoss = enemy as DragonBossSprite;
                    List<ISprite> dragonOrbs = dragonBoss.getEnemyProjectiles();

                    foreach (IEnemyProjectile orb in dragonOrbs)
                    {
                        if (orb.keepThrowing)
                        {
                            if (!sprites.Contains(orb))
                                toAdd.Add(orb);
                        }
                        else
                        {
                            toRemove.Add(orb);
                        }
                    }

                }
                else if (enemy is GoriyaSprite)
                {
                    GoriyaSprite goriya = (GoriyaSprite)enemy;
                    IEnemyProjectile currBoomerang = goriya.GetCurrentBoomerang();
                    if (currBoomerang != null)
                    {
                        if (currBoomerang.keepThrowing)
                        {
                            if (!sprites.Contains(currBoomerang))
                                toAdd.Add(currBoomerang);
                        }
                        else
                        {
                            toRemove.Add(currBoomerang);
                        }
                    }
                }
                else if (enemy is OldManBoss)
                {
                    OldManBoss oldMan = enemy as OldManBoss;
                    List<ISprite> dragonOrbs = oldMan.getEnemyProjectiles();

                    foreach (IEnemyProjectile orb in dragonOrbs)
                    {
                        if (orb.keepThrowing)
                        {
                            if (!sprites.Contains(orb))
                                toAdd.Add(orb);
                        }
                        else
                        {
                            toRemove.Add(orb);
                        }
                    }
                }
                if (enemy.DyingComplete)
                {
                    toRemove.Add(sprite);
                    ISprite item = enemy.DropItem();
                    if (item != null)
                    {
                        SoundFactory.Instance.CreateSoundEffect("ItemDrop").Play();
                        toAdd.Add(item);
                    }
                }
            }

            foreach (var spr in toRemove)
            {
                RemoveObject(spr);
            }

            foreach (var spr in toAdd)
            {
                AddObject(spr);
            }
        }
    }
}
