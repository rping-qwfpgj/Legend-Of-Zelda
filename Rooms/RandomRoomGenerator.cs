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

namespace LegendofZelda.Rooms
{
    public class RandomRoomGenerator
    {
        private List<string> enemyList;
        private List<string> blockList;
        private List<Vector2> blockLocations;
        private readonly int blockHeight = 44;
        private readonly int blockWidth = 50;
        private readonly int wallHeight = 88;
        private readonly int wallWidth = 100;

        public RandomRoomGenerator()
        {
            enemyList = new();
            //enemyList.Add("Goriya");
            //enemyList.Add("Stalfos");
            //enemyList.Add("Keese");
            //enemyList.Add("Dodongo");
            enemyList.Add("Gel");
            //enemyList.Add("Gohma");

            blockList = new();
            blockList.Add("StatueOneBlock");
            blockList.Add("StatueTwoBlock");
            blockList.Add("DepthBlock");
            makeCoordinates();

        }

        public Room NewRandomRoom(List<string> directions)
        {
            List<ISprite> sprites = new();
            makeCoordinates();
            Random rnd = new Random();
            int numOfEnemies = rnd.Next(1, 1);
            int numOfBlocks = rnd.Next(1, 1);
            sprites.Clear();

            var topBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "HorizontalBoundingBlock");
            var bottomBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 392), "HorizontalBoundingBlock");
            var leftBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "VerticalBoundingBlock");
            var rightBoundBlock = BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 44), "VerticalBoundingBlock");

            sprites.Add(topBoundBlock);
            sprites.Add(bottomBoundBlock);
            sprites.Add(rightBoundBlock);
            sprites.Add(leftBoundBlock);

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

            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "left":
                        sprites.Remove(leftBoundBlock);
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 264), "VerticalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "VerticalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockLeft"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockLeft"));
                       
                       // sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "LockedWhiteDoorBlockLeft"));
                        break;
                    case "right":
                        sprites.Remove(rightBoundBlock);
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 264), "VerticalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 44), "VerticalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockRight"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockRight"));
                       // sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "LockedWhiteDoorBlockRight"));
                        break;
                    case "top":
                        sprites.Remove(topBoundBlock);
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "HorizontalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(435, 44), "HorizontalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockTop"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockTop"));
                        //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "LockedWhiteDoorBlockTop"));
                        break;
                    case "bottom":
                        sprites.Remove(bottomBoundBlock);
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 392), "HorizontalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(435, 392), "HorizontalHalfBoundingBlock"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenWhiteDoorBlockBottom"));
                        sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "OpenDoorBlockBottom"));
                        //sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(0, 0), "LockedWhiteDoorBlockBottom"));
                        break;
                }
            }
            return new Room(sprites, BackgroundSpriteFactory.Instance.CreateBackground("Background21"), true);
        }

        private void makeCoordinates()
        {
            blockLocations = new();
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
