using Interfaces;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace LegendofZelda
{
    public class RoomLoader
    {
        private readonly XDocument xml;
        private readonly SpriteBatch spriteBatch;
 
        public RoomLoader(SpriteBatch spriteBatch)
        {
            this.spriteBatch = spriteBatch;
        }

        public Room ParseXML(XDocument xml)
        {
            
            List<ISprite> sprites = new();
          
            //parse background
            string backgroundString = xml.Root.Descendants("Item").Select(x => x.Element("Background").Value).FirstOrDefault();
            var backgroundSprite = BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), backgroundString);


            //parse blocks
            var blocks = from c in xml.Root.Descendants("Item")
                         where c.Element("ObjectType").Value == "Block"
                         select c;

            foreach (var block in blocks)
            {

                string[] locationString = block.Element("Location").Value.Split(" ");
                Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
                sprites.Add(BlockSpriteFactory.Instance.CreateBlock(location, block.Element("ObjectName").Value));
                
                //testing purposes
                Console.WriteLine("Check that it's getting all blocks {0}\n", block.Value);
                Console.WriteLine("Check that it's getting block types {0}\n", block.Element("ObjectName").Value);

            }

            //parse enemies and NPCs
            var enemies = from c in xml.Root.Descendants("Item")
                         where c.Element("ObjectType").Value == "Enemy"
                         select c;

            foreach (var enemy in enemies)
            {

                string[] locationString = enemy.Element("Location").Value.Split(" ");
                Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
                sprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(location, enemy.Element("ObjectName").Value));

                //testing purposes
                Console.WriteLine("Check that it's getting all enemies{0}\n", enemy.Value);
                Console.WriteLine("Check that it's getting enemy types {0}\n", enemy.Element("ObjectName").Value);
            }

            return new Room(sprites, backgroundSprite, spriteBatch);
           
        }
    
    }
}
