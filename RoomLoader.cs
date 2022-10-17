using Interfaces;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;


namespace LegendofZelda
{
    public class RoomLoader
    {
        private readonly XDocument xml;
        private readonly SpriteBatch spriteBatch;
 
        public RoomLoader(XDocument xml, SpriteBatch spriteBatch)
        {
            this.xml = xml;
            this.spriteBatch = spriteBatch;
        }





        public Room Parse()
        {
            
            List<ISprite> sprites = new();

          
            string backgroundString = xml.Root.Descendants("Item").Select(x => x.Element("Background").Value).FirstOrDefault();
            var backgroundSprite = BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), backgroundString);

            var blocks = from c in xml.Root.Descendants("Item")
                         where c.Element("ObjectType").Value == "Block"
                         select c;


            foreach (var block in blocks)
            {

                string[] locationString = block.Element("Location").Value.Split(" ");
                Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
                sprites.Add(BlockSpriteFactory.Instance.CreateBlock(location, block.Element("ObjectName").Value));
                

                //testing purposes
                Console.WriteLine("Contact's Full Name:");
            }

            Room returner = new(sprites, backgroundSprite, spriDteBatch);

            return returner;
        }
    
    }
}
