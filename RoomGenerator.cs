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
        private int countDown;
        private List<String> enemyList;
        private List<String> blockList;
        private readonly int blockHeight = 44;
        private readonly int blockWidth = 50;
        private List<Vector2> blockLocations;
        private readonly int wallHeight = 88;
        private readonly int wallWidth = 100;
        private List<ISprite> sprites;
  

        public RoomGenerator()
        {
            countDown = 10;
            enemyList = new();
            enemyList.Add("Goriya");
            enemyList.Add("Stalfos");
            enemyList.Add("Keese");
            enemyList.Add("Dodongo");

            blockList = new();
            blockList.Add("StatueOneBlock");
            blockList.Add("StatueTwoBlock");
            blockList.Add("DepthBlock");

            blockLocations = new();
            makeCoordinates();
            sprites = new();
        }

        public Room NewRoom()
        {
            makeCoordinates();
            countDown--;
            Random rnd = new Random();
            int numOfEnemies = rnd.Next(2)+1;
            int numOfBlocks = rnd.Next(20)+3;
            sprites.Clear();

            sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 264), "VerticalHalfBoundingBlock"));
            sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(700, 44), "VerticalHalfBoundingBlock"));
            sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "HorizontalBoundingBlock"));
            sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 392), "HorizontalBoundingBlock"));
            sprites.Add(BlockSpriteFactory.Instance.CreateBlock(new Vector2(50, 44), "VerticalBoundingBlock"));

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
