using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using Sprites;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;


namespace LegendofZelda
{
    public class RushRoomLoader
    {
        List<Vector2> coordinates;
        public RushRoomLoader(List<Vector2> coordinates)
        {
           this.coordinates = coordinates;  
        }
        public List<ISprite> ParseXML(XDocument xml)
        {
            List<ISprite> sprites = new();

            List<string> spriteStrings = new List<string>(new string[] { "Block" });

            //for each sprite type to create (block, enemy, or item)
            foreach (var spriteString in spriteStrings)
            {
                //spritesToCreate is a list of XElements
                var spritesToCreate = from c in xml.Root.Descendants("Item")
                                      where c.Element("ObjectType").Value == spriteString
                                      select c;

                foreach (var spriteToCreate in spritesToCreate)
                {

                    string locationString = spriteToCreate.Element("Location").Value;
                    Debug.WriteLine(locationString);
                    int location = Int32.Parse(locationString);
                    var vector = coordinates[location];
                    if (spriteString == "Block")
                    {
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(vector, spriteToCreate.Element("ObjectName").Value));
                    }
                }
            }

            return sprites;
              
        }

    }

}