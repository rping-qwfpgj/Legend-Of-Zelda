using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Sprites;
using LegendofZelda.SpriteFactories;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;

namespace LegendofZelda
{
    public class Room
    {
        public List<ISprite> sprites;
        private ISprite background;
        public ISprite Background { get => background; set => background = value; }
        public Room(List<ISprite> sprites, ISprite background)
        {
            this.sprites = sprites;
            this.background = background;
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

            int gcounter = 0;
            foreach (var test in sprites)
            {
                if (test is GoriyaBoomerangDownSprite || test is GoriyaBoomerangUpSprite || test is GoriyaBoomerangRightSprite || test is GoriyaBoomerangLeftSprite)
                {
                    gcounter++;
                }
            }
            //Debug.WriteLine("goriya");
            //Debug.WriteLine(gcounter);

            int counter = 0;
            foreach (var test in sprites)
            {
                if (test is BottomDragonAttackOrbSprite || test is MiddleDragonAttackOrbSprite || test is TopDragonAttackOrbSprite || test is FrontOldManOrb || test is RightOldManOrb || test is LeftOldManOrb)
                {
                    counter++;
                }
            }
            //Debug.WriteLine("dragon");
            //Debug.WriteLine(counter);
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
            if (sprite is IEnemy && sprite!=null)
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
