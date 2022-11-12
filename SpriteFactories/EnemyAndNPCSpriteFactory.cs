
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Sprites;
using Microsoft.Xna.Framework;
using LegendofZelda.Interfaces;
using Microsoft.Xna.Framework.Audio;

namespace LegendofZelda.SpriteFactories
{
    public class EnemyAndNPCSpriteFactory : ISpriteFactory
    {
        private Texture2D enemySpriteSheet;
        private Texture2D oldManSpriteSheet;
        private Texture2D bossSpriteSheet;
        private SoundEffect enemyHit;
        private Texture2D dyingSpriteSheet;
        private static EnemyAndNPCSpriteFactory instance = new();
        private SpriteFont font;
        

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


        public void loadContent(ContentManager content)
        {
            enemySpriteSheet = content.Load<Texture2D>("enemies");
            oldManSpriteSheet = content.Load<Texture2D>("oldman");
            bossSpriteSheet = content.Load<Texture2D>("bosses");
            enemyHit = content.Load<SoundEffect>("enemy_hit");
            dyingSpriteSheet = content.Load<Texture2D>("enemy_death");
            font = content.Load<SpriteFont>("Times New Roman");


        }


        public IEnemy CreateEnemyOrNPC(Vector2 location, string name)
        {
            int inventoryHeight = 150;

            switch (name)
            {
                case "Goriya":

                    return new GoriyaSprite(enemySpriteSheet, location.X, location.Y + inventoryHeight, dyingSpriteSheet);

                case "Keese":

                    return new KeeseSprite(enemySpriteSheet, location.X, location.Y + inventoryHeight, enemyHit, dyingSpriteSheet);

                case "Stalfos":

                    return new StalfosSprite(enemySpriteSheet, location.X, location.Y + inventoryHeight, enemyHit, dyingSpriteSheet);

                case "Gel":

                    return new GelSprite(enemySpriteSheet, location.X, location.Y + inventoryHeight, enemyHit, dyingSpriteSheet);

                case "DragonBoss":

                    return new DragonBossSprite(bossSpriteSheet, location.X, location.Y + inventoryHeight, enemyHit, dyingSpriteSheet);

                case "OldMan":

                    return new OldManSprite(oldManSpriteSheet, location.X, location.Y + inventoryHeight, font);

                case "Wallmaster":

                    return new WallMasterSprite(enemySpriteSheet, location.X, location.Y + inventoryHeight, enemyHit, dyingSpriteSheet);

                case "Trap":

                    return new TrapSprite(enemySpriteSheet, location.X, location.Y + inventoryHeight);

                

                default:

                    return null;
            }

        }

    }
}