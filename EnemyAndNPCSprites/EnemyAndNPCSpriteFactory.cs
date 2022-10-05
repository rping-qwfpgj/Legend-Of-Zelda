
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Interfaces;
using Sprites;

namespace SpriteFactories
{
    public class EnemyAndNPCSpriteFactory : ISpriteFactory
    {
        private Texture2D enemySpriteSheet;
        private Texture2D oldManSpriteSheet;
        private Texture2D bossSpriteSheet;
        private static EnemyAndNPCSpriteFactory instance = new EnemyAndNPCSpriteFactory();

        public static EnemyAndNPCSpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }
        private EnemyAndNPCSpriteFactory()
        {
        }

        public void Initialize(Texture2D spriteSheet)
        {
            this.enemySpriteSheet = spriteSheet;
        }

        public ISprite CreateStalfos()
        {
            return new StalfosSprite(enemySpriteSheet, 600, 250);
        }

        public ISprite CreateGel()
        {
            return new GelSprite(enemySpriteSheet, 600, 250);
        }

        public ISprite CreateKeese()
        {
            return new KeeseSprite(enemySpriteSheet, 600, 250);
        }

        public ISprite CreateGoriya()
        {
            return new GoriyaSprite(enemySpriteSheet, 600, 250);
        }

        public ISprite CreateDragonBoss()
        {
            return new DragonBossSprite(bossSpriteSheet, 600, 250);
        }

        public ISprite CreateOldMan()
        {
            return new OldManSprite(oldManSpriteSheet, 600, 250);
        }

        public void loadContent(ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>("enemies");
            oldManSpriteSheet = content.Load<Texture2D>("oldman");
            bossSpriteSheet = content.Load<Texture2D>("bosses");

        }
    }
}