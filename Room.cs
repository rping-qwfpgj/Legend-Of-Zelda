using Interfaces;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using Sprites;
using Microsoft.VisualBasic.Devices;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace LegendofZelda
{
    public class Room
    {
        public List<ISprite> sprites;
        private ISprite background;

        public Room(List<ISprite> sprites, ISprite background)
        {
            this.sprites = sprites;
            this.background = background;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);
            foreach (var sprite in sprites)
            {
                //If the object is link , then don't draw it, will cause duplicates otherwise
                if(!(sprite is IAttackingSprite) && !(sprite is INonAttackingSprite)) { 
                    sprite.Draw(spriteBatch);
                }
                
            }
        }

        public void Update() 
        {
            List<ISprite> copy = new List<ISprite>(this.sprites);
            List<ISprite> toAdd = new();
            List<ISprite> toRemove = new();
            
            foreach (var sprite in copy)
            {
                DealWithEnemies(sprite);
               

                sprite.Update();
            }
            if (toAdd.Count > 0)
            {
                this.sprites.AddRange(toAdd);
            }

            foreach (ISprite sprite in toRemove)
            {
                this.sprites.Remove(sprite);
            }
            

        }

        public List<ISprite> ReturnObjects()
        {
            List<ISprite> copyOfSprites = new List<ISprite>(sprites);
            return copyOfSprites;
        }

        public void removeObject(ISprite sprite)
        { 
            sprites.Remove(sprite);
        }

       public void AddObject(ISprite sprite)
        {
            
            sprites.Add(sprite);
        }

        public void DealWithEnemies(ISprite sprite)
        {
            List<ISprite> toRemove = new();
            List<ISprite> toAdd = new();
            if (sprite is IEnemy)
            {
                IEnemy enemy = sprite as IEnemy;

                 if (enemy is DragonBossSprite)
                {
                    DragonBossSprite dragonBoss = enemy as DragonBossSprite;
                    toAdd.AddRange(dragonBoss.getEnemyProjectiles());
                } else if (enemy is GoriyaSprite)
                {
                    GoriyaSprite goriya = enemy as GoriyaSprite;
                    IEnemyProjectile currBoomerang = goriya.GetCurrentBoomerang();

                    if(currBoomerang.keepThrowing)
                    {
                        toAdd.Add(currBoomerang);
                    } else
                    {
                        toRemove.Add(currBoomerang);
                    }
                } 
                if (enemy.DyingComplete == true)
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
                this.removeObject(spr);

            }
            foreach (var spr in toAdd)
            {
                this.AddObject(spr);

            }
        }
    }
}
