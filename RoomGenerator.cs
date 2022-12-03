using LegendofZelda.Interfaces;
using LegendofZelda.SpriteFactories;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;


namespace LegendofZelda
{
    public class RoomGenerator
    {
        private int countDown;
        private List<String> enemyList;
        public RoomGenerator()
        {
            countDown = 10;
            enemyList = new List<String>();
            enemyList.Add("Goriya");
            enemyList.Add("Stalfos");
            enemyList.Add("Keese");
        }

        public Room NewRoom()
        {
            countDown--;
            Random rnd = new Random();
            int numOfEnemies = rnd.Next(15);
            var sprites = new List<ISprite>();
     
            for(int i = 0; i < numOfEnemies; i++)
            {
                var location = new Vector2(rnd.Next(300), rnd.Next(300));
                int enemyType = rnd.Next(3);
                sprites.Add(EnemyAndNPCSpriteFactory.Instance.CreateEnemyOrNPC(location, enemyList[enemyType]));
            }
   
            return new Room(sprites, BackgroundSpriteFactory.Instance.CreateBackground("Background0"));
        }

    }
}
