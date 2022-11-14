using Microsoft.Xna.Framework;
using States;
using Interfaces;
using Microsoft.Xna.Framework.Graphics;
using LegendofZelda.SpriteFactories;
using LegendofZelda.Interfaces;
using System;
using System.Collections.Generic;
using LegendofZelda;
using LegendofZelda.Items;

namespace Sprint0
{
    public class Inventory
    {
        private Dictionary<string, int> inventory = new();

        public Inventory()
        {
            this.inventory.Add("bomb", 0);
            this.inventory.Add("key", 0);
            this.inventory.Add("orange map", 0);
            this.inventory.Add("compass", 0);
            this.inventory.Add("fairy", 0); // may remove fairies from dungeon 1
            this.inventory.Add("orange gemstone", 0);
            this.inventory.Add("triforce", 0);
            this.inventory.Add("bow", 0);

        }

        public int getItemCount(String itemStr)
        {   
            return this.inventory[itemStr];
        }

        public void addItem(IItem item)
        {
            int itemCount;

            //this.inventory.TryGetValue(item.toString(), out itemCount);

            if (this.inventory.ContainsKey(item.toString()))
            {
                itemCount = this.inventory[item.toString()];
                if (item.toString() == "bomb") // bomb items give link 4 throwable bombs
                {
                    inventory[item.toString()] = itemCount + 4;
                }
                else
                {
                    inventory[item.toString()] = itemCount + 1;
                }
            }

        }

        public void removeItem(String itemStr)
        {
            int itemCount;

            //this.inventory.TryGetValue(item.toString(), out itemCount);

            if (this.inventory.ContainsKey(itemStr))
            {
                itemCount = this.inventory[itemStr];
                inventory[itemStr] = itemCount - 1;
                
            }

        }
    }
}

