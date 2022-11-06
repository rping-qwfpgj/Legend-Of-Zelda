﻿using Interfaces;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using Sprites;

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
                // If the object is not link, then don't draw him, will cause multiple links
                if(!(sprite is IAttackingSprite) && !(sprite is INonAttackingSprite)) { 
                    sprite.Draw(spriteBatch);
                }
                
            }
        }

        public void Update()
        {
            List<ISprite> toRemove = new();
           foreach (var sprite in sprites)
            {
                
                if (sprite is IEnemy)
                {
                    IEnemy enemy = sprite as IEnemy;
                    if (enemy.DyingComplete == true)
                    {
                        toRemove.Add(sprite);
                    }
                }
                sprite.Update();
                
            }

            foreach (var sprite in toRemove)
            {
                this.removeObject(sprite);

            }

        }

        public List<ISprite> ReturnObjects()
        {
            List<ISprite> copyOfSprites = new List<ISprite>(sprites);
            return copyOfSprites;
        }

        public void removeObject(ISprite sprite)
        { 
            if (sprite is IEnemy)
            {
                Debug.WriteLine("remove works");
            }
            sprites.Remove(sprite);
          
        }

        public void AddObject(ISprite sprite)
        {
            if (sprite is IEnemy)
            {
                Debug.WriteLine("add works");
            }
            sprites.Add(sprite);
        }

    }
}
