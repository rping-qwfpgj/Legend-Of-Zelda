
/*
using Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using SpriteFactories;

namespace Sprites
{
    public class Enemy : ISprite
    {
        public ISprite currentEnemy;
        public int currentEnemyNum;
        private ISprite stalfos = EnemyAndNPCSpriteFactory.Instance.CreateStalfos();
        private ISprite gel = EnemyAndNPCSpriteFactory.Instance.CreateGel();
        private ISprite keese = EnemyAndNPCSpriteFactory.Instance.CreateKeese();
        private ISprite oldMan = EnemyAndNPCSpriteFactory.Instance.CreateOldMan();
        private ISprite goriya = EnemyAndNPCSpriteFactory.Instance.CreateGoriya();
        private ISprite dragonBoss = EnemyAndNPCSpriteFactory.Instance.CreateDragonBoss();

        private List<ISprite> enemiesAndNPCS = new List<ISprite>();
        
        public Enemy()
        {
            currentEnemyNum = 0;
            this.enemiesAndNPCS.Add(stalfos);
            this.enemiesAndNPCS.Add(gel);
            this.enemiesAndNPCS.Add(keese);
            this.enemiesAndNPCS.Add(oldMan);
            this.enemiesAndNPCS.Add(goriya);
            this.enemiesAndNPCS.Add(dragonBoss);
        }

        public void Reset()
        {
            // set it to a stalfo
            this.enemiesAndNPCS.Remove(stalfos);
            this.stalfos = EnemyAndNPCSpriteFactory.Instance.CreateStalfos();
            this.enemiesAndNPCS.Insert(0,stalfos);
            this.currentEnemyNum = 0;
            

            // 600, 250
            //this.currentEnemy = EnemyAndNPCSpriteFactory.Instance.CreateStalfos();

        }

        public void Update()
        {
            currentEnemy = enemiesAndNPCS[currentEnemyNum];
            currentEnemy.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentEnemy.Draw(spriteBatch);
        }


        public Vector2 getPosition()
        {
            return new Vector2(0,0);
        }
    }
}
*/