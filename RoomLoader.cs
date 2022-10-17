using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpriteFactories;
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
        private XDocument xml;
        private SpriteBatch spriteBatch;
 
        public RoomLoader(XDocument xml, SpriteBatch spriteBatch)
        {
            this.xml = xml;
            this.spriteBatch = spriteBatch;
        }





        public Room Parse()
        {
            
            List<ISprite> sprites = new();
            

            var blocks = from c in xml.Root.Descendants("Item")
                         where c.Element("ObejctType").Value == "Block"
                         select c;


            foreach (var block in blocks)
            {

                string[] locationString = block.Element("Location").Value.Split(" ");
                Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
                sprites.Add(BlockSpriteFactory.Instance.CreateBlock(location, block.Element("ObjectName").Value));
                


                Console.WriteLine("Contact's Full Name:");
            }

            Room returner = new(sprites, background, spriteBatch);


            return returner;
        }
    
    }
}
