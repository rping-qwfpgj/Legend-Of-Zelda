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
        public RoomLoader()
        {
        }

        public Room ParseXML(XDocument xml)
        {

            List<ISprite> sprites = new();

            //parse background
            string backgroundString = xml.Root.Descendants("Item").First().Element("ObjectName").Value;
            var backgroundSprite = BackgroundSpriteFactory.Instance.CreateBackground(backgroundString);

            List<string> spriteStrings = new List<string>(new string[] { "Block", "Enemy", "Item" });

            //for each sprite type to create (block, enemy, or item)
            foreach (var spriteString in spriteStrings)
            {

                //spritesToCreate is a list of XElements
                var spritesToCreate = from c in xml.Root.Descendants("Item")
                                      where c.Element("ObjectType").Value == spriteString
                                      select c;

                foreach (var spriteToCreate in spritesToCreate)
                {

                    string[] locationString = spriteToCreate.Element("Location").Value.Split(" ");
                    Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
                    if (spriteString == "Block")
                    {
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(location, spriteToCreate.Element("ObjectName").Value));
                    }
                    else if(spriteString == "Enemy")
                    {
                        sprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(location, spriteToCreate.Element("ObjectName").Value));
                    }
                    else if (spriteString == "Item")
                    {
                        sprites.Add(ItemSpriteFactory.Instance.CreateItem(location, spriteToCreate.Element("ObjectName").Value));
                    }


                    //testing purposes
                    Console.WriteLine("Check that it's getting all sprites{0}\n", spriteToCreate.Value);
                    Console.WriteLine("Check that it's getting sprite types {0}\n", spriteToCreate.Element("ObjectName").Value);

                }

            }

            return new Room(sprites, backgroundSprite);
        }

    }

}

    //        //parse blocks
    //        var blocks = from c in xml.Root.Descendants("Item")
    //                     where c.Element("ObjectType").Value == "Block"
    //                     select c;

    //        foreach (var block in blocks)
    //        {
    //            string[] locationString = block.Element("Location").Value.Split(" ");
    //            Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
    //            sprites.Add(BlockSpriteFactory.Instance.CreateBlock(location, block.Element("ObjectName").Value));
                
    //            //testing purposes
    //            Console.WriteLine("Check that it's getting all blocks {0}\n", block.Value);
    //            Console.WriteLine("Check that it's getting block types {0}\n", block.Element("ObjectName").Value);

    //        }

    //        //parse enemies and NPCs
    //        var enemies = from c in xml.Root.Descendants("Item")
    //                     where c.Element("ObjectType").Value == "Enemy"
    //                     select c;

    //        foreach (var enemy in enemies)
    //        {

    //            string[] locationString = enemy.Element("Location").Value.Split(" ");
    //            Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
    //            sprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(location, enemy.Element("ObjectName").Value));

    //            //testing purposes
    //            Console.WriteLine("Check that it's getting all enemies{0}\n", enemy.Value);
    //            Console.WriteLine("Check that it's getting enemy types {0}\n", enemy.Element("ObjectName").Value);
    //        }

    //        //parse items
    //        var items = from c in xml.Root.Descendants("Item")
    //                      where c.Element("ObjectType").Value == "Item"
    //                      select c;

    //        foreach (var item in items)
    //        {
    //            string[] locationString = item.Element("Location").Value.Split(" ");
    //            Vector2 location = new((float)Convert.ToDouble(locationString[0]), (float)Convert.ToDouble(locationString[1]));
    //            sprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(location, item.Element("ObjectName").Value));

    //            //testing purposes
    //            Console.WriteLine("Check that it's getting all items{0}\n", item.Value);
    //            Console.WriteLine("Check that it's getting item types {0}\n", item.Element("ObjectName").Value);
    //        }


    //       
           
    //    }
    //}

