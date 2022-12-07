using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;

using System;
using System.Collections.Generic;

using System.IO;
using System.Xml.Linq;

namespace LegendofZelda.Rooms
{
    public class RandomRoomGenerator
    {
        private List<string> enemyList;
        private List<Vector2> locations;
        private readonly int blockHeight = 44;
        private readonly int blockWidth = 50;
        private readonly int wallHeight = 88;
        private readonly int wallWidth = 100;
        RushRoomLoader roomLoader;
        public RandomRoomGenerator()
        {
            enemyList = new();
            enemyList.Add("Goriya");
            enemyList.Add("Stalfos");
            enemyList.Add("Keese");
            enemyList.Add("Dodongo");
            enemyList.Add("Gel");

            //enemyList.Add("DigDogger");
            //enemyList.Add("Gohma");
            makeCoordinates();
            roomLoader = new(locations);

        }

        public Room NewRandomRoom(List<string> directions, int backgroundNumber)
        {
            List<ISprite> sprites = new();
            makeCoordinates();
            Random rnd = new Random();
            int numOfEnemies = rnd.Next(1);
            int blockConfiguration = rnd.Next(0, 6);
            sprites.Clear();
            var enviroment = Environment.CurrentDirectory;
            string directory = Directory.GetParent(enviroment).Parent.Parent.FullName;
            string rushRoomsFolder = "\\Content\\RoomXMLs\\RushRooms";
            var path = directory + rushRoomsFolder + blockConfiguration.ToString() + ".xml";
            XDocument xml = XDocument.Load(path);

            sprites.AddRange(roomLoader.ParseXML(xml));

            var topBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "HorizontalBoundingBlock");
            var bottomBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 392), "HorizontalBoundingBlock");
            var leftBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "VerticalBoundingBlock");
            var rightBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 44), "VerticalBoundingBlock");

            sprites.Add(topBoundBlock);
            sprites.Add(bottomBoundBlock);
            sprites.Add(rightBoundBlock);
            sprites.Add(leftBoundBlock);

            for (int i = 0; i < numOfEnemies; i++)
            {
                var location = locations[rnd.Next(locations.Count)];
                int enemyType = rnd.Next(enemyList.Count);
                sprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(location, enemyList[enemyType]));
            }

            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "left":
                        sprites.Remove(leftBoundBlock);
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 264), "VerticalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "VerticalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockLeft"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockLeft"));
                      
                        break;
                    case "right":
                        sprites.Remove(rightBoundBlock);
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 264), "VerticalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 44), "VerticalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockRight"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockRight"));
                        break;
                    case "top":
                        sprites.Remove(topBoundBlock);
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "HorizontalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(435, 44), "HorizontalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockTop"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockTop"));
                        break;
                    case "bottom":
                        sprites.Remove(bottomBoundBlock);
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 392), "HorizontalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(435, 392), "HorizontalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockBottom"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockBottom"));
                        break;
                }
            }
            return new Room(sprites, BackgroundSpriteFactory.Instance.CreateBackground("Background"+backgroundNumber.ToString()) , true);
        }

        private void makeCoordinates()
        {
            locations = new();
            int numOfBlocksX = 12;
            int numOfBlocksY = 7;

            for (int i = 0; i < numOfBlocksY; i++)
            {
                for (int j = 0; j < numOfBlocksX; j++)
                {
                    locations.Add(new Vector2(j * blockWidth + wallWidth, i * blockHeight + wallHeight));
                }
            }
        }
    }
}
