using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D11;
using System;
using System.Collections.Generic;

using System.IO;
using System.Xml.Linq;

namespace LegendofZelda.Rooms
{
    public class RandomRoomGenerator
    {
        private List<string> enemyList;
        public Dictionary<int, Vector2> locations;
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
            

            enemyList.Add("Digdogger");
            //enemyList.Add("Gohma");
            makeCoordinates();
            roomLoader = new(this);

        }

        public Room NewRandomRoom(List<string> directions, int backgroundNumber)
        {
            List<ISprite> sprites = new();
            makeCoordinates();
            roomLoader = new(this);
            Random rnd = new Random();

            int numOfEnemies = rnd.Next(1, 5);
            int blockConfiguration = rnd.Next(0, 6);
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

            int enemiesAdded = 0;
            while (enemiesAdded!=numOfEnemies) {
                int rndLocation = rnd.Next(locations.Count);
                if (locations.ContainsKey(rndLocation))
                {
                    var location = locations[rndLocation];
                    int enemyType = rnd.Next(enemyList.Count);
                    sprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(location, enemyList[enemyType]));
                    enemiesAdded++;
                }
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
            int counter = 0;

            for (int i = 0; i < numOfBlocksY; i++)
            {
                for (int j = 0; j < numOfBlocksX; j++)
                {
                    locations.Add(counter, new Vector2(j * blockWidth + wallWidth, i * blockHeight + wallHeight));
                    counter++;
                }
            }
        }
    }
}
