using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using SharpDX.MediaFoundation;
using SharpDX.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Security.AccessControl;

namespace LegendofZelda
{
    public class RoomGenerator
    {
      
        private List<String> enemyList;
        private List<String> blockList;
        private readonly int blockHeight = 44;
        private readonly int blockWidth = 50;
        private List<Vector2> blockLocations;
        private readonly int wallHeight = 88;
        private readonly int wallWidth = 100;
      

        public RoomGenerator()
        {
            enemyList = new();
            enemyList.Add("Goriya");
            enemyList.Add("Stalfos");
            enemyList.Add("Keese");
            enemyList.Add("Dodongo");
            //enemyList.Add("Gohma");

            blockList = new();
            blockList.Add("StatueOneBlock");
            blockList.Add("StatueTwoBlock");
            blockList.Add("DepthBlock");

            blockLocations = new();
            makeCoordinates();
          
        }

        public Room NewRoom(List<string> directions)
        {
            List < ISprite > sprites = new();
            makeCoordinates();
            Random rnd = new Random();
            int numOfEnemies = rnd.Next(1, 4);
            int numOfBlocks = rnd.Next(4, 5);
            sprites.Clear();

            //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 264), "VerticalHalfBoundingBlock"));
            //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 44), "VerticalHalfBoundingBlock"));
            //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "HorizontalBoundingBlock"));
            //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 392), "HorizontalBoundingBlock"));
            //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "VerticalBoundingBlock"));
            //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 44), "VerticalBoundingBlock"));

            for (int i = 0; i < numOfBlocks; i++)
            {
                var randomIndex = rnd.Next(blockLocations.Count);
                var location = blockLocations[randomIndex];
                blockLocations.RemoveAt(randomIndex);
                int blockType = rnd.Next(blockList.Count);
                sprites.Add(BlockSpriteFactory.Instance.CreateBlock(location, blockList[blockType]));
            }

            for (int i = 0; i < numOfEnemies; i++)
            {
                var location = blockLocations[rnd.Next(blockLocations.Count)];
                int enemyType = rnd.Next(enemyList.Count);
                sprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(location, enemyList[enemyType]));
            }

            foreach(var direction in directions)
            {
                Debug.WriteLine("roomGenerator"+direction);
                switch (direction){
                    case "left":
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockLeft"));
                       // sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockLeft"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "LockedWhiteDoorBlockLeft"));
                        break;
                    case "right":
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockRight"));
                       // sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockRight"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "LockedWhiteDoorBlockRight"));
                        break;
                    case "top":
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockTop"));
                        //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockTop"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "LockedWhiteDoorBlockTop"));
                        break;
                    case "bottom":
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockBottom"));
                        //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockBottom"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "LockedWhiteDoorBlockBottom"));
                        break;
                }
            }
            return new Room(sprites, BackgroundSpriteFactory.Instance.CreateBackground("Background21"));
        }

        private void makeCoordinates()
        {
            blockLocations.Clear();
            int numOfBlocksX = 12;
            int numOfBlocksY = 7;

            for (int i = 0; i < numOfBlocksX; i++)
            {
                for (int j = 0; j < numOfBlocksY; j++)
                {
                    blockLocations.Add(new Vector2(i * blockWidth + wallWidth, j * blockHeight + wallHeight));
                }
            }
        }

    }
}
